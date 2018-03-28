using System;

namespace SmartArray_Test
{
    class UnderflowException : Exception
    {
        public UnderflowException(string s) : base(s) { }
    }
    class OverflowException : Exception
    {
        public OverflowException(string s) : base(s) { }
    }

    class SmartArray
    {
        int[] rgNums;
        int index;
        public SmartArray()
        {
            index = 5;
            rgNums = new int[5];
            for (int i = 0; i < index; i++)
                rgNums[i] = 0;
        }
        public SmartArray(int val)
        {
            index = val;
            rgNums = new int[index];
            for (int i = 0; i < index; i++)
                rgNums[i] = 0;
        }

        public void SetAtIndex(int idx, int val)
        {
            if (idx>=0 &&idx<index)
            {
                rgNums[idx] = val;

            }
            else if (idx<0)
            {
                throw new UnderflowException("UnderFlow Exception");
            }
            else
            {
                throw new OverflowException("Overflow Exception");

            }
        }

        public int GetAtIndex(int idx)
        {
            if (idx >= 0 && idx < index)
            {
                return rgNums[idx];

            }
            else if (idx < 0)
            {
                throw new UnderflowException("UnderFlow Exception");
            }
            else
            {
                throw new OverflowException("Overflow Exception");

            }
            //return 0;
        }

        public void PrintAllElements()
        {
            for (int i = 0; i < index; i++)
                Console.WriteLine(rgNums[i] + " ");

            Console.WriteLine();
        }

