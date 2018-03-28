using System;

namespace SmartArray_Test
{

    //    // Your enum goes here:
    enum ErrorCode
    {
        NoError,
        Underflow,
        Overflow,
    
    };

    class SmartArray
    {
        int[] rgNums;
        int index;
        //// Running time for this method:
        //// Explanation (Why did you choose that running time?):
        public SmartArray()
        {
            index = 5;
            for (int i = 0; i < 5; i++)
                rgNums[i] = 0;
        }

        //// Running time for this method:
        //// Explanation (Why did you choose that running time?):
        /*  Also called "Linear time."  Normally occurs whenever you have to access every single element of the array. 
         *   Accessing every single element of the array twice ends up being Y = 2N, 
         *   but since the O() notation allows us to ignore coefficients, it ends up being the same thing as O(N). 
         *    Similarly for accessing each element three times, or each element four times, etc.
         *      As long as the number of times we access each element is limited, and unrelated to the number of elements, 
         *      then we'll end up with a linear runtime.
         *      Good examples of this are finding the maximum in an unsorted array,
         *       or printing every single element of an array out.
         *  When we create an array, C# puts a zero into each space in the array,
         *   and therefore it allocates the following code for us.  
         *   Because it’s a loop that goes from 0 to N = length of the array, 
         *   the following line of code runs in linear time (based on the size of the array that’s being created):
                  int [] array = new int[20]; 

         * 
         * */
        public SmartArray(int howMany)
        {
            index = howMany;
            rgNums = new int[howMany];
            for (int i = 0; i < index; i++)
                rgNums[i] = 0;
        }

        //// Running time for this method:
        //// Explanation (Why did you choose that running time?):
        /*This called "constant time" – basically, not matter how many input elements 
         * there are (no matter how many array elements, etc), we'll never do more than X steps.
         *   You'll typically see this in situations wherein you're asked to access a 
         *   single element of the array (for example, get the first element of the array & 
         *   return it – it'll take the same amount of time whether there are 10, or 10 million, elements in the array)
         *   Example of Code that run in constant time:
         *   	Array access, such as rgNums[10] = 20;
         * */

        public ErrorCode SetAtIndex(int idx, int val)
        {

            ErrorCode value = ErrorCode.NoError;
            if (idx > -1 && idx < index)
            {
                rgNums[idx] = val;
               // Console.WriteLine(ErrorCode.NoError);
                if (value == ErrorCode.NoError)
                    return ErrorCode.NoError;
            }
            if (idx < 0)
            {
                value = ErrorCode.Underflow;
                return ErrorCode.Underflow;
            }
            else
            {        value = ErrorCode.Overflow;
            return ErrorCode.Overflow;
        }
        }

        //// Running time for this method:
        //// Explanation (Why did you choose that running time?):
        /*This called "constant time" – basically, not matter how many input elements 
        * there are (no matter how many array elements, etc), we'll never do more than X steps.
        *   You'll typically see this in situations wherein you're asked to access a 
        *   single element of the array (for example, get the first element of the array & 
        *   return it – it'll take the same amount of time whether there are 10, or 10 million, elements in the array)
       
        * */

        public ErrorCode GetAtIndex(int idx, out int val)
        {
            ErrorCode value = ErrorCode.NoError;
            if (idx > -1 && idx < index)
            {
                val=rgNums[idx];
                if (value == ErrorCode.NoError)
                    return ErrorCode.NoError;
            }
            if (idx <0)
            {
                val = Int32.MinValue;
                value = ErrorCode.Underflow;
                return ErrorCode.Underflow;
            }
            else
            {
                val = Int32.MinValue;
                value = ErrorCode.Overflow;
                return ErrorCode.Overflow;
            }
        }

        //// Running time for this method:
        //// Explanation (Why did you choose that running time?):
        /*This called "constant time" – basically, not matter how many input elements 
       * there are (no matter how many array elements, etc), we'll never do more than X steps.
       *   You'll typically see this in situations wherein you're asked to access a 
       *   single element of the array (for example, get the first element of the array & 
       *   return it and print each element in array – it'll take the same amount of time whether there are 10,
       *    or 10 million, elements in the array)

       * */
        public void PrintAllElements()
        {
            for (int i=0;i<index;i++)
            {
                Console.WriteLine(rgNums[i] + "  ");
            }
            Console.WriteLine();
        }


