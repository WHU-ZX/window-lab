namespace Calculator.UI
{
    partial class SysConvertForm
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
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.s2RB = new System.Windows.Forms.RadioButton();
            this.s8RB = new System.Windows.Forms.RadioButton();
            this.s10RB = new System.Windows.Forms.RadioButton();
            this.s16RB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.t10RB = new System.Windows.Forms.RadioButton();
            this.t2RB = new System.Windows.Forms.RadioButton();
            this.t8RB = new System.Windows.Forms.RadioButton();
            this.t16RB = new System.Windows.Forms.RadioButton();
            this.convertBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(79, 138);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(649, 25);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(79, 332);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(649, 25);
            this.outputTextBox.TabIndex = 1;
            this.outputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // s2RB
            // 
            this.s2RB.AutoSize = true;
            this.s2RB.Location = new System.Drawing.Point(11, 17);
            this.s2RB.Name = "s2RB";
            this.s2RB.Size = new System.Drawing.Size(52, 19);
            this.s2RB.TabIndex = 2;
            this.s2RB.TabStop = true;
            this.s2RB.Text = "bin";
            this.s2RB.UseVisualStyleBackColor = true;
            // 
            // s8RB
            // 
            this.s8RB.AutoSize = true;
            this.s8RB.Location = new System.Drawing.Point(157, 17);
            this.s8RB.Name = "s8RB";
            this.s8RB.Size = new System.Drawing.Size(52, 19);
            this.s8RB.TabIndex = 3;
            this.s8RB.TabStop = true;
            this.s8RB.Text = "oct";
            this.s8RB.UseVisualStyleBackColor = true;
            // 
            // s10RB
            // 
            this.s10RB.AutoSize = true;
            this.s10RB.Checked = true;
            this.s10RB.Location = new System.Drawing.Point(330, 17);
            this.s10RB.Name = "s10RB";
            this.s10RB.Size = new System.Drawing.Size(52, 19);
            this.s10RB.TabIndex = 4;
            this.s10RB.TabStop = true;
            this.s10RB.Text = "dec";
            this.s10RB.UseVisualStyleBackColor = true;
            // 
            // s16RB
            // 
            this.s16RB.AutoSize = true;
            this.s16RB.Location = new System.Drawing.Point(487, 17);
            this.s16RB.Name = "s16RB";
            this.s16RB.Size = new System.Drawing.Size(52, 19);
            this.s16RB.TabIndex = 5;
            this.s16RB.TabStop = true;
            this.s16RB.Text = "hex";
            this.s16RB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 37);
            this.label1.TabIndex = 6;
            this.label1.Text = "From";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(29, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "To";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.s10RB);
            this.panel1.Controls.Add(this.s2RB);
            this.panel1.Controls.Add(this.s8RB);
            this.panel1.Controls.Add(this.s16RB);
            this.panel1.Location = new System.Drawing.Point(79, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 69);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.t10RB);
            this.panel2.Controls.Add(this.t2RB);
            this.panel2.Controls.Add(this.t8RB);
            this.panel2.Controls.Add(this.t16RB);
            this.panel2.Location = new System.Drawing.Point(79, 257);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 69);
            this.panel2.TabIndex = 13;
            // 
            // t10RB
            // 
            this.t10RB.AutoSize = true;
            this.t10RB.Checked = true;
            this.t10RB.Location = new System.Drawing.Point(330, 17);
            this.t10RB.Name = "t10RB";
            this.t10RB.Size = new System.Drawing.Size(52, 19);
            this.t10RB.TabIndex = 4;
            this.t10RB.TabStop = true;
            this.t10RB.Text = "dec";
            this.t10RB.UseVisualStyleBackColor = true;
            // 
            // t2RB
            // 
            this.t2RB.AutoSize = true;
            this.t2RB.Location = new System.Drawing.Point(11, 17);
            this.t2RB.Name = "t2RB";
            this.t2RB.Size = new System.Drawing.Size(52, 19);
            this.t2RB.TabIndex = 2;
            this.t2RB.TabStop = true;
            this.t2RB.Text = "bin";
            this.t2RB.UseVisualStyleBackColor = true;
            // 
            // t8RB
            // 
            this.t8RB.AutoSize = true;
            this.t8RB.Location = new System.Drawing.Point(157, 17);
            this.t8RB.Name = "t8RB";
            this.t8RB.Size = new System.Drawing.Size(52, 19);
            this.t8RB.TabIndex = 3;
            this.t8RB.TabStop = true;
            this.t8RB.Text = "oct";
            this.t8RB.UseVisualStyleBackColor = true;
            // 
            // t16RB
            // 
            this.t16RB.AutoSize = true;
            this.t16RB.Location = new System.Drawing.Point(487, 17);
            this.t16RB.Name = "t16RB";
            this.t16RB.Size = new System.Drawing.Size(52, 19);
            this.t16RB.TabIndex = 5;
            this.t16RB.TabStop = true;
            this.t16RB.Text = "hex";
            this.t16RB.UseVisualStyleBackColor = true;
            // 
            // convertBtn
            // 
            this.convertBtn.Location = new System.Drawing.Point(611, 374);
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.Size = new System.Drawing.Size(117, 37);
            this.convertBtn.TabIndex = 14;
            this.convertBtn.Text = "Convert";
            this.convertBtn.UseVisualStyleBackColor = true;
            this.convertBtn.Click += new System.EventHandler(this.convertBtn_Click);
            // 
            // SysConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 450);
            this.Controls.Add(this.convertBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.inputTextBox);
            this.Name = "SysConvertForm";
            this.Text = "SysConvertForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SysConvertForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.RadioButton s2RB;
        private System.Windows.Forms.RadioButton s8RB;
        private System.Windows.Forms.RadioButton s10RB;
        private System.Windows.Forms.RadioButton s16RB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton t10RB;
        private System.Windows.Forms.RadioButton t2RB;
        private System.Windows.Forms.RadioButton t8RB;
        private System.Windows.Forms.RadioButton t16RB;
        private System.Windows.Forms.Button convertBtn;
    }
}