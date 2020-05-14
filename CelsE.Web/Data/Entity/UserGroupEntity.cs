namespace CelsE.Web.Data.Entity
{
    using System.Collections.Generic;

    public class UserGroupEntity
    {
        public int Id { get; set; }

        public UserEntity Usuario { get; set; }

        public ICollection<UserEntity> Usuarios { get; set; }
    }

}
