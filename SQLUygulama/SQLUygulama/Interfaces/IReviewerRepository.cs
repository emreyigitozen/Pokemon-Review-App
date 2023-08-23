using SQLUygulama.Models;

namespace SQLUygulama.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerid);
        ICollection<Reviewer> GetReviewsByReviewer(int reviewerid);
        bool ReviewerExits(int reviewerid);
        bool CreateReviewer(Reviewer reviewer);
        bool UpdateReviewer(Reviewer reviewer);
        bool DeleteReviewer(Reviewer reviewer);
        bool Save();




    }
}
