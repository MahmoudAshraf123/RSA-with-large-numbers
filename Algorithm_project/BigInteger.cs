using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Algorithm_Project
{
    class BigInteger
    {
        
        //constructor
        public BigInteger()
        {

        }
        //ADD fucntion
        public string ADD(string a, string b)
        {
            int sum;
            int counter = 0; // to stop adding in case of diffrence size
            StringBuilder arr;
            StringBuilder s;
            string s2;
            int arrsize;
            int arr1size, arr2size;
            if (a.Length > b.Length)
            {
                arr1size = a.Length;
                arr2size = b.Length;
                arrsize = a.Length + 1;
                counter = arr2size;
                arr = new StringBuilder("0" + a, arrsize + 1);
                s = new StringBuilder(a);
                s2 = b;
            }
            else
            {
                arr1size = b.Length;
                arr2size = a.Length;
                arrsize = b.Length + 1;
                counter = arr2size;
                arr = new StringBuilder("0" + b, arrsize + 1);
                s = new StringBuilder(b);
                s2 = a;
            }
            int carry = 0;

            for (int i = s.Length; i > 0; i--, arrsize--, arr1size--, arr2size--)
            {
                //Console.WriteLine("i am here");
                if (counter == 0)
                {
                    if (s[arr1size - 1] == '9' && carry == 1)
                    {
                        arr[arrsize - 1] = '0';
                        if (i == 1)
                        {
                            arr[arrsize - 2] = '1';
                        }
                    }
                    else
                    {
                        arr[arrsize - 1] = ((s[arr1size - 1] - '0') + carry).ToString()[0];
                        carry = 0;
                    }
                }
                else
                {
                    sum = (s[arr1size - 1] - '0') + (s2[arr2size - 1] - '0') + carry;
                    if (sum > 9)
                    {
                        arr[arrsize - 1] = (sum % 10).ToString()[0];
                        if (i != 1)
                        {
                            if (s[arr1size - 2] == '9')
                                carry = 1;
                            else
                            {
                                carry = 0;
                                s[arr1size - 2] = ((s[arr1size - 2] - '0') + (sum / 10)).ToString()[0];
                            }
                        }
                        else
                        {
                            arr[arrsize - 2] = (sum / 10) .ToString()[0];
                            carry = 0;
                        }
                    }
                    else
                    {
                        arr[arrsize - 1] = sum.ToString()[0];
                        carry = 0;
                    }
                    counter--;
                }
            }

            if (arr[0] == '0')
                return arr.Remove(0, 1).ToString();
            else
                return arr.ToString();
        }




        public string sub(string a, string b)
        {
            
            bool carry = false;
            int counter = b.Length;
            int arrsize = a.Length, arr1size = a.Length, arr2size = b.Length;
            StringBuilder arr = new StringBuilder(a, arrsize), s1 = new StringBuilder(a);     
            for (int i = 0; i < a.Length; i++, arr1size--, arr2size--, arrsize--)
            {
                if (counter == 0)
                {
                    if (s1[arr1size - 1] == '0' && carry == true)
                    {
                        arr[arrsize - 1] = ((s1[arr1size - 1] - '0') + 9).ToString()[0];

                    }
                    else if (carry == true)
                    {
                        carry = false;
                        arr[arrsize - 1] = ((s1[arr1size - 1] - '0') - 1).ToString()[0];
                    }
                    else
                        arr[arrsize - 1] = s1[arr1size - 1];

                }
                else
                {
                    if (s1[arr1size - 1] > b[arr2size - 1] && carry == false)
                    {
                        int r = (((s1[arr1size - 1])) - ((b[arr2size - 1])));
                        

                        arr[arrsize - 1] = ((s1[arr1size - 1]) - (b[arr2size - 1])).ToString()[0];

                        carry = false;
                    }
                    else if (s1[arr1size - 1] == b[arr2size - 1])
                    {
                        if (s1[arr1size - 1] == '0' && carry == true)
                        {
                            arr[arrsize - 1] = (((s1[arr1size - 1] - '0') + 9) - (b[arr2size - 1] - '0')).ToString()[0];

                        }
                        else if (carry == true)
                        {
                            s1[arr1size - 1] = ((s1[arr1size - 1] - '0') - 1).ToString()[0];
                            if (s1[arr1size - 1] < b[arr2size - 1])
                            {
                                arr[arrsize - 1] = (((s1[arr1size - 1] - '0') + 10) - (b[arr2size - 1] - '0')).ToString()[0];
                            }
                            else
                            {
                                arr[arrsize - 1] = ((s1[arr1size - 1] - '0') - (b[arr2size - 1] - '0')).ToString()[0];
                                carry = false;
                            }
                        }
                        else
                        {
                            arr[arrsize - 1] = '0';

                        }
                        

                    }
                    else
                    {
                        if (s1[arr1size - 1] == '0' && carry == true)
                        {
                            arr[arrsize - 1] = (((s1[arr1size - 1] - '0') + 9) - (b[arr2size - 1] - '0')).ToString()[0];

                        }
                        else if (carry == true)
                        {
                            s1[arr1size - 1] = ((s1[arr1size - 1] - '0') - 1).ToString()[0];
                            if (s1[arr1size - 1] < b[arr2size - 1])
                            {
                                arr[arrsize - 1] = (((s1[arr1size - 1] - '0') + 10) - (b[arr2size - 1] - '0')).ToString()[0];
                            }
                            else
                            {
                                arr[arrsize - 1] = ((s1[arr1size - 1] - '0') - (b[arr2size - 1] - '0')).ToString()[0];
                                carry = false;
                            }
                        }
                        else
                        {
                            arr[arrsize - 1] = (((s1[arr1size - 1] - '0') + 10) - (b[arr2size - 1] - '0')).ToString()[0];
                            carry = true;
                        }


                    }
                    counter--;
                }
            }
            int Counter = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '0')
                {
                    if (i == arr.Length - 1)
                    {
                        
                        return arr.Remove(0, Counter).ToString();

                    }
                    Counter++;

                }
                else
                    break;
            }
           
            return arr.Remove(0, Counter).ToString();

        }

        //Multiply func
        public string multiply(string Num1, string Num2)
        {
            int length;
            if (Num1.Length > Num2.Length)
                length = Num1.Length;
            else
                length = Num2.Length;
            //add zeros at the left to make each sring at the same size
            while (Num1.Length < length)
                Num1 = "0" + Num1;

            while (Num2.Length < length)
                Num2 = "0" + Num2;

            if (length == 1)
                return ((Num1[0] - '0') * (Num2[0] - '0')).ToString();

            string lhs0 = Num1.Substring(0, length / 2);
            string lhs1 = Num1.Substring(length / 2, length - length / 2);
            string rhs0 = Num2.Substring(0, length / 2);
            string rhs1 = Num2.Substring(length / 2, length - length / 2);

            string p0 = multiply(lhs0, rhs0);
            string p1 = multiply(lhs1, rhs1);
            string p2 = multiply(ADD(lhs0, lhs1), ADD(rhs0, rhs1));

            string R2 = ADD(p0, p1);
            string p3 = sub(p2, R2);

            for (int i = 0; i < 2 * (length - (length / 2)); i++)
                p0 = p0 + "0";
            for (int i = 0; i < length - (length / 2); i++)
                p3 = p3 + "0";

            
            string R = ADD(p0, p1);
            string result = ADD(R, p3);           
            int Counter = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == '0')
                {
                    if (i ==result.Length - 1)
                        return result.Remove(0, Counter);
                    Counter++;

                }
                else
                    break;
            }
            return result.Remove(0, Counter);
            
        }



        //division func 
        public string division(string x, string y)
        {
            if (y[0] == '0' && y.Length == 1)
            {
                return "0";
            }
            else if (sub(x, y) == "0")
            {
                return "1";
            }
            else if (bigger(x, y) == -1)
            {
                return "0";
            }
            else
            {
                return (ADD("1", division(sub(x, y), y)));

            }
        }
        //mod func 
        public string mod(string n, string b)
        {
            if (bigger(n, b) == -1)
                return n;


            return mod(sub(n, b), b);
            
        }

        
        //encrypt function
        public string encrypt(string x, string y, string p)
        {
            string res = "1";      // Initialize result 

            x = mod(x, p);  

            while (true)
            {
                // If y is odd, multiply x with result 
                if (mod(y, "2") != "0")
                    res = mod((multiply(res, x)), p);

                
                y = division(y, "2"); // y = y/2 
                x = mod((multiply(x, x)), p);
                if (y == "0")
                    break;
            }
            return res;
        }

        //decrypt function
        public string decrypt(string x, string y, string p)
        {
            string res = "1";      // Initialize result 

            x = mod(x, p);

            while (true)
            {
                // If y is odd, multiply x with result 
                if (mod(y, "2") != "0")
                    res = mod((multiply(res, x)), p);

                
                y = division(y, "2"); // y = y/2 
                x = mod((multiply(x, x)), p);
                if (y == "0")
                    break;
            }
            return res;
        }
        //to know thich number is bigger>>
        int bigger(string a, string b)
        {
            if (b.Length > a.Length)
                return -1;
            else if (b.Length < a.Length)
                return 1;
            for (int i = 0; i < a.Length; i++)
            {
                if (b[i] > a[i])
                {
                    return -1;
                }
                else if (b[i] == a[i])
                    continue;
                else
                    return 1;
            }
            return 1;
        }

    }
}


