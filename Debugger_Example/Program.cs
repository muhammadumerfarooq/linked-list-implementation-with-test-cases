using System;

namespace Debugger_Example
{
	class Class1
	{
		static void Main(string[] args)
		{
			int [] nums = new int[] {5, 6, 1, 3, 8, -1, 0, 10};

			PrintArray(nums);
			Console.WriteLine("*************************************");
			BubbleSort(nums);
			PrintArray(nums);
			Console.WriteLine("*************************************");

			// Uncomment the following line, and try out your debugging skills!
			 ProgramToDebug.problem();
		}
	
		public static void PrintArray(int[] theArray)
		{
			for(int i = 0; i< theArray.Length; i++)
			{
				Console.WriteLine(theArray[i]);
			}
		}

		public static void BubbleSort(int [] theArray)
		{
			int lastSwapped;
			for(int counter = theArray.Length; counter >= 0 ; counter--)
			{
				for(int i = 0; i < counter-1; i++)
				{
					if(theArray[i] > theArray[i+1])
					{
						lastSwapped = theArray[i];
						theArray[i] = theArray[i+1];
						theArray[i+1] = lastSwapped;
					}
				}
			}
		}

	}
}
