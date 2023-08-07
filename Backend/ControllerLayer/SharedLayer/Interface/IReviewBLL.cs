using SharedLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface IReviewBLL
    {
        //add review
        Task<bool> AddReview(AddReviewDto addReviewDto);
        Task<IEnumerable<ReviewResponseDto>> GetProductReviews(int productId);

    }
}
