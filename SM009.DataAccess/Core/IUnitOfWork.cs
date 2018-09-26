using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.DataAccess.Core
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void RollbackTransaction();

        void CommitTransaction();

        void SaveChanges();
    }
}
