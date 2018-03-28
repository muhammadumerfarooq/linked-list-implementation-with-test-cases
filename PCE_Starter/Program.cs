using System;
using System.Collections;
using System.Collections.Generic;

namespace PCE_StarterProject
{


    class What_Is_A_Stack
    {
        // Put your answer here (in comments)
        //Stack is such DataStore whose lenght is constant in array but in linked list and generic array its length increases
        // with increase in no of inputs, stack works on basis of first in last out, the item inserted first is popped out last
        // the difference between gereric stack and array is in generic stack to pop out one element in middle of stack you
        //have to pop out all elements that come first so it means there is no direct accessing but in array you can have direct access 
        // and its size is fixed but in generic stack its size is never fixed.
    }

    class Basic_AbsValComparer_Test_Code
    {
        public void RunExercise()
        {
            AbsValComparer absolute_val_comp = new AbsValComparer();

            List<double> nums = new List<double>();

            nums.Add(20.4);
            nums.Add(-20.4);
            nums.Add(-10.3);
            nums.Add(3.1);
            nums.Add(-4.2);

            Console.WriteLine("Before sorting:\n");
            foreach( double num in nums)
            {
                Console.WriteLine(num);
            }

            nums.Sort(absolute_val_comp);

            Console.WriteLine("\nAfter sorting\n");

            foreach (double num in nums)
            {
                Console.WriteLine(num);
            }

            double[] nums_to_find = { 3.1, -4.2, -20.4, 999 };
            foreach( double targetNum in nums_to_find)
            {
                int loc = nums.BinarySearch(targetNum, absolute_val_comp);
                if (loc >= 0)
                    Console.WriteLine("Found {0} at location {1}", targetNum, loc);
                else
                    Console.WriteLine("Did not find {0}", targetNum);
            }
        }
    }


    class Basic_Generic_Test_Code
    {
        public void RunExercise()
        {
            //These lines of code have been commented out.
            // They won't compile until you implement the generic
            // BasicGeneric class.

            // Note that you should NOT modify this code at all:

            //////////////// ints /////////////////////////////////////////////
            Console.WriteLine("=============================");
            Console.WriteLine("Test for INT");
            Console.WriteLine("=============================\n");

            BasicGeneric<int> basic_int = new BasicGeneric<int>();
            int intValueToStore = 100;
            basic_int.SetItem(intValueToStore);

            Console.WriteLine("Stored {0}, Print() tells us:", intValueToStore);
            basic_int.Print();

            double intCheckVal = basic_int.GetItem();
            Console.WriteLine("Using Get, got back: {0}", intCheckVal);
            if (intCheckVal != intValueToStore)
                Console.WriteLine("\tERROR: checkVal is not {0}", intValueToStore);
            else
                Console.WriteLine("\tGetItem appeared to work!");

            //////////////// doubles //////////////////////////////////////////
            Console.WriteLine("\n=============================");
            Console.WriteLine("Test for DOUBLE");
            Console.WriteLine("=============================\n");
            BasicGeneric<double> basic_double = new BasicGeneric<double>();
            double doubleValueToStore = 3.14159;
            basic_double.SetItem(doubleValueToStore);

            Console.WriteLine("Stored {0}, Print() tells us:", doubleValueToStore);
            basic_double.Print();

            double doubleCheckVal = basic_double.GetItem();
            Console.WriteLine("Using Get, got back: {0}", doubleCheckVal);
            if (doubleCheckVal != doubleValueToStore)
                Console.WriteLine("\tERROR: checkVal is not {0}", doubleValueToStore);
            else
                Console.WriteLine("\tGetItem appeared to work!");

            //////////////// strings //////////////////////////////////////////
            Console.WriteLine("\n=============================");
            Console.WriteLine("Test for STRING");
            Console.WriteLine("=============================\n");

            BasicGeneric<string> basic_string = new BasicGeneric<string>();
            string stringValueToStore = "fun  text here";
            basic_string.SetItem(stringValueToStore);

            Console.WriteLine("Stored {0}, Print() tells us:", stringValueToStore);
            basic_string.Print();

            string stringCheckVal = basic_string.GetItem();
            Console.WriteLine("Using Get, got back: {0}", stringCheckVal);

            // != is ok for strings in C#, but not in Java
            if (stringCheckVal != stringValueToStore)
                Console.WriteLine("\tERROR: checkVal is not {0}", stringValueToStore);
            else
                Console.WriteLine("\tGetItem appeared to work!");
        }
    }
    class Using_DotNets_Stack

