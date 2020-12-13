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
    public class Products : BaseEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public string ProductName { get; set; }
        [ForeignKey("Suppliers")]
        public int SupplierId { get; set; }
        public Suppliers Suppliers { get; set; }
        [ForeignKey("Categories")]
        public int Catgory { get; set; }
        public virtual Categories Categories { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int UnitsInOrder { get; set; }
        public int UnitsOnLevel { get; set; }
        public int ReorderLEvel { get; set; }
        public byte Discontinued { get; set; }



        public List<OrdersDetails> OrdersDetails { get; set; }

    }

}
        
   
