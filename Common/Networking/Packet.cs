using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Networking
{
	[ProtoContract]
	public abstract class PacketType
	{
		public Action OnSend;

		public byte[] Serialize()
		{
			using(MemoryStream ms = new MemoryStream())
			{
				Serializer.Serialize(ms, this);
				ms.Position = 0;
				return ms.ToArray();
			}
		}

		/// <summary>
		/// Should indicate whether the package is intact and handlable.
		/// </summary>
		/// <returns>Returns true if the packet is in a handlable state.</returns>
		public abstract bool ValidatePacket();

		public virtual void OnRecieve()
		{
			//This obviously can be an Action because that can't be serialized easily.
		}
	}
}
