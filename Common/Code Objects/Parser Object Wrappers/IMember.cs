using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Parsing
{
	public interface IMember
	{
		/// <summary>
		/// A collection of attributes targeting the member.
		/// </summary>
		IEnumerable<IAttribute> Attributes { get; }

		/// <summary>
		/// A collection of required using statements for a given member to be compilable.
		/// </summary>
		IEnumerable<string> UsingDirectives { get; }
	}
}
