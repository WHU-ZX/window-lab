using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.Analyser;

namespace Calculator
{
    public partial class BasicForm : Form
    {
        public BasicForm()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void delAllBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = "";
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if(inputTextBox.Text == "")
            {
                return;
            }
            String text = inputTextBox.Text;
            text = text.Substring(0, text.Length - 1);
            inputTextBox.Text = text;
        }

        private void multiOpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "×";
        }

        private void divideOpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "÷";
        }

        private void addOpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "+";
        }

        private void minusOpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "-";
        }

        private void num1Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "1";
        }

        private void num2Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "2";
        }

        private void num3Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "3";
        }

        private void num4Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "4";
        }

        private void num5Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "5";
        }

        private void num6Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "6";
        }

        private void num7Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "7";
        }

        private void num8Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "8";
        }

        private void num9Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "9";
        }

        private void num0Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "0";
        }

        private void pointBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += ".";
        }

        private void powerOpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "^";
        }

        private void lpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "(";
        }

        private void rpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += ")";
        }

        private void eqBtn_Click(object sender, EventArgs e)
        {
            //执行
            String str = "(" + inputTextBox.Text + ")";
            Lexer lexer = new Lexer(str);
            Analyser.Analyser analyser = null;
            try
            {
                lexer.Lex();
                analyser = new Analyser.Analyser(lexer.getList());
                analyser.analyse();
                Calculator.Excutor.Excutor excutor = new Calculator.Excutor.Excutor(analyser.getRootNode());
                double result = excutor.Excute();
                ansTextBox.Text = result.ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("输入不合规范!", "警告");
            }
        }

        private void moreBtn_Click(object sender, EventArgs e)
        {
            //创建ExtendForm窗口
            extendForm = new UI.ExtendForm(this);
            extendForm.Show();
            this.Visible = false;
        }

        public void clearExtendForm()
        {
            this.extendForm = null;
        }

        private void ansBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += ansTextBox.Text;
        }
    }
}
