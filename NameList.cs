using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class NameList : Form
    {
        static String playerName = "";
        
        public NameList()
        {
            InitializeComponent();
            nameListBox.SetSelected(0, true);
        }
        public static string getName()
        {
            return playerName;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            playerName = nameListBox.SelectedItem.ToString();
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
   
             if (nameListBox.Items.Count > 50)
                MessageBox.Show("Error: Too many names in the list");
            else
            {
                if (nameListBox.Items.Contains(txtBox.Text))
                    MessageBox.Show("Cannot add the same name twice.");
                else
                    nameListBox.Items.Add(txtBox.Text);
            }
        }
    }
}
