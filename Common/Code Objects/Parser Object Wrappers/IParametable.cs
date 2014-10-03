using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Parsing
{
	public interface IParametable
	{
		/// <summary>
		/// Collection of the parameter values in string form.
		/// </summary>
		IEnumerable<string> ParameterNames { get; }

		/// <summary>
		/// Collection of parameter types used.
		/// </summary>
		IEnumerable<string> ParameterTypesShort { get; }

		//TODO: Remove the Tuple<T1, T2>
		/// <summary>
		/// Readonly dictionary of uint, representing parameter index, and a pair of the parameter name and type.
		/// </summary>
		IReadOnlyDictionary<uint, Tuple<string, string>> ParameterData { get; }
	}
}
