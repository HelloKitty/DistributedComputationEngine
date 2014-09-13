using ProtoBuf;
using System.Collections.Generic;

namespace Distributed.Code
{
	[ProtoContract]
	public class ComputationPackage : ICodePackage
	{
		public enum ComputationMethodType : byte
		{
			MainComputation,
			ResultsHandler
		}
		
		public int Version { get; protected set; }
		
		public MSLanguage Language { get; protected set; }

		[ProtoMember(3, IsRequired = true)]
		private IDictionary<byte, CodeData> SerializerReadyCodeCollection;
		
		public ComputationPackage(MSLanguage language, int version)
		{
			Version = version;
			Language = language;
			SerializerReadyCodeCollection = new Dictionary<byte, CodeData>(3);
		}
		
		#region ICodePackage Explict Method Implementation
		bool ICodePackage.RegisterMethod(CodeData codeData, byte typeByteSignifier)
		{
			if(SerializerReadyCodeCollection.Keys.Contains(typeByteSignifier) 
			&& SerializerReadyCodeCollection[typeByteSignifier] != null)
				return false;

			SerializerReadyCodeCollection[typeByteSignifier] = codeData;
			return true;
		}
		
		bool ICodePackage.TryGetMethod(byte typeByteSignifier, out CodeData data)
		{
			if(!SerializerReadyCodeCollection.Keys.Contains(typeByteSignifier) 
			|| SerializerReadyCodeCollection[typeByteSignifier] == null)
			{
				data = null;
				return false;
			}
			
			data = SerializerReadyCodeCollection[typeByteSignifier];
			return true;
		}
		#endregion
		
		#region Methods that 'hide' ICodePackage methods
		public bool RegisterMethod(CodeData codeData, ComputationMethodType type)
		{
			return ((ICodePackage)this).RegisterMethod(codeData, (byte)type);
		}
		
		public bool TryGetMethod(byte typeByteSignifier, out CodeData data)
		{
			return ((ICodePackage)this).TryGetMethod(typeByteSignifier, out data);
		}
		#endregion
		
	}
}
