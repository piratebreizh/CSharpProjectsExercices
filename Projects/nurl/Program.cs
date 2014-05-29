
using System;

namespace nurl
{
	/// <summary>
	/// Description of Program.
	/// </summary>	
	class Program
	{
		public static void Main(string[] args)
		{
			Nurl nurl = new Nurl();
			if(nurl.isArgsCorrect(args))
				nurl.routage(args);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		     

	}
}
