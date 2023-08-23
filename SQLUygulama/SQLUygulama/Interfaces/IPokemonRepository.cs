using SQLUygulama.Models;

namespace SQLUygulama.Interfaces
{
    public interface IPokemonRepository   //İnterface dosyamız.
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);     //GetPokemon bizim detay sayfamız olacak.
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);

        bool CreatePokemon(int ownerId,int categoryId,Pokemon pokemon);
        bool UpdatePokemon(int ownerId,int categoryId,Pokemon pokemon);
        bool DeletePokemon(Pokemon pokemon);
        bool Save();






    }
}
