using PANWebApp.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PANWebApp.DAL.Repositories
{
    internal class MoviesRepository : RepositoryBase<Movies>
    {
        public MoviesRepository(LibraryContext context) : base(context)
        {
        }
    }
}
