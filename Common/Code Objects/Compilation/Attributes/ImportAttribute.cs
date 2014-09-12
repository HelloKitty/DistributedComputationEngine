using System;

namespace Distributed.Compile
{
	[Obsolete("Use Rosyln using parse.")]
	[AttributeUsage(System.AttributeTargets.Method)]
	public class ImportAttribute : Attribute
	{
		public string AssemblyName { get; private set; }
		
		public ImportAttribute(string assemblyUsingName)
		{
			AssemblyName = assemblyUsingName;
		}
	}
}
