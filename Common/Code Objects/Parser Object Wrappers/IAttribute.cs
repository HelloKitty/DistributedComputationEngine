using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Parsing
{
	public interface IAttribute : IConstructable
	{
		/// <summary>
		/// Name of the attribute type
		/// </summary>
		string TypeName { get; }
	}
}
