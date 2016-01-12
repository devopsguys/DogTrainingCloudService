using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DogTrainingWeb.Models
{
    public class DogBarkContext : DbContext
    {
        public static DogBarkContext Instance { get; } = new DogBarkContext();

        public DbSet<DogBarkModel> Barks { get; set; }

        public IEnumerable<DogBarkViewModel> GetAll()
        {
            return Barks.Select(bark => new DogBarkViewModel {Bark = bark.Bark}).ToList();
        }

        public IEnumerable<DogBarkModel> GetAllApi()
        {
            return Barks.ToList();
        }

        public void Create(DogBarkViewModel viewModel)
        {
            Barks.Add(new DogBarkModel { Bark = viewModel.Bark });
            SaveChanges();
        }
    }
}