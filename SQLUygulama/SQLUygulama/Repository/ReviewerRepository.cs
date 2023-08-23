using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SQLUygulama.Data;
using SQLUygulama.Interfaces;
using SQLUygulama.Models;

namespace SQLUygulama.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public ReviewerRepository(DataContext datacontext,IMapper mapper)
        {
            _dataContext = datacontext;
            _mapper = mapper;
        }
        public Reviewer GetReviewer(int reviewerid)
        {
            return _dataContext.Reviewers.Where(r => r.Id == reviewerid).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _dataContext.Reviewers.ToList();
        }

        public ICollection<Reviewer> GetReviewsByReviewer(int reviewerid)
        {
            return (ICollection<Reviewer>)_dataContext.Reviews.Where(r => r.Reviewer.Id == reviewerid).ToList();
        }

        public bool ReviewerExits(int reviewerid)
        {
            return _dataContext.Reviewers.Any(r=> r.Id == reviewerid);
        }

        public bool CreateReviewer(Reviewer reviewer)
        {
            _dataContext.Add(reviewer);
            return Save();
        }


        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved>0 ? true : false;
        }

        public bool UpdateReviewer(Reviewer reviewer)
        {
            _dataContext.Update(reviewer);
            return Save();
        }

        public bool DeleteReviewer(Reviewer reviewer)
        {
            _dataContext.Remove(reviewer);
            return Save();
        }
    }
}
