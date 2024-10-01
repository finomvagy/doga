using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doga
{
    
    public partial class Form1 : Form
    {
        dataBaseHandler database = new dataBaseHandler();
        bakery oneBakery = new bakery();
        bakery bk;
        public Form1()
        {
            InitializeComponent();
          
            updatelist();
            

            button1.Click += (s, e) =>
             {
                
                 database.readaAll();
                 listBox1.Items.Add("name" + textBox1.Text + "mennyiseg" + textBox2.Text + "ára" + textBox3.Text);
             
                 oneBakery.name = textBox1.Text;
                 oneBakery.db = Convert.ToInt32(textBox2.Text);
                 oneBakery.price = Convert.ToInt32(textBox3.Text);
                 database.Addone(oneBakery);
             };
            button2.Click += (s, e) =>
            {

                try
                {
                    if (listBox1.SelectedIndex > 0)
                    {
                        database.deleteOne(bakery.list[listBox1.SelectedIndex]);
                        listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    }
                   
                }
                catch (Exception a)
                {

                    MessageBox.Show(a.Message+"nem jo");
                }
              
               

            };
        }
        void updatelist()
        {
            listBox1.Items.Clear();
     
            database.readaAll();
            foreach (bakery item in bakery.list)
            {
                listBox1.Items.Add("name" + item.name + "mennyiseg" + item.db + "ára" + item.price);
            }

        }
    }
}
