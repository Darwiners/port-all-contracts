using AElf.Types;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.Report
{
    public partial class ReportContract
    {
        public override Report GetReport(GetReportInput input)
        {
            return State.ReportMap[input.EthereumContractAddress][input.RoundId];
        }

        public override StringValue GetSignature(GetSignatureInput input)
        {
            return new StringValue
            {
                Value = State.ObserverSignatureMap[input.EthereumContractAddress][input.RoundId][input.Address]
            };
        }

        public override OffChainAggregationInfo GetOffChainAggregationInfo(StringValue input)
        {
            return State.OffChainAggregationInfoMap[input.Value];
        }

        public override ReportQueryRecord GetReportQueryRecord(Hash input)
        {
            return State.ReportQueryRecordMap[input];
        }

        public override MerklePath GetMerklePath(GetMerklePathInput input)
        {
            return State.BinaryMerkleTreeMap[input.EthereumContractAddress][input.RoundId]
                .GenerateMerklePath(input.NodeIndex);
        }

        public override Int64Value GetCurrentRoundId(StringValue input)
        {
            var roundId = State.CurrentRoundIdMap[input.Value];
            return new Int64Value
            {
                Value = roundId
            };
        }

        public override StringValue GenerateEthererumReport(GenerateEthererumReportInput input)
        {
            var report = GenerateEthereumReport(input.ConfigDigest, input.Organization, input.Report);
            return new StringValue
            {
                Value = report
            };
        }

        public override StringValue GetEthererumReport(GetEthererumReportInput input)
        {
            var contractInfo = State.OffChainAggregationInfoMap[input.EthereumContractAddress];
            Assert(contractInfo != null, $"contract: [{input.EthereumContractAddress}] info does not exist");
            var roundReport = State.ReportMap[input.EthereumContractAddress][input.RoundId];
            Assert(roundReport != null, $"contract: [{input.EthereumContractAddress}]: round: [{input.RoundId}] info does not exist");
            var configDigest = contractInfo.ConfigDigest;
            var organization = contractInfo.ObserverAssociationAddress;
            var report = GenerateEthereumReport(configDigest, organization, roundReport);
            return new StringValue
            {
                Value = report
            };
        }
    }
}