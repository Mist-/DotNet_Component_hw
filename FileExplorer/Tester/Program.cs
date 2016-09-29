using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileExplorer;


namespace Tester
{
	class Program
	{
		static void Main(string[] args)
		{
			FileExplorerModel model = new FileExplorerModel("c:\\");
			FileExplorerModel.DeleteFromDisk("c:\\a.cfg", false);
		}
	}
}
