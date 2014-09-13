using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Code
{
	public interface ICodeSource : IDisposable
	{
		string Path { get; }
	}
}
