using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Parsing
{
	public interface IConstructable : IParametable
	{
		/// <summary>
		/// Attempts to construct an instance representing the parsed data.
		/// It will use the paramater dictionary in attempts to create a runtime instance of the object for use.
		/// </summary>
		/// <typeparam name="T">Type of the object to attempt to construct.</typeparam>
		/// <param name="obj">Empty object reference unitialized</param>
		/// <returns>Indicates whether construction was successful.</returns>
		bool TryConstructInstanceAs<T>(out T obj);
	}
}
