using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileExplorer;
using FileExplorer.Exceptions;
using FileExplorer.VO;

namespace FileExplorerTester
{
	class Program
	{
		static void Main(string[] args)
		{
			FileExplorerModel explorer = new FileExplorerModel("d:\\recycle.bin");
			List<FileSystemInfo> fileList = explorer.GetFileList();
			if (fileList == null)
				return;
			foreach (FileSystemInfo info in fileList)
			{
				if (info.Name.Equals("a.txt") && info is FileInfo)
				{
					try
					{
						explorer.RenameTo(info as FileInfo, "a.reg");
					}
					catch (FileAlreadyExistException e)
					{
						Console.Error.WriteLine(e.Message);
					}
				}
				Console.WriteLine(info.FullName);
			}
		}
	}
}
