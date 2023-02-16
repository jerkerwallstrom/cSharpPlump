namespace TestWindowsApp.Source
{
    partial class PlayersConsoleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlayCard = new System.Windows.Forms.Button();
            this.lblPointText = new System.Windows.Forms.Label();
            this.lblPointsValue = new System.Windows.Forms.Label();
            this.lblCard = new System.Windows.Forms.Label();
            this.txtBet = new System.Windows.Forms.TextBox();
            this.btnBet = new System.Windows.Forms.Button();
            this.lblSticksValue = new System.Windows.Forms.Label();
            this.lblStickText = new System.Windows.Forms.Label();
            this.lblStickBet = new System.Windows.Forms.Label();
            this.btnSort = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(63, 55);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(189, 308);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cards";
            // 
            // btnPlayCard
            // 
            this.btnPlayCard.Location = new System.Drawing.Point(71, 384);
            this.btnPlayCard.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlayCard.Name = "btnPlayCard";
            this.btnPlayCard.Size = new System.Drawing.Size(100, 26);
            this.btnPlayCard.TabIndex = 2;
            this.btnPlayCard.Text = "Play card";
            this.btnPlayCard.UseVisualStyleBackColor = true;
            this.btnPlayCard.Click += new System.EventHandler(this.btnPlayCard_Click);
            // 
            // lblPointText
            // 
            this.lblPointText.AutoSize = true;
            this.lblPointText.Location = new System.Drawing.Point(69, 523);
            this.lblPointText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPointText.Name = "lblPointText";
            this.lblPointText.Size = new System.Drawing.Size(51, 17);
            this.lblPointText.TabIndex = 3;
            this.lblPointText.Text = "Points:";
            // 
            // lblPointsValue
            // 
            this.lblPointsValue.AutoSize = true;
            this.lblPointsValue.Location = new System.Drawing.Point(140, 524);
            this.lblPointsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPointsValue.Name = "lblPointsValue";
            this.lblPointsValue.Size = new System.Drawing.Size(16, 17);
            this.lblPointsValue.TabIndex = 4;
            this.lblPointsValue.Text = "0";
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(196, 391);
            this.lblCard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(24, 17);
            this.lblCard.TabIndex = 5;
            this.lblCard.Text = "....";
            // 
            // txtBet
            // 
            this.txtBet.Location = new System.Drawing.Point(67, 427);
            this.txtBet.Margin = new System.Windows.Forms.Padding(4);
            this.txtBet.Name = "txtBet";
            this.txtBet.Size = new System.Drawing.Size(60, 22);
            this.txtBet.TabIndex = 6;
            // 
            // btnBet
            // 
            this.btnBet.Location = new System.Drawing.Point(152, 427);
            this.btnBet.Margin = new System.Windows.Forms.Padding(4);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(100, 28);
            this.btnBet.TabIndex = 7;
            this.btnBet.Text = "Bet";
            this.btnBet.UseVisualStyleBackColor = true;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // lblSticksValue
            // 
            this.lblSticksValue.AutoSize = true;
            this.lblSticksValue.Location = new System.Drawing.Point(141, 481);
            this.lblSticksValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSticksValue.Name = "lblSticksValue";
            this.lblSticksValue.Size = new System.Drawing.Size(16, 17);
            this.lblSticksValue.TabIndex = 9;
            this.lblSticksValue.Text = "0";
            // 
            // lblStickText
            // 
            this.lblStickText.AutoSize = true;
            this.lblStickText.Location = new System.Drawing.Point(71, 480);
            this.lblStickText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStickText.Name = "lblStickText";
            this.lblStickText.Size = new System.Drawing.Size(49, 17);
            this.lblStickText.TabIndex = 8;
            this.lblStickText.Text = "Sticks:";
            // 
            // lblStickBet
            // 
            this.lblStickBet.AutoSize = true;
            this.lblStickBet.Location = new System.Drawing.Point(281, 433);
            this.lblStickBet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStickBet.Name = "lblStickBet";
            this.lblStickBet.Size = new System.Drawing.Size(24, 17);
            this.lblStickBet.TabIndex = 10;
            this.lblStickBet.Text = "....";
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(171, 24);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(81, 23);
            this.btnSort.TabIndex = 11;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(259, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 50);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(311, 55);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 50);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox2.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(259, 111);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(46, 50);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(311, 111);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(46, 50);
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(259, 167);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(46, 50);
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(311, 167);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(46, 50);
            this.pictureBox6.TabIndex = 18;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(259, 223);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(46, 50);
            this.pictureBox7.TabIndex = 17;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(311, 223);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(46, 50);
            this.pictureBox8.TabIndex = 16;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Location = new System.Drawing.Point(259, 279);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(46, 50);
            this.pictureBox9.TabIndex = 21;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Location = new System.Drawing.Point(311, 279);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(46, 50);
            this.pictureBox10.TabIndex = 20;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // PlayersConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 554);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.lblStickBet);
            this.Controls.Add(this.lblSticksValue);
            this.Controls.Add(this.lblStickText);
            this.Controls.Add(this.btnBet);
            this.Controls.Add(this.txtBet);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.lblPointsValue);
            this.Controls.Add(this.lblPointText);
            this.Controls.Add(this.btnPlayCard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PlayersConsoleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Console";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayersConsoleForm_FormClosed);
            this.Load += new System.EventHandler(this.PlayersConsoleForm_Load);
            this.Leave += new System.EventHandler(this.PlayersConsoleForm_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPlayCard;
        private System.Windows.Forms.Label lblPointText;
        private System.Windows.Forms.Label lblPointsValue;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.TextBox txtBet;
        private System.Windows.Forms.Button btnBet;
        private System.Windows.Forms.Label lblSticksValue;
        private System.Windows.Forms.Label lblStickText;
        private System.Windows.Forms.Label lblStickBet;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
    }
}