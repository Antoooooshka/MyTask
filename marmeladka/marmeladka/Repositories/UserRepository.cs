using System;
using marmeladka.core.entities;
using System.Collections.Generic;
using System.Linq;
using marmeladka.DTOs;

namespace marmeladka.Repositories
{
    public class UserRepository : BaseRepository<user>
    {
        #region Controllers
        public UserRepository()
            : this(new marmeladkaDBEntities1())
        {

        }
        public UserRepository(marmeladkaDBEntities1 marmDb) : base(marmDb) { }
        #endregion

        public IEnumerable<user> GetUsers()
        {
            return DbSet.ToList();
        }

        public user AddUser(OrderRequestDTO dto)
        {
            user user = new user
            {
                id = Guid.NewGuid(),
                name = dto.Name,
                second_name = dto.Second_name,
                adress = dto.Adress,
                email = dto.Email,
                postcode = dto.Postcode,
                phone = dto.Phone
            };
            return user;
        }

        public user GetUserByEmail(string userEmail)
        {
            return DbSet.FirstOrDefault(x => x.email == userEmail);
        }
    }
}