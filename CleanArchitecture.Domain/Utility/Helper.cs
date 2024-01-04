using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Utility
{
    public class Helper
    {
        public static string Code(int length)
        {
            Random r = new();
            string codeTable = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder sb = new();
            for (int i = 0; i < length; i++)
            {
                int index = r.Next(1, 63);
                sb.Append(codeTable[index - 1]);
            }
            return sb.ToString();
        }
    }
}
