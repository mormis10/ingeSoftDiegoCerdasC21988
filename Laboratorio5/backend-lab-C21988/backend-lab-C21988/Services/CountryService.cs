﻿using backend_lab_C21988.Models;
using backend_lab_C21988.Repositories;



namespace backend_lab_C21988.Services
{
    public class CountryService
    {
        private readonly CountryRepository countryRepository;
        public CountryService()
        {
            countryRepository = new CountryRepository();
        }
        public List<CountryModel> GetCountries()
        {
            // Add any missing business logic when it is necessary
            return countryRepository.GetCountries();
        }

        public string CreateCountry(CountryModel country)
        {
            var result = string.Empty;
            try
            {
                var isCreated = countryRepository.CreateCountry(country);
                if (!isCreated)
                {
                    result = "Error al crear el país";
                }
            }
            catch (Exception)
            {
                result = "Error creando país";
            }
            return result;
        }



    }
}
