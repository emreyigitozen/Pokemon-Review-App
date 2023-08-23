namespace SQLUygulama.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Review> Reviews { get; set; }   /*Pokemon - reviews one to many */ /* Many'ler liste halinde olacağı için ICollection yapıyoruz.*/
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }




    }
}
