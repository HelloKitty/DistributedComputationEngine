using Distributed.Code;
using Distributed.Networking;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Work
{
	[ProtoContract]
	public class WorkOrder : PacketType
	{
		/// <summary>
		/// Contains a payload of information related to the computation method that will be excuted on terminal clients.
		/// </summary>
		[ProtoMember(1, IsRequired = true)]
		public ICodePackage ComputationInfoContainer { get; private set; }
		
		/// <summary>
		/// Contains a payload of information that will be used to partition a dataset for distribution for the server.
		/// </summary>
		[ProtoMember(2, IsRequired = true)]
		public ICodePackage WorkDelegateContainer { get; private set; }
		
		//Protobuf-net constructor
		protected WorkOrder(ICodePackage compInfo, ICodePackage workDelegate)
		{
			ComputationInfoContainer = compInfo;
			WorkDelegateContainer = workDelegate;
		}
		
		#region Packet Validation Methods
		public override bool ValidatePacket()
		{
			throw new NotImplementedException("Implement this please");
		}
		
		private bool ValidateCodePackages()
		{
			throw new NotImplementedException("Implement this please");
		}
		#endregion
		
	}
}
