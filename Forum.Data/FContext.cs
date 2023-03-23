namespace Forum.Data
{
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Entity.Validation;
    using Forum.Core.Models.Users;
    using Forum.Core.Models.Messages;
    using Forum.Core.Models.System;
    using Forum.Core.Models.Common;
    using Forum.Core.Models;
    using System.Data.Entity.Infrastructure;
    using System;

    public partial class FContext : IdentityDbContext<User, Role, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {

        public int UserID { get; set; }

        public FContext()
            : base("name=FContext")
        {
        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<MessageType> MessageType { get; set; }
        public virtual DbSet<Seniority> Seniority { get; set; }
        public virtual DbSet<SysAppEvent> SysAppEvent { get; set; }
        public virtual DbSet<SysAppEventType> SysAppEventType { get; set; }
        public virtual DbSet<SysLoginLog> SysLoginLog { get; set; }
        public virtual DbSet<Thread> Thread { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MessageType>()
                .HasMany(e => e.Message)
                .WithRequired(e => e.MessageType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seniority>()
                .HasMany(e => e.UserProfile)
                .WithRequired(e => e.Seniority)
                .HasForeignKey(e => e.UserReputationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SysAppEventType>()
                .HasMany(e => e.SysAppEvent)
                .WithRequired(e => e.SysAppEventType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thread>()
                .HasMany(e => e.Message)
                .WithRequired(e => e.Thread)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SysAppEvent)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SysLoginLog)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserProfile)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);
        }

        public static FContext Create()
        {
            return new FContext();
        }

        public override int SaveChanges()
        {

            var changeSet = ChangeTracker.Entries<IMaintainableEntity>();

            foreach (DbEntityEntry entry in changeSet.Where(c => c.State != EntityState.Unchanged && c.State != EntityState.Detached))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((IMaintainableEntity)entry.Entity).SetCreationData(DateTime.Now, UserID);
                        ((IMaintainableEntity)entry.Entity).SetStatus(Core.Enums.Common.States.ACTIVE);
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        ((IMaintainableEntity)entry.Entity).SetDeletedData(DateTime.Now, UserID);
                        ((IMaintainableEntity)entry.Entity).SetStatus(Core.Enums.Common.States.DELETED);
                        break;
                    case EntityState.Modified:
                        ((IMaintainableEntity)entry.Entity).SetModifiedData(DateTime.Now, UserID);
                        break;
                }
            }

#if (DEBUG)
            try
            {                
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errors = ex.EntityValidationErrors
                    .Select(x => new
                    {
                        Entity = x.Entry.Entity,
                        PropertyErrors = ex.EntityValidationErrors.SelectMany(y => y.ValidationErrors).Select(y => y.ErrorMessage)
                    });

                var fullErrorMessage = string.Empty;

                foreach (var e in errors)
                {
                    fullErrorMessage += string.Format("Conflicting entity: {0} - Error messages: {1} ; ", e.Entity.ToString(), string.Join(", ", e.PropertyErrors));
                }

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are -> ", fullErrorMessage);
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
#else

            return base.SaveChanges();
            
#endif

        }
    }
}
