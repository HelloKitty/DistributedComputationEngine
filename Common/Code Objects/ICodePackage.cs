using Microsoft.CSharp;
using ProtoBuf;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Distributed.Compile;
using Distributed.Networking;

namespace Distributed.Code
{
	/// <summary>
	/// Contract that may be implemented on a serializable wire type that will carry a payload of information
	/// regarding computation methods.
	/// </summary>
	[ProtoContract]
	public interface ICodePackage
	{
		/// <summary>
		/// Members indicates the version number for a given executable
		/// package of code.
		/// </summary>
		[ProtoMember(1, IsRequired = true)]
		int Version { get; protected set; }

		[ProtoMember(2, IsRequired=true)]
		CodeData SerializerReadyCodeData { get; protected set; }
		
		[ProtoMember(3, IsRequired=true)]
		ComputationMethod.MSLanguage Language { get; protected set; }
		
	}
}
