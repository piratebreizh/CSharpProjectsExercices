using System;
using NUnit.Framework;
using System.Text.RegularExpressions;
using System.Net;

namespace nurl
{
	/// <summary>
	/// Description of Nurl.
	/// </summary>
	public class Nurl
	{
		

		public Nurl()	
		{
		}
		
		public string getContent(string URL)
		{
			return "<h1>hello</h1>";
		}
		
		public void saveContent(string URL)
		{
			
		}
		
		public void showContent(string URL)
		{
			
		}
		
		/**
		 * Si nos options lors de l'execution du programme comporte la notion GET en args[0] on rentre dans cette fonction 
		**/
		public void Get(string[] args)
		{
			var contenuWEB = loadindSourceHtmlPage(args[3]);
			
			if(args.Length==5){
				if(args[3].Equals("-save") && isFolderOrFilePath(args[4])){
					ecritureDansFichierContenuWEB(contenuWEB,args[4]);
				}
			}else if (args.Length == 3){
				sortieConsoleContenuWEB(contenuWEB);
			}
		}
		
		
		public Boolean isFolderOrFilePath(string chemin){
			
			Match match = Regex.Match(chemin, @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$",RegexOptions.IgnoreCase); 
			if(match.Success){
				return true;
			}else{
				return false;	
			}
		}
		
		public void ecritureDansFichierContenuWEB (string contenuWEB,string cheminEnregistrementFichier){
			System.IO.File.WriteAllText(cheminEnregistrementFichier, contenuWEB);
		}
		
		public void sortieConsoleContenuWEB (string contenuWEB){
	 		Console.WriteLine(contenuWEB);
		}
		
		public string loadindSourceHtmlPage(string url)
		{
			
			string htmlCode = null;
			using (WebClient client = new WebClient ())
			{
				if(client != null){
			    	htmlCode = client.DownloadString(url);
				}
			}
			return htmlCode;
		}
		
		public Boolean isURL(string URL)
		{
			Match match = Regex.Match(URL, @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)",RegexOptions.IgnoreCase); 
			if(match.Success){
				return true;
			}else{
				return false;	
			}
			
		}
		
		public Boolean isArgsCorrect(string[] args)
		{
			if(args != null){
				if(args.Length>=3){
					if(args[0].Equals("test") || args[0].Equals("get")){
						if(args[1].Equals("-url")){
							return true;
						}
					}
				}
			}
			return false;
		}
		
		public void routage(string[] args)
		{
			if(this.isURL(args[2])){
				if(args[0].Equals("get")){
					this.Get(args);
				}else if(args[0].Equals("test")){
					//this.Test(args);
				}
				
				
			}
		}
	}
}
