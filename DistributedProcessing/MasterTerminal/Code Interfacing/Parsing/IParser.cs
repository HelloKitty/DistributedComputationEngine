using Distributed.Code;
using System;
using System.Collections.Generic;

namespace Distributed.Parsing
{
	public interface IParser
	{
		void LoadFromSource(ICodeSource source);
		IEnumerable<string> DetermineImports();
		
		IEnumerable<IMethod> GetMethodsTargetedBy<T>() where T : Attribute;
		IMethod GetMethodTargetedBy<T>() where T : Attribute;
		
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
