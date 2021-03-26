using AElf.Contracts.Association;
using AElf.Contracts.MultiToken;
using AElf.Contracts.Oracle;
using AElf.Sdk.CSharp.State;
using AElf.Types;

namespace AElf.Contracts.Report
{
    public partial class ReportContractState : ContractState
    {
        internal OracleContractContainer.OracleContractReferenceState OracleContract { get; set; }

        internal TokenContractContainer.TokenContractReferenceState TokenContract { get; set; }
        internal AssociationContractImplContainer.AssociationContractImplReferenceState AssociationContract { get; set; }

        public SingletonState<Address> ObserverAssociationAddress { get; set; }
        public SingletonState<string> OracleTokenSymbol { get; set; }
        public SingletonState<string> ObserverMortgageTokenSymbol { get; set; }
        public SingletonState<long> ReportFee { get; set; }
        public SingletonState<long> ApplyObserverFee { get; set; }
        public MappedState<Hash, ReportQueryRecord> ReportQueryRecordMap { get; set; }
        public MappedState<long, Address, string> ObserverSignatureMap { get; set; }
        public SingletonState<ObserverList> ObserverList { get; set; }
        public SingletonState<long> CurrentReportNumber { get; set; }
        public SingletonState<long> CurrentEpochNumber { get; set; }
        public SingletonState<long> CurrentRoundNumber { get; set; }
        
        /// <summary>
        /// Round Number (Round Id) -> Report.
        /// </summary>
        public MappedState<long, Report> ReportMap { get; set; }
        public MappedState<long, Epoch> EpochMap { get; set; }
    }
}