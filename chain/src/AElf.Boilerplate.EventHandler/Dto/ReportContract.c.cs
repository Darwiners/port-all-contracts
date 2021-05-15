// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: report_contract.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using System.Collections.Generic;
using aelf = global::AElf.CSharp.Core;

namespace AElf.Contracts.Report {

  #region Events
  public partial class ReportProposed : aelf::IEvent<ReportProposed>
  {
    public global::System.Collections.Generic.IEnumerable<ReportProposed> GetIndexed()
    {
      return new List<ReportProposed>
      {
      };
    }

    public ReportProposed GetNonIndexed()
    {
      return new ReportProposed
      {
        RawReport = RawReport,
        ObserverAssociationAddress = ObserverAssociationAddress,
        EthereumContractAddress = EthereumContractAddress,
        RoundId = RoundId,
      };
    }
  }

  public partial class ReportConfirmed : aelf::IEvent<ReportConfirmed>
  {
    public global::System.Collections.Generic.IEnumerable<ReportConfirmed> GetIndexed()
    {
      return new List<ReportConfirmed>
      {
      };
    }

    public ReportConfirmed GetNonIndexed()
    {
      return new ReportConfirmed
      {
        RoundId = RoundId,
        Signature = Signature,
        ObserverAssociationAddress = ObserverAssociationAddress,
        EthereumContractAddress = EthereumContractAddress,
        IsAllNodeConfirmed = IsAllNodeConfirmed,
      };
    }
  }

  public partial class OffChainAggregationRegistered : aelf::IEvent<OffChainAggregationRegistered>
  {
    public global::System.Collections.Generic.IEnumerable<OffChainAggregationRegistered> GetIndexed()
    {
      return new List<OffChainAggregationRegistered>
      {
      };
    }

    public OffChainAggregationRegistered GetNonIndexed()
    {
      return new OffChainAggregationRegistered
      {
        EthereumContractAddress = EthereumContractAddress,
        OffChainQueryInfoList = OffChainQueryInfoList,
        ObserverAssociationAddress = ObserverAssociationAddress,
        ConfigDigest = ConfigDigest,
        AggregateThreshold = AggregateThreshold,
        AggregatorContractAddress = AggregatorContractAddress,
        ChainType = ChainType,
      };
    }
  }

  public partial class MerkleReportNodeAdded : aelf::IEvent<MerkleReportNodeAdded>
  {
    public global::System.Collections.Generic.IEnumerable<MerkleReportNodeAdded> GetIndexed()
    {
      return new List<MerkleReportNodeAdded>
      {
      };
    }

    public MerkleReportNodeAdded GetNonIndexed()
    {
      return new MerkleReportNodeAdded
      {
        EthereumContractAddress = EthereumContractAddress,
        NodeIndex = NodeIndex,
        NodeRoundId = NodeRoundId,
        AggregatedData = AggregatedData,
      };
    }
  }

  #endregion
  /// <summary>
  /// the contract definition: a gRPC service definition.
  /// </summary>
  public static partial class ReportContractContainer
  {
    static readonly string __ServiceName = "ReportContract";

    #region Marshallers
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.InitializeInput> __Marshaller_InitializeInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.InitializeInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.QueryOracleInput> __Marshaller_QueryOracleInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.QueryOracleInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Types.Hash> __Marshaller_aelf_Hash = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Types.Hash.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.ConfirmReportInput> __Marshaller_ConfirmReportInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.ConfirmReportInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.RejectReportInput> __Marshaller_RejectReportInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.RejectReportInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Google.Protobuf.WellKnownTypes.Int64Value> __Marshaller_google_protobuf_Int64Value = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Int64Value.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::CallbackInput> __Marshaller_CallbackInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CallbackInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.Report> __Marshaller_Report = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.Report.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.RegisterOffChainAggregationInput> __Marshaller_RegisterOffChainAggregationInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.RegisterOffChainAggregationInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.OffChainAggregationInfo> __Marshaller_OffChainAggregationInfo = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.OffChainAggregationInfo.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Types.Address> __Marshaller_aelf_Address = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Types.Address.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.GetMerklePathInput> __Marshaller_GetMerklePathInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.GetMerklePathInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Types.MerklePath> __Marshaller_aelf_MerklePath = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Types.MerklePath.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.GetReportInput> __Marshaller_GetReportInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.GetReportInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.GetSignatureInput> __Marshaller_GetSignatureInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.GetSignatureInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Google.Protobuf.WellKnownTypes.StringValue> __Marshaller_google_protobuf_StringValue = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.StringValue.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.ReportQueryRecord> __Marshaller_ReportQueryRecord = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.ReportQueryRecord.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.GetEthererumReportInput> __Marshaller_GetEthererumReportInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.GetEthererumReportInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.GenerateEthererumReportInput> __Marshaller_GenerateEthererumReportInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.GenerateEthererumReportInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.GetSignatureMapInput> __Marshaller_GetSignatureMapInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.GetSignatureMapInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Report.SignatureMap> __Marshaller_SignatureMap = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Report.SignatureMap.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Google.Protobuf.WellKnownTypes.BoolValue> __Marshaller_google_protobuf_BoolValue = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.BoolValue.Parser.ParseFrom);
    #endregion

