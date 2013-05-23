namespace TroyLeeMVCEF.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TroyLeeMVCEF.Domain.Entities;

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            Property(c => c.UserName).IsRequired();
        }
    }
}