        //// Running time for this method:
        //// Explanation (Why did you choose that running time?):
        /*It takes constant time whihc is equal to N or number of elements in array, in best case if element found at 
         * 1st indes it will takes O(1) time, in worst it takes O(N) but both are linear so it takes linear time
         * */
        public bool Find(int val)
        {
            for (int i = 0; i < index; i++)
            {
                if (rgNums[i] == val)
                    return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            

                        SmartArray sa = new SmartArray();
                        const int SMART_ARRAY_SIZE = 5;
                        bool testPassed = false;
                        ErrorCode ec;
                        sa = new SmartArray(SMART_ARRAY_SIZE);
                        Console.WriteLine("CHECK THIS: SmartArray starts with all zeros");
                        sa.PrintAllElements();
                        Console.WriteLine("\n*******************\n");


                        Console.WriteLine("================= SetAtIndex =================");
                        Console.WriteLine("AutoChecked: Can add at slot 0?");
                        if ( (ec = sa.SetAtIndex(0, 10))!= ErrorCode.NoError)
                            Console.WriteLine("TEST FAILED: UNABLE TO SET ELEMENT 0! (ErrorCode: {0})", ec);
                        else
                            Console.WriteLine("Test Passed: Able to set element 0!");
                        Console.WriteLine("\n*******************\n");

                        Console.WriteLine("AutoChecked: Can add at slots 0-4?");
                        testPassed = true;
                        for (int i = 0; i < SMART_ARRAY_SIZE; i++)
                        {
                            if ((ec = sa.SetAtIndex(i, 10 * i)) != ErrorCode.NoError)
                            {
                                Console.WriteLine("TEST FAILED: UNABLE TO SET ELEMENT {0}! (ErrorCode: {1})", i, ec);
                                testPassed = false;
                                break; // out of the loop
                            }
                        }
                        if(testPassed)
                            Console.WriteLine("Test Passed: Able to set all elements!");
                        Console.WriteLine("\n*******************\n");

                        Console.WriteLine("AutoChecked: Should NOT be able to add at slot {0}?", SMART_ARRAY_SIZE);

                        if ((ec = sa.SetAtIndex(SMART_ARRAY_SIZE, 10)) != ErrorCode.Overflow)
                            Console.WriteLine("TEST FAILED: SET ELEMENT {0} DIDN'T OVERFLOW (ErrorCode: {1})", SMART_ARRAY_SIZE, ec);
                        else
                            Console.WriteLine("Test Passed: Unable to set element {0}!", SMART_ARRAY_SIZE);
                        Console.WriteLine("\n*******************\n");

                        Console.WriteLine("AutoChecked: Should NOT be able to add at slot {0}?", SMART_ARRAY_SIZE+10);
                        if ((ec = sa.SetAtIndex(SMART_ARRAY_SIZE+10, 10)) != ErrorCode.Overflow)
                            Console.WriteLine("TEST FAILED: SET ELEMENT {0} DIDN'T OVERFLOW (ErrorCode: {1})", SMART_ARRAY_SIZE+10, ec); 
                        else
                            Console.WriteLine("Test Passed: Unable to set element {0}!", SMART_ARRAY_SIZE + 10);
                        Console.WriteLine("\n*******************\n");

                        Console.WriteLine("AutoChecked: Should NOT be able to add at slot -1?");
                        if ((ec = sa.SetAtIndex(-1, 10)) != ErrorCode.Underflow)
                            Console.WriteLine("TEST FAILED: SET ELEMENT -1 DIDN'T UNDERFLOW! ErrorCode: {0})", ec);
                        else
                            Console.WriteLine("Test Passed: Unable to set element -1!");
                        Console.WriteLine("\n*******************\n");

                        Console.WriteLine("AutoChecked: Should NOT be able to add at slot -10?");
                        if ((ec = sa.SetAtIndex(-10, 10)) != ErrorCode.Underflow)
                            Console.WriteLine("TEST FAILED: SET ELEMENT -10 DIDN'T UNDERFLOW! ErrorCode: {0})", ec);
                        else
                            Console.WriteLine("Test Passed: Unable to set element -1!");
                        Console.WriteLine("\n*******************\n");

                        Console.WriteLine("CHECK THIS: Should see 0, 10, 20, 30, 40");
                        sa.PrintAllElements();
                        Console.WriteLine("\n*******************\n");

                        Console.WriteLine("================= GetAtIndex =================");
                        int valueGotten;
                        Console.WriteLine("AutoChecked: Can get from slot 0?");
                        ec = sa.GetAtIndex(0, out valueGotten);
                        if (ec != ErrorCode.NoError)
                        {
                            Console.WriteLine("TEST FAILED: UNABLE TO GET FROM SLOT 0 (ErrorCode: {0})", ec);
                        }
                        else if (valueGotten != 0)
                        {
                            Console.WriteLine("TEST FAILED: UNEXPECTED VALUE FROM SLOT 0: (EXPECTED 0, GOT {0})", valueGotten);
                        }
                        else
                            Console.WriteLine("Test Passed: Able to get expected value from slot 0!");
                        Console.WriteLine("\n*******************\n");

                            Console.WriteLine("AutoChecked: Can get from slots 0-4?");
                            testPassed = true;
                            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
                            {
                                ec = sa.GetAtIndex(i, out valueGotten);
                                if (ec != ErrorCode.NoError)
                                {
                                    Console.WriteLine("TEST FAILED: UNABLE TO GET FROM SLOT {0} (ErrorCode: {1})", i, ec);
                                }
                                else if (valueGotten != 10 * i)
                                {
                                    Console.WriteLine("TEST FAILED:  UNEXPECTED VALUE AT SLOT {0} (EXPECTED {1}, GOT {2})", i, i*10, valueGotten);
                                    testPassed = false;
                                    break; // out of the loop
                                }
                            }
                            if (testPassed)
                                Console.WriteLine("Test Passed: Able to get expected values!");
                            Console.WriteLine("\n*******************\n");


                            Console.WriteLine("AutoChecked: Should NOT be able to get from slot {0}?", SMART_ARRAY_SIZE);
                            if ( (ec = sa.GetAtIndex(SMART_ARRAY_SIZE, out valueGotten)) != ErrorCode.Overflow)
                                Console.WriteLine("TEST FAILED: GET FROM ELEMENT {0} DIDN'T OVERFLOW (ErrorCode: {1})?", SMART_ARRAY_SIZE, ec);
                            else if (valueGotten != Int32.MinValue)
                                Console.WriteLine("TEST FAILED: GET FROM ELEMENT {0} DIDN'T PRODUCE Int32.MinValue", SMART_ARRAY_SIZE);
                            else
                                Console.WriteLine("Test Passed: Unable to get from slot {0}!", SMART_ARRAY_SIZE);
                            Console.WriteLine("\n*******************\n");

                            Console.WriteLine("AutoChecked: Should NOT be able to get from slot {0}?", SMART_ARRAY_SIZE+10);
                            if ((ec = sa.GetAtIndex(SMART_ARRAY_SIZE+10, out valueGotten)) != ErrorCode.Overflow)
                                Console.WriteLine("TEST FAILED: GET FROM ELEMENT {0} DIDN'T OVERFLOW (ErrorCode: {1})?", SMART_ARRAY_SIZE+10, ec);
                            else if (valueGotten != Int32.MinValue)
                                Console.WriteLine("TEST FAILED: GET FROM ELEMENT {0} DIDN'T PRODUCE Int32.MinValue", SMART_ARRAY_SIZE+10);
                            else
                                Console.WriteLine("Test Passed: Unable to get from slot {0}!", SMART_ARRAY_SIZE+10);
                            Console.WriteLine("\n*******************\n");

                            Console.WriteLine("AutoChecked: Should NOT be able to get from slot -1?");
                            if ((ec = sa.GetAtIndex(-1, out valueGotten)) != ErrorCode.Underflow)
                                Console.WriteLine("TEST FAILED: GET FROM ELEMENT {0} DIDN'T UNDERFLOW(ErrorCode: {1})", -1, ec);
                            else if (valueGotten != Int32.MinValue)
                                Console.WriteLine("TEST FAILED: GET FROM ELEMENT {0} DIDN'T PRODUCE Int32.MinValue", -1);
                            else
                                Console.WriteLine("Test Passed: Unable to get from slot {0}!", SMART_ARRAY_SIZE); 

                            Console.WriteLine("\n*******************\n");

                            Console.WriteLine("AutoChecked: Should NOT be able to get from slot -10?");
                            if ((ec = sa.GetAtIndex(-10, out valueGotten)) != ErrorCode.Underflow)
                                Console.WriteLine("TEST FAILED: GET FROM ELEMENT {0} DIDN'T UNDERFLOW(ErrorCode:{1})", -10, ec);
                            else if (valueGotten != Int32.MinValue)
                                Console.WriteLine("TEST FAILED: GET FROM ELEMENT {0} DIDN'T PRODUCE Int32.MinValue", -10);
                            else
                                Console.WriteLine("Test Passed: Unable to get from slot {0}!", SMART_ARRAY_SIZE);
                            Console.WriteLine("\n*******************\n");


                            Console.WriteLine("================= Find =================");
                            Console.WriteLine("AutoChecked: Can find 0?");
                            if (! sa.Find(0))
                                Console.WriteLine("TEST FAILED: UNABLE TO FIND VALUE 0!");
                            else
                                Console.WriteLine("Test Passed: Able to find value 0!");
                            Console.WriteLine("\n*******************\n");

                            Console.WriteLine("AutoChecked: Can find the values in slots 0-4?");
                            testPassed = true;
                            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
                            {
                                ec = sa.GetAtIndex(i, out valueGotten);
                                if (ec != ErrorCode.NoError)
                                {
                                    Console.WriteLine("TEST FAILED:UNABLE TO GET ELEMENT AT SLOT {0} (ErrorCode: {1})!", i, ec);
                                    testPassed = false;
                                    break;
                                }  // technically don't need the 'else'....
                                else if (!sa.Find(valueGotten)) // test by getting from array
                                {
                                    Console.WriteLine("TEST FAILED: UNABLE TO FIND {0}!", valueGotten);
                                    testPassed = false;
                                    break; // out of the loop
                                }
                            }
                            if (testPassed)
                                Console.WriteLine("Test Passed: Able to find values that are already in the array!");
                            Console.WriteLine("\n*******************\n");

                            Console.WriteLine("AutoChecked: Can find the values calculated to be in slots 0-4?");
                            testPassed = true;
                            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
                            {
                                if (!sa.Find(i * 10)) // test by re-calculating the result
                                {
                                    Console.WriteLine("TEST FAILED: UNABLE TO FIND {0}!", i * 10);
                                    testPassed = false;
                                    break; // out of the loop
                                }
                            }
                            if (testPassed)
                                Console.WriteLine("Test Passed: Able to find values calculated to be in the array!");
                            Console.WriteLine("\n*******************\n");

                            Console.WriteLine("AutoChecked: Should NOT be able to find -1?");
                            if (sa.Find(-1))
                                Console.WriteLine("TEST FAILED: ABLE TO FIND -1, WHICH SHOULD NOT BE PRESENT");
                            else
                                Console.WriteLine("Test Passed: Unable to find nonexistent value -1!");
                            Console.WriteLine("\n*******************\n");

                            Console.WriteLine("AutoChecked: Should NOT be able to find -10?");
                            if (sa.Find(-10))
                                Console.WriteLine("TEST FAILED: ABLE TO FIND -10, WHICH SHOULD NOT BE PRESENT");
                            else
                                Console.WriteLine("Test Passed: Unable to find nonexistent value -10!");
                            Console.WriteLine("\n*******************\n");

                            Console.WriteLine("AutoChecked: Should NOT be able to find 11?");
                            if (sa.Find(11))
                                Console.WriteLine("TEST FAILED: ABLE TO FIND 11, WHICH SHOULD NOT BE PRESENT");
                            else
                                Console.WriteLine("Test Passed: Unable to find nonexistent value 11!");
                            Console.WriteLine("\n*******************\n");
            Console.ReadLine();

            
        }
    }
}