    #region Methods
    static readonly aelf::Method<global::AElf.Contracts.Report.InitializeInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Initialize = new aelf::Method<global::AElf.Contracts.Report.InitializeInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "Initialize",
        __Marshaller_InitializeInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Contracts.Report.QueryOracleInput, global::AElf.Types.Hash> __Method_QueryOracle = new aelf::Method<global::AElf.Contracts.Report.QueryOracleInput, global::AElf.Types.Hash>(
        aelf::MethodType.Action,
        __ServiceName,
        "QueryOracle",
        __Marshaller_QueryOracleInput,
        __Marshaller_aelf_Hash);

    static readonly aelf::Method<global::AElf.Types.Hash, global::Google.Protobuf.WellKnownTypes.Empty> __Method_CancelQueryOracle = new aelf::Method<global::AElf.Types.Hash, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "CancelQueryOracle",
        __Marshaller_aelf_Hash,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Contracts.Report.ConfirmReportInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_ConfirmReport = new aelf::Method<global::AElf.Contracts.Report.ConfirmReportInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "ConfirmReport",
        __Marshaller_ConfirmReportInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Contracts.Report.RejectReportInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_RejectReport = new aelf::Method<global::AElf.Contracts.Report.RejectReportInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "RejectReport",
        __Marshaller_RejectReportInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AdjustAmercementAmount = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "AdjustAmercementAmount",
        __Marshaller_google_protobuf_Int64Value,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::CallbackInput, global::AElf.Contracts.Report.Report> __Method_ProposeReport = new aelf::Method<global::CallbackInput, global::AElf.Contracts.Report.Report>(
        aelf::MethodType.Action,
        __ServiceName,
        "ProposeReport",
        __Marshaller_CallbackInput,
        __Marshaller_Report);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty> __Method_MortgageTokens = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "MortgageTokens",
        __Marshaller_google_protobuf_Int64Value,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty> __Method_WithdrawTokens = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "WithdrawTokens",
        __Marshaller_google_protobuf_Int64Value,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty> __Method_ApplyObserver = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "ApplyObserver",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty> __Method_QuitObserver = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "QuitObserver",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty> __Method_ProposeAdjustApplyObserverFee = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "ProposeAdjustApplyObserverFee",
        __Marshaller_google_protobuf_Int64Value,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AdjustApplyObserverFee = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "AdjustApplyObserverFee",
        __Marshaller_google_protobuf_Int64Value,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AdjustReportFee = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "AdjustReportFee",
        __Marshaller_google_protobuf_Int64Value,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Contracts.Report.RegisterOffChainAggregationInput, global::AElf.Contracts.Report.OffChainAggregationInfo> __Method_RegisterOffChainAggregation = new aelf::Method<global::AElf.Contracts.Report.RegisterOffChainAggregationInput, global::AElf.Contracts.Report.OffChainAggregationInfo>(
        aelf::MethodType.Action,
        __ServiceName,
        "RegisterOffChainAggregation",
        __Marshaller_RegisterOffChainAggregationInput,
        __Marshaller_OffChainAggregationInfo);

    static readonly aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddRegisterWhiteList = new aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "AddRegisterWhiteList",
        __Marshaller_aelf_Address,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty> __Method_RemoveFromRegisterWhiteList = new aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "RemoveFromRegisterWhiteList",
        __Marshaller_aelf_Address,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Contracts.Report.GetMerklePathInput, global::AElf.Types.MerklePath> __Method_GetMerklePath = new aelf::Method<global::AElf.Contracts.Report.GetMerklePathInput, global::AElf.Types.MerklePath>(
        aelf::MethodType.View,
        __ServiceName,
        "GetMerklePath",
        __Marshaller_GetMerklePathInput,
        __Marshaller_aelf_MerklePath);

