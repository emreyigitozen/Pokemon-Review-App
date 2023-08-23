using SQLUygulama.Models;

namespace SQLUygulama.Interfaces
{
    public interface IReviewRepository
    {
        ICollection <Review> GetReviews ();
        Review GetReview (int reviewid);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists (int reviewid);

        bool CreateReview(Review review);
        bool ReviewExits(int reviewid);
        bool UpdateReview(Review review);
        bool DeleteReview(Review review);
        bool DeleteReviews(List<Review> reviews);
        bool Save();



    }
}
