using NKart.Core.Chains;
using Umbraco.Core;

namespace NKart.Tests.UnitTests.Chains
{
    internal class DemoAttemptChainTask : IAttemptChainTask<int>
    {
        public int Index { get; set; }

        public Attempt<int> PerformTask(int value)
        {
            var addOne = value + 1;
            return Attempt.Succeed(addOne);
        }
    }
}