namespace Forum.Data.Migrations
{
    using Core;
    using Forum.Core.Models.Common;
    using Forum.Core.Models.Messages;
    using Forum.Core.Models.System;
    using Forum.Core.Models.Users;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FContext context)
        {

            context.Category.AddOrUpdate(
              m => m.ID,
              new Category { ID = 1, Name = "All", Description = "De todo" },
              new Category { ID = 2, Name = "Young", Description = "Sólo Jóvenes" },
              new Category { ID = 3, Name = "Adults", Description = "Sólo adultos" }
            );

            context.MessageType.AddOrUpdate(
              m => m.ID,
              new MessageType { ID = 1, Name = "Public" },
              new MessageType { ID = 2, Name = "Private" }
            );

            context.Roles.AddOrUpdate(
              m => m.Id,
              new Role { Id = 1, Name = "Admin" },
              new Role { Id = 2, Name = "User" }
            );

            context.Seniority.AddOrUpdate(
              m => m.ID,
              new Seniority { ID = 1, Name = "Junior", Description="Recién llegado" },
              new Seniority { ID = 2, Name = "Middle-Weight", Description="Avanzado" },
              new Seniority { ID = 3, Name = "Senior", Description="Maestro" }
            );

            context.SysAppEventType.AddOrUpdate(
              m => m.ID,
              new SysAppEventType { ID = 1, Name = "Unknown"},
              new SysAppEventType { ID = 2, Name = "Info"},
              new SysAppEventType { ID = 3, Name = "Error" },
              new SysAppEventType { ID = 4, Name = "Warning" }
            );

            context.Status.AddOrUpdate(
              m => m.ID,
              new Status { ID = 1, Name = "Active" },
              new Status { ID = 2, Name = "Inactive" },
              new Status { ID = 3, Name = "Deleted" }
            );
        }
    }
}
