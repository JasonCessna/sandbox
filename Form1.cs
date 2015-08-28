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
    public partial class Form1 : Form
    {          
            //declare booleans
            bool isLocked = false; //IF BUTTON IS ALREADY X
            bool isThreat = false; //IF DEFENSIVE THREAT IS GREATER THAN OFFENSIVE OPPORTUNITY
            bool turn = true; //TRUE == X TURN; FALSE == O TURN
            int turnCount = 0;


        public Form1()
        {
            InitializeComponent();      
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
           
            if (turn)                //check player's turn
                b.Text = "X";        //change box's text
            else
                b.Text = "O";        //change box's text
               
            turn = !turn;           //change turn
            b.Enabled = false;      //turn button off
            checkForWinner();       //check rows, columns, and diagnols
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////UPDATE BELOW/////////////////////////////////////////////////////////////////////////////
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private void checkForWinner()
        {
            bool isWinner = false; //IF isWinner == TRUE GAME ENDS
            bool isRow = false;    //IF isRow == TRUE, GAME WON BY ROW
            bool isVert = false;   //IF isVert == TRUE, GAME WON BY COLUMN
            bool isDiag = false;   //IF isDiag == TRUE, GAME WON BY DIAGNOL
            String typeOfWin = "";
            

            isRow = Row();
            isVert = Vert();
            isDiag = Diag();
            //isVert = true;
            //check rows
             if (isRow)
            {   
                isWinner = true;
                typeOfWin = "row";
            }
            //check columns
            else if (isVert)
            {
                isWinner = true;
                typeOfWin = "column";
            }
            //check diagnols
            else if (isDiag)
            {
                isWinner = true;
                typeOfWin = "diagnol";
            }
            turnCount++;
            if (isWinner)
            {
                disableButtons();
                String winner = "";
                
                if (turn)           //CHECK TURN: IF TURN = O, WINNER = X ELSE WINNER = O
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show(winner + " wins with 4-in-a-" + typeOfWin + " in " + turnCount + " moves!");
              
            }

        }
 /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private void disableButtons()  //BUG?
        {
           try
           {
                    foreach (Control c in Controls)
                    {
                      Button b = (Button)c;
                      b.Enabled = false;
                    }
           }
            catch { //MessageBox.Show("Error.");
            }
        }

        /////
        private bool Row()
        {                   ///BUG HERE: All buttons starting with a null text field makes this a win every turn?
            if (a1.Text == a2.Text && a2.Text == a3.Text && a3.Text == a4.Text)
                return true;
            else if (a5.Text == a2.Text && a2.Text == a3.Text && a3.Text == a4.Text)
                return true;
            else if (b1.Text == b2.Text && b2.Text == b3.Text && b3.Text == b4.Text)
                return true;
            else if (b5.Text == b2.Text && b2.Text == b3.Text && b3.Text == b4.Text)
                return true;
            else if (c1.Text == c2.Text && c2.Text == c3.Text && c3.Text == c4.Text)
                return true;
            else if (c5.Text == c2.Text && c2.Text == c3.Text && c3.Text == c4.Text)
                return true;
            else if (d1.Text == d2.Text && d2.Text == d3.Text && d3.Text == d4.Text)
                return true;
            else if (d5.Text == d2.Text && d2.Text == d3.Text && d3.Text == d4.Text)
                return true;
            else if (e1.Text == e2.Text && e2.Text == e3.Text && e3.Text == e4.Text)
                return true;
            else if (e5.Text == e2.Text && e2.Text == e3.Text && e3.Text == e4.Text)
                return true;
            else
            return false;
        }
        private bool Vert()
        {
            return false;
        }
        private bool Diag()
        {
            return false;
        }
        private bool isDraw()
        {
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }
       

        //MENU ON-CLICK HANDLERS
        //FILE - NEW
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //FILE - QUIT
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //HELP - HOW TO PLAY
        private void howToPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //HELP - ABOUT
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Team Name: Tic Tac Shenanigans\nTeam Members/Roles:\nJose Fidel Huertero- SQA\nMir Abutaiab- SQA\n" + 
            "Ana Segura- Secretary\nJason Cessna- Team Lead\nLuis Gonzalez- SQA", "Tic Tac Toe - Shenanigans");
        }
        //DIFFICULTY - PvP
        private void playerVsPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //DIFFICULTY - PvEasy
        private void playerVsAIEasyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //DIFFICULTY - PvMedium
        private void playerVsAIMediumToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //DIFFICULTY - PvHard
        private void playerVsAIHardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //SCORE - PvP
        private void pvPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //SCORE - PvEasy
        private void vsEasyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //SCORE - PvMedium
        private void vsMediumToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //SCORE - PvHard
        private void vsHardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}
