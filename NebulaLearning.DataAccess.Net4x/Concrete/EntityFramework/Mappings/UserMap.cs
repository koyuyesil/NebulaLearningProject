using NebulaLearning.Entities.Net4x.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework.Mappings
{
    // TODO Entity 5 : User için Users Mapping Configuration yapılır.
    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"Users", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.UserName).HasColumnName("UserName");
            Property(x => x.Password).HasColumnName("Password");
            Property(x => x.FirstName).HasColumnName("FirstName");
            Property(x => x.LastName).HasColumnName("LastName");
            Property(x => x.Email).HasColumnName("Email");
        }
    }
}
