﻿using SQLUygulama.Models;

namespace SQLUygulama.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerid);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
        bool CountryExits(int id);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
        bool Save();



    }
}