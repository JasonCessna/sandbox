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
        bool isLocked = true; //IF START BUTTON HASN'T BEEN PUSHED, BUTTONS ARE NOT PLAYABLE
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
            if (isLocked == false)
            {
                if (turn)                //check player's turn
                {
                    b.Text = "X";        //change box's text
                    b.BackColor = System.Drawing.Color.SlateBlue;
                }
                else
                {
                    b.Text = "O";        //change box's text
                    b.BackColor = System.Drawing.Color.YellowGreen;
                }

                turn = !turn;           //change turn
                b.Enabled = false;      //turn button off
                checkForWinner();       //check rows, columns, and diagonals
            }
            else MessageBox.Show("Press \"START\" to begin!");
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
            bool isDraw = false;   //IF isDraw == TRUE, GAME IS A TIE
            String typeOfWin = "";
            

            isRow = Row();
            isVert = Vert();
            isDiag = Diag();
            isDraw = Draw();

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
            //check diagonals
            else if (isDiag)
            {
                isWinner = true;
                typeOfWin = "diagonal";
            }
             else if (isDraw)
             {
                 MessageBox.Show("Game ended in a draw.");
             }
            turnCount++;
            if (isWinner)
            {
                DisableButtons(this);
                String winner = "";
                
                if (turn)           //CHECK TURN: IF TURN = O, WINNER = X ELSE WINNER = O
                    winner = "O";
                else
                    winner = "X";
                turnCount = (turnCount / 2);
                MessageBox.Show(winner + " wins with 4-in-a-" + typeOfWin + " in " + turnCount + " moves!");
              
            }

        }

        protected void DisableButtons(Control root)  //BUG FIXED 8/28/15 (WAS TRYING TO CHANGE EVERY CONTROL, NOT JUST BUTTONS) -Jason
        {
            foreach (Control ctrl in root.Controls)
            {
                if (ctrl is Button)
                {
                    ((Control)ctrl).Enabled = false;
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        DisableButtons(ctrl);                           //RECURSIVELY CALL FUNCTION UNTIL ALL BUTTONS ARE DISABLED
                    }
                }
            }
        }


        protected void EnableButtons(Control root) //use with File -> New
        {
            int btnCounter = 1;
            foreach (Control ctrl in root.Controls)
            {
                if (ctrl is Button)
                {
                    ((Control)ctrl).Enabled = true;  
                    if (((Control)ctrl).Text == "PLAYING!")         //CHECK FOR START BUTTON
                    {
                        ((Control)ctrl).Text = "START";             //REVERT TEXT BACK TO START
                        ((Control)ctrl).BackColor = Color.Lime;     //REVERT START BUTTON COLOR
                    }
                    else if (((Control)ctrl).Text == "START") { }  //IF ACTIVE START BUTTON, DO NOTHING
                    else if (btnCounter % 2 == 0)
                    {
                        ((Control)ctrl).Text = "\\" + (Char)btnCounter;  //CHANGE TEXT TO PREVIOUS BACK-TEXT
                        ((Control)ctrl).BackColor = Color.Silver;        //REVERT BUTTON COLOR
                    }
                    else
                    {
                        ((Control)ctrl).Text = "/ " + (Char)btnCounter;  //CHANGE TEXT TO PREVIOUS BACK-TEXT
                        ((Control)ctrl).BackColor = Color.Silver;        //REVERT BUTTON COLOR
                    }
                    btnCounter++;                                        //KEEP BUTTON COUNTER IN ORDER TO FORCE ALL
                }                                                        //TEXT TO BE DIFFERENT ON EVERY BUTTON
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        EnableButtons(ctrl);                            //RECURSIVELY CALL FUNCTION UNTIL ALL BUTTONS ARE ENABLED
                    }
                }
            }
        }


       
        private bool Row()
        {                   ///BUG HERE: All buttons starting with a null text field makes this a win every turn?  //BUG FIXED 8/28/15 -Jason
            if      (a1.Text == a2.Text && a2.Text == a3.Text && a3.Text == a4.Text)
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
            if      (a1.Text == b1.Text && b1.Text == c1.Text && c1.Text == d1.Text)
                return true;
            else if (e1.Text == b1.Text && b1.Text == c1.Text && c1.Text == d1.Text)
                return true;
            else if (a2.Text == b2.Text && b2.Text == c2.Text && c2.Text == d2.Text)
                return true;
            else if (e2.Text == b2.Text && b2.Text == c2.Text && c2.Text == d2.Text)
                return true;
            else if (a3.Text == b3.Text && b3.Text == c3.Text && c3.Text == d3.Text)
                return true;
            else if (e3.Text == b3.Text && b3.Text == c3.Text && c3.Text == d3.Text)
                return true;
            else if (a4.Text == b4.Text && b4.Text == c4.Text && c4.Text == d4.Text)
                return true;
            else if (e4.Text == b4.Text && b4.Text == c4.Text && c4.Text == d4.Text)
                return true;
            else if (a5.Text == b5.Text && b5.Text == c5.Text && c5.Text == d5.Text)
                return true;
            else if (e5.Text == b5.Text && b5.Text == c5.Text && c5.Text == d5.Text)
                return true;
            else
                return false;
        }
        private bool Diag()
        {
            if      (a1.Text == b2.Text && b2.Text == c3.Text && c3.Text == d4.Text)
                return true;//
            else if (e5.Text == b2.Text && b2.Text == c3.Text && c3.Text == d4.Text)
                return true;//
            else if (a5.Text == b4.Text && b4.Text == c3.Text && c3.Text == d2.Text)
                return true;//
            else if (e1.Text == b4.Text && b4.Text == c3.Text && c3.Text == d2.Text)
                return true;//
            else if (b1.Text == c2.Text && c2.Text == d3.Text && d3.Text == e4.Text)
                return true;//
            else if (a2.Text == b3.Text && b3.Text == c4.Text && c4.Text == d5.Text)
                return true;//
            else if (a4.Text == b3.Text && b3.Text == c2.Text && c2.Text == d1.Text)
                return true;//
            else if (b5.Text == c4.Text && c4.Text == d3.Text && d3.Text == e2.Text)
                return true;//
            return false;
        }
        private bool Draw() //check the whole board to determine if all the buttons where clicked in order to 
        {
            if    (a1.Enabled != true && a2.Enabled != true && a3.Enabled != true && a4.Enabled != true && a5.Enabled != true
                && b1.Enabled != true && b2.Enabled != true && b3.Enabled != true && b4.Enabled != true && b5.Enabled != true
                && c1.Enabled != true && c2.Enabled != true && c3.Enabled != true && c4.Enabled != true && c5.Enabled != true
                && d1.Enabled != true && d2.Enabled != true && d3.Enabled != true && d4.Enabled != true && d5.Enabled != true
                && e1.Enabled != true && e2.Enabled != true && e3.Enabled != true && e4.Enabled != true && e5.Enabled != true)
                return true;

            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }
       

        //MENU ON-CLICK HANDLERS
        //FILE - NEW
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableButtons(this);
            //Needs a reset score function. 
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

        private void startButton_Click(object sender, EventArgs e)
        {
            isLocked = false; //unlock the board
            startButton.Enabled = false; //make start button no longer clickable
            startButton.Text = "PLAYING!"; //change text to playing
            startButton.ForeColor = Color.SteelBlue;
            turnCount = 0;
            turn = true;
        }
        
    }
}
