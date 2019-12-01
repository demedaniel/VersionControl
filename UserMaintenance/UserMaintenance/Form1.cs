using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource1.LastName; // label1

            btnAdd.Text = Resource1.Add; // button1
            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
            button1.Text = Resource1.Add_to_File; //button2
            button2.Text = Resource1.Delete;//button3
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtLastName.Text,
              
            };
            users.Add(u);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = Application.StartupPath;
            sf.Filter = "Comma Separated values (*.txt)|*.txt";
            sf.DefaultExt = "txt";
            sf.AddExtension = true;
            if (sf.ShowDialog() != DialogResult.OK) return;
            using (StreamWriter sw= new StreamWriter(sf.FileName, false,  Encoding.UTF8))
            {
                foreach (var u in users )
                {
                    sw.Write(u.FullName);
                    sw.Write(";");
                    sw.Write(value: u.ID);
                    sw.WriteLine();
                }
            }
            

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var torol = (User)listUsers.SelectedItem;
            users.Remove(torol);
        }
    }
}
