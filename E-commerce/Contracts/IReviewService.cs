namespace E_commerce.Contracts;

/// <summary>
/// Defines the contract for managing reviews in the e-commerce system.
/// </summary>
public interface IReviewService
{
    /// <summary>
    /// Adds a new review for a product.
    /// </summary>
    /// <param name="review">The review object containing the details to be added.</param>
    /// <returns>The added review object.</returns>
    Review AddReview(Review review);

    /// <summary>
    /// Retrieves all reviews in the system.
    /// </summary>
    /// <returns>A list of all reviews.</returns>
    List<Review> GetAllReviews();

    /// <summary>
    /// Deletes a review by its ID.
    /// </summary>
    /// <param name="reviewId">The ID of the review to delete.</param>
    /// <returns>The deleted review object.</returns>
    Review DeleteReview(int reviewId);
}
