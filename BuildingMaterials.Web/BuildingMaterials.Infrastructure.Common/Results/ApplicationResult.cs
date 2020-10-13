using System.Collections.Generic;

namespace BuildingMaterials.Infrastructure.Common.Results
{
    public class ApplicationResult
    {
        private ApplicationResult()
        {
            IsSuccess = true;
        }

        private ApplicationResult(string failureReason)
        {
            FailureReason = failureReason;
            IsSuccess = false;
        }

        private ApplicationResult(string failureReason, IEnumerable<string> errors) : this(failureReason)
        {
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; }

        public string FailureReason { get; }

        public bool IsSuccess { get; }

        public static ApplicationResult Success { get; } = new ApplicationResult();

        public static ApplicationResult Fail(string reason, params string[] errors)
        {
            return new ApplicationResult(reason, errors);
        }

        public static implicit operator bool(ApplicationResult result)
        {
            return result.IsSuccess;
        }
    }
}
