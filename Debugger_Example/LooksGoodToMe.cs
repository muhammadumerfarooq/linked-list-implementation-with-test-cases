using System;

class Summarizer
{
	private float upperLimit;
	private float incr;

	public Summarizer() : this(0.0F, 0.1F)
	{
	}

	public Summarizer(float sumUpToThisNumber) : this(sumUpToThisNumber, 0.1F)
	{
	}

	public Summarizer(float sumUpToThisNumber , float incrBy )
	{
		upperLimit = sumUpToThisNumber;
		incr = incrBy;
	}

	public double computeAnswer()
	{
		float total = 0.0F;
		float counter = 0.0F;
		while(counter != upperLimit)
		{	
			total += counter;
			counter+=incr;
		}
		return total;
	}
}

class ProgramToDebug
{
	public static void problem()
	{
		Summarizer s1 = new Summarizer(2.2F);
		Summarizer s2 = new Summarizer(3.0F);
		Summarizer s3 = new Summarizer(5.0F, 1.0F);

		Console.WriteLine("First answer:  {0}", s1.computeAnswer() );
		Console.WriteLine("Second answer: {0}", s2.computeAnswer() );
		Console.WriteLine("Third answer:  {0}", s3.computeAnswer() );
	}
}