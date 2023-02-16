namespace TestWindowsApp
{
    partial class Form1
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
            this.AddPlayerBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chbVirtual = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.picBoxCardToBeat = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCardToBeat)).BeginInit();
            this.SuspendLayout();
            // 
            // AddPlayerBtn
            // 
            this.AddPlayerBtn.Location = new System.Drawing.Point(16, 15);
            this.AddPlayerBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AddPlayerBtn.Name = "AddPlayerBtn";
            this.AddPlayerBtn.Size = new System.Drawing.Size(100, 28);
            this.AddPlayerBtn.TabIndex = 0;
            this.AddPlayerBtn.Text = "Add player";
            this.AddPlayerBtn.UseVisualStyleBackColor = true;
            this.AddPlayerBtn.Click += new System.EventHandler(this.AddPlayerBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(133, 16);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(132, 22);
            this.txtName.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(16, 87);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 28);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Deal";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 192);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(245, 292);
            this.listBox1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(316, 192);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(341, 292);
            this.textBox1.TabIndex = 5;
            // 
            // chbVirtual
            // 
            this.chbVirtual.AutoSize = true;
            this.chbVirtual.Location = new System.Drawing.Point(289, 20);
            this.chbVirtual.Margin = new System.Windows.Forms.Padding(4);
            this.chbVirtual.Name = "chbVirtual";
            this.chbVirtual.Size = new System.Drawing.Size(70, 21);
            this.chbVirtual.TabIndex = 7;
            this.chbVirtual.Text = "Virtual";
            this.chbVirtual.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(505, 23);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(152, 28);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Create players [Test]";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // picBoxCardToBeat
            // 
            this.picBoxCardToBeat.Location = new System.Drawing.Point(573, 87);
            this.picBoxCardToBeat.Name = "picBoxCardToBeat";
            this.picBoxCardToBeat.Size = new System.Drawing.Size(84, 98);
            this.picBoxCardToBeat.TabIndex = 9;
            this.picBoxCardToBeat.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 554);
            this.Controls.Add(this.picBoxCardToBeat);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.chbVirtual);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddPlayerBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCardToBeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddPlayerBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chbVirtual;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.PictureBox picBoxCardToBeat;
    }
}

