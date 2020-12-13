using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.SqlServer;

namespace Lab1_DbFirstExamplesLinqTo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //ORM(Object Relation Mapping)
        //Entity Framework ve alternatiflerinin arkasında yatan mantık ORM mimarisidir. EntityFramework özünde bir ORM mimarisidir. ORM, veritabanında yaratmış olduğunuz her varlığın yani tablonun karşılığında uygulama tarafında ilgili tabloların birer karşılığı objeler bulunmaklıdır.Ef code generation tekniği kullanarak bizim yazmamız gerek kodu otomatik olarak üretir. OOP mantığına ve SOLİD prensiplerine uygun bir şekilde veri tabanımızda bulunan tabloların birer nesne örneklerini oluşturuyoruz.

        //Entity Framework
        //ORM gerekliliklerini yukarıda tartıştık. Son cümle tabloların birer nesne örneklerini oluşturuyoruz. Buradan anlaşılan veri tabanı yansıması projeye entegre etmemiz yada bu yansımayı bizim hatırlamamız gerektiğidir. Bu bağlamda EF bize 3 yaklaşımıyla yardımcı olmaktadır.

        // 1.Datebase First Approach:Bu lab1 uygulamamızda kullandığımız yaklaşımdır. Hazır bir veri tabanı varsa bu veri tabanını kullanacaksam ilgili veri tabanının yansımasını uygulamaya ekliyoruz. Sonuç olarak veritabanında bulunan tabloları projeme sınıf oarak EF tarafından otomatik olarak eklenir. Application tarafında bu yansıma üzerinde çalışırız. CRUD operasyonlarını bu yansıma üzerinden yürütüyoruz. Çok büyük projelerin ihtiyacı olan geniş çaplı veritabanlarında bu performans kayıplarına neden olur. Ayrıca yansıma üzerinde bir değişiklik yaptığımızda bu değişikliği veri tabanındaki varlıklar üzerinde uygulanması gerekir.
        // 2. Model Firast Approach: Uygulama tarafında SQL Server Object Explorer yardımıyla veri tabanında ihtiyaç duyulan varlık tablolar halinde oluşturulur. Oluşturulan bu şema veri tabanına gönderilir.
        // 3. Code First Approach: Veri tabanında ihtiyaç duyulan varlıkların ve bu varlıkların arasındaki ilişikileri OOP yaklaşımları çerçevesinde application tarafında ,developer tarafından sınıflar (class) halinde yaratılması daha sora oluşturulan bu sınıflardan teşekkül eden bu yapının veri tabanı tarafına migration edilerek, EF tarafından veri tabanı ve onun varlıklarının otomatik olarak yaratıldığı bir yaklaşımdır. Sonuç olarak yaratılan sınıflar veri tabanına gidecek ve tablo olarak ayağa kalacaklar.

        NorthwindEntities db = new NorthwindEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            //ToList()=> Methodu veritabanında bulunan tablodaki tüm veriyi herhangi bir şarttta bakmaksızın RAM'ın HEAP alanına çıkarır.Genellikle uygulama tarafında veri tabanında bulunan varlığın yani tablonun uygulama tarafındaki yansıması tipinde bir generic liste oluşturulması için kullanılır.
            //select * from Categories
            //db.Categories.ToList() bu linq to sorgusu SQL tarafında TSQL dönüştürülerek execute edilecek.
            dataGridView1.DataSource = db.Categories.ToList(); //linq to sorgusu
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Customer CompanyName,ContactName,Phone ve Adress bilgilerini getiriniz.
            dataGridView1.DataSource = db.Customers.Select(x => new
            {
                ŞirketAdı = x.CompanyName,
                Yetkili = x.ContactName,
                Telefon = x.Phone,
                Adress = x.Address
            }).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Where()=> Veritabanındaki tablolar üzerinde şartlar doğrultusunda verileri filtrelemeye yarar.
            //dataGridView1.DataSource = db.Products.Where(x => x.UnitPrice > 20).ToList();

            //Lamda Expression("x=>x."):Lamda, Bu örnekte Product sınıfının tüm özelliklerinin "x" generic ismine atamakta yaramaktadır. Nasıl ki instance aldığımızda instance name+"." notasyonu ile sınıfın özelliklerine erişiyoruz burada aynı durum söz konusudur.

            //Soru: Products tablosundan UnitInStock bilgisi 100 ile 200 arasında olan ürünleri listeleyin.

            dataGridView1.DataSource = db.Products.Where(x => x.UnitsInStock > 100 && x.UnitsInStock < 200).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //T-SQL'deki mantığı buradada uygulanılmaktadır.Sorgu sonucunda dönen generic list üzerinde sıralama işlemleri yapar.Burada SQL de olduğu gibi default "asc"dir.Descending işlemi için ayrıca bir method bulunmaktadır.

            //Ascending
            dataGridView1.DataSource = db.Products.OrderBy(x => x.ProductName).ToList();

            //ürünleri birim fiyatlarına göre çooktan aza sıralayarak, ürünlerin Id, ürün adının stok miktarını ve birim fiyatının bilgilerini getiriniz.
            dataGridView1.DataSource = db.Products.OrderByDescending(x => x.UnitPrice).Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.UnitsInStock,
                x.UnitPrice
            }).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //T-SQL'de bulunan özelliği ile buradaki kullanımı aynıdır. Sonuç kümesi üzerinde belirli şartlara göre gruplama yapmamızı sağlar. 

            //Hangi kategoride kaç tane ürün var
            dataGridView1.DataSource = db.Products
                .GroupBy(x => x.Category.CategoryName)
                .Select(x => new
                {
                    KetegoriAdi = x.Key,
                    ToplamStok = x.Sum(y => y.UnitsInStock)
                }).ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //First()=> Bir koleksiyonda sorgu sonucunda bize dönen veri kümesindeki ilk eleman seçmek için kullanılmaktadır. Dikkat: Null değer gelirse uygulama patlar. Ona göre try-catch yada if blokları ile gerekli kontrol mekanizmaları kurulmak zorundadır.TSQL deki Top komutuna benzetebiliriz. 

            //First methodunu kullanırken şu hususada dikkat etmek gerekmektedir. First methodu içerisinde parametre girmessek sorgu sonucunda bize dönen kümesinin ilk satırını bize default olarak döner.

            Category category = db.Categories.First();
            MessageBox.Show($"Bana şart vemerdin sorgu sonucunda dönen ilk satırı getirdim:{category.CategoryName}");

            //Lakin bir şart belirtirsek şart sonucunda dönen sorgu kümesindeki ilk satır döner.

            Category category1 = db.Categories.First(x => x.CategoryID > 7);
            MessageBox.Show($"Category ID'si 7 den büyük olan ilk categori: {category1.CategoryName}");

            //NOT:First methodu il ToList() methodu birlikte kullanılamazi çünkü first methodu tek bir veri satırı döner, bu yüzden ToList() kullanılamaz.

            //Dikkat: null değer gelirse uygulama patlar. Ona göre try-catch yada if blokları ile gerekli kontrol mekanizmaları kurulmak zorundadır. TSQL'deki top komutuna benzetebiliriz.
            //Category category2 = db.Categories.First(x => x.CategoryID > 15);
            //MessageBox.Show($"Category ID'si 10 den büyük olan ilk categori: {category2.CategoryName}");

            //yukarıdaki linq to sorgusu çalışmamaktadır. Çünkü veritanabında 16 nolu bir ıd bulunmamaktadır.Bunu try catch ile halledebiliriz.

            try
            {
                Category category2 = db.Categories.First(x => x.CategoryID > 15);
                MessageBox.Show($"Category ID'si 10 den büyük olan ilk categori: {category2.CategoryName}");
            }
            catch (Exception)
            {

                MessageBox.Show("Aradığınız kategori bulunamadı");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //FirstOrDefault()=> First ile aynı kullanım amacına sahiptir.Farklı olarak First methodu null değer geldiğinde patlamaktaydı. FirstOrDefault bu hatayı yaşamıyor direk değer yoksa null dönmektedir.Yani şart sağlanmadığında patlamak yerine Null dönüyor.

            Category category = db.Categories.FirstOrDefault(x => x.CategoryID > 7);

            if (category == null)
            {
                MessageBox.Show("Aradığınız kategori bulunmamkatdır..");
            }
            else
            {
                MessageBox.Show($"Aradığınız kategori{category.CategoryName}");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Find()=> SQL server üzerinde veritabanı işlemlerini incelerken Identity Key(Id) olduğunu öğrenmişsinizdir. Uniq olduğunu tek bir kayıtı temsil ettiğini unutmayın. eğer bir tek kayıt erişmek istersek Id'den yararlanmamız çok olağandır ve bu bağlamda find methodunu kullanabiliriz.

            //Employee employee = db.Employees.Find(1);

            //if (employee==null)
            //{
            //    MessageBox.Show("Aradığınız çalışan bulunmmaktadır");
            //}
            //else
            //{
            //    MessageBox.Show($"Aradığınız çalışanın adı:{employee.FirstName}");
            //}

            //Kategori ve tedarikçi ID'si 1 olan ürünlerin isimlerinie göre tersten sıralayınız.

            dataGridView1.DataSource = db.Products.Where(x => x.CategoryID == 1 && x.SupplierID == 1).OrderByDescending(x => x.ProductName).ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Take()=> methodu T-SQL sorgulama dilindeli Top komutunun karşılığıdır diyabiliriz. Sorgu sonucunda bize dönen küme üzerinden istediğimiz kadar satırı ekrana yazdırmamızı sağlayacaktır.

            //Products tablosundaki ürünleri UnitPrice göre çoktan aza sıralayınız. İlk 5 ürününüID productName ünitprice,ünitinstock bilgilerini getirin

            dataGridView1.DataSource = db.Products
                .OrderByDescending(x => x.UnitPrice)
                .Select(x => new
                {
                    x.ProductID,
                    x.ProductName,
                    x.UnitPrice,
                    x.UnitsInStock,
                })
                .Take(5)
                .ToList();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Skip()=> Sorgu sonucunda dönen sonuç kümesi üzerinde, methodun parametresine verilen değer kadar satırı görmezden gelir.

            //Stokta en çok bulunan ürünlerimden 10 ile 20 arasındaki

            dataGridView1.DataSource = db.Products.OrderByDescending(x => x.UnitsInStock)
                .Select(x => new
                {
                    x.ProductID,
                    x.ProductName,
                    x.UnitPrice,
                    x.UnitsInStock
                })
                .Skip(10)
                .Take(10)
                .ToList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Contains:Belirili bir harf yada hece yada söz öbeğininin ilgili alanda yer alıp almadığını kontrol eder.Where methodu ile birlikte kullanılır. 
            //Çalışanlarımın isimleri içerisinde a harfi geçenleri listeyelim. ve 5 ile 10 arasındakileri alalım.
            dataGridView1.DataSource = db.Employees
                .Where(x => x.FirstName.Contains("a")).OrderBy(x => x.FirstName).Skip(5).Take(5)
                .ToList();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Any methodunun iki farlı kullanım şekli bulunmaktadır. 
            //ilk kullanım olan bir tabloda kayıt var mı yok mu bunun kontrol edebilirsiniz.
            //ikinci kullanımı ise tablodan verilen şartlara uygun kayıt var mı yok mu onu kontrol eder.
            //Any methodunun geri dönüş tipi boolean'dır.

            bool sonuc = db.Categories.Any(x => x.CategoryName == "SeaFood");
            MessageBox.Show(sonuc.ToString());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Count=> Sorgu sonucunda dönen satır sayısını bize sayar. int tipinde geri dönüş yapar

            int urunSayisi = db.Products.Count();
            MessageBox.Show($"Toplam Urun SAyısı{urunSayisi}");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //Sorgu sonucunda dönen sonuç kümesinde bizim belirttiğimiz sutündak, değerleri toplar

            int? stok = db.Products.Sum(x => x.UnitsInStock); //nullable (?) null olan değerler varsa onları katmaz
            MessageBox.Show($"Stok Durumu: {stok}");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Çalışanların yaşlarını hesaplayınız
            dataGridView1.DataSource = db.Employees.Select(x => new
            {
                Adi = x.FirstName,
                Soyadi = x.LastName,
                DogumTarihi = x.BirthDate,
                Yasi = SqlFunctions.DateDiff("Year", x.BirthDate, DateTime.Now)
            }).ToList();
        }
    }
}
