using System;
using System.Data.Entity.Migrations;
using System.Linq;
using SuperZapatosAPI.Data;

namespace SuperZapatosAPI.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SuperZapatosAPI.Data.SuperZapatosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuperZapatosAPI.Data.SuperZapatosContext context)
        {
            context.Stores.AddOrUpdate(s => s.id,
                new Store() { name = "Store1", address = "San Jose, Costa Rica" },
                new Store() { name = "Store2", address = "Cartago, Costa Rica" });

            context.Articles.AddOrUpdate(a => a.id,
                new Article() { name = "article1", description = "it is article1", price = 3546, total_in_shelf = 5, total_in_vault = 5, store_id = 1 },
                new Article() { name = "article2", description = "it is article2", price = 3546, total_in_shelf = 5, total_in_vault = 5, store_id = 1 },
                new Article() { name = "article3", description = "it is article3", price = 3546, total_in_shelf = 5, total_in_vault = 5, store_id = 2 },
                new Article() { name = "article4", description = "it is article4", price = 3546, total_in_shelf = 5, total_in_vault = 5, store_id = 2 }
    );

        }
    }
}
