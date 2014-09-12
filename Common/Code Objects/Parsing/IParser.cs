//

namespace Distributed.Parsing
{
	public interface class IParser
	{
		public abstract void LoadSource(ICodeSource source);
		public abstract IEnumerable<string> DetermineImports();
		
		public abstract string MethodString<T>(T attribute) where T : Attribute;
		public abstract string MethodString(string methodName)
		
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
