using Distributed.Compile;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Code
{
	[ProtoContract]
	public class CodeData
	{
		/// <summary>
		/// This information is serialized and it contains a string of the computation method to be used
		/// on the recieving clients for execution.
		/// </summary>
		[ProtoMember(1, IsRequired = true)]
		public string internalStringCode { get; protected set; }

		/// <summary>
		/// Member that will contain a list of all the required assemblies needed for the code to compile
		/// on remote machines. Provides only public enumerable access to elements.
		/// </summary>
		public IEnumerable<string> assembliesNeeded
		{
			get { return _assembliesNeeded; }
		}
		
		/// <summary>
		/// Serialized collection of assemblies needed to compile the code.
		/// </summary>
		[ProtoMember(2, IsRequired = false)]
		private ICollection<string> _assembliesNeeded;
		

		public CodeData(string code)
		{
			internalStringCode = code;
			_assembliesNeeded = new List<string>();
		}

		//Protobuf constructor
		private CodeData()
		{

		}

		public void AddReferencedAssembly(string ass)
		{
			//TODO: Implement
			if (!_assembliesNeeded.Contains(ass))
			{
				Console.WriteLine("\nAdded assembly " + ass + " to CodeData from desired code.");
				_assembliesNeeded.Add(ass);
			}
			else
				Console.WriteLine("\nFound duplicate assembly " + ass + " referenced multiple times by method.");
		}
		
		public void AddReferencedAssembly(ImportAttribute attr)
		{
			AddReferencedAssembly(attr.AssemblyName);
		}
		
		public void AddReferencedAssembly(IEnumerable<ImportAttribute> attrs)
		{
			var names = attrs.Select(x => x.AssemblyName);
			
			foreach(string s in names)
				AddReferencedAssembly(s);
		}
	}
}
