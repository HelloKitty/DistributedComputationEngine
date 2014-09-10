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
	/// Class will be a sub-package that the WorkOrder package packet will be carrying
	/// when it heads to the master server from the master client to then be handled
	/// there.
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
