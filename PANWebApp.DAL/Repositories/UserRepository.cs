using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PANWebApp.DAL.DbModels;

namespace PANWebApp.DAL.Repositories
{
    internal class UsersRepository : RepositoryBase<User>
    {
        public UsersRepository(LibraryContext context) : base(context)
        {
        }

        public bool Exists(string login)
        {
            return base.Context.Users.Any(_ => _.Login == login);
        }

        public bool Exists(string login, string passwordHash)
        {
            return base.Context.Users.Any(_ => _.Login == login && _.PasswordHash == passwordHash);
        }
    }
}
