using SharedLayer.Dto;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class ReviewBLL : IReviewBLL
    {
        private readonly IUnitOfWork uow;

        public ReviewBLL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> AddReview(AddReviewDto addReviewDto)
        {
            //convert dto to review type
            var review = new Review
            {
                ProductId = addReviewDto.ProductId,
                UserId = addReviewDto.UserId,
                UserName = addReviewDto.UserName,
                Rating = addReviewDto.Rating,
                Comment = addReviewDto.Comment,
                ReviewDate = DateTime.Now
            };

            //send to dal layer
            var result = await uow.ReviewRepository.AddReview(review);
            await uow.SaveAsync();
            return result;
        }

        public async Task<IEnumerable<ReviewResponseDto>> GetProductReviews(int productId)
        {
            var result = await uow.ReviewRepository.GetProductReview(productId);

            var reviewResponseDto = result.Select(r => new ReviewResponseDto
            {
                ProductId = r.ProductId,
                UserName = r.UserName,
                Rating = r.Rating,
                ReviewDate = r.ReviewDate,
                Comment = r.Comment
            }).ToList();

            return reviewResponseDto;
        }
    }
}
