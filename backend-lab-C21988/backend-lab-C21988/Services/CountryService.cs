using backend_lab_C21988.Models;
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

    }
}
