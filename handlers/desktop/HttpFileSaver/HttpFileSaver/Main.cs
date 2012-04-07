using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using HttpFileSaverLib;

namespace HttpFileSaver 
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			
			int port = 50400;
			
			FileSaver fs = null;
			
			// read from parameters
			try {
				FileSaver.RootMapping mapping = new FileSaver.RootMapping ();
				mapping.domain = args[0];
				mapping.localRootPath = args[1];
				
				if (args.Length >= 3)
					port = int.Parse(args[2]);
					
				fs = new FileSaver (port);
				fs.AddRoot(mapping);
			}
			catch (IndexOutOfRangeException)
			{
				Console.Error.WriteLine ("Bad arguments");
				Console.WriteLine ("Usage:\nHttpFileSaver domain path/to/www/root [port-number]");
				return;
			}
			catch(Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
				Console.WriteLine("Usage:\nHttpFileSaver domain path/to/www/root [port-number]");
				return;
			}


			fs.NewMessage += (sender, e) => Console.Write(e.message);
			
			
			Console.WriteLine ("Starting listening on port {0}", port);
			fs.Start();
			
		}
	}
	
	
	
	
}



















