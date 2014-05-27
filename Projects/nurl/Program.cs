
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
			var isCorrect = nurl.isArgsCorrect(args);
			
			if(isCorrect)
				nurl.routage(args);
		}
		
	}
}
