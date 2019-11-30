using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Model;
using System.Collections;

namespace Calculator.Analyser
{
    class Lexer
    {
        String sourceStr;
        ArrayList list = new ArrayList();
        public Lexer(String str)
        {
            this.sourceStr = str;
        }

        private bool isAlpha(char c)
        {
            if(c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isNumber(char c)
        {
            if(c >= '0' && c <= '9')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Lex()
        {
            for(int i = 0; i < sourceStr.Length;)
            {
                Item item = null;
                switch (sourceStr[i])
                {
                    case '+':
                        item = new Item(Token.OP, "+");
                        i++;
                        break;
                    case '-':
                        item = new Item(Token.OP, "-");
                        i++;
                        break;
                    case '×':
                        item = new Item(Token.OP, "×");
                        i++;
                        break;
                    case '÷':
                        item = new Item(Token.OP, "÷");
                        i++;
                        break;
                    case '^':
                        item = new Item(Token.OP, "^");
                        i++;
                        break;
                    case '!':
                        item = new Item(Token.OP, "!");
                        i++;
                        break;
                    case '(':
                        item = new Item(Token.OTHER, "(");
                        i++;
                        break;
                    case ')':
                        item = new Item(Token.OTHER, ")");
                        i++;
                        break;
                    default:
                        if (isAlpha(sourceStr[i]))
                        {
                            String str = "";
                            while (i < sourceStr.Length && isAlpha(sourceStr[i]))
                            {
                                str += sourceStr[i];
                                i++;
                            }
                            item = new Item(Token.FUNC, str);

                        }
                        else if (isNumber(sourceStr[i]))
                        {
                            String str = "";
                            while (i < sourceStr.Length && isNumber(sourceStr[i]))
                            {
                                str += sourceStr[i];
                                i++;
                            }
                            if(i < sourceStr.Length)
                            {
                                if (sourceStr[i] == '.')
                                {
                                    if(i + 1 < sourceStr.Length && isNumber(sourceStr[i + 1]))
                                    {
                                        str += '.';
                                        i++;
                                        while (i < sourceStr.Length && isNumber(sourceStr[i]))
                                        {
                                            str += sourceStr[i];
                                            i++;
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                            }
                            item = new Item(Token.NUMBER, str);
                        }
                        else
                        {
                            throw new Exception();
                        }
                        break;
                }
                list.Add(item);
            }
            ArrayList newList = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                Item item = (Item)list[i];
                if (item.GetValue() == "-")
                {
                    if(i + 1 < list.Count&& ((Item)list[i+1]).GetToken() == Token.NUMBER)//后面还有数字
                    {
                        if(i == 0 || ((Item)list[i-1]).GetValue() == "(")//负号是第一个字符或者负号前面是LP
                        {
                            i++;
                            Item newitem = (Item)list[i];
                            newitem.setNeg();
                            newList.Add(newitem);
                        }
                        else
                        {
                            newList.Add(item);
                        }
                    }
                    else
                    {
                        newList.Add(item);
                    }
                }
                else
                {
                    newList.Add(item);
                }
            }
            this.list = newList;
        }
        public void showList()
        {
            foreach(Item item in list)
            {
                Console.WriteLine(item.GetValue());
            }
        }

        public ArrayList getList()
        {
            return this.list;
        }
    }
}
