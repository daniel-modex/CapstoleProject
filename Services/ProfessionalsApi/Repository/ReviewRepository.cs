using Microsoft.EntityFrameworkCore;
using ProfessionalsApi.Data;
using ProfessionalsApi.Models;
using ProfessionalsApi.Repository.IRepository;

namespace ProfessionalsApi.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ProfessionalApiContext _context;

        public ReviewRepository(ProfessionalApiContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        


        public async Task<Reviews> GetReviewById(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return new Reviews();
            }
            return review;
        }

        public async Task<IEnumerable<Reviews>> GetReviewsByProfessional(string username) => await _context.Reviews
            .Where(x => x.ProfessionalName == username)
            .ToListAsync();

        public async Task<bool> PostReview(Reviews review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            var count = await _context.Reviews.Where(x=>x.ProfessionalName==review.ProfessionalName).CountAsync();
            var oldRating = await _context.Professionals.FirstOrDefaultAsync(x=>x.UserName == review.ProfessionalName); 
            var newRating = (oldRating.Rating+review.UserRating)/count;
            oldRating.Rating = newRating;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
