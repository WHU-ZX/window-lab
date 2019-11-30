using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.UI
{
    public partial class SysConvertForm : Form
    {
        private UI.ExtendForm parent = null;
        public SysConvertForm(UI.ExtendForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void SysConvertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Show();
            }
        }

        private void convertBtn_Click(object sender, EventArgs e)
        {
            byte fromType = 0,toType = 0;
            if (s2RB.Checked)
            {
                fromType = 2;
            }
            else if (s8RB.Checked)
            {
                fromType = 8;
            }
            else if (s10RB.Checked)
            {
                fromType = 10;
            }
            else if (s16RB.Checked)
            {
                fromType = 16;
            }

            if (t2RB.Checked)
            {
                toType = 2;
            }
            else if (t8RB.Checked)
            {
                toType = 8;
            }
            else if (t10RB.Checked)
            {
                toType = 10;
            }
            else if (t16RB.Checked)
            {
                toType = 16;
            }
            //string aimStr = Tools.MyConvert.ConvertGenericBinary(inputTextBox.Text, fromType, toType);
            //outputTextBox.Text = aimStr;
            try
            {
                string aimStr = Tools.MyConvert.ConvertGenericBinary(inputTextBox.Text, fromType, toType);
                outputTextBox.Text = aimStr;
            }
            catch (Exception)
            {
                MessageBox.Show("输入有误!","警告");
                inputTextBox.Text = "";
            }
        }
    }
}
