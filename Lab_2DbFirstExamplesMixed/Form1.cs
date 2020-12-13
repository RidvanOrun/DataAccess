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

namespace Lab_2DbFirstExamplesMixed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NorthwindEntities db = new NorthwindEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            //Çalışanların isim , soyisim, ünvan, doğum tarihi bilgilerini getiren linq to entitiy ve linq to sql sorgularını yazınız.

            dataGridView1.DataSource = db.Employees.Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Title,
                x.BirthDate,
            }).ToList();

            //Linq to sql sorguları; 
            var result = from emp in db.Employees
                         select new
                         {
                             emp.FirstName,
                             emp.LastName,
                             emp.Title,
                             emp.BirthDate
                         };
            dataGridView1.DataSource = result.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //çalışanların ıd si 2 ve 8 arasında olanların A'dan Z'ye sıralayarak Id, Ad, Soyadını TitleOfCurtisy

            dataGridView1.DataSource = db.Employees.Where(x => x.EmployeeID > 2 && x.EmployeeID < 8).OrderBy(x => x.FirstName).Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Title,
                x.BirthDate,
            }).ToList();

            //Linq to Sql
            var result = from Empl in db.Employees
                         where Empl.EmployeeID > 2 && Empl.EmployeeID < 8
                         orderby Empl.FirstName
                         select new
                         {
                             Empl.EmployeeID,
                             Empl.FirstName,
                             Empl.LastName,
                             Empl.TitleOfCourtesy
                         };
            dataGridView1.DataSource = result.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //1960 yılında doğan çalışanların adı,soyadı, doğum tarihi
            dataGridView1.DataSource = db.Employees.Where(x => SqlFunctions.DatePart("Year", x.BirthDate) == 1960).Select(x => new
            {
                x.FirstName,
                x.LastName,
                BirthYear = SqlFunctions.DatePart("Year", x.BirthDate)
            }).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //60 yaşından büyük olan çalışanların Adı, Soyadını , Doğum tarihini, A'dan Z'ye sıralayınız
            dataGridView1.DataSource = db.Employees.Where(x => SqlFunctions.DateDiff("Year", x.BirthDate, DateTime.Now) > 60).OrderBy(x => x.LastName).Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.BirthDate
            }).ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Doğum tarihi 1930 ile 1960 arasında olan ve USA'da oturan çalışanların listesini getiriniz
            dataGridView1.DataSource = db.Employees
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    Date = SqlFunctions.DatePart("Year", x.BirthDate),
                    Title = x.TitleOfCourtesy,
                    Country = x.Country,
                    Age = SqlFunctions.DateDiff("Year", x.BirthDate, DateTime.Now),
                    Picture = x.Photo
                }).Where(x => x.Date >= 1930 && x.Date <= 1960 && x.Country.Contains("USA")).ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Kategorilerime göre stok durum nasıl?
            dataGridView1.DataSource = db.Categories
                .Join(db.Products,
                c => c.CategoryID,
                p => p.CategoryID,
                (c, p) => new { c, p })
                .GroupBy(x => x.c.CategoryName)
                .Select(x => new
                {
                    Name = x.Key,
                    Count = x.Sum(z => z.p.UnitsInStock)
                }).ToList();
        }
    }
}
