using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Calculator.Model;

namespace Calculator.Analyser
{
    class Analyser//将得到的Item数组生成Node树
    {
        private ArrayList list;
        private Node rootNode = null;

        public Analyser(ArrayList list)
        {
            this.list = list;
        }

        public void analyse()
        {
            if(list.Count > 0)
            {
                int i = 0;
                rootNode = analysePart(ref i);
            }
        }

        private Node analysePart(ref int i)
        {
            ArrayList stack = new ArrayList();
            ArrayList levelStack = new ArrayList();//0 -> +/-   1 -> */%   2-> ^
            int stackTop = -1;
            bool meetLeft = false, meetRight = false;
            Object obj;
            Object obj1, obj2, obj3;
            Node newNode;
            for (; i < this.list.Count;)
            {
                Item item = (Item)list[i];
                switch (item.GetToken())
                {
                    case Token.FUNC:
                        if(i < list.Count - 1)//下一个还有
                        {
                            Item nextItem = (Item)list[i+1];
                            if (nextItem.GetValue() != "(")
                            {
                                throw new Exception();//Func后一个必须是"("
                            }
                            i++;
                            Node node = analysePart(ref i);
                            newNode = new Node(null, node, new Operator(item.GetValue()));
                            stack.Add(newNode);
                            stackTop++;
                        }
                        else
                        {
                            throw new Exception();//Func后一个必须是"("
                        }
                        break;
                    case Token.NUMBER:
                        //要么是空栈，要么栈里是运算符，然后根据运算符选择不同操作
                        if(stackTop != -1)
                        {
                            obj = stack[stackTop];
                            if(obj is Node)
                            {
                                throw new Exception();
                            }
                        }
                        String dStr = item.GetValue();
                        double value = Convert.ToDouble(dStr);
                        newNode = new Node(value);
                        stack.Add(newNode);
                        stackTop++;
                        i++;
                        break;
                    case Token.OP://
                        //创建Operator类对象加入栈
                        //先判断栈中是否有Node，没有则报错，因为不可能以运算符开头，也不可能两个运算符挨在一起
                        if(stackTop < 0)
                        {
                            if (item.GetValue() == "-" && i < list.Count - 1 && ((Item)list[i+1]).GetValue() == "(")
                            {
                                newNode = new Node(-1);
                                stack.Add(newNode);
                                stackTop++;
                                Operator op = new Operator("×");
                                stack.Add(op);
                                stackTop++;
                                levelStack.Add(1);
                                i++;
                                Node node = analysePart(ref i);
                                stack.Add(node);
                                stackTop++;
                                break;
                            }
                            else if(item.GetValue() == "-" && i < list.Count - 1 && ((Item)list[i + 1]).GetToken() == Token.FUNC)
                            {
                                newNode = new Node(-1);
                                stack.Add(newNode);
                                stackTop++;
                                Operator op = new Operator("×");
                                stack.Add(op);
                                stackTop++;
                                levelStack.Add(1);
                                i++;
                                break;
                            }
                            else
                            {
                                throw new Exception();//栈中没有Node
                            }
                        }
                        obj = stack[stackTop];
                        if(!(obj is Node))
                        {
                            throw new Exception();//操作符前面还有一个操作符
                        }
                        if(item.GetValue() == "+" || item.GetValue() == "-")
                        {
                            Operator op = new Operator(item.GetValue());
                            if(stackTop >= 2 && levelStack.Count >= 1)
                            {
                                while(stackTop != 0)
                                {
                                    obj3 = stack[stackTop];
                                    obj2 = stack[stackTop - 1];
                                    obj1 = stack[stackTop - 2];
                                    stack.RemoveAt(stackTop);
                                    stackTop--;
                                    stack.RemoveAt(stackTop);
                                    stackTop--;
                                    stack.RemoveAt(stackTop);
                                    stackTop--;
                                    levelStack.RemoveAt(levelStack.Count - 1);
                                    newNode = new Node((Node)obj1, (Node)obj3, (Operator)obj2);
                                    stack.Add(newNode);
                                    stackTop++;
                                }
                            }
                            stack.Add(op);
                            stackTop++;
                            levelStack.Add(0);
                        }
                        else if(item.GetValue() == "×" || item.GetValue() == "÷")
                        {
                            Operator op = new Operator(item.GetValue());
                            if (stackTop >= 2 && levelStack.Count >= 1)
                            {
                                while(stackTop!=0 && (int)levelStack[levelStack.Count-1] >= 1)
                                {
                                    obj3 = stack[stackTop];
                                    obj2 = stack[stackTop - 1];
                                    obj1 = stack[stackTop - 2];
                                    stack.RemoveAt(stackTop);
                                    stackTop--;
                                    stack.RemoveAt(stackTop);
                                    stackTop--;
                                    stack.RemoveAt(stackTop);
                                    stackTop--;
                                    levelStack.RemoveAt(levelStack.Count - 1);
                                    newNode = new Node((Node)obj1, (Node)obj3, (Operator)obj2);
                                    stack.Add(newNode);
                                    stackTop++;
                                }
                            }
                            stack.Add(op);
                            stackTop++;
                            levelStack.Add(1);
                        }
                        else if(item.GetValue() == "^")
                        {
                            Operator op = new Operator(item.GetValue());
                            //while()
                            if (stackTop >= 2 && levelStack.Count >= 1)
                            {
                                while (stackTop != 0 && (int)levelStack[levelStack.Count - 1] >= 2)
                                {
                                    obj3 = stack[stackTop];
                                    obj2 = stack[stackTop - 1];
                                    obj1 = stack[stackTop - 2];
                                    stack.RemoveAt(stackTop);
                                    stackTop--;
                                    stack.RemoveAt(stackTop);
                                    stackTop--;
                                    stack.RemoveAt(stackTop);
                                    stackTop--;
                                    levelStack.RemoveAt(levelStack.Count - 1);
                                    newNode = new Node((Node)obj1, (Node)obj3, (Operator)obj2);
                                    stack.Add(newNode);
                                    stackTop++;
                                }
                            }
                            stack.Add(op);
                            stackTop++;
                            levelStack.Add(2);
                        }
                        else// !
                        {
                            stack.RemoveAt(stackTop);
                            stackTop--;
                            Node node = new Node((Node)obj, null, new Operator("!"));
                            stack.Add(node);
                            stackTop++;
                        }
                        i++;
                        break;
                    case Token.OTHER:
                        if (item.GetValue() == "(")
                        {
                            if (meetLeft)//已经遇到括号了，证明这是表达式中的其他括号
                            {
                                Node node = analysePart(ref i);
                                if(stackTop == -1)//栈中无数据
                                {
                                    stack.Add(node);
                                    stackTop++;
                                }
                                else
                                {
                                    obj = stack[stackTop];
                                    if(obj is Operator)//有点问题
                                    {
                                        stack.Add(node);
                                        stackTop++;
                                    }
                                    else
                                    {
                                        throw new Exception();//不可能出现两个都是数值而中间没有操作符
                                    }
                                }
                                //i不用自增
                            }
                            else
                            {
                                meetLeft = true;
                                i++;
                            }
                        }
                        else if(item.GetValue() == ")")
                        {
                            if(!meetLeft || !(stack[0] is Node))
                            {
                                throw new Exception();
                            }
                            meetRight = true;
                            i++;
                            while (stackTop != 0)//此时剩下的符号中，从栈顶向下，符号的优先级越来越低，故只要依次出栈并生成node再入栈，知道栈只剩一个
                            {
                                obj3 = stack[stackTop];
                                obj2 = stack[stackTop - 1];
                                obj1 = stack[stackTop - 2];
                                stack.RemoveAt(stackTop);
                                stackTop--;
                                stack.RemoveAt(stackTop);
                                stackTop--;
                                stack.RemoveAt(stackTop);
                                stackTop--;
                                levelStack.RemoveAt(levelStack.Count - 1);
                                newNode = new Node((Node)obj1, (Node)obj3, (Operator)obj2);
                                stack.Add(newNode);
                                stackTop++;
                            }
                            return (Node)stack[0];
                        }
                        break;
                }
            }
            //此时i >= list.Count
            if ((meetLeft&&!meetRight)|| !(stack[0] is Node))//meetLeft表示有左括号但没右括号
            {
                throw new Exception();
            }
            else
            {
                while(stackTop != 0)//此时剩下的符号中，从栈顶向下，符号的优先级越来越低，故只要依次出栈并生成node再入栈，知道栈只剩一个
                {
                    obj3 = stack[stackTop];
                    obj2 = stack[stackTop - 1];
                    obj1 = stack[stackTop - 2];
                    stack.RemoveAt(stackTop);
                    stackTop--;
                    stack.RemoveAt(stackTop);
                    stackTop--;
                    stack.RemoveAt(stackTop);
                    stackTop--;
                    levelStack.RemoveAt(levelStack.Count - 1);
                    newNode = new Node((Node)obj1, (Node)obj3, (Operator)obj2);
                    stack.Add(newNode);
                    stackTop++;
                }
                return (Node)stack[0];
            }
            
        }

        public Node getRootNode()
        {
            return this.rootNode;
        }


    }
}
