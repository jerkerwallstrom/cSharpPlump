using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestWindowsApp.Source
{
    public partial class PlayersConsoleForm : Form
    {
        public Player player;
        public bool bTest = true;
        private List<PictureBox> pictures = new List<PictureBox>();
        public PlayersConsoleForm()
        {
            InitializeComponent();
        }

        internal void SetPlayer(Player aPlayer)
        {
            player = aPlayer;
            Text = "Player: " + player.name;
            //throw new NotImplementedException();
            if (!bTest)
            {
                listBox1.Visible = !aPlayer.IsVirtualPlayer();
            }

        }
        internal void c_UpdateGUI(object sender, EventArgs e)
        {
            ShowCard();
        }

        internal void c_PlayerSetStick(object sender, EventArgs e)
        {
            VirtualSetStick();
        }

        private void VirtualSetStick()
        {
            if (player.IsVirtualPlayer())
            {
                if (player.IsDriver())
                {
                    if (player.betRound)
                    {
                        btnBet_Click(this, null);
                    }
                }
            }
        }

        internal void c_PlayerPlayCard(object sender, EventArgs e)
        {
            VirtualPlayCard();
        }

        private void VirtualPlayCard()
        {
            if (player.IsVirtualPlayer())
            {
                if (player.IsDriver())
                {
                    btnPlayCard_Click(this, null);
                }
            }
        }

        internal void ShowCard()
        {
            ClearPictures();
            listBox1.Items.Clear();
            int i = 0;
            foreach (Card card in player.cards)
            {
                pictures[i].Image = card.image;
                listBox1.Items.Add(card);
                i++;
            }
            lblSticksValue.Text = player.sticks.ToString();
            lblPointsValue.Text = player.points.ToString();
            btnPlayCard.Enabled = player.IsDriver() && !player.betRound;
            btnBet.Enabled = player.IsDriver() && player.betRound;
            lblStickBet.Text = player.stickToWin.ToString();
        }

        private void ClearPictures()
        {
            pictures.Clear();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
            pictureBox10.Image = null;
            pictures.Add(pictureBox1);
            pictures.Add(pictureBox2);
            pictures.Add(pictureBox3);
            pictures.Add(pictureBox4);
            pictures.Add(pictureBox5);
            pictures.Add(pictureBox6);
            pictures.Add(pictureBox7);
            pictures.Add(pictureBox8);
            pictures.Add(pictureBox9);
            pictures.Add(pictureBox10);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            if (!player.IsVirtualPlayer())
            {
                if (int.TryParse(txtBet.Text, out int sticksToWin))
                {
                    SetBet(sticksToWin);
                }
            }
            else
            {
                SetBet(-1);
            }
        }

        private void SetBet(int sticksToWin)
        {
            if (!player.IsVirtualPlayer())
            {
                player.SetStickToWin(sticksToWin);
                lblStickBet.Text = player.stickToWin.ToString();
            }
            else
            {
                txtBet.Text = player.stickToWin.ToString();
                lblStickBet.Text = player.stickToWin.ToString();
            }
            player.SetStickToWin(player.stickToWin);
            OnPlayerSetSticksToWin(null);
            ShowCard();

        }

        private void btnPlayCard_Click(object sender, EventArgs e)
        {
            Card card = listBox1.SelectedItem as Card;
            PlaySelectedCard(card);
        }
        private void PlaySelectedCard(Card card)
        {
            bool bOK = true;
            if (!player.IsVirtualPlayer())
            {
                if (card == null)
                {
                    bOK = false;
                    lblCard.Text = player.name + ": Who pushed the button!";
                }
                else
                {
                    lblCard.Text = card.ToString();
                    if (!player.SetSelected(card))
                    {
                        bOK = false;
                        lblCard.Text = "Not valid suit! Play a card to match: " + player.cardToBeat.ToString();
                    }
                }

            }
            else
            {
                if (player.selected != null)
                {
                    lblCard.Text = player.selected.ToString();
                }
                else
                {
                    bOK = false;
                    lblCard.Text = "oops!!";
                }
            }
            if (bOK)
            {
                player.PlayCard();
                OnPlayerPlayACard(null);
                ShowCard();
            }
        }

        public event EventHandler PlayerHavePlayACard;

        protected virtual void OnPlayerPlayACard(EventArgs e)
        {
            EventHandler handler = PlayerHavePlayACard;
            handler?.Invoke(this, e);
        }


        public event EventHandler PlayerHaveSetSticksToWin;

        protected virtual void OnPlayerSetSticksToWin(EventArgs e)
        {
            EventHandler handler = PlayerHaveSetSticksToWin;
            handler?.Invoke(this, e);
        }

        internal void SetBet()
        {
            btnBet.Enabled = player.betRound;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            SortMyCards();
        }

        private void SortMyCards()
        {
            player.SortMyCards();
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pb = (PictureBox)sender;
                foreach (var item in listBox1.Items)
                {
                    Card card = (Card)item;
                    if (card.image == pb.Image)
                    {
                        this.PlaySelectedCard(card);
                        break;
                    }
                }
            }
        }

        private void PlayersConsoleForm_Load(object sender, EventArgs e)
        {

        }

        private void PlayersConsoleForm_Leave(object sender, EventArgs e)
        {
        }

        private void PlayersConsoleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            player.Remove();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SetSelectedCard(sender);
        }

        private void SetSelectedCard(object sender)
        {
            if (sender is PictureBox)
            {
                PictureBox pb = (PictureBox)sender;
                int i = 0;
                foreach (var item in listBox1.Items)
                {
                    Card card = (Card)item;
                    if (card.image == pb.Image)
                    {
                        listBox1.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }
        }
    }
}
