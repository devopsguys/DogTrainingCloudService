using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace DogTrainingWeb.Models
{
    public class EmptyBarkException: Exception {}

    public class InvalidSecretException : Exception { }

    public class DogBarkContext : DbContext
    {
        private readonly string DogTrainingSecret = ConfigurationManager.AppSettings["DogTrainingSecret"];

        public DbSet<DogBarkModel> Barks { get; set; }

        public IEnumerable<DogBarkModel> GetAll()
        {
            return Barks.ToList();
        }

        public DogBarkModel GetLatest()
        {
            if (Barks.Count() == 0) return null;

            int maxId = Barks.Max(x => x.Id);
            return Barks.First(x => x.Id == maxId);
        }

        public void Create(DogBarkViewModel viewModel)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Bark)) throw new EmptyBarkException();
            if (viewModel.Secret != DogTrainingSecret) throw new InvalidSecretException();

            Barks.Add(new DogBarkModel { Bark = viewModel.Bark });
            SaveChanges();
        }
    }
}