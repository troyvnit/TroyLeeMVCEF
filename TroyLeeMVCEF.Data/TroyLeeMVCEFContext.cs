namespace TroyLeeMVCEF.Data
{
    using System.Data.Entity;

    using TroyLeeMVCEF.Data.Configurations;
    using TroyLeeMVCEF.Domain.Entities;

    public class TroyLeeMVCEFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

    }
}
