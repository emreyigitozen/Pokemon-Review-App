﻿namespace SQLUygulama.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PokemonCategory> pokemonCategories { get; set; }


    }
}
