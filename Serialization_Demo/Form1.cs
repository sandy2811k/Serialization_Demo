using System;
using System.Windows.Forms;
//Binary 
using System.Runtime.Serialization.Formatters.Binary;
//XML
using System.Xml.Serialization;
//SOAP
using System.Runtime.Serialization.Formatters.Soap;
//JSON
using System.Text.Json;
//File
using System.IO;

namespace Serialization_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1-store data in the object
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtid.Text);
                employee.Name = txtName.Text;
                employee.Salary=Convert.ToDouble(txtSalary.Text);
                //Step 2
                FileStream fs=new FileStream(@"D:\emp.dat", FileMode.Create, FileAccess.Write);
                //Step 3
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                //Step 1
                FileStream fs = new FileStream(@"D:\emp.dat", FileMode.Open, FileAccess.Read);
                //Step 2
                BinaryFormatter bf = new BinaryFormatter();
                Employee employee = new Employee();
                employee=(Employee)bf.Deserialize(fs);
                //Step 3
                txtid.Text=employee.Id.ToString();
                txtName.Text = employee.Name; 
                txtSalary.Text=employee.Salary.ToString();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXMLWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1-store data in the object
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtid.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);
                //Step 2
                FileStream fs = new FileStream(@"D:\emp.xml", FileMode.Create, FileAccess.Write);
                //Step 3
                XmlSerializer xserializer = new XmlSerializer(typeof(Employee));
                xserializer.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXMLRead_Click(object sender, EventArgs e)
        {
            try
            {
                //Step 1
                FileStream fs = new FileStream(@"D:\emp.xml", FileMode.Open, FileAccess.Read);
                //Step 2
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
                Employee employee = new Employee();
                employee = (Employee)xmlSerializer.Deserialize(fs);
                //Step 3
                txtid.Text = employee.Id.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSOAPWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1-store data in the object
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtid.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);
                //Step 2
                FileStream fs = new FileStream(@"D:\emp.soap", FileMode.Create, FileAccess.Write);
                //Step 3
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSOAPRead_Click(object sender, EventArgs e)
        {
            try
            {
                //Step 1
                FileStream fs = new FileStream(@"D:\emp.soap", FileMode.Open, FileAccess.Read);
                //Step 2
                SoapFormatter soapFormatter = new SoapFormatter();
                Employee employee = new Employee();
                employee = (Employee)soapFormatter.Deserialize(fs);
                //Step 3
                txtid.Text = employee.Id.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJOSNWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1-store data in the object
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtid.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);
                //Step 2
                FileStream fs = new FileStream(@"D:\emp.json", FileMode.Create, FileAccess.Write);
                //Step 3
                JsonSerializer.Serialize<Employee>(fs, employee);
                fs.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnJOSNRead_Click(object sender, EventArgs e)
        {
            try
            {
                //Step 1
                FileStream fs = new FileStream(@"D:\emp.json", FileMode.Open, FileAccess.Read);
                //Step 2
                SoapFormatter soapFormatter = new SoapFormatter();
                Employee employee = new Employee();
                employee = JsonSerializer.Deserialize<Employee>(fs);
                //Step 3
                txtid.Text = employee.Id.ToString();
                txtName.Text = employee.Name;      
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

       
    }
}
