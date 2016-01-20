using FluentNHibernate.Mapping;
using JustBlog.Core.Objects;

namespace JustBlog.Core.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("User");
            Id(x => x.Id);
            Map(x => x.firstName).Length(50).Not.Nullable();
            Map(x => x.lastName).Length(50).Not.Nullable();
            Map(x => x.Email).Length(50).Not.Nullable();
            Map(x => x.Username).Length(50).Not.Nullable().Column("username");
            Map(x => x.Password).Length(50).Not.Nullable().Column("password");
            Map(x => x.Active).Length(5).Not.Nullable().Column("active");
            Map(x => x.Session).Length(5).Not.Nullable().Column("session_code");
            // Test Ando 
            
        }

    }
}
