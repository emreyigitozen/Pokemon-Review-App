namespace SQLUygulama.Models
{
    public class PokemonOwner
    {                                   /*Join Table */
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Owner Owner { get; set; }




    }
}
