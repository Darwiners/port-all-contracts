using System.Collections.Generic;
using System.Threading.Tasks;
using AElf.Contracts.TestKit;
using AElf.Kernel;
using AElf.Kernel.Blockchain.Application;
using AElf.Kernel.SmartContract.Parallel;
using AElf.Types;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace AElf.Contracts.ACS2DemoContract
{
    public class ACS2Test : ACS2DemoContractTestBase
    {
        [Fact]
        public async Task Test()
        {
            var keyPair1 = SampleECKeyPairs.KeyPairs[0];
            var acs2DemoContractStub1 = GetACS2DemoContractStub(keyPair1);

            var keyPair2 = SampleECKeyPairs.KeyPairs[1];
            var acs2DemoContractStub2 = GetACS2DemoContractStub(keyPair2);

            var transactionGrouper = Application.ServiceProvider.GetRequiredService<ITransactionGrouper>();
            var blockchainService = Application.ServiceProvider.GetRequiredService<IBlockchainService>();
            var chain = await blockchainService.GetChainAsync();

            // Situation can be parallel executed.
            {
                var groupedTransactions = await transactionGrouper.GroupAsync(new ChainContext
                {
                    BlockHash = chain.BestChainHash,
                    BlockHeight = chain.BestChainHeight
                }, new List<Transaction>
                {
                    acs2DemoContractStub1.TransferCredits.GetTransaction(new TransferCreditsInput
                    {
                        To = Address.FromPublicKey(SampleECKeyPairs.KeyPairs[2].PublicKey),
                        Amount = 1
                    }),
                    acs2DemoContractStub2.TransferCredits.GetTransaction(new TransferCreditsInput
                    {
                        To = Address.FromPublicKey(SampleECKeyPairs.KeyPairs[3].PublicKey),
                        Amount = 1
                    }),
                });
                groupedTransactions.Parallelizables.Count.ShouldBe(2);
            }

            // Situation cannot.
            {
                var groupedTransactions = await transactionGrouper.GroupAsync(new ChainContext
                {
                    BlockHash = chain.BestChainHash,
                    BlockHeight = chain.BestChainHeight
                }, new List<Transaction>
                {
                    acs2DemoContractStub1.TransferCredits.GetTransaction(new TransferCreditsInput
                    {
                        To = Address.FromPublicKey(SampleECKeyPairs.KeyPairs[2].PublicKey),
                        Amount = 1
                    }),
                    acs2DemoContractStub2.TransferCredits.GetTransaction(new TransferCreditsInput
                    {
                        To = Address.FromPublicKey(SampleECKeyPairs.KeyPairs[2].PublicKey),
                        Amount = 1
                    }),
                });
                groupedTransactions.Parallelizables.Count.ShouldBe(1);
            }
        }
    }
}