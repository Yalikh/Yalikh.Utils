using System;
using Xunit;

namespace Yalikh.Utils.Operations.Tests
{
    public class OperationResultTest
    {
        [Fact]
        public void ToString_Success_ReturnsTypeAndSuccess()
        {
            var res = OperationResult.Success;

            Assert.Equal("Success", res.ToString());
        }

        [Fact]
        public void ToString_Failure_ReturnsTypeAndFailure()
        {
            var res = OperationResult.Failure("");

            Assert.Equal("Failure", res.ToString());
        }

        [Fact]
        public void GetHashCode_Success_Returns0()
        {
            var actual = OperationResult.Success.GetHashCode();

            Assert.Equal(0, actual);
        }

        [Fact]
        public void GetHashCode_Failure_Returns1()
        {
            var actual = OperationResult.Failure("").GetHashCode();

            Assert.Equal(1, actual);
        }
    }
}
