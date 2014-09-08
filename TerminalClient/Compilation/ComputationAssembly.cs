using System;
using System.Codedom;


namespace Distributed.Compile
{
	///<Summary>
	/// Provides a wrapper for the dyanmic assembly, method substituion and etc.
	/// It's important that this class only be created once or we will suffer memory issues
	/// as dynamic assemblies in the same AppDomain cannot be freed up.
	///<Summary>
	public sealed class ComputationAssembly
	{
		//Jon Skeet's thread safe singleton design
		private static readonly ComputationAssembly _instance = new ComputationAssembly();
		
		private ComputationAssembly()
		{
			
		}
		
		public static ComputationAssembly Instance
		{
			get { return _instance; }
		}
		
		#region Dynamic Assembly Members
		
		
		
		
		#endregion
		
		public RetrieveDynamicAssembly()
	}
}
