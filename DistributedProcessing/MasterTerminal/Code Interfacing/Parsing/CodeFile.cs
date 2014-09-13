using Distributed.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Parsing
{
	public class CodeFile : ICodeSource
	{
		public string Path { get; private set; }

		public CodeFile(string filePath)
		{
			try
			{ 
				Path = File.ReadAllText(filePath);
			}
			catch
			{
				Console.WriteLine("Failed to load file at path " + filePath 
					+ " for some reason when creating an ICodeSource to parse.");
			}
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
