using Microsoft.AspNetCore.Mvc;
using E_commerce.Contracts;
namespace E_commerce.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    [HttpGet]
    public IActionResult GetAllReviews()
    {
        var reviews = _reviewService.GetAllReviews();
        return Ok(reviews);
    }
    [HttpPost]
    public IActionResult AddReview(Review review)
    {
        var addedReview = _reviewService.AddReview(review);
        return Ok(addedReview);
    }
    [HttpDelete("{reviewId}")]
    public IActionResult DeleteReview(int reviewId)
    {
        var deletedReview = _reviewService.DeleteReview(reviewId);
        return Ok(deletedReview);
    }
}