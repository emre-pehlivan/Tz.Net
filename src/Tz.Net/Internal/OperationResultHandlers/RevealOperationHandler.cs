using Newtonsoft.Json.Linq;

namespace Tz.Net.Internal.OperationResultHandlers
{
    internal class RevealOperationHandler : IOperationHandler
    {
        public string HandlesOperation => Operations.Reveal;

        public OperationResult ParseApplyOperationsResult(JToken appliedOp)
        {
            SendTransactionOperationResult result = new SendTransactionOperationResult(appliedOp);

            JToken opResult = appliedOp["metadata"]?["operation_result"];
            result.Status = opResult?["status"]?.ToString() ?? result.Status;
            result.ConsumedGas = opResult?["consumed_gas"]?.ToString() ?? result.ConsumedGas;
            result.Succeeded = result.Status == "applied";

            return result;
        }
    }
}