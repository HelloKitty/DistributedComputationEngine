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
		/// on remote machines.
		/// </summary>
		[ProtoMember(2, IsRequired = false)]
		protected List<string> assembliesNeeded;

		public CodeData(string code)
		{
			internalStringCode = code;
			assembliesNeeded = new List<string>();
		}

		//Protobuf constructor
		protected CodeData()
		{

		}

		public virtual void AddReferencedAssembly(string ass)
		{
			//TODO: Implement
			if (!assembliesNeeded.Contains(ass))
				Console.WriteLine("\nAdded assembly " + ass + " to CodeData from desired code.");
		}
	}
}
