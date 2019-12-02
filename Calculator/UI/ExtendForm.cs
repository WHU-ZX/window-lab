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
using Calculator.Model;

namespace Calculator.UI
{
    public partial class ExtendForm : Form
    {
        private String[] stack = new string[1000];
        private int stackTop = -1;
        public static String FStr = null;
        private String pop()
        {
            if(stackTop < 0)
            {
                return null;
            }
            String str = stack[stackTop];
            stackTop--;
            return str;
        }
        private void push(String str)
        {
            if(stackTop == 999)
            {
                //应该抛异常
                return;
            }
            stackTop++;
            stack[stackTop] = str;
        }
        private void clearStack()
        {
            if(stackTop < 0)
            {
                return;
            }
            while(stackTop >= 0)
            {
                stack[stackTop] = null;
                stackTop--;
            }
        }


        public ExtendForm(BasicForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            convertBtn.Text = "进\n制\n转\n换\n器";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void ExtendForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(parent != null)
            {
                parent.Show();
                parent.clearExtendForm();
            }
        }

        private void num1Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "1";
            push("1");
        }

        private void num2Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "2";
            push("2");
        }

        private void num3Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "3";
            push("3");
        }

        private void factorOpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "!";
            push("!");
        }

        private void num4Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "4";
            push("4");
        }

        private void num5Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "5";
            push("5");
        }

        private void num6Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "6";
            push("6");
        }

        private void ExtendForm_Load(object sender, EventArgs e)
        {
            inputTextBox.Text += "7";
            push("7");
        }

        private void num8Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "8";
            push("8");
        }

        private void num9Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "9";
            push("9");
        }

        private void num0Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "0";
            push("0");
        }

        private void pointBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += ".";
            push(".");
        }

        private void multiOpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "×";
            push("×");
        }

        private void divideOpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "÷";
            push("÷");        }

        private void addOpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "+";
            push("+");
        }

        private void minusOpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "-";
            push("-");
        }

        private void eqBtn_Click(object sender, EventArgs e)
        {
            //执行
            String str = "(" + inputTextBox.Text + ")";
            FStr = fTextBox.Text;
            
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
            catch (Exception)
            {
                MessageBox.Show("输入不合规范!", "警告");
            }
        }

        private void delAllBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = "";
            clearStack();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text == "")
            {
                return;
            }
            String text = inputTextBox.Text;
            String str = pop();
            if(text.Length <= str.Length)
            {
                inputTextBox.Text = "";
            }
            else
            {
                text = text.Substring(0, text.Length - str.Length);
                inputTextBox.Text = text;
            }
        }
            

        private void lpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "(";
            push("(");
        }

        private void rpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += ")";
            push(")");
        }

        private void sinBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "sin";
            push("sin");
        }

        private void cosBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "cos";
            push("cos");
        }

        private void tanBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "tan";
            push("tan");
        }

        private void fBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "f";
            push("f");
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "log";
            push("log");
        }

        private void lnBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "ln";
            push("ln");
        }

        private void expBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "exp";
            push("exp");
        }

        private void num7Btn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "7";
            push("7");
        }

        private void powerOpBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "^";
            push("^");
        }

        private void ansBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += ansTextBox.Text;
        }

        private void asinBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "asin";
            push("asin");
        }

        private void acosBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "acos";
            push("acos");
        }

        private void atanBtn_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "atan";
            push("atan");
        }

        private void convertBtn_Click(object sender, EventArgs e)
        {
            SysConvertForm scf = new SysConvertForm(this);
            this.Visible = false;
            scf.Show();
        }

        private void addXBtn_Click(object sender, EventArgs e)
        {
            fTextBox.Text += "×";
        }

        private void addDBtn_Click(object sender, EventArgs e)
        {
            fTextBox.Text += "÷";
        }
    }
}
