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
	[ProtoInclude(500, typeof(ComputationPackage))]
	public interface ICodePackage
	{
		/// <summary>
		/// Members indicates the version number for a given executable
		/// package of code.
		/// </summary>
		[ProtoMember(1, IsRequired = true)]
		int Version { get; }

		[ProtoMember(2, IsRequired = true)]
		ComputationMethod.MSLanguage Language { get; }
		
		bool RegisterMethod(CodeData code, byte typeByteSignifier);
		bool TryGetMethod(byte typeByteSignifier, out CodeData data);
	}
}
