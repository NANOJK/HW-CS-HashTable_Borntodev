using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HashTable_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Hashtable hashtable;
        public MainWindow()
        {
            InitializeComponent();
            hashtable = new Hashtable();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            //Add

            //Observe for blank
            if (Key.Text == "")
            {
                MessageBox.Show("Please Insert Key !!!");
            } 
            else if (Value.Text == "") 
            {
                MessageBox.Show("Please Insert Value !!!");
            } 
            else if (Key.Text == "" && Value.Text == "")
            {
                MessageBox.Show("Please Insert Key and Value !!!");
            }
            else
            {
                //Observe for *
                if (Key.Text == "*")
                {
                    MessageBox.Show("* is Keyword, Cannot insert *");
                    Key.Text = "";
                    Value.Text = "";
                } else {
                    //SameKeyDetection
                    if (hashtable.Contains(Key.Text) == true)
                    {
                        MessageBox.Show("This Key already has in HashTable !!! Please Insert New Key");
                        Key.Text = "";
                        Value.Text = "";
                    }
                    else
                    {
                        //Add
                        hashtable.Add(Key.Text, Value.Text);
                        MessageBox.Show("Add Complete !!!");
                        Key.Text = "";
                        Value.Text = "";
                    }
                }
            }
        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            //Remove

            //Observe for blank
            if (Key.Text == "")
            {
                MessageBox.Show("Please Insert Key !!!");
            }
            else
            {
                //Observe for *
                if (Key.Text == "*")
                {
                    hashtable.Clear();
                    MessageBox.Show("Remove All Complete !!!");
                    Key.Text = "";
                    Value.Text = "";
                }
                else
                {
                    //IncoorectKeyDetection
                    if (hashtable.Contains(Key.Text) == false)
                    {
                        MessageBox.Show("This Key doesn't has in HashTable !!! Please Insert New Key");
                        Key.Text = "";
                        Value.Text = "";
                    }
                    else
                    {
                        //Remove
                        hashtable.Remove(Key.Text);
                        MessageBox.Show("Remove Complete !!!");
                        Key.Text = "";
                        Value.Text = "";
                    }
                }
            }
        }

        private void Button_Click_ShowAll(object sender, RoutedEventArgs e)
        {
            //ShowAll

            ICollection icollection = hashtable.Keys;
            StringBuilder stringBuilder = new StringBuilder();

            //NotHaveAnyData
            if (hashtable.Keys.Count == 0)
            {
                Output.Text = "";
                MessageBox.Show("Not have any Data in HashTable !!! Please Add Key and Value");
            }
            else
            {
                //Show
                foreach (string key in icollection)
                {
                    stringBuilder = stringBuilder.Append(key + " - " + hashtable[key].ToString() + " , ");
                    Output.Text = stringBuilder.ToString();
                }

                string finalOutput = Output.Text.Substring(0, Output.Text.Length - 2);

                Output.Text = finalOutput;
            }
        }
    }
}
