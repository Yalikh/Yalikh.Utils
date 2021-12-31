using System;
using System.Collections.Generic;
using System.Linq;

namespace Yalikh.Utils.Operations
{
    public struct OperationResult
    {
        private readonly List<string> _errors;

        public bool IsSuccessful { get; }

        public IEnumerable<string> Errors
        {
            get => _errors;
        }

        public static OperationResult Success => new OperationResult(true);

        public static OperationResult Failure() => new OperationResult(false);

        public static OperationResult Failure(params string[] errors) => new OperationResult(errors);

        private OperationResult(bool isSuccess)
        {
            IsSuccessful = isSuccess;
            _errors = new List<string>();
        }

        private OperationResult(params string[] errors)
            : this(false)
        {
            _errors = new List<string>(errors);
        }
/*
        public override string ToString()
        {
            var resultStr = HasErrors ? "Failure" : "Success";
            return $"OperationResult[{resultStr}]";
        }

        public bool Equals(OperationResult obj)
        {
            if ((object)obj == null)
                return false;

            return ((object)this).Equals(obj) || HasErrors && HasErrors == obj.HasErrors;
        }

        public override bool Equals(object? obj)
        {
            if ((object?)obj == null)
                return false;

            if (obj is OperationResult typedObj)
                return Equals(typedObj);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HasErrors.GetHashCode();
        }

        public static bool operator ==(OperationResult left, OperationResult right)
        {
            if (left == null || right == null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(OperationResult left, OperationResult right) => !(left == right);
*/
    }
}