    {
        /* O(1) it means your method takes constant time  e.g. x=1, or y=2 it takes cosntant time or adding two numbers 
     * O(N) it means the method takes linear time, here linear is different from constant in such a way that 
     * constant time remains same but linear may vary depending upon the value of N so here N is the no of times the loops runs
     * 
     * */
       public static Stack<int> RunExcersie()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            return stack;
        }

    }
    class Reversing_User_Input
    {
        Stack<int> stack;
        Stack<int> stack1;

        public Reversing_User_Input()
        {
            stack = new Stack<int>();
            stack1 = new Stack<int>();

        }
        public void RunExcersie(int val)
        {
           
            stack.Push(val);
           
        }
        public void printreverse()
        {
            while (stack.Count!=0)
            {
                Console.WriteLine(stack.Peek());
                stack.Pop();
                
            }
            /*
            while (stack.Count != 0 || stack1.Count!=0)
            {
                while (true)
                    {
                    if (stack.Count == 0)
                        break;
                    if (stack.Count == 1)
                    {
                        Console.WriteLine(stack.Peek());
                        stack.Pop();
                    }
                    else { 
                    int num = stack.Pop();
                    stack1.Push(num);
                    }
                }
                stack.Clear();
                while(stack1.Count!=0)
                {
                    if (stack1.Count == 1)
                    {
                        Console.WriteLine(stack1.Peek());
                        stack1.Pop();
                    }

                    else { 
                    int num = stack1.Pop();
                    stack.Push(num);
                    }
                }
                stack1.Clear();
            }
        */}
        
    }
    class BasicGeneric<T>
    {
        private T variable;
        public BasicGeneric()
        {

            //variable= new T;
            /*for (int i = 0; i < 4; i++)
                variable[i] = T value;
            */
        }
        public void storedItem(T item)
        {
            variable = item;
        }
        public T GetItem()
        {
            //          object obj = stack.Pop();
            //            return obj;
            return variable;
        }
        public void SetItem(T item)
        {
            variable = item;
        }
        public void Print()

        {
            Console.WriteLine(variable.ToString());
        }
    }
    class AbsValComparer : IComparer<Double>
    {
        public int Compare(Double x, Double y)
        {
            return x.CompareTo(y);
            
        }
    }
    class What_Is_An_Enum
    {
        // What is an enum? Why would you want to use one?
        /*
         * An enumeration is a set of named integer constants. An enumerated type is declared using the enum keyword.
         * C# enumerations are value data type. In other words, enumeration contains its own values and cannot inherit or cannot pass inheritance.
         * e.g.  class EnumProgram
                   {
                      enum Days { Sun, Mon, tue, Wed, thu, Fri, Sat };
                    }
         * */
        // Why is an enum better than a public const int? (or a public static readonly int)?
        // enum is better because it can provide you with alot of different constants set where as in int you have limited choice
        //enum is more generic if you have differnet options for your choice you cannot you int because int can store alot of genric choices 
        // e,g,  enum Days { Sun, Mon, tue, Wed, thu, Fri, Sat };
    }
    class Program
    {
    
        static void Main(string[] args)
        {
            Basic_Generic_Test_Code bas = new Basic_Generic_Test_Code();
            bas.RunExercise();
            Basic_AbsValComparer_Test_Code basic = new Basic_AbsValComparer_Test_Code();
            basic.RunExercise();
            // BasicGeneric bas = new BasicGeneric();
            /*bas.storedItem("3.14343");
            bas.storedItem("3.14");
            bas.storedItem("5543");
            bas.storedItem("fddfgdfgdfg");
            bas.storedItem("100");
            bas.print();
            */
            /*
            while(true)
            {
                Console.WriteLine(" Please type any thing any data type value");
                string s = Console.ReadLine();
                bas.storedItem(s);
                Console.WriteLine("Press 1 to print data and press 2 to Get data or press anyting else to quit");
                 s = Console.ReadLine();
                if (s == "1")
                {
                    object obj = bas.getitem();
                    Console.WriteLine(obj.ToString());
                }
                else if (s == "2")
                {
                    bas.print();
                    Console.WriteLine("Now Stack is empty ");
                }
                else
                    break;

            }
            */

            Reversing_User_Input rever = new Reversing_User_Input();
            

                        int num = 10;

                        while (num > 0)
                        {

                            Console.WriteLine(" Please type a number");
                Console.WriteLine("Please type a non-negative number to stop");


                string s = Console.ReadLine();
                 num = int.Parse(s);
                if(num>=0)
                rever.RunExcersie(num);

                        }
            rever.printreverse();

                        
            //Using_DotNets_Stack dotnet = new Using_DotNets_Stack();

            var stack = Using_DotNets_Stack.RunExcersie();
            Console.WriteLine("--- Stack elements are ---");
            foreach (int i in stack)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
