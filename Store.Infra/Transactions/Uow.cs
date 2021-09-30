using System;
using Store.Infra.Context;
using Store.Infra.Transactions;

namespace Store.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly DataContext _context;
        public Uow(DataContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            //death
        }
    }
}
