using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Calculator.Model;

namespace Calculator.Excutor
{
    class Excutor
    {
        private Node node;
        public Excutor(Node node)
        {
            this.node = node;
        }

        public double Excute()
        {
            node.Excute();
            return node.getValue();
        }


    }
}
