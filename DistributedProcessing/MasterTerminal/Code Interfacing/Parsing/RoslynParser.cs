using Distributed.Code;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Distributed.Parsing
{
	/// <summary>
	/// Wrapper class for the RoslynParser that is generic to support both parser types.
	/// Helps to abtract Roslyn functionality as it's in pre-release and thus in flux.
	/// </summary>
	/// <typeparam name="ParserType"></typeparam>
	public class RoslynParser<ParserType> : IParser, IDisposable where ParserType : SyntaxTree
	{
		public string CodeText
		{
			get
			{
				if (syntaxTree == null)
					throw new Exception("Tried to parse full text from code with an invalid source or syntax tree.");

				SourceText text;
				syntaxTree.TryGetText(out text);
				return text.ToString();
			}
		}

		private ICodeSource codeSource;

		private SyntaxTree syntaxTree;

		public void LoadFromSource(ICodeSource source)
		{
			codeSource = source;
			syntaxTree = typeof(ParserType)
				//TODO: Maybe clean up this garbage so I'm not using reflection. Done to keep the class generic though in the event
				//That someone insane wants to write VB.
				.GetMethod("ParseText", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public, null, new Type[] { typeof(string), typeof(CSharpParseOptions), typeof(string), typeof(Encoding), typeof(CancellationToken) }, null)
				.Invoke(null, new object[] { source.Path, null, "", null, null }) as SyntaxTree;
		}

		public IEnumerable<string> DetermineImports()
		{
			//TODO: Add try catch for error handling when it's known what should occur if we error here.
			return syntaxTree.GetRoot().DescendantNodesAndSelf().OfType<UsingDirectiveSyntax>().Select(x => x.Name.ToString());
		}

		public string MethodString<T>(T attribute) where T : Attribute
		{
			throw new NotImplementedException();
		}

		public string MethodString(string methodName)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			codeSource.Dispose();
		}
	}
}
