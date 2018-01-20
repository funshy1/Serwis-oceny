using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projekt.Extensions;
using projekt.Models;

namespace projekt.Persistence
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ServiceDbContext context;

        public ReviewRepository(ServiceDbContext context)
        {
            this.context = context;

        }

        public void Add(Review review)
        {
            context.Reviews.Add(review);
        }

        public void Remove(Review review)
        {
            context.Remove(review);
        }

        public async Task<Review> GetReview(int id)
        {
            var review = await context.Reviews
                .Where(r => r.Id == id).SingleOrDefaultAsync();

            return review;
        }

        public async Task<QueryResult<Review>> GetReviews(ReviewQuery queryObject)
        {
            var result = new QueryResult<Review>();

            var query = this.context.Reviews
                .AsQueryable();

            if (!String.IsNullOrEmpty(queryObject.UserId))
                query = query.Where(r => r.UserId == queryObject.UserId);
            if(queryObject.ProductId.HasValue)
                query = query.Where(r => r.Product.Id == queryObject.ProductId);

            var map = new Dictionary<string, Expression<Func<Review, object>>>()
            {
                ["rating"] = r => r.Rating,
                ["product"] = r => r.Product.Name,
            };

            query = query.ApplyOrdering(queryObject, map);
            result.TotalItems = await query.CountAsync();
            query = query.ApplyPaging(queryObject);
            result.Items = await query.ToListAsync();

            return result;
        }

        public void SetRating(Review review, bool onAdd) {
            var ratings = context.Reviews.Where(r => r.ProductId == review.ProductId).Select(r => r.Rating);

            var sum = ratings.Sum();
            var count = ratings.Count();

            if (onAdd) {
                sum += review.Rating;
                count += 1;
            } else {
                sum -= review.Rating;
                count -= 1;
            }

            var product = context.Products.Where(p => p.Id == review.ProductId).SingleOrDefault();
            product.Rating = sum / count;
        }

        public void SetRating(Review review) {
            var ratings = context.Reviews.Where(r => r.ProductId == review.ProductId).Select(r => r.Rating);

            var product = context.Products.Where(p => p.Id == review.ProductId).SingleOrDefault();
            product.Rating = ratings.Sum() / ratings.Count();
        }
    }
}