using NKart.Core.Persistence.UnitOfWork;
using NKart.Tests.Base.Respositories.UnitOfWork;


namespace NKart.Tests.Base.Respositories
{
    public class MockUnitOfWorkProvider : IDatabaseUnitOfWorkProvider
    {

        public IDatabaseUnitOfWork GetUnitOfWork()
        {
            return new MockDatabaseUnitOfWork();
        }
    }
}
