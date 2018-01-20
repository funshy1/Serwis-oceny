using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using projekt.Controllers.Resources;
using projekt.Models;
using projekt.Persistence;

namespace projekt.Controllers
{
    [Route("api/review")]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository repository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ReviewController> logger;

        public ReviewController(IReviewRepository repository, IMapper mapper, IUnitOfWork unitOfWork, ILogger<ReviewController> logger)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;

        }
        
        [HttpGet]
        public async Task<QueryResultResource<ReviewResource>> GetReviews(ReviewQueryResource queryResource)
        {
            var query = mapper.Map<ReviewQueryResource, ReviewQuery>(queryResource);
            var queryResult = await repository.GetReviews(query);

            return mapper.Map<QueryResult<Review>, QueryResultResource<ReviewResource>>(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id) {
            var review = await repository.GetReview(id);

            if (review == null)
                return NotFound();

            var reviewResource = mapper.Map<Review, ReviewResource>(review);
            return Ok(reviewResource);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] SaveReviewResource reviewResource) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var review = mapper.Map<SaveReviewResource, Review>(reviewResource);

            repository.Add(review);
            repository.SetRating(review, onAdd: true);
            await unitOfWork.CompleteAsync();

            review = await repository.GetReview(reviewResource.Id);

            var result = mapper.Map<Review, ReviewResource>(review);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id) 
        {
            var review = await repository.GetReview(id);

            if (review == null)
                return NotFound();

            repository.Remove(review);
            repository.SetRating(review, onAdd: false);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody]SaveReviewResource reviewResource) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var review = await repository.GetReview(id);

            if (review == null)
                return NotFound();

            mapper.Map<SaveReviewResource, Review>(reviewResource, review);

            repository.SetRating(review);
            
            await unitOfWork.CompleteAsync();

            review = await repository.GetReview(review.Id);
            var result = mapper.Map<Review, ReviewResource>(review);
            
            return Ok(result);
        }

    }
}