using System;
using NUnit.Framework;
using System.Text.RegularExpressions;
using System.Net;
using System.Diagnostics;


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
		

		
		/**
		 * Si nos options lors de l'execution du programme comporte la notion GET en args[0] on rentre dans cette fonction 
		**/
		public void Get(string[] args)
		{
			var contenuWEB = loadindSourceHtmlPage(args[2]);
			
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
		
		
		public void Test(string[] args)
		{
			bool avecMoyenne = false;
			if(args[3].Equals("-times")){
				if(args.Length==5){
					avecMoyenne = false;
				}else if (args.Length == 6){
					if(args[5].Equals("-avg")){
						avecMoyenne = true;						
					}
				}
			}
	
			int nb = 0;
			try
			{
			    nb = int.Parse(args[4]);

			}
			catch(Exception ex)
			{
			      Console.WriteLine(@"Erreur de parsing");
			}
			
			if(isURL(args[2]))
				afficherTempsDeChargementTEST(args[2],nb,avecMoyenne);

		}
						
		public void afficherTempsDeChargementTEST(string url, int nb, bool avecMoyenne){
		
				var cummule = 0;
				for(int i = 1;i<=nb;i++){
					HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

					System.Diagnostics.Stopwatch timer = new Stopwatch();
					timer.Start();
					
					HttpWebResponse response = (HttpWebResponse)request.GetResponse();
					
					timer.Stop();
					
					TimeSpan timeTaken = timer.Elapsed;
				if(avecMoyenne){
					cummule += timeTaken.Milliseconds;
				}else{
					Console.WriteLine(@"Passage numéro " + i + " = " + timeTaken.Milliseconds +" ms");
				}
				}
				
				Console.WriteLine(@"Moyenne = " + cummule/nb +" ms");
		}
	}
}
