using System.Collections.Generic;
using System.Threading.Tasks;
using projekt.Models;

namespace projekt.Persistence
{
    public interface IReviewRepository
    {
        Task<QueryResult<Review>> GetReviews(ReviewQuery queryObject);
        Task<Review> GetReview(int id);
        void Add(Review review);
        void Remove(Review review);
    }
}