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

namespace REPRECORD_HACKLYTICS
{
    public partial class Form1 : Form
    {
        List<GymUser> Users = new List<GymUser>();

        public Form1()
        {
            InitializeComponent();


        }

        public void LoadDetails()
        {
            String Header = "Name".PadRight(17) + "\t" + "\t" + "Age" + "\t" + "\t" + "Weight" + "\t" + "\t" + "PR Bench Press" + "\t" + "\t" + "PR Squats" + "\t" + "\t" + "PR Cardio";
            OutputListBox.Items.Add(Header);

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
                
        }

        private void SaveDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                using(StreamWriter writes= new StreamWriter())
                {
                    string limit = ",";
                    string Headers = "Name,Age,Weight,PRBENCHPRESS,PRCSQUAT,PRCARDIO";
                    writes.WriteLine(Headers);

                    foreach(GymUser user in Users) { 
                    
                    writes.WriteLine(user)
                    
                            }
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BringDataToScreenButton_Click(object sender, EventArgs e)
        {
            LoadDetails();

            try
            {
                using (StreamReader reads = new StreamReader("gymusers.csv"))
                {
                    string Endofline;

                    if (!reads.EndOfStream)
                    {
                       Endofline= reads.ReadLine();

                    }

                    while (!reads.EndOfStream)
                    {
                        Endofline= reads.ReadLine();

                        string[]arrs= Endofline.Split(',');
                        string Name = arrs[0];
                        string Age = arrs[1];
                        int.TryParse(Age, out int age);
                        string Weight= arrs[2];
                        int.TryParse(Weight, out int weight);   
                        string prbp = arrs[3];
                        int.TryParse(prbp, out int PRbp);
                        string prsq = arrs[4];
                        int.TryParse(prsq, out int PRsq);
                        string cardiopr = arrs[5];
                        int.TryParse(cardiopr, out int Carpr);

                        GymUser users = new GymUser(Name, age, weight, PRbp, PRsq, Carpr);

                        Users.Add(users);
                        OutputListBox.Items.Add(users);

                    }


                }
              

            }catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void ChangeNameButton_Click(object sender, EventArgs e)
        {
            int lbindex = OutputListBox.SelectedIndex;

            if (lbindex == 0)
            {
                MessageBox.Show("Please Choose a value other than header");

            }


            else if (lbindex < 0)
            {
                MessageBox.Show("please choose some value");
            }

           else if(lbindex > 0)
            {

                if (NameTextBox.Text == "")
                {
                    MessageBox.Show("Please Enter A Value, this cannot be empty");
                } 

            }

            else
            {
                // STILL UNDER DEVELOPMENT
                

            }

        }

        private void DeleteDataButton_Click(object sender, EventArgs e)
        {
            int lbindex = OutputListBox.SelectedIndex;

            if (lbindex< 0)
            {
                MessageBox.Show("Please choose a valid value");

            }

            else if (lbindex == 0)
            {
                MessageBox.Show("Please select a valid option");
            }

            else if (lbindex > 0)
            {
                Users.RemoveAt(lbindex - 1);
                OutputListBox.Items.RemoveAt(lbindex);
            }
        }
    }
}
