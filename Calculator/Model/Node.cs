using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPS;
using Calculator.UI;
using Calculator.Analyser;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.DataVisualization;

namespace Calculator.Model
{
    class Node
    {
        private Node left = null;
        private Node right = null;
        private Operator op = null;

        
        double value;
        public Node(double val)
        {
            this.op = new Operator("");
            this.value = val;
        }
        public Node(Node left, Node right,Operator op)
        {
            this.left = left;
            this.right = right;
            this.op = op;
            this.value = 0.0;
        }

        public double getValue()
        {
            return this.value;
        }

        public void Excute()
        {
            switch (this.op.GetOP())
            {
                case "":
                    break;
                case "+":
                    left.Excute();
                    right.Excute();
                    this.value = Operations.add(left.value, right.value);//left.value + right.value;
                    break;
                case "-":
                    left.Excute();
                    right.Excute();
                    this.value = Operations.minus(left.value, right.value); //left.value - right.value;
                    break;
                case "×":
                    left.Excute();
                    right.Excute();
                    this.value = Operations.multiply(left.value, right.value); //left.value * right.value;
                    break;
                case "÷":
                    left.Excute();
                    right.Excute();
                    this.value = Operations.divide(left.value, right.value);
                    break;
                case "^":
                    left.Excute();
                    right.Excute();
                    this.value = Math.Pow(left.value, right.value);
                    break;
                case "!":
                    left.Excute();
                    Chart chart = new Chart();
                    if(left.value == 0)
                    {
                        this.value = 1;
                    }
                    else
                    {
                        this.value = left.value * chart.DataManipulator.Statistics.GammaFunction(left.value);
                    }
                    break;
                case "sin":
                    right.Excute();
                    this.value = Math.Sin(right.value);
                    break;
                case "cos":
                    right.Excute();
                    this.value = Math.Cos(right.value);
                    break;
                case "tan":
                    right.Excute();
                    this.value = Math.Tan(right.value);
                    break;
                case "asin":
                    right.Excute();
                    this.value = Math.Asin(right.value);
                    break;
                case "acos":
                    right.Excute();
                    this.value = Math.Acos(right.value);
                    break;
                case "atan":
                    right.Excute();
                    this.value = Math.Atan(right.value);
                    break;
                case "log":
                    right.Excute();
                    this.value = Math.Log10(right.value);
                    break;
                case "ln":
                    right.Excute();
                    this.value = Math.Log(right.value);
                    break;
                case "exp":
                    right.Excute();
                    this.value = Math.Exp(right.value);
                    break;
                case "f":
                    right.Excute();
                    String FString = ExtendForm.FStr;
                    String RValStr = right.value.ToString();
                    RValStr = "(" + RValStr + ")";
                    String newString = FString.Replace("exp", "MMM");
                    newString = newString.Replace("x", RValStr);
                    newString = newString.Replace("MMM", "exp");
                    newString = newString.Replace(" ", "");
                    newString = newString.Replace("\t", "");
                    newString = "(" + newString + ")";
                    Lexer lexer = new Lexer(newString);
                    Analyser.Analyser analyser = null;
                    try
                    {
                        lexer.Lex();
                        analyser = new Analyser.Analyser(lexer.getList());
                        analyser.analyse();
                        Calculator.Excutor.Excutor excutor = new Calculator.Excutor.Excutor(analyser.getRootNode());
                        this.value = excutor.Excute();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    break;
            }
        }
    }
}
