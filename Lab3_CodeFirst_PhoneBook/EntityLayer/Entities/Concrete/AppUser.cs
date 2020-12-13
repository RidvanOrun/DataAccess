using Lab3_CodeFirst_PhoneBook.EntityLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_CodeFirst_PhoneBook.EntityLayer.Entities.Concrete
{
    //AppUser class ımız BaseEntity den temel özelliklerini aldı. AppUser bizim database e aktaracağımız tablomuz olacak.
    public class AppUser : BaseEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        [Required]
        public string FirstNAme { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName => FirstNAme + " " + LastName;
        [Required]
        public string Adress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
