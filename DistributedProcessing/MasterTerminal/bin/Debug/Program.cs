using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTerminal
{
	class Program
	{
		static void Main(string[] args)
		{

			SyntaxTree code = CSharpSyntaxTree.ParseText(File.ReadAllText("Program.cs"));

			SourceText text;
			code.TryGetText(out text);

			Console.WriteLine(text.ToString());
			Console.ReadKey();
		}
	}
}
