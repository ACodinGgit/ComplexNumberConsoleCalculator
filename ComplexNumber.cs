using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumberConsole
{
    public class ComplexNumber
    {

        private float re;
        private float im;

        public ComplexNumber()
        {
        }

        public ComplexNumber(float re, float im)
        {
            this.re = re;
            this.im = im;
        }

        public static ComplexNumber operator +(ComplexNumber z) => z;
        public static ComplexNumber operator -(ComplexNumber z) => new ComplexNumber(-z.re, -z.im);
        public static ComplexNumber operator +(float a, ComplexNumber z) => new ComplexNumber(z.re + a, z.im);
        public static ComplexNumber operator -(float a, ComplexNumber z) => a + -z;
        public static ComplexNumber operator *(float a, ComplexNumber z) => new ComplexNumber(a * z.re, a * z.im);
        public static ComplexNumber operator /(float a, ComplexNumber z) => a * z.reciprocal();
        public static ComplexNumber operator +(ComplexNumber z, float a) => a + z;
        public static ComplexNumber operator -(ComplexNumber z, float a) => -(a - z);
        public static ComplexNumber operator *(ComplexNumber z, float a) => a * z;
        public static ComplexNumber operator /(ComplexNumber z, float a) => new ComplexNumber(z.re / a, z.im / a);
        public static ComplexNumber operator +(ComplexNumber z1, ComplexNumber z2) => new ComplexNumber(z1.re + z2.re, z1.im + z2.im);
        public static ComplexNumber operator -(ComplexNumber z1, ComplexNumber z2) => z1 + -z2;
        public static ComplexNumber operator *(ComplexNumber z1, ComplexNumber z2) => new ComplexNumber(z1.re * z2.re - z1.im * z2.im, z1.re * z2.im + z1.im * z2.re);
        public static ComplexNumber operator /(ComplexNumber z1, ComplexNumber z2) => z1 * z2.reciprocal();

        public ComplexNumber reciprocal()
        {

            float divisor = this.re * this.re - this.im * this.im;
            return new ComplexNumber(this.re / divisor, -this.im / divisor);
        }
        public ComplexNumber pow(int n)
        {

            if (n == 0) return new ComplexNumber(1, 0);

            ComplexNumber result = new ComplexNumber(1, 0);
            ComplexNumber multiplier = (n > 0) ? this : this.reciprocal();
            for (int i = 0; i < Math.Abs(n); i++)
            {
                result *= multiplier;
            }
            return result;
        }

        public static ComplexNumber parse(String zString)
        {

            //For now, assume valid string
            zString = zString.Replace(" ", "");
            zString = zString.Replace("-", "+-");

            String[] zParts = zString.Split('+');
            
            float re = 0;
            float im = 0;

            foreach (String zPart in zParts)
            {
                if (zPart.Contains("i"))
                {
                    //9 can't currently handle i on its own
                    if (zPart.Equals("i")) im++;
                    else im += float.Parse(zPart.Replace("i", ""));
                }
                else
                {
                    re += float.Parse(zPart);
                }
            }

            return new ComplexNumber(re, im);
        }
        
        public override bool Equals(object obj)
        {
            return obj is ComplexNumber number &&
                   re == number.re &&
                   im == number.im;
        }

        public override string ToString()
        {
            if (im == 0) return re.ToString();
            if(re == 0) return im.ToString() + "i";
            String zString = re.ToString();

            if (im > 0) zString += " + ";
            else zString += " - ";
            zString += Math.Abs(im) + "i";
            return zString;
        }

        public static Boolean isValidString(string zString) {

            return false;
        
        }
    }
}