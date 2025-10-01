using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace LR1_PRUN_M_PM
{
    internal class Program
    {
        public static StreamWriter sw = new StreamWriter("output.txt");

        static double[] Prior_E (double[,] a) {
            double[] E_shtih = new double[7];
            double[] result = new double[7];
            double e_shtih = 0.0;
            for (int i = 0; i < 7; i++)
            {
                double product = 1.0;
                for (int j = 0; j < 7; j++)
                    product *= a[i, j];

                E_shtih[i] = Math.Round(Math.Pow(product, 1.0/7), 6);
            }

            for (int i = 0; i < 7; i++)
            {
                e_shtih += E_shtih[i];
            }

            e_shtih = Math.Round(e_shtih, 6);

            for (int i = 0; i < 7; i++) 
            {
                result[i] = Math.Round(E_shtih[i] / e_shtih, 6);
            }
            return result; 
        }

        static double[] Prior_W (double[,] a)
        {
            double[] E_shtih = new double[6];
            double[] result = new double[6];
            double e_shtih = 0.0;
            for (int i = 0; i < 6; i++)
            {
                double product = 1.0;
                for (int j = 0; j < 6; j++)
                    product *= a[i, j];

                E_shtih[i] = Math.Round(Math.Pow(product, 1.0/6), 6);
            }

            for (int i = 0; i < 6; i++)
            {
                e_shtih += E_shtih[i];
            }

            e_shtih = Math.Round(e_shtih, 6);

            for (int i = 0; i < 6; i++)
            {
                result[i] = Math.Round(E_shtih[i] / e_shtih, 6);
            }
            return result;
        }

        static double Result_prior_w(double[] e, double[] w)
        {
            double result = 0.0;
            for (int i = 0; i < 6; i++)
            {
                result += Math.Round(e[i] * w[i], 3);
            }
            return result;
        }


        static void Main(string[] args)
        {
            var E = new[,]
            {
                { 1.0, 1.0/7, 4.0, 5.0, 1.0/8, 2.0, 2.0 },
                { 7.0, 1.0, 9.0, 7.0, 1.0/7, 6.0, 2.0 },
                { 1.0/4, 1.0/9, 1.0, 7.0, 1.0/5, 1.0/2, 1.0/5 },
                { 1.0/5, 1.0/7, 1.0/7, 1.0, 5.0, 1.0/7, 3.0 },
                { 8.0, 7.0, 5.0, 1.0/5, 1.0, 1.0/7, 1.0/6 },
                { 1.0/2, 1.0/6, 2.0, 7.0, 7.0, 1.0, 1.0 },
                { 1.0/2, 1.0/2, 5.0, 1.0/3, 6.0, 1.0, 1.0 }
            };
            var W1 = new[,]
            {
                { 1.0, 1.0/5, 1.0/7, 3.0, 8.0, 1.0/2 },
                { 5.0, 1.0, 1.0/4, 4.0, 1.0/7, 1.0/9 },
                { 7.0, 4.0, 1.0, 7.0, 1.0/3, 6.0 },
                { 1.0/3, 1.0/4, 1.0/7, 1.0, 6.0, 3.0 },
                { 1.0/8, 7.0, 3.0, 1.0/6, 1.0, 2.0 },
                { 2.0, 9.0, 1.0/6, 1.0/3, 1.0/2, 1.0 }

            };
            var W2 = new[,]
            {
                { 1.0, 2.0, 1.0/3, 2.0, 1.0/2, 1.0/9 },
                { 1.0/2, 1.0, 2.0, 6.0, 1.0/5, 1.0/4 },
                { 3.0, 1.0/2, 1.0, 5.0, 3.0, 5.0 },
                { 1.0/2, 1.0/6, 1.0/5, 1.0, 3.0, 8.0 },
                { 2.0, 5.0, 1.0/3, 1.0/3, 1.0, 6.0 },
                { 9.0, 4.0, 1.0/5, 1.0/8, 1.0/6, 1.0 }
            };
            var W3 = new[,]
            {
                { 1.0, 7.0, 3.0, 8.0, 7.0, 1.0/8 },
                { 1.0/7, 1.0, 3.0, 1.0/9, 1.0/7, 1.0/6 },
                { 1.0/3, 1.0/3, 1.0, 1.0/4, 2.0, 5.0 },
                { 1.0/8, 9.0, 4.0, 1.0, 1.0/2, 1.0/8 },
                { 1.0/7, 7.0, 1.0/2, 2.0, 1.0, 1.0/9 },
                { 8.0, 6.0, 1.0/5, 8.0, 9.0, 1.0 }
            };
            var W4 = new[,]
            {
                { 1.0, 1.0/5, 1.0/2, 2.0, 8.0, 1.0/5 },
                { 5.0, 1.0, 1.0/9, 9.0, 1.0/8, 1.0/3 },
                { 2.0, 9.0, 1.0, 8.0, 5.0, 8.0 },
                { 1.0/2, 1.0/9, 1.0/8, 1.0, 7.0, 1.0/9 },
                { 1.0/8, 8.0, 1.0/5, 1.0/7, 1.0, 1.0/5 },
                { 5.0, 3.0, 1.0/8, 9.0, 5.0, 1.0 }
            };
            var W5 = new[,]
            {
                { 1.0, 4.0, 2.0, 1.0/8, 1.0/4, 3.0 },
                { 1.0/4, 1.0, 6.0, 1.0/7, 4.0, 9.0 },
                { 1.0/2, 1.0/6, 1.0, 1.0/5, 8.0, 1.0/9 },
                { 8.0, 7.0, 5.0, 1.0, 9.0, 1.0/8 },
                { 4.0, 1.0/4, 1.0/8, 1.0/9, 1.0, 6.0 },
                { 1.0/3, 1.0/9, 9.0, 8.0, 1.0/6, 1.0 }
            };
            var W6 = new[,]
            {
                { 1.0, 1.0/4, 6.0, 9.0, 3.0, 9.0 },
                { 4.0, 1.0, 3.0, 1.0/3, 6.0, 1.0/2 },
                { 1.0/6, 1.0/3, 1.0, 1.0/3, 1.0/9, 1.0/6 },
                { 1.0/9, 3.0, 3.0, 1.0, 9.0, 1.0/6 },
                { 1.0/3, 1.0/6, 9.0, 1.0/9, 1.0, 2.0 },
                { 1.0/9, 2.0, 6.0, 6.0, 1.0/2, 1.0 }
            };
            var W7 = new[,]
            {
                { 1.0, 1.0/7, 1.0, 1.0/2, 8.0, 1.0/3 },
                { 7.0, 1.0, 6.0, 1.0/9, 5.0, 1.0/9 },
                { 1.0, 1.0/6, 1.0, 1.0/4, 2.0, 1.0/2 },
                { 2.0, 9.0, 4.0, 1.0, 5.0, 1.0/6 },
                { 1.0/8, 1.0/5, 1.0/2, 1.0/5, 1.0, 1.0/6 },
                { 3.0, 9.0, 2.0, 6.0, 6.0, 1.0 }
            };
            double[] E_prior = Prior_E(E);
            double[] W1_prior = Prior_W(W1);
            double[] W2_prior = Prior_W(W2);
            double[] W3_prior = Prior_W(W3);
            double[] W4_prior = Prior_W(W4);
            double[] W5_prior = Prior_W(W5);
            double[] W6_prior = Prior_W(W6);
            double[] W7_prior = Prior_W(W7);

            double w1 = Result_prior_w(E_prior, W1_prior);
            double w2 = Result_prior_w(E_prior, W2_prior);
            double w3 = Result_prior_w(E_prior, W3_prior);
            double w4 = Result_prior_w(E_prior, W4_prior);
            double w5 = Result_prior_w(E_prior, W5_prior);
            double w6 = Result_prior_w(E_prior, W6_prior);
            double w7 = Result_prior_w(E_prior, W7_prior);

            var result = new double[] { w1, w2, w3, w4, w5, w6, w7 };

            var max = 0.0;
            var index = 0;

            Console.WriteLine("Окончательные приоритеты альтернатив:");

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("W" + (i + 1) + " = " + result[i]);
                if (result[i] > max)
                {
                    max = result[i]; 
                    index = i;
                }
            }

            Console.WriteLine("Оптимальная альтернатива x" + (index + 1) + ", w" + (index + 1) + " = " + result[index] + ".");

            Console.WriteLine("Press any key to continue...");
        }
    }
}
