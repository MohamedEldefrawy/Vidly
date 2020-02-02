namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vidly.BL.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<Vidly.DAL.VidlyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vidly.DAL.VidlyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Set<MemberShipType>().AddOrUpdate(
                new MemberShipType
                {
                    Id = 1,
                    DiscountRate = 0,
                    DurationInMonths = 0,
                    SignUpFee = 0
                },
            new MemberShipType
            {
                Id = 2,
                DiscountRate = 10,
                SignUpFee = 30,
                DurationInMonths = 1
            },
            new MemberShipType
            {
                Id = 3,
                DiscountRate = 15,
                DurationInMonths = 3,
                SignUpFee = 90
            },

            new MemberShipType
            {
                Id = 4,
                DiscountRate = 20,
                DurationInMonths = 12,
                SignUpFee = 300
            }

            );
        }
    }
}
