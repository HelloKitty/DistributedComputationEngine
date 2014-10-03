using Distributed.Code;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
			return GetTypesInSource<UsingDirectiveSyntax>().Select(x => x.Name.ToString());
		}

		public IEnumerable<IMethod> GetMethodsTargetedBy<T>() where T : Attribute
		{
			IEnumerable<MethodDeclarationSyntax> methods = GetTypesInSource<MethodDeclarationSyntax>();

			if (methods == null)
				return null;

			IEnumerable<MethodDeclarationSyntax> targeteds = FilterMethodsWithAttribute<T, IEnumerable<MethodDeclarationSyntax>>(methods.Where);

			if (targeteds == null || targeteds.Count() == 0)
				return new List<IMethod>();

			return targeteds.Select(x => new RoslynMethod(x.AttributeLists, x));
		}

		public IMethod GetMethodTargetedBy<T>() where T : Attribute
		{
			IEnumerable<MethodDeclarationSyntax> methods = GetTypesInSource<MethodDeclarationSyntax>();

			if (methods == null)
				return null;

			MethodDeclarationSyntax targeted = FilterMethodsWithAttribute<T, MethodDeclarationSyntax>(methods.FirstOrDefault);

			//Test code for looking at attributes
			/*foreach (var m in methods)
				foreach (var a in m.AttributeLists)
					foreach (var aa in a.Attributes)
						Console.WriteLine(aa.ToString());

			Console.WriteLine(targetedMethod == null);*/

			return targeted != null ? new RoslynMethod(targeted.AttributeLists, targeted) : null;
		}

		private T FilterMethodsWithAttribute<AttributeType, T>(Func<Func<MethodDeclarationSyntax, bool>, T> finderFunc)
			where AttributeType : Attribute
		{
			Func<MethodDeclarationSyntax, bool> attributeNameSelectionLambda = method =>
			{

				var attributeNames = method.AttributeLists.Select(y => GetAttributeTypeName(y.ToString()));

				//A little hack that tries to find if the typenames are equal with or without an added, or even removed, Attribute in the string.
				return attributeNames.Contains(typeof(AttributeType).Name) || attributeNames.Contains(typeof(AttributeType).Name + "Attribute")
					|| (typeof(AttributeType).Name.Contains("Attribute") ? attributeNames.Contains(typeof(AttributeType).Name.Replace("Attribute", "")) : false);
			};


			T targeted = finderFunc(attributeNameSelectionLambda);
			return targeted;
		}

		private string GetAttributeTypeName(string attributeText)
		{
			//TODO: Implement exception handling in the case that it's not an attribute passed or
			//in incorrect form.
			string removedFirstBrace = attributeText.Substring(1);
			return removedFirstBrace.Substring(0, removedFirstBrace.IndexOf('('));
		}

		private IEnumerable<T> GetTypesInSource<T>()
		{
			return syntaxTree.GetRoot().DescendantNodesAndSelf().OfType<T>();
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
