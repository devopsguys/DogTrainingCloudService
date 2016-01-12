using DogTrainingWeb.Models;

namespace DogTrainingWeb.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DogBarkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DogBarkContext context)
        {
            context.Barks.AddOrUpdate(
                new DogBarkModel { Bark = "My first bark" },
                new DogBarkModel { Bark = "Woof woof!!!" }
            );
        }
    }
}
