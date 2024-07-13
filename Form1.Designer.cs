namespace piatnashki
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(777, 336);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ChooseThePictureButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Location = new Point(117, 47);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(600, 600);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(783, 272);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(801, 540);
            button2.Name = "button2";
            button2.Size = new Size(27, 23);
            button2.TabIndex = 3;
            button2.Text = "^";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += UpButton_Click;
            // 
            // button3
            // 
            button3.Location = new Point(835, 569);
            button3.Name = "button3";
            button3.Size = new Size(27, 23);
            button3.TabIndex = 4;
            button3.Text = ">";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += RightButton_Click;
            // 
            // button4
            // 
            button4.Location = new Point(768, 569);
            button4.Name = "button4";
            button4.Size = new Size(27, 23);
            button4.TabIndex = 5;
            button4.Text = "<";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += LeftButtonClick;
            // 
            // button5
            // 
            button5.Location = new Point(801, 598);
            button5.Name = "button5";
            button5.Size = new Size(27, 23);
            button5.TabIndex = 6;
            button5.Text = "v";
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            button5.Click += DownButton_Click;
            // 
            // button6
            // 
            button6.Location = new Point(777, 386);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 7;
            button6.Text = "shuffle";
            button6.UseVisualStyleBackColor = true;
            button6.Visible = false;
            button6.Click += ShuffleButton_Click;
            // 
            // button7
            // 
            button7.Location = new Point(777, 437);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 8;
            button7.Text = "Reset";
            button7.UseVisualStyleBackColor = true;
            button7.Visible = false;
            button7.Click += ResetButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(922, 706);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private Label label1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
