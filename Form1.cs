using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
//using Microsoft.VisualBasic.Interaction;
using System.Windows.Forms;
using TestWindowsApp.Source;

namespace TestWindowsApp
{
    public partial class Form1 : Form
    {
        public Game game = new Game();
        public List<Form> consoles = new List<Form>();
        public Form1()
        {
            InitializeComponent();
            Rectangle screen = Screen.FromControl(this).Bounds;
            Top = screen.Height - this.Height - 40;
            Left = screen.Width - this.Width - 10;
            Text = "Plump - antagligen världens bästa kortspel";

        }

        private void AddPlayerBtn_Click(object sender, EventArgs e)
        {
            label1.Text = "You push " + (sender as Button).Text; // ToString();

            string name = txtName.Text;
            //MessageBox.Show("Enter name:", "Add player");

            AddPlayer(name, chbVirtual.Checked);
        }

        private void AddPlayer(string name, bool bVirtual)
        {

            Player player = (!bVirtual) ? game.AddPlayer(name) : game.AddVirtualPlayer(name);

            if (player == null)
            {
                label1.Text = game.szError;
            }
            else
            {
                PlayersConsoleForm aCons = new PlayersConsoleForm();
                consoles.Add(aCons);
                aCons.SetPlayer(player);
                player.PlayerUpdateGUI += aCons.c_UpdateGUI;
                player.PlayerRemove += game.c_RemovePlayer;
                if (player.IsVirtualPlayer())
                {
                    player.PlayerPlayCard += aCons.c_PlayerPlayCard;
                    player.PlayerSetStick += aCons.c_PlayerSetStick;
                }

                Rectangle screen = Screen.FromControl(this).Bounds;
                aCons.Left = 10 + ((10 + aCons.Width) * (game.players.Count() - 1));
                aCons.Top = screen.Top;

                if (aCons.Left > (screen.Left + screen.Width - 20))
                {
                    aCons.Left = 10 * game.players.Count();
                    aCons.Top = screen.Top + aCons.Height;
                }
                aCons.Show();


                aCons.PlayerHavePlayACard += c_SelectedPlayerPlayedCard;
                aCons.PlayerHaveSetSticksToWin += c_SelectedPlayerSetSticksToWin;
            }

        }

        void c_SelectedPlayerSetSticksToWin(object sender, EventArgs e)
        {
            if (sender is PlayersConsoleForm)
            {
                Player player = (sender as PlayersConsoleForm).player;
                label1.Text = player.name + " Sticks: " + player.stickToWin.ToString();
                AddTextToTextBox(label1.Text);
                if (game.SetStick(player))
                {
                    Player start = game.GetStartPlayer();
                    AddTextToTextBox("Startplayer are: " + start.name);
                    game.StartRound(start);
                }
                else
                {
                    game.AutomaticSetStick();
                }
            }
        }

        void c_SelectedPlayerPlayedCard(object sender, EventArgs e)
        {
            if (sender is PlayersConsoleForm)
            {
                Player player = (sender as PlayersConsoleForm).player;
                AddTextToTextBox(player.name + ": " + player.selected.ToString());
                Player winnerOfRound = game.Play(player);

                string szToBeat = game.GetCardToBeatInfo();
                string szCardToBeat = (szToBeat == "") ? player.selected.ToString() : szToBeat;
                label1.Text = "Card to beat:  " + szCardToBeat;
                if (game.cardToBeat != null)
                {
                    picBoxCardToBeat.Image = game.cardToBeat.image;
                }
                if (winnerOfRound != null)
                {
                    winnerOfRound.AddStick();
                    //winner.AddPoints(1);
                    winnerOfRound.UpdateGUI(e);
                    if (!game.IsDealOver())
                    {
                        AddTextToTextBox("next round!");
                        label1.Text = "";
                        picBoxCardToBeat.Image = null;
                        game.StartRound(winnerOfRound);
                        AddTextToTextBox(winnerOfRound.name + ": to play card first!");
                    }
                    else
                    {
                        game.SetPoints();
                        foreach (Player pl in game.players)
                        {
                            string points = pl.name + ": pt. " + pl.points.ToString();
                            listBox1.Items.Add(points);
                        }
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                        if (game.IsGameOver())
                        {
                            var winnerOfGame = game.GetWinner();
                            label1.Text = "Winner is: " + ((winnerOfGame!=null) ? winnerOfGame.name : "no winner");
                            game.PrepareFornewGame();
                        }
                        else
                        {
                            label1.Text = "new round!";

                        }
                        picBoxCardToBeat.Image = null;
                        btnStart.Enabled = true;
                        game.UpdateUI();
                    }
                }
                if (!game.IsDealOver())
                {
                    game.AutomaticPlay();
                }
            }
            else
            {
                label1.Text = "The console was calling.";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //AddPlayer("Computer", true); //Virtual playeer!!
            listBox1.Items.Add("New deal!");
            textBox1.Text = "";

            game.SetCardsPerPlayer();
            var firstBetter = game.SetFirstBetter();
            game.Deal();
            foreach (var console in consoles)
            {
                (console as PlayersConsoleForm).ShowCard();
                (console as PlayersConsoleForm).SetBet();
            }
            btnStart.Enabled = false;
            AddTextToTextBox(firstBetter.name + " to set first bet!");
            game.UpdateUI();

        }

        private void AddTextToTextBox(string szText)
        {
            textBox1.Text = textBox1.Text + "\r\n" + szText;
            moveToEnd();
        }

        private void moveToEnd()
        {
            textBox1.Select(textBox1.Text.Length, 0);
            textBox1.Focus();
            textBox1.ScrollToCaret();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //if Jag not exist
            bool bJagExist = false;
            foreach (var player in game.players)
            {
                bJagExist = player.name == "Jag";
                if (bJagExist)
                {
                    break;
                }
            }
            if (!bJagExist)
            {
                AddPlayer("Jag", false);
            }
            for (int i = 0; i < 3; i++)
            {
                string name = "PC" + game.players.Count().ToString();
                AddPlayer(name, true);
            }

            //AddPlayer("PC1", true);
            //AddPlayer("PC2", true);
        }

    }
}
