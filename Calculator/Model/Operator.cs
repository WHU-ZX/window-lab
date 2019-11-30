using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    class Operator
    {
        private string op;
        public Operator(string op)
        {
            this.op = op;
        }

        public double Excute(Node left,Node right)
        {
            


            return 0.0;
        }

        public string GetOP()
        {
            return this.op;
        }
    }
}
