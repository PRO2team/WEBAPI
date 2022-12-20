using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Contexts;
using Webapi.Helpers;
using Webapi.Models;
using Webapi.Models.Requests;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ReviewsController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            return await _dbContext.Reviews.IncludeAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _dbContext.Reviews.IncludeAll().FirstOrDefaultAsync(e => e.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(AddReviewRequest addReviewRequest)
        {
            var appointment = await _dbContext.Appointments.FirstOrDefaultAsync(e => e.AppointmentID == addReviewRequest.AppointmentID);

            if(appointment is null)
            {
                return NotFound();
            }

            var review = new Review()
            {
                PostedTimestamp = DateTime.Now,
                Rating = addReviewRequest.Rating,
                Comment = addReviewRequest.Comment,
                Appointment = appointment
            };
            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.ReviewID }, review);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _dbContext.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _dbContext.Reviews.Remove(review);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
