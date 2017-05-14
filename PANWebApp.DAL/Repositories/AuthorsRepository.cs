using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PANWebApp.DAL.DbModels;

namespace PANWebApp.DAL.Repositories
{
    internal class AuthorsRepository : RepositoryBase<Author>
    {
        public AuthorsRepository(LibraryContext context) : base(context)
        {
        }
    }
}
