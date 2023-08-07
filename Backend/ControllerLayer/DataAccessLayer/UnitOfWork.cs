using DataAccessLayer.Context;
using SharedLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GroceryDbContext context;

        public UnitOfWork(GroceryDbContext context)
        {
            this.context = context;
        }
        public IUserRepository UserRepository => new UserRepository(context);

        public IProductRepository ProductRepository => new ProductRepository(context);

        public ICartRepository CartRepository => new CartRepository(context);

        public IOrderRepository OrderRepository => new OrderRepository(context);

        public IReviewRepository ReviewRepository => new ReviewRepository(context);

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
