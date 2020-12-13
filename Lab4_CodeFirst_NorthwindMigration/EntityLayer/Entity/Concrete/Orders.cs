using Lab4_CodeFirst_NorthwindMigration.EntityLayer.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_CodeFirst_NorthwindMigration.EntityLayer.Entity.Concrete
{
    public class Orders : BaseEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public virtual Customers Customers { get; set; }
        [ForeignKey("Employees")]
        public int EmployeId { get; set; }
        public virtual Employees Employees { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShipperDate { get; set; }

        [ForeignKey("Shippers")]
        public int ShipVia { get; set; }
        public Shippers Shippers { get; set; }
        public double Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public virtual List<OrdersDetails> OrdersDetails { get; set; }

    }
}
