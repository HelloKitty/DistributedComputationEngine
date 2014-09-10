using Microsoft.CSharp;
using ProtoBuf;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Code
{
	/// <summary>
	/// Class will be a sub-package that the WorkOrder package packet will be carrying
	/// when it heads to the master server from the master client to then be handled
	/// there.
	/// </summary>
	[ProtoContract]
	public class CodePackage
	{
		/// <summary>
		/// Members indicates the version number for a given executable
		/// package of code.
		/// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int Version { get; protected set; }

		[ProtoMember(2, IsRequired=true)]
		public CodeData SerializerReadyCodeData { get; protected set; }

		public CodePackage(CodeData codeDataObject)
		{
			SerializerReadyCodeData = codeDataObject;
		}

		//Protobuf constructor
		protected CodePackage()
		{

		}
	}
}
