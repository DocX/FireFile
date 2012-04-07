using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace HttpFileSaverLib
{
	/// <summary>
	/// File saver service class. It encapsulate HttpListener and handles requests to save content.
	/// Operates with URL in form /domain/?... where domain is used to match corresponding File root path
	/// </summary>
	/// <exception cref='ArgumentException'>
	/// Is thrown when an argument passed to a method is invalid.
	/// </exception>
	public class FileSaver
	{		
		
		System.Net.HttpListener server;
		int port;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="HttpFileSaver.FileSaver"/> class.
		/// </summary>
		/// <param name='port'>
		/// Port on which server will listen
		/// </param>
		public FileSaver (int port)
		{
			server = new System.Net.HttpListener ();
			this.port = port;
			mappings = new Dictionary<string, RootMapping> ();
		}
	
		
		public class RootMapping
		{
			/// <summary>
			/// Value of URL first path level, which is used to determine this instance of mapping
			/// </summary>
			public string domain;
			
			/// <summary>
			/// The local root path, where are files saved
			/// </summary>
            public string localRootPath { get; set; }
			
		}
		
		private Dictionary<string, RootMapping> mappings;
		
		
		/// <summary>
		/// Adds the root mapping to server.
		/// </summary>
		/// <param name='mapping'>
		/// Mapping.
		/// </param>
		public void AddRoot (RootMapping mapping)
		{
			mappings.Add (mapping.domain, mapping);
			
			server.Prefixes.Add ("http://localhost:" + port.ToString () + "/" + mapping.domain + "/");
		}
	
		/// <summary>
		/// Start listening and requesting. Calling this is blocking, uninterruptable.
		/// </summary>
		public void Start ()
		{
			server.Start ();

            NewMessage(this,"Listening started");

			Loop ();
		}

        public void Stop()
        {
            server.Stop();
        }

		[Serializable]
		public sealed class MessageEventArgs : EventArgs
		{
			public string message;
		
			public MessageEventArgs (string message)
			{
				this.message = message;
			}
			
			static public implicit operator MessageEventArgs (string s)
			{
				return new MessageEventArgs (s);
			}
		}
		
		/// <summary>
		/// Occurs when server wants to log some message
		/// </summary>
		public event EventHandler<MessageEventArgs> NewMessage;
		
		private void Loop ()
		{
			while (true) {
				HttpListenerContext context = server.GetContext ();
				HttpListenerRequest request = context.Request;
				HttpListenerResponse response = context.Response;
				StreamWriter sw = new StreamWriter (response.OutputStream);
				
				string[] pathParts = request.Url.AbsolutePath.Split (new char[] {'/'}, 3);
				
				RootMapping currentRoot = null;
				try {
					currentRoot = mappings [pathParts [1]];
				} catch (Exception ex) {
					Console.WriteLine (ex.Message);
					
					response.StatusCode = 500;
					sw.WriteLine (ex.Message);
					sw.Flush ();
					response.Close ();
					
					NewMessage (this, "Bad request " + request.RawUrl);
					
					continue;
				}
				 
				
				NewMessage(this, "Domain: " + currentRoot.domain);
				
				Uri changeFile = new Uri (request.QueryString ["filename"]);
				
				try {
					SaveContent (request.InputStream, currentRoot.localRootPath + "/" + changeFile.AbsolutePath);
					response.StatusCode = 200;
                    sw.WriteLine("Saved " + currentRoot.localRootPath + "/" + changeFile.AbsolutePath);
					sw.Flush ();
					response.Close ();
					
					NewMessage (this, "Saved " + changeFile.AbsolutePath);
				} catch (Exception ex) {
					response.StatusCode = 500;
					sw.WriteLine (ex.Message);
					sw.Flush ();
					response.Close ();
					
					NewMessage (this, "Error saving " + changeFile.AbsolutePath);
				}

			}
		
		}
		
		/// <summary>
		/// Saves the content.
		/// </summary>
		/// <param name='content'>
		/// Content.
		/// </param>
		/// <param name='filename'>
		/// Filename where to save
		/// </param>
		/// <exception cref='ArgumentException'>
		/// When file not exists
		/// </exception>
		private void SaveContent (Stream content, string filename)
		{

			// check if file exists
			if (!File.Exists (filename)) {
				throw new ArgumentException ("File not exists");
			}
			
			// if not exists bak, copy bak
			if (!File.Exists (filename + ".bak")) {
				File.Copy (filename, filename + ".bak");
			}
			
			// write content
			Stream file = null;
			try {
				file = File.Open (filename, FileMode.Truncate);
				file.Position = 0;
				CopyStream (content, file);
				file.Close ();
			} finally {
				if (file != null)
					file.Close ();	
			}
			
		}
		
		/// <summary>
		/// Copies the stream.
		/// </summary>
		/// <param name='input'>
		/// Input.
		/// </param>
		/// <param name='output'>
		/// Output.
		/// </param>
		public static void CopyStream (Stream input, Stream output)
		{
			byte[] buffer = new byte[32768];
			int read;
			while ((read = input.Read(buffer, 0, buffer.Length)) > 0) {
				output.Write (buffer, 0, read);
			}
		}

	}
}

