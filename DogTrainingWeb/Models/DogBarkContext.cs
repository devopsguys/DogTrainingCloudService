using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DogTrainingWeb.Models
{
    public class DogBarkContext : DbContext
    {
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
            Barks.Add(new DogBarkModel { Bark = viewModel.Bark });
            SaveChanges();
        }
    }
}