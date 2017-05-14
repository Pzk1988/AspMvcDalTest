using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PANWebApp.DAL.DbModels
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            
        }

        protected EntityBase(Guid id)
        {
            Id = id;
        }

        protected EntityBase(string id)
        {
            Id = Guid.Parse(id);
        }

        public Guid Id { get; set; }
    }
}
