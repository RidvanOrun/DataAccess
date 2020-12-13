using Lab3_CodeFirst_PhoneBook.EntityLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_CodeFirst_PhoneBook.EntityLayer.Entities.Abstract
{
    //oluşturacağımız tablolarımızın temel özelliklerini tuutcağımız sınıfımız
    public abstract class BaseEntity<T>
    {
        public abstract T Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public DateTime? PassiveDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get { return _status; } set { _status = value; } }


    }
}
