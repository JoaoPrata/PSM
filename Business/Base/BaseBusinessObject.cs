using agap2it.labs.projects.PSM.Business.OperationResults;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.Business.Base
{
    public abstract class BaseBusinessObject
    {
        protected async Task<OperationResult> ExecuteOperation(Func<Task> func, IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted, long timeoutInSeconds = 30)
        {
            try
            {
                var transactionOptions = new TransactionOptions() { IsolationLevel = isolationLevel, Timeout = TimeSpan.FromSeconds(timeoutInSeconds) };
                using(var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    await func.Invoke();
                    scope.Complete();
                    return new OperationResult() { IsSuccessful = true };
                }
            }
            catch(Exception ex)
            {
                return new OperationResult { IsSuccessful = false, Exception = ex };
            }
        }
        protected async Task<OperationResult<T>> ExecuteOperation<T>(Func<Task<T>> func, IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted, long timeoutInSeconds = 30)
        {
            try
            {
                var transactionOptions = new TransactionOptions() { IsolationLevel = isolationLevel, Timeout = TimeSpan.FromSeconds(timeoutInSeconds) };
                using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = await func.Invoke();
                    scope.Complete();
                    return new OperationResult<T>() { IsSuccessful = true, Result = result };
                }
            }
            catch(Exception ex)
            {
                return new OperationResult<T>() { IsSuccessful = false, Exception = ex };
            } 
        } 
    }
}
