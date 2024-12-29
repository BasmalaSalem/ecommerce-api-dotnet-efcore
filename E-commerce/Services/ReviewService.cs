namespace E_commerce.Services;
using E_commerce.Contracts;
public class ReviewService : IReviewService
{
    private readonly AppDbContext _context;
    public ReviewService(AppDbContext context)
    {
        _context = context;
    }
    public Review AddReview(Review review)
    {
        try
        {
            if (review == null)
                throw new ArgumentNullException(nameof(review), "Review cannot be null.");

            var productExists = _context.Products.FirstOrDefault(p => p.Id == review.ProductId);
            if (productExists == null)
            {
                throw new ArgumentException("The specified product does not exist.");
            }
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return review;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while adding a new review.", e);
        }
    }

    public List<Review> GetAllReviews()
    {
        try
        {
            return _context.Reviews.ToList();
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while retrieving all reviews.", e);
        }
    }

    public Review DeleteReview(int reviewId)
    {
        try
        {
            var reviewToDelete = _context.Reviews.Find(reviewId);
            if (reviewToDelete == null)
            {
                throw new ApplicationException($"Review with ID {reviewId} not found.");
            }
            _context.Reviews.Remove(reviewToDelete);
            _context.SaveChanges();
            return reviewToDelete;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while deleting a review.", e);
        }
    }

    // public Review UpdateReview(Review review)
    // {}

}