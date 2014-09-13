using Distributed.Code;
using System;
using System.Collections.Generic;

namespace Distributed.Parsing
{
	public interface IParser
	{
		string CodeText { get; }
		void LoadFromSource(ICodeSource source);
		IEnumerable<string> DetermineImports();
		
		string MethodString<T>(T attribute) where T : Attribute;
		string MethodString(string methodName);
		
		/*#region IDiposable Implementation
		public void Dispose()
		{
			//Dispose of the codesource.
			Source.Dispose();
			
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		protected virtual void Dispose(bool disposing)
		{
			//Implement in inherited classes that need their resources freed up.
		}
		#endregion*/
	}
}
