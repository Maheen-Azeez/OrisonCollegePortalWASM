using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonCollegePortal.Client.Services
{
    public class AmountInWords
    {
        private static String[] units = { "Zero", "One", "Two", "Three","Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven","Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen","Seventeen", "Eighteen", "Nineteen" };
        private static String[] tens = { "", "", "Twenty", "Thirty", "Forty","Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public static String ConvertAmount(double amount,string Currency, string CurrencyDec)
        {
            try
            {
                Int64 amount_int = (Int64)amount;
                Int64 amount_dec = (Int64)Math.Round((amount - (double)(amount_int)) * 100);
                if (amount_dec == 0)
                {
                    return ConvertAmt(amount_int) + Currency + " and No " + CurrencyDec + ".";
                }
                else
                {
                    return ConvertAmt(amount_int) + Currency + " and " + ConvertAmt(amount_dec) + CurrencyDec + ".";
                }

                //if (amount_dec == 0)
                //{
                //    return ConvertAmt(amount_int) + Currency;
                //}
                //else
                //{
                //    //return ConvertAmt(amount_int) + ConvertAmt(amount_dec) + Currency;
                //    return ConvertAmt(amount_int) + "." + ConvertAmt(amount_dec) + Currency;
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "";
        }

        public static String ConvertAmt(Int64 i)
        {
            if (i < 20)
            {
                return units[i];
            }
            if (i < 100)
            {
                return tens[i / 10] + ((i % 10 > 0) ? " " + ConvertAmt(i % 10) : "");
            }
            if (i < 1000)
            {
                return units[i / 100] + " Hundred"
                        + ((i % 100 > 0) ? " And " + ConvertAmt(i % 100) : "");
            }
            if (i < 100000)
            {
                return ConvertAmt(i / 1000) + " Thousand "
                + ((i % 1000 > 0) ? " " + ConvertAmt(i % 1000) : "");
            }
            if (i < 10000000)
            {
                return ConvertAmt(i / 100000) + " Lakh "
                        + ((i % 100000 > 0) ? " " + ConvertAmt(i % 100000) : "");
            }
            if (i < 1000000000)
            {
                return ConvertAmt(i / 10000000) + " Crore "
                        + ((i % 10000000 > 0) ? " " + ConvertAmt(i % 10000000) : "");
            }
            return ConvertAmt(i / 1000000000) + " Arab "
                    + ((i % 1000000000 > 0) ? " " + ConvertAmt(i % 1000000000) : "");
        }

    }
}
