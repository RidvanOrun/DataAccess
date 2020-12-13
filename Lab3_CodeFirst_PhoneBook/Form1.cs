using Lab3_CodeFirst_PhoneBook.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_CodeFirst_PhoneBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Methods.SearchMember(dataGridView1, txtSearchFirstName, txtSearchLastName,txtSearchPhoneNumber, txtSearchCity);
            Methods.ClearText(gbxSearch);
        }

        private void btnAllMember_Click(object sender, EventArgs e)
        {
            Methods.ListOfMember(dataGridView1);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Methods.Add(txtAddFirstName, txtAddLastName, txtAddPhoneNumber, txtAddCity, txtAddAddress);
            Methods.ListOfMember(dataGridView1);
            MessageBox.Show(txtAddFirstName.Text + " " + txtAddLastName.Text + " : İsimli kullanıcı başarı ile eklendi ");
            Methods.ClearText(gbxAdd);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Methods.updateMember(txtUpdateFirstName, txtUpdateLastName, txtUpdatePhoneNumber, txtUpdateCity, txtUpdateAddres);
            Methods.ListOfMember(dataGridView1);
            MessageBox.Show(txtUpdateFirstName.Text + " " + txtUpdateLastName.Text + " : İsimli kullanıcı başarı ile güncellendi ");
            Methods.ClearText(gbxUpdate);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Methods.DeletedMember();
            Methods.ListOfMember(dataGridView1);
            MessageBox.Show(txtUpdateFirstName.Text + " " + txtUpdateLastName.Text + " : İsimli kullanıcı listeden kaldırıldı ");
            Methods.ClearText(gbxUpdate);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Methods.ListOfMember(dataGridView1);
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Methods.Choose(dataGridView1, txtUpdateFirstName, txtUpdateLastName, txtUpdatePhoneNumber, txtUpdateCity, txtUpdateAddres);
        }
    }
}
