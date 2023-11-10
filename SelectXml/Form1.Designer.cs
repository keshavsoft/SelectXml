namespace SelectXml
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
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            comboBox3 = new ComboBox();
            richTextBox1 = new RichTextBox();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            button1.Location = new Point(45, 32);
            button1.Margin = new Padding(1);
            button1.Name = "button1";
            button1.Size = new Size(88, 28);
            button1.TabIndex = 0;
            button1.Text = "Select Xml";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_ClickAsync;
            // 
            // button2
            // 
            button2.Location = new Point(144, 96);
            button2.Margin = new Padding(1);
            button2.Name = "button2";
            button2.Size = new Size(88, 28);
            button2.TabIndex = 1;
            button2.Text = "ReadFile";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(248, 151);
            button3.Margin = new Padding(1);
            button3.Name = "button3";
            button3.Size = new Size(88, 28);
            button3.TabIndex = 2;
            button3.Text = "FillCombo";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(89, 137);
            comboBox3.Margin = new Padding(3, 4, 3, 4);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(138, 28);
            comboBox3.TabIndex = 5;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(36, 196);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(772, 279);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // button4
            // 
            button4.Location = new Point(390, 151);
            button4.Margin = new Padding(1);
            button4.Name = "button4";
            button4.Size = new Size(88, 28);
            button4.TabIndex = 7;
            button4.Text = "Read Xml";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(510, 151);
            button5.Margin = new Padding(1);
            button5.Name = "button5";
            button5.Size = new Size(151, 28);
            button5.TabIndex = 8;
            button5.Text = "Loop Names";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(390, 81);
            button6.Margin = new Padding(1);
            button6.Name = "button6";
            button6.Size = new Size(88, 28);
            button6.TabIndex = 9;
            button6.Text = "Stock Item";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(532, 81);
            button7.Margin = new Padding(1);
            button7.Name = "button7";
            button7.Size = new Size(139, 28);
            button7.TabIndex = 10;
            button7.Text = "Stock Items Only";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 520);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(richTextBox1);
            Controls.Add(comboBox3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox comboBox3;
        private RichTextBox richTextBox1;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}