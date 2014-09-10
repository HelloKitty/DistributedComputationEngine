

namespace Distributed.Compile
{
	public class ComputationMethod : Attribute
	{
		public int Version { get; private set; }
		
		public MSLanguage Language { get; private set; }
		
		public enum MSLanguage
		{
			CSharp,
			VB,
			FSharp,
			CPlusPlus
		}
		
		public ComputationMethod(int versionNumber, ComputationMethod.MSLanguage lang)
		{
			Version = versionNumber;
			Language = lang;
		}
	}
}
