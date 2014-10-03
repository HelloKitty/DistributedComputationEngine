using Distributed.Code;
using Distributed.Compile;
using Distributed.Parsing;
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
		//Testing comment
		[Obsolete("Test")]
		static void Main(string[] args)
		{

			RoslynParser<CSharpSyntaxTree> parser = new RoslynParser<CSharpSyntaxTree>();
			parser.LoadFromSource(new CodeFile("Program.cs"));

			parser.MethodString<ComputationMethod>();

			Console.ReadKey();

			/* TEST CODE
			//SyntaxTree code = CSharpSyntaxTree.ParseText(File.ReadAllText("Program.cs"));
			RoslynParser<CSharpSyntaxTree> parser = new RoslynParser<CSharpSyntaxTree>();
			parser.LoadFromSource(new CodeFile("Program.cs"));

			Console.WriteLine(parser.CodeText);

			foreach(string s in parser.DetermineImports())
			{
				Console.WriteLine(s);
			}
			Console.ReadKey(); */
		}
	}
}
