using System.Collections;
using System.Collections.Generic;
using CarManager.Data.Domain;

namespace CarManager.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarManager.Data.CarDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        /// <summary>
        /// EF初始化数据
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(CarManager.Data.CarDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Set<Car>().AddOrUpdate(
                new Car { CarName = "BWMS", Price = 38, CreateTime = DateTime.Now },
                new Car { CarName = "AOdis", Price = 40, CreateTime = DateTime.Now },
                new Car { CarName = "dazhongs", Price = 120, CreateTime = DateTime.Now },
                new Car { CarName = "sangtana", Price = 120, CreateTime = DateTime.Now }
                );
        }
    }
}
