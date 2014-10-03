using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Parsing
{
	public interface IMethod : IMember, ICallable
	{
		string Body { get; }
	}
}
