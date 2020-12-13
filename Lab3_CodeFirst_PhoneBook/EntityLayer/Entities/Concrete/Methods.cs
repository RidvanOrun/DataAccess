using Lab3_CodeFirst_PhoneBook.DataAccessLayer.Context;
using Lab3_CodeFirst_PhoneBook.EntityLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_CodeFirst_PhoneBook.EntityLayer.Entities.Concrete
{
    public static class Methods
    {
        public static void Add(TextBox textBox, TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            AppUser appUser = new AppUser();
            ProjectContext db = new ProjectContext();

            appUser.FirstNAme = textBox.Text;
            appUser.LastName = textBox1.Text;
            appUser.PhoneNumber = textBox2.Text;
            appUser.City = textBox3.Text;
            appUser.Adress = textBox4.Text;
            appUser.CreateDate = DateTime.Now;
            db.AppUsers.Add(appUser);
            db.SaveChanges();

        }

        ///
        public static void ClearText(GroupBox groupBox)
        {
            foreach (Control item in groupBox.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

            }
        }

        ///
        public static void ListOfMember(DataGridView dataGridView)
        {
            ProjectContext db = new ProjectContext();
            dataGridView.DataSource = db.AppUsers.Where(x => x.Status != Status.Passive).ToList();

        }

        static int id;
        public static void updateMember(TextBox textBox, TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            AppUser appUser = new AppUser();
            ProjectContext db = new ProjectContext();
            appUser = db.AppUsers.FirstOrDefault(x => x.Id == id);

            appUser.FirstNAme = textBox.Text;
            appUser.LastName = textBox1.Text;
            appUser.PhoneNumber = textBox2.Text;
            appUser.City = textBox3.Text;
            appUser.Adress = textBox4.Text;

            db.SaveChanges();
            appUser.Status = Status.Modified;
            appUser.ModifiedDate = DateTime.Now;

        }

        public static void Choose(DataGridView dataGridView, TextBox textBox, TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
            textBox.Text = dataGridView.CurrentRow.Cells["FirstNAme"].Value.ToString();
            textBox1.Text = dataGridView.CurrentRow.Cells["LastName"].Value.ToString();
            textBox2.Text = dataGridView.CurrentRow.Cells["PhoneNumber"].Value.ToString();
            textBox3.Text = dataGridView.CurrentRow.Cells["City"].Value.ToString();
            textBox4.Text = dataGridView.CurrentRow.Cells["Adress"].Value.ToString();

        }
        public static void DeletedMember()
        {
            AppUser appUser = new AppUser();
            ProjectContext db = new ProjectContext();
            appUser = db.AppUsers.FirstOrDefault(x => x.Id == id);
            appUser.PassiveDate = DateTime.Now;
            appUser.Status = Status.Passive;
            db.SaveChanges();
        }
        public static void SearchMember(DataGridView dataGridView, TextBox textBox, TextBox textBox1, TextBox textBox2,TextBox textBox3)
        {
            ProjectContext db = new ProjectContext();
            dataGridView.DataSource = db.AppUsers.Where(x => x.FirstNAme == textBox.Text || x.LastName == textBox1.Text || x.PhoneNumber == textBox2.Text || x.City == textBox3.Text && x.Status == Status.Active).ToList();


        }

    }
}
