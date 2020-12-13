using Lab3_CodeFirst_PhoneBook.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_CodeFirst_PhoneBook.DataAccessLayer.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            //Windows Authentication
            Database.Connection.ConnectionString = @"Server=(localdb)\MSSQLLocalDB; Database=PhoneBook222; Integrated Security=true";


        }
        //Oluşturduğumuz AppUser class ımızı burda artık table olacağını belirtiyoruz.
        public DbSet<AppUser> AppUsers { get; set; }
        //Entity Framework'un CodFirst yönetmindeki Ayağı kaldırma işleminin özeti burada açıklanmıştır.  
        //Öcelikle  Database aktaracağımız table'ı ;EntityLayer de Concrete Folder ın içerisinde BaseEntity den kalıtım alarak oluşturduk.
        //Daha sonra DataAccess Layer'ı içeirindeki Context Folder'ınde Database ile yapılacak bağlantının yolunu gösterdik. Bu işlemi ProjectContext class'ının içine Constructor method tanımlayarak yaptık.
        //Müteakiben AppUser Class ımıza sen Database de table olacaksın vurgusunu dbset<>ile belirttik.
        //Devamında Projenin References kısmında EntityFromwork install işlemine yapıcaz.
        //Ve en sonda Package maneger console ekranına Enable-Migrations komutu ile göç işlemi gerçekleştiricez. ve Update-Database komutu ile database kısmındaki güncelleme işlemini yaparak tabloyu oluşturma yani ayağa kaldırma işlemini yapmış olucaz.
    }
}
