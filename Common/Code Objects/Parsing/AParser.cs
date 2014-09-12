//

namespace Distributed.Parsing
{
	public abstract class AParser : IDisposable
	{
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		protected virtual void Dispose(bool disposing)
		{
			//Implement in inherited classes that need their resources freed up.
		}
	}
}
