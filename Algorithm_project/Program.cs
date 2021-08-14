using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Algorithm_Project
{
    class Program
    {
        static string num1, num2;
        static string Resault;
        
        static void Main(string[] args)
        {
            //calculate the time
            Console.WriteLine(System.Environment.TickCount);
            read();
            Console.WriteLine(System.Environment.TickCount);
        }

        /////////////////////read and write func
        public static void read()
        {
            try
            {
                FileStream F;
                //open the file stream

                F = new FileStream("SampleRSA.txt", FileMode.Open);
               
                StreamReader sr = new StreamReader(F);
                BigInteger rsa = new BigInteger();
                int N,r; // number of test cases
                string n,e,m;
                
                N = Int32.Parse(sr.ReadLine());
                
                
                //Console.WriteLine(System.Environment.TickCount.ToString());
                //loop on test cases
                for (int a = 0; a < N; a++)
                {

                    n = sr.ReadLine();
                
                    //read second number
                    e = sr.ReadLine();
                   
                    m = sr.ReadLine();
                    r = Int32.Parse(sr.ReadLine());
                    Resault = rsa.multiply( n, e);
                    if(r==1)
                        Resault = rsa.decrypt(m, e, n);
                    else
                        Resault = rsa.encrypt(m, e, n);
                    
                    write(Resault, a, "SampleOutPut.txt");
               
                }
                //Console.WriteLine(System.Environment.TickCount.ToString());
                sr.Close();
                F.Close();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            

        }

        public static void write(string Number,int a,string fileName )
        {
            FileStream F;
            if(a==0)
                F = new FileStream(fileName, FileMode.Create);
            else
                F = new FileStream(fileName, FileMode.Append);
            StreamWriter sw = new StreamWriter(F);
            sw.WriteLine(Number);
            
            sw.Close();           
            F.Close();
        }
    }
}
