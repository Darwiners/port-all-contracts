using System.Threading.Tasks;
using AElf.Contracts.Oracle;
using AElf.Types;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace AElf.Boilerplate.EventHandler
{
    public class SufficientCommitmentsCollectedLogEventProcessor : LogEventProcessorBase, ITransientDependency
    {
        private readonly ISaltProvider _saltProvider;
        private readonly IDataProvider _dataProvider;
        private readonly ContractAddressOptions _contractAddressOptions;
        private readonly ConfigOptions _configOptions;
        private readonly ILogger<SufficientCommitmentsCollectedLogEventProcessor> _logger;

        public SufficientCommitmentsCollectedLogEventProcessor(IOptionsSnapshot<ConfigOptions> configOptions,
            IOptionsSnapshot<ContractAddressOptions> contractAddressOptions,
            ISaltProvider saltProvider, IDataProvider dataProvider,
            ILogger<SufficientCommitmentsCollectedLogEventProcessor> logger) : base(contractAddressOptions)
        {
            _saltProvider = saltProvider;
            _dataProvider = dataProvider;
            _logger = logger;
            _configOptions = configOptions.Value;
            _contractAddressOptions = contractAddressOptions.Value;
        }

        public override string ContractName => "Oracle";
        public override string LogEventName => nameof(SufficientCommitmentsCollected);

        public override async Task ProcessAsync(LogEvent logEvent)
        {
            var collected = new SufficientCommitmentsCollected();
            collected.MergeFrom(logEvent);
            var data = await _dataProvider.GetDataAsync(collected.QueryId);
            _logger.LogInformation($"Get data for revealing: {data}");
            var node = new NodeManager(_configOptions.BlockChainEndpoint, _configOptions.AccountAddress,
                _configOptions.AccountPassword);
            node.SendTransaction(_configOptions.AccountAddress,
                _contractAddressOptions.ContractAddressMap[ContractName], "Reveal", new RevealInput
                {
                    QueryId = collected.QueryId,
                    Data = new StringValue {Value = data}.ToByteString(),
                    Salt = _saltProvider.GetSalt(collected.QueryId)
                });
        }
    }
}