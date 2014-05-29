using System;
using NUnit.Framework;

namespace nurl
{
	[TestFixture]
	public class NurlTest
	{
		
		
		static string [] argsOkPourGet = {"get","-url","https://www.youtube.com/watch?v=o1tj2zJ2Wvg"};
		static string [] argsOkPourTest = {"test","-url","https://www.youtube.com/watch?v=o1tj2zJ2Wvg"};
		static string file1 = @"c:\folder\myfile.txt";
		
		[Test]
		public void isArgsCorrectTest()
		{
			//given
			var nurl = new Nurl();
			
			//when
			var result = nurl.isArgsCorrect(argsOkPourGet); 
			
			//then
			Assert.IsTrue(result,"C'est bien un get ou un test");
		}
		
		/**Test pour la fonction Nurl.isURL
		* 
		*/
		[Test]
		public void testValiderAdresseURL()
		{
			//given
			string url = argsOkPourGet[2];
			var nurl = new Nurl();
			
			//when
			var isURL = nurl.isURL(url);						
			
			//then
			Assert.IsTrue(isURL);
		}
		
		
		/** Test afin de savoir si le code source de la page HTML à bien été retourné
		 * 
		*/
		[Test]
		public void testRetournSource(){
			//given
			string url = argsOkPourGet[2];
			var nurl = new Nurl();
			
			//when
			var contentHTML = nurl.loadindSourceHtmlPage(url);
			
			//then
			Assert.NotNull(contentHTML);
		}
		
		
		[Test]
		public void testisFolderOrFilePath(){
			//given
			string path = file1;
			var nurl = new Nurl();
			
			//when
			var isPath = nurl.isFolderOrFilePath(path);
			
			//then
			Assert.IsTrue(isPath);
		}
		
	
		
	}
}
