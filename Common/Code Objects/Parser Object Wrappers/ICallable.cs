using Distributed.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Parsing
{
	public interface ICallable : IParametable
	{
		bool TryExecute(ICompiler compilerInstance, IReadOnlyDictionary<uint, object> parameterData);
	}
}
