﻿using SQLUygulama.Models;

namespace SQLUygulama.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner>GetOwners();
        Owner GetOwner(int ownerId);

        ICollection<Owner> GetOwnerOfAPokemon(int pokeId);
        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        bool OwnerExits (int ownerId);

        bool CreateOwner(Owner owner);
        bool UpdateOwner(Owner owner);
        bool DeleteOwner(Owner owner);

        bool Save();




    }
}
