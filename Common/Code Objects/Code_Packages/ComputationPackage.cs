
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
		
		public ComputationMethod.MSLanguage Language { get; protected set; }
		
		[ProtoMember(3, IsRequired = true)]
		private IDictionary<byte, CodeData> SerializerReadyCodeCollection { get; private set; }
		
		public ComputationPackage(ComputationMethod info)
		{
			Version = info.Version;
			Language = info.Language;
			SerializerReadyCodeCollection = Dictionary<byte, CodeData>(3);
		}
		
		#region ICodePackage Explict Method Implementation
		bool ICodePackage.RegisterMethod(CodeData codeData, byte typeByteSignifier)
		{
			if(SerializerReadyCodeCollection.HasKey(typeByteSignifier) 
			&& SerializerReadyCodeCollection[typeByteSignifier] != null)
				return false;
				
			SerializerReadyCodeCollection[typeByteSignifier] = codeData
		}
		
		bool ICodePackage.TryGetMethod(byte typeByteSignifier, out CodeData data)
		{
			if(!SerializerReadyCodeCollection.HasKey(typeByteSignifier) 
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
			return ICodePackage.RegisterMethod((byte)type);
		}
		
		public bool TryGetMethod(byte typeByteSignifier, out CodeData data)
		{
			return ICodePackage.RegisterMethod((byte)type);
		}
		#endregion
		
	}
}
