using SQLUygulama.Models;

namespace SQLUygulama.Dto
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Owner> Owners { get; set; }


    }
}
