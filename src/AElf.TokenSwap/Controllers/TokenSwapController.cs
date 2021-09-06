using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using AElf.Client.Dto;
using AElf.Contracts.Bridge;
using AElf.Contracts.MultiToken;
using AElf.TokenSwap.Dtos;
using AElf.Types;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AElf.TokenSwap.Controllers
{
    [ApiController]
    [Route("api/v1.0/swap")]
    public class TokenSwapController : ControllerBase
    {
        private readonly ILogger<TokenSwapController> _logger;

        private readonly ITokenSwapStore<SendingInfo> _tokenSwapStore;
        private readonly ConfigOptions _configOptions;

        public TokenSwapController(IOptionsSnapshot<ConfigOptions> configOptions,
            ITokenSwapStore<SendingInfo> tokenSwapStore, ILogger<TokenSwapController> logger)
        {
            _tokenSwapStore = tokenSwapStore;
            _logger = logger;
            _configOptions = configOptions.Value;
        }

        [HttpPost("record")]
        public async Task<ResponseDto> InsertSendingInfo(SendingInfoDto sendingInfoDto)
        {
            _logger.LogInformation($"Inserting: {JsonSerializer.Serialize(sendingInfoDto)}");

            var sendingInfo = new SendingInfo
            {
                ReceiptId = sendingInfoDto.ReceiptId,
                SendingTime = sendingInfoDto.SendingTime,
                SendingTxId = sendingInfoDto.SendingTxId
            };

            await _tokenSwapStore.SetAsync(sendingInfo.ReceiptId.ToString(), sendingInfo);

            return new ResponseDto
            {
                Message = $"Added sending info of receipt id {sendingInfo.ReceiptId}"
            };
        }

        [HttpGet("get")]
        public async Task<List<ReceiptInfoDto>> GetReceiptInfoList(string receivingAddress)
        {
            var swapId = Hash.LoadFromHex(_configOptions.SwapId);

            var nodeManager = new NodeManager(_configOptions.BlockChainEndpoint);
            var tx = nodeManager.GenerateRawTransaction(_configOptions.AccountAddress,
                _configOptions.BridgeContractAddress,
                "GetSwappedReceiptInfoList", new GetSwappedReceiptInfoListInput
                {
                    SwapId = swapId,
                    ReceivingAddress = Address.FromBase58(receivingAddress)
                });
            var result = await nodeManager.ApiClient.ExecuteTransactionAsync(new ExecuteTransactionDto
            {
                RawTransaction = tx
            });
            var receiptInfoList = new ReceiptInfoList();
            receiptInfoList.MergeFrom(ByteString.CopyFrom(ByteArrayHelper.HexStringToByteArray(result)));

            var receiptInfoDtoList = new List<ReceiptInfoDto>();
            foreach (var receiptInfo in receiptInfoList.Value)
            {
                var sendingInfo = await _tokenSwapStore.GetAsync(receiptInfo.ReceiptId.ToString());
                receiptInfoDtoList.Add(new ReceiptInfoDto
                {
                    ReceiptId = receiptInfo.ReceiptId,
                    Amount = receiptInfo.Amount,
                    ReceivingTime = receiptInfo.ReceivingTime == null
                        ? string.Empty
                        : (receiptInfo.ReceivingTime.Seconds * 1000).ToString(),
                    ReceivingAddress = receivingAddress,
                    ReceivingTxId = receiptInfo.ReceivingTxId?.ToHex() ?? string.Empty,
                    SendingTime = sendingInfo?.SendingTime ?? string.Empty,
                    SendingTxId = sendingInfo?.SendingTxId ?? string.Empty,
                });
            }

            return receiptInfoDtoList;
        }

        [HttpGet("get_bridge_balance")]
        public async Task<TokenSwapInfoDto> GetBridgeBalance()
        {
            var tokenSwapInfo = new TokenSwapInfoDto();

            var nodeManager = new NodeManager(_configOptions.BlockChainEndpoint);

            // get Bridge Contract balance.
            var txBridge = nodeManager.GenerateRawTransaction(_configOptions.AccountAddress,
                _configOptions.TokenContractAddress,
                "GetBalance", new GetBalanceInput
                {
                    Owner = Address.FromBase58(_configOptions.BridgeContractAddress),
                    Symbol = "ELF"
                });
            var resultBridge = await nodeManager.ApiClient.ExecuteTransactionAsync(new ExecuteTransactionDto
            {
                RawTransaction = txBridge
            });
            var getBalanceOutputBridge = new GetBalanceOutput();
            getBalanceOutputBridge.MergeFrom(ByteString.CopyFrom(ByteArrayHelper.HexStringToByteArray(resultBridge)));
            var balanceOfBridge = getBalanceOutputBridge.Balance;
            
            var txLottery = nodeManager.GenerateRawTransaction(_configOptions.AccountAddress,
                _configOptions.TokenContractAddress,
                "GetBalance", new GetBalanceInput
                {
                    Owner = Address.FromBase58(_configOptions.BridgeContractAddress),
                    Symbol = "ELF"
                });
            var resultLottery = await nodeManager.ApiClient.ExecuteTransactionAsync(new ExecuteTransactionDto
            {
                RawTransaction = txLottery
            });
            var getBalanceOutputLottery = new GetBalanceOutput();
            getBalanceOutputLottery.MergeFrom(ByteString.CopyFrom(ByteArrayHelper.HexStringToByteArray(resultLottery)));
            tokenSwapInfo.PreviousPeriodAward = getBalanceOutputLottery.Balance;

            return tokenSwapInfo;
        }
    }
}