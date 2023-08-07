using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly GroceryDbContext context;

        public ReviewRepository(GroceryDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddReview(Review review)
        {
            //if product does not exits in database return false
            if (!await context.Products.AnyAsync(x => x.ProductId == review.ProductId))
            {
                return false;
            }

            await context.Reviews.AddAsync(review);
            return true;
        }

        public async Task<IEnumerable<Review>> GetProductReview(int productId)
        {
            var reviews = await context.Reviews.Where(r => r.ProductId == productId).ToListAsync();
            return reviews;
        }

    }
}