    static readonly aelf::Method<global::AElf.Contracts.Report.GetReportInput, global::AElf.Contracts.Report.Report> __Method_GetReport = new aelf::Method<global::AElf.Contracts.Report.GetReportInput, global::AElf.Contracts.Report.Report>(
        aelf::MethodType.View,
        __ServiceName,
        "GetReport",
        __Marshaller_GetReportInput,
        __Marshaller_Report);

    static readonly aelf::Method<global::AElf.Contracts.Report.GetSignatureInput, global::Google.Protobuf.WellKnownTypes.StringValue> __Method_GetSignature = new aelf::Method<global::AElf.Contracts.Report.GetSignatureInput, global::Google.Protobuf.WellKnownTypes.StringValue>(
        aelf::MethodType.View,
        __ServiceName,
        "GetSignature",
        __Marshaller_GetSignatureInput,
        __Marshaller_google_protobuf_StringValue);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.StringValue, global::AElf.Contracts.Report.OffChainAggregationInfo> __Method_GetOffChainAggregationInfo = new aelf::Method<global::Google.Protobuf.WellKnownTypes.StringValue, global::AElf.Contracts.Report.OffChainAggregationInfo>(
        aelf::MethodType.View,
        __ServiceName,
        "GetOffChainAggregationInfo",
        __Marshaller_google_protobuf_StringValue,
        __Marshaller_OffChainAggregationInfo);

    static readonly aelf::Method<global::AElf.Types.Hash, global::AElf.Contracts.Report.ReportQueryRecord> __Method_GetReportQueryRecord = new aelf::Method<global::AElf.Types.Hash, global::AElf.Contracts.Report.ReportQueryRecord>(
        aelf::MethodType.View,
        __ServiceName,
        "GetReportQueryRecord",
        __Marshaller_aelf_Hash,
        __Marshaller_ReportQueryRecord);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.StringValue, global::Google.Protobuf.WellKnownTypes.Int64Value> __Method_GetCurrentRoundId = new aelf::Method<global::Google.Protobuf.WellKnownTypes.StringValue, global::Google.Protobuf.WellKnownTypes.Int64Value>(
        aelf::MethodType.View,
        __ServiceName,
        "GetCurrentRoundId",
        __Marshaller_google_protobuf_StringValue,
        __Marshaller_google_protobuf_Int64Value);

    static readonly aelf::Method<global::AElf.Contracts.Report.GetEthererumReportInput, global::Google.Protobuf.WellKnownTypes.StringValue> __Method_GetEthererumReport = new aelf::Method<global::AElf.Contracts.Report.GetEthererumReportInput, global::Google.Protobuf.WellKnownTypes.StringValue>(
        aelf::MethodType.View,
        __ServiceName,
        "GetEthererumReport",
        __Marshaller_GetEthererumReportInput,
        __Marshaller_google_protobuf_StringValue);

    static readonly aelf::Method<global::AElf.Contracts.Report.GenerateEthererumReportInput, global::Google.Protobuf.WellKnownTypes.StringValue> __Method_GenerateEthererumReport = new aelf::Method<global::AElf.Contracts.Report.GenerateEthererumReportInput, global::Google.Protobuf.WellKnownTypes.StringValue>(
        aelf::MethodType.View,
        __ServiceName,
        "GenerateEthererumReport",
        __Marshaller_GenerateEthererumReportInput,
        __Marshaller_google_protobuf_StringValue);

    static readonly aelf::Method<global::AElf.Contracts.Report.GetSignatureMapInput, global::AElf.Contracts.Report.SignatureMap> __Method_GetSignatureMap = new aelf::Method<global::AElf.Contracts.Report.GetSignatureMapInput, global::AElf.Contracts.Report.SignatureMap>(
        aelf::MethodType.View,
        __ServiceName,
        "GetSignatureMap",
        __Marshaller_GetSignatureMapInput,
        __Marshaller_SignatureMap);

    static readonly aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.BoolValue> __Method_IsInRegisterWhiteList = new aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.BoolValue>(
        aelf::MethodType.View,
        __ServiceName,
        "IsInRegisterWhiteList",
        __Marshaller_aelf_Address,
        __Marshaller_google_protobuf_BoolValue);

    #endregion

    #region Descriptors
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::AElf.Contracts.Report.ReportContractReflection.Descriptor.Services[0]; }
    }

    public static global::System.Collections.Generic.IReadOnlyList<global::Google.Protobuf.Reflection.ServiceDescriptor> Descriptors
    {
      get
      {
        return new global::System.Collections.Generic.List<global::Google.Protobuf.Reflection.ServiceDescriptor>()
        {
          global::AElf.Contracts.Report.ReportContractReflection.Descriptor.Services[0],
        };
      }
    }
    #endregion
  }
}
#endregion

