using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tools
{
    class MyConvert
    {
        public static string ConvertGenericBinary(string input, byte fromType, byte toType)
        {
            string output = input;
            try
            {
                switch (fromType)
                {
                    case 2:
                        output = ConvertGenericBinaryFromBinary(input, toType);
                        break;
                    case 8:
                        output = ConvertGenericBinaryFromOctal(input, toType);
                        break;
                    case 10:
                        output = ConvertGenericBinaryFromDecimal(input, toType);
                        break;
                    case 16:
                        output = ConvertGenericBinaryFromHexadecimal(input, toType);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }

        private static string ConvertGenericBinaryFromBinary(string input, byte toType)
        {
            try
            {
                switch (toType)
                {
                    case 8:
                        //先转换成十进制然后转八进制
                        input = Convert.ToString(Convert.ToInt32(input, 2), 8);
                        break;
                    case 10:
                        input = Convert.ToInt32(input, 2).ToString();
                        break;
                    case 16:
                        input = Convert.ToString(Convert.ToInt32(input, 2), 16);
                        break;
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return input;
        }

        private static string ConvertGenericBinaryFromOctal(string input, byte toType)
        {
            try
            {
                switch (toType)
                {
                    case 2:
                        input = Convert.ToString(Convert.ToInt32(input, 8), 2);
                        break;
                    case 10:
                        input = Convert.ToInt32(input, 8).ToString();
                        break;
                    case 16:
                        input = Convert.ToString(Convert.ToInt32(input, 8), 16);
                        break;
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return input;
        }

        private static string ConvertGenericBinaryFromDecimal(string input, int toType)
        {
            string output = "";
            int intInput = Convert.ToInt32(input);
            try
            {
                switch (toType)
                {
                    case 2:
                        output = Convert.ToString(intInput, 2);
                        break;
                    case 8:
                        output = Convert.ToString(intInput, 8);
                        break;
                    case 16:
                        output = Convert.ToString(intInput, 16);
                        break;
                    default:
                        output = input;
                        break;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return output;
        }

        private static string ConvertGenericBinaryFromHexadecimal(string input, int toType)
        {
            try
            {
                switch (toType)
                {
                    case 2:
                        input = Convert.ToString(Convert.ToInt32(input, 16), 2);
                        break;
                    case 8:
                        input = Convert.ToString(Convert.ToInt32(input, 16), 8);
                        break;
                    case 10:
                        input = Convert.ToInt32(input, 16).ToString();
                        break;
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return input;
        }
    }
}
