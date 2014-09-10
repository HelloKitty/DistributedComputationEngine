using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Distributed.Code
{
	public interface ICompiler
	{
		bool isCompiled { get; }
		bool Compile(CompileSettings settings = CompileSettings.Default);
	}
}
