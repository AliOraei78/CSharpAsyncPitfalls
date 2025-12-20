namespace AsyncPitfallsUI
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
            label1 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(175, 217);
            button1.Name = "button1";
            button1.Size = new Size(172, 29);
            button1.TabIndex = 0;
            button1.Text = "Test ConfigureAwait";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(305, 269);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 1;
            label1.Text = "Results:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(369, 266);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(188, 27);
            textBox1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(561, 217);
            button2.Name = "button2";
            button2.Size = new Size(160, 29);
            button2.TabIndex = 3;
            button2.Text = "Test Deadlock(fixed)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(380, 217);
            button3.Name = "button3";
            button3.Size = new Size(150, 29);
            button3.TabIndex = 4;
            button3.Text = "Test Deadlock(bad)";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(266, 344);
            button4.Name = "button4";
            button4.Size = new Size(161, 29);
            button4.TabIndex = 5;
            button4.Text = "Deadlock with bad library";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(451, 344);
            button5.Name = "button5";
            button5.Size = new Size(184, 29);
            button5.TabIndex = 6;
            button5.Text = "Deadlock with fixed library";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(266, 428);
            button6.Name = "button6";
            button6.Size = new Size(161, 29);
            button6.TabIndex = 7;
            button6.Text = "BadFireForget";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(487, 428);
            button7.Name = "button7";
            button7.Size = new Size(148, 29);
            button7.TabIndex = 8;
            button7.Text = "SafeFireForget";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 572);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
