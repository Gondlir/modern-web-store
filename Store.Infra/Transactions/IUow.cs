using System;

namespace Store.Infra.Transactions
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
