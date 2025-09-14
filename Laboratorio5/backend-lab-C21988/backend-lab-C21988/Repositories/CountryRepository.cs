﻿using backend_lab_C21988.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace backend_lab_C21988.Handlers
{
    using backend_lab_C21988.Models;
    using Dapper;
    using System.Data.SqlClient;
}

namespace backend_lab_C21988.Repositories
{
    public class CountryRepository
    {
        private readonly string _connectionString;
        public CountryRepository()
        {
            var builder = WebApplication.CreateBuilder();
            _connectionString =
            builder.Configuration.GetConnectionString("CountryContext");
        }
        public List<CountryModel> GetCountries()
        {
            using var connection = new
            SqlConnection(_connectionString);
            string query = "SELECT * FROM dbo.Country";
            return connection.Query<CountryModel>(query).ToList();
        }

        public bool CreateCountry(CountryModel country)
        {
            using var connection = new
           SqlConnection(_connectionString);
            var query = @"INSERT INTO [dbo].[Country]
                        ([Name],[Language],[Continent])
                        VALUES(@Name, @Language, @Continent)";
            var affectedRows = connection.Execute(query, new
            {
                Name = country.Name,
                Language = country.language,
                Continent = country.Continent
            });
            return affectedRows >= 1;
        }
    }
}

