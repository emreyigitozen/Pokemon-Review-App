using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SQLUygulama.Data;
using SQLUygulama.Interfaces;
using SQLUygulama.Models;
using System.Diagnostics.Metrics;

namespace SQLUygulama.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public OwnerRepository(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public Owner GetOwner(int ownerId)
        {
            return _dataContext.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            return _dataContext.PokemonOwners.Where(p => p.Pokemon.Id == pokeId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _dataContext.Owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return _dataContext.PokemonOwners.Where(o=>o.Owner.Id==ownerId).Select(p=>p.Pokemon).ToList();
        }

        public bool OwnerExits(int ownerId)
        {
            return _dataContext.Owners.Any(o=>o.Id == ownerId);
        }
        public bool CreateOwner(Owner owner)
        {
            _dataContext.Add(owner);
            return Save();
        }
        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _dataContext.Update(owner);
            return Save();
        }

        public bool DeleteOwner(Owner owner)
        {
            _dataContext.Remove(owner);
            return Save();
        }
    }
}
