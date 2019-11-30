using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    enum Token { NUMBER,OP,FUNC,OTHER};
    class Item
    {
        private Token token;
        private String value;
        public Item(Token token,String val)
        {
            this.token = token;
            this.value = val;
        }

        public Token GetToken()
        {
            return this.token;
        }

        public void setNeg()
        {
            if(this.token == Token.NUMBER && this.value.Length > 0 && this.value[0] != '-')
            {
                this.value = '-' + this.value;
            }
        }

        public String GetValue()
        {
            return this.value;
        }
    }
}
