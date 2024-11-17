using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B07CSHarp11_W01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Doctor> listdoctors=new List<Doctor>();
        private void btnGet_Click(object sender, EventArgs e)
        {
          Doctor doctor = new Doctor();
            doctor.Name=txtName.Text;
            doctor.Id=int.Parse( this.txtId.Text);
            doctor.Address=txtAddress.Text;
            doctor.Contact=txtContact.Text;
            doctor.Email = this.txtEMail.Text;
            if(listdoctors.Any(a=>a.Id==doctor.Id))
            {
                MessageBox.Show($"{doctor.Id} already exist.");
            }
            else
            {
                listdoctors.Add(doctor);
                LoadData();
                ClearControl();
            }
            

           
            //MessageBox.Show($"Your Company Name is {this.txtName.Text}","Your Name",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);

        }
        private void LoadData()
        {
            this.dataGridView1.DataSource = null;
         this.dataGridView1.DataSource = listdoctors;
            this.dataGridView1.Refresh();


        }
        int selectedindex;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedindex = this.dataGridView1.Rows[e.RowIndex].Index;
           
        }
        private void ClearControl()
        {
            txtName.Text="";
              this.txtId.Text="";
          txtAddress.Text  = "";
          txtContact.Text = "";
            this.txtEMail.Text = "";

        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            listdoctors.RemoveAt(selectedindex);
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = listdoctors;
            this.dataGridView1.Refresh();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void dataGridView1_DpiChangedAfterParent(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            selectedindex = this.dataGridView1.SelectedRows[0].Index;
            var selectedItem = dataGridView1.SelectedRows;
           this.txtName.Text = selectedItem[0].Cells[0].Value.ToString();
          this.txtId.Text = selectedItem[0].Cells[1].Value.ToString();
            this.txtEMail.Text = selectedItem[0].Cells[2].Value.ToString();
            this.txtAddress.Text = selectedItem[0].Cells[3].Value.ToString();
            this.txtContact.Text = selectedItem[0].Cells[4].Value.ToString();
            this.txtId.Enabled = false;
            this.btnUpdate.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id =int.Parse( this.txtId.Text);
           var doctor= this.listdoctors.Find(d=>d.Id== id);
            doctor.Name=this.txtName.Text;
            doctor.Email = this.txtAddress.Text;
            doctor.Contact= this.txtContact.Text;
            doctor.Address= this.txtAddress.Text;
            doctor.Id= id;
            listdoctors.RemoveAt(selectedindex);
            listdoctors.Insert(selectedindex,doctor);
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = listdoctors;
            this.dataGridView1.Refresh();

        }
    }
}
