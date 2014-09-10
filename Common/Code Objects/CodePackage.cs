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
	public class CodePackage : Packet
	{
		/// <summary>
		/// Members indicates the version number for a given executable
		/// package of code.
		/// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int Version { get; protected set; }

		[ProtoMember(2, IsRequired=true)]
		public CodeData SerializerReadyCodeData { get; protected set; }
		
		[ProtoMember(3, IsRequired=true)]
		public ComputationMethod.MSLanguage Language { get; protected set; }

		public CodePackage(CodeData codeDataObject, ComputationMethod methodInfo)
		{
			SerializerReadyCodeData = codeDataObject;
			this.Version = methodInfo.Version;
			this.Language = methodInfo.Language;
		}
		
		public CodePacake(string code, IEnumerable<ImportAttribute> imports, ComputationMethod methodInfo)
		{
			this.SerializerCodeData = new CodeData(code);
			SerializerCodeData.AddReferencedAssembly(imports);
			
			this.Version = methodInfo.Version;
			this.Language = methodInfo.Language;
		}

		//Protobuf constructor
		protected CodePackage()
		{

		}
		
		public override bool ValidatePacket()
		{
			return SerializerCodeData != null && SerializerCodeData.CodeString;
		}
	}
}
