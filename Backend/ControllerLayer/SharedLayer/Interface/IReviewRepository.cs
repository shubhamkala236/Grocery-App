using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface IReviewRepository
    {
        Task<bool> AddReview(Review review);
        Task<IEnumerable<Review>> GetProductReview(int productId);
    }
}
