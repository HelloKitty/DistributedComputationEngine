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
		[ProtoMember(1, IsRequired = true)]
		public ICodePackage ComputationInfoContainer { get; private set; }
		
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
		
		private bool ValidateICodePackage()
		{
			throw new NotImplementedException("Implement this please");
		}
		#endregion
		
	}
}
