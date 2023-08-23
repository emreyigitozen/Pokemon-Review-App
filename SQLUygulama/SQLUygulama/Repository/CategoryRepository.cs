using SQLUygulama.Data;
using SQLUygulama.Interfaces;
using SQLUygulama.Models;

namespace SQLUygulama.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);  //Kategori var mı yok mu kontrol ediyor.
        }

        public ICollection<Category> GetCategories()  //Burada liste return ediyoruz.
        {
            return _context.Categories.OrderBy(c => c.Id).ToList();
        }

        public Category GetCategory(int id)  //Burda ise sadece bir kategori return ediyoruz.
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        public bool Save()
        {
            var saved= _context.SaveChanges();
            return saved>0 ? true : false;
        }
        public bool CreateCategory(Category category)
        {

            _context.Add(category);
            return Save();

            
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }
    }
}
