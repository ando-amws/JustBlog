using FluentNHibernate.Mapping;
using JustBlog.Core.Objects;

namespace JustBlog.Core.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.firstName).Length(250).Not.Nullable();
            Map(x => x.lastName).Length(250).Not.Nullable();
            Map(x => x.Email).Length(250).Not.Nullable();
            Map(x => x.Username).Length(250).Not.Nullable();
            Map(x => x.Password).Length(250).Not.Nullable();
            Map(x => x.Active).Length(5).Not.Nullable();
            Map(x => x.Session).Length(5).Not.Nullable();
            Table("User");
        }

    }
}
