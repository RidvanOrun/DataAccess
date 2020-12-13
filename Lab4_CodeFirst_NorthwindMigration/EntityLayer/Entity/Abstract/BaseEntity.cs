using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_CodeFirst_NorthwindMigration.EntityLayer.Entity.Abstract
{
    public abstract class BaseEntity<T>
    {
        public abstract T Id { get; set; }
    }
}
