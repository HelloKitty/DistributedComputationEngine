using Distributed.Parsing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Code
{
	public sealed class RoslynMethod : IMethod
	{
		private readonly MethodDeclarationSyntax roslynMethodObject;

		public RoslynMethod(IEnumerable<AttributeListSyntax> attributes, MethodDeclarationSyntax method)
		{
			UsingDirectives = ((CompilationUnitSyntax)method.SyntaxTree.GetRoot()).Usings.Select(x => x.ToString());
			roslynMethodObject = method;

			Body = method.Body.ToString();
			//Parses the parameter namees into a list of params.
			ParameterNames = method.ParameterList.Parameters.Select(x => x.Identifier.Text);
		}
		public string Body { get; private set; }

		public IEnumerable<IAttribute> Attributes { get; private set; }

		public bool TryExecute(ICompiler compilerInstance, IReadOnlyDictionary<uint, object> parameterData)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<string> ParameterNames { get; private set; }


		private IEnumerable<string> _ParameterTypesShort = null;
		public IEnumerable<string> ParameterTypesShort
		{
			get { return _ParameterTypesShort == null ? _ParameterTypesShort = LazyLoadParameterTypeCollection() : _ParameterTypesShort; }
		}

		public IReadOnlyDictionary<uint, Tuple<string, string>> ParameterData
		{
			get { throw new NotImplementedException(); }
		}

		//TODO: IMplement if ever needed
		private IReadOnlyDictionary<uint, Tuple<string, string>> LazyLoadParamaterDictionary()
		{
			throw new NotImplementedException();
		}

		//TODO: Implement if ever needed
		private IEnumerable<string> LazyLoadParameterTypeCollection()
		{
			return roslynMethodObject.ParameterList.Parameters.Select(x => x.Type.ToString());
		}

		public IEnumerable<string> UsingDirectives { get; private set; }
	}
}