        public bool Find(int val)
        {
            for (int i = 0; i < index; i++)
            {
                if (rgNums[i]==val)
                {
                    return true;
                }
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

            Console.WriteLine("CHECK THIS: SmartArray starts with all zeros");
            sa.PrintAllElements();
            Console.WriteLine("\n*******************\n");

            try
            {
                Console.WriteLine("================= SetAtIndex =================");
                Console.WriteLine("AutoChecked: Can add at slot 0?");
                sa.SetAtIndex(0, 10);
                Console.WriteLine("Test Passed: Able to set element 0!");
            }
            catch (Exception e)
            {
                Console.WriteLine("TEST FAILED: UNABLE TO SET ELEMENT 0!");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Can add at slots 0-4?");
            testPassed = true;
            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
            {
                try
                {
                    sa.SetAtIndex(i, 10 * i);
                }
                catch (Exception e)
                {
                    Console.WriteLine("TEST FAILED: UNABLE TO SET ELEMENT {0}!", i);
                    Console.WriteLine(e.Message);
                    testPassed = false;
                    break; // out of the loop
                }
            }
            if (testPassed)
                Console.WriteLine("Test Passed: Able to set all elements!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to add at slot {0}?", SMART_ARRAY_SIZE);

            try
            {
                sa.SetAtIndex(SMART_ARRAY_SIZE, 10);
                Console.WriteLine("TEST FAILED: SET ELEMENT {0} DID NOT OVERFLOW (but should have)", SMART_ARRAY_SIZE);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Test Passed: Unable to set element {0}!", SMART_ARRAY_SIZE);
            }
            catch (Exception e)
            {
                Console.WriteLine("TEST FAILED: SET ELEMENT {0} FAILED, BUT FOR THE WRONG REASON", SMART_ARRAY_SIZE);
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n*******************\n");


            Console.WriteLine("AutoChecked: Should NOT be able to add at slot {0}?", SMART_ARRAY_SIZE + 10);
            try
            {
                sa.SetAtIndex(SMART_ARRAY_SIZE + 10, 10);
                Console.WriteLine("TEST FAILED: SET ELEMENT {0} DIDN'T OVERFLOW", SMART_ARRAY_SIZE + 10);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Test Passed: Unable to set element {0}!", SMART_ARRAY_SIZE);
            }
            catch (Exception e)
            {
                Console.WriteLine("TEST FAILED: SET ELEMENT {0} FAILED, BUT FOR THE WRONG REASON", SMART_ARRAY_SIZE);
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to add at slot -1?");
            try
            {
                sa.SetAtIndex(-1, 10);
                Console.WriteLine("TEST FAILED: SET ELEMENT -1 DIDN'T UNDERFLOW");
            }
            catch (UnderflowException e)
            {
                Console.WriteLine("Test Passed: Unable to set element -1!");
            }
            catch (Exception e)
            {
                Console.WriteLine("TEST FAILED: SET ELEMENT -1 FAILED, BUT FOR THE WRONG REASON");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to add at slot -10?");
            try
            {
                sa.SetAtIndex(-10, 10);
                Console.WriteLine("TEST FAILED: SET ELEMENT -10 DIDN'T UNDERFLOW");
            }
            catch (UnderflowException e)
            {
                Console.WriteLine("Test Passed: Unable to set element -10!");
            }
            catch (Exception e)
            {
                Console.WriteLine("TEST FAILED: SET ELEMENT -10 FAILED, BUT FOR THE WRONG REASON");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("CHECK THIS: Should see 0, 10, 20, 30, 40");
            sa.PrintAllElements();
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("================= GetAtIndex =================");
            int valueGotten;
            Console.WriteLine("AutoChecked: Can get from slot 0?");
            try
            {
                valueGotten = sa.GetAtIndex(0);
                if (valueGotten != 0)
                {
                    Console.WriteLine("TEST FAILED: UNEXPECTED VALUE FROM SLOT 0: (EXPECTED 0, GOT {0})", valueGotten);
                }
                else
                    Console.WriteLine("Test Passed: Able to get expected value from slot 0!");
            }
            catch (Exception e)
            {
                Console.WriteLine("TEST FAILED: UNABLE TO GET FROM SLOT 0");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Can get from slots 0-4?");
            testPassed = true;
            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
            {
                try
                {
                    valueGotten = sa.GetAtIndex(i);
                    if (valueGotten != 10 * i)
                    {
                        Console.WriteLine("TEST FAILED:  UNEXPECTED VALUE AT SLOT {0} (EXPECTED {1}, GOT {2})", i, i * 10, valueGotten);
                        testPassed = false;
                        break; // out of the loop
                    }
                    else
                        Console.WriteLine("Test Passed: Able to get expected value from slot 0!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("TEST FAILED: UNABLE TO GET FROM SLOT {0}", i);
                    Console.WriteLine(e.Message);
                    break;
                }
            }
            if (testPassed)
                Console.WriteLine("Test Passed: Able to get expected values!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to get from slot {0}?", SMART_ARRAY_SIZE);
            try
            {
                valueGotten = sa.GetAtIndex(SMART_ARRAY_SIZE);
                Console.WriteLine("TEST FAILED: GET FROM ELEMENT {0} DIDN'T OVERFLOW?", SMART_ARRAY_SIZE);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Test Passed: Unable to get element at SMART_ARRAY_SIZE!");
            }
            catch (Exception e)
            {
                Console.WriteLine("TEST FAILED: GET ELEMENT AT SMART_ARRAY_SIZE FAILED, BUT FOR THE WRONG REASON");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to get from slot {0}?", SMART_ARRAY_SIZE + 10);
            try
            {
                valueGotten = sa.GetAtIndex(SMART_ARRAY_SIZE + 10);
                Console.WriteLine("TEST FAILED: GET FROM ELEMENT {0} DIDN'T OVERFLOW?", SMART_ARRAY_SIZE + 10);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Test Passed: Unable to get element at SMART_ARRAY_SIZE!");
            }
            catch (Exception e)
            {
                Console.WriteLine("TEST FAILED: GET ELEMENT AT SMART_ARRAY_SIZE FAILED, BUT FOR THE WRONG REASON");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to get from slot -1?");
            try
            {
                valueGotten = sa.GetAtIndex(-1);
                Console.WriteLine("TEST FAILED: GET FROM ELEMENT -1 DIDN'T UNDERFLOW");
            }
            catch (UnderflowException e)
            {
                Console.WriteLine("Test Passed: Unable to get element at -1!");
            }
            catch (Exception e)
            {
                Console.WriteLine("TEST FAILED: GET ELEMENT AT -1 FAILED, BUT FOR THE WRONG REASON");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to get from slot -10?");
            try
            {
                valueGotten = sa.GetAtIndex(-10);
                Console.WriteLine("TEST FAILED: GET FROM ELEMENT -10 DIDN'T UNDERFLOW");
            }
            catch (UnderflowException e)
            {
                Console.WriteLine("Test Passed: Unable to get element at -10!");
            }
            catch (Exception e)
            {
                Console.WriteLine("TEST FAILED: GET ELEMENT AT -10 FAILED, BUT FOR THE WRONG REASON");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("================= Find =================");
            Console.WriteLine("AutoChecked: Can find 0?");
            if (!sa.Find(0))
                Console.WriteLine("TEST FAILED: UNABLE TO FIND VALUE 0!");
            else
                Console.WriteLine("Test Passed: Able to find value 0!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Can find the values in slots 0-4?");
            testPassed = true;
            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
            {
                try
                {
                    valueGotten = sa.GetAtIndex(i);
                    if (!sa.Find(valueGotten)) // test by getting from array
                    {
                        Console.WriteLine("TEST FAILED: UNABLE TO FIND {0}!", valueGotten);
                        testPassed = false;
                        break; // out of the loop
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("TEST FAILED: FIND (iteration " + i + ") FAILED BECAUSE GETATINDEX FAILED");
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
