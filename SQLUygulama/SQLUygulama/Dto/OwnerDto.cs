using SQLUygulama.Models;

namespace SQLUygulama.Dto
{
    public class OwnerDto       //Owner modelinden paylaşmak istediğimiz verileri aktardık.
    {
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
