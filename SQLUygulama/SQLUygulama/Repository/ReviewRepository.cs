using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SQLUygulama.Data;
using SQLUygulama.Interfaces;
using SQLUygulama.Models;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace SQLUygulama.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;




        public ReviewRepository(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }


        public Review GetReview(int reviewid)  //Spesifik bir yorumu çekiyoruz.
        {
            return _dataContext.Reviews.Where(r => r.Id == reviewid).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _dataContext.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return _dataContext.Reviews.Where(p=>p.Pokemon.Id == pokeId).ToList();

        }

        public bool ReviewExists(int reviewid)
        {
            return _dataContext.Reviews.Any(r=> r.Id == reviewid);
        }

        public bool ReviewExits(int reviewid)
        {
            throw new NotImplementedException();
        }

        public bool CreateReview(Review review)
        {
            _dataContext.Add(review);
            return Save();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(Review review)
        {
            _dataContext.Update(review);
            return Save();
        }

        public bool DeleteReview(Review review) //Genel bütün yorumları silmek için
        {
            _dataContext.Remove(review);
            return Save();
        }

        public bool DeleteReviews(List<Review> reviews)  //Spesifik bir yorumu silmek için
        {
            _dataContext.RemoveRange(reviews);
            return Save();
        }
    }
}
