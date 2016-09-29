/*
 * Created by alpaca.
 * 
 * 2016/9/23
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using FileExplorer;
using FileExplorer.Exceptions;

namespace ForTestOnly
{
	class Program
	{
		static void Main(string[] args)
		{
			FileExplorerModel explorer = new FileExplorerModel("d:\\");
		}
	}
}

namespace FileExplorer
{
	public class FileExplorerModel
	{
		public FileExplorerModel(FileInfo fileInfo)
		{
			this.path = fileInfo.FullName;
			info = fileInfo;
			if (Directory.Exists(fileInfo.FullName))
			{
				info = new DirectoryInfo(path);
			}
		}

		public FileExplorerModel(string path)
		{
			this.path = path;
			if (path == null || path.Equals(""))
				return;
			if (!File.Exists(path) && !Directory.Exists(path))
			{
				throw new FileNotFoundException("File '" + path + "'does not exist.");
			}
			info = new FileInfo(path);
			if (Directory.Exists(path))
			{
				info = new DirectoryInfo(path);
			}
		}

		/// <summary>
		/// 返回该文件结构包含的文件列表。
		/// </summary>
		/// <returns>子文件的FileInfo列表，如果不是一个文件夹，则返回null</returns>
		public List<FileSystemInfo> GetFileList()
		{
			List<FileSystemInfo> result = new List<FileSystemInfo>();
			if (!(info is DirectoryInfo))
			{
				return null;
			}
			foreach (FileSystemInfo info in ((DirectoryInfo)this.info).GetFileSystemInfos())
			{
				if ((info.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
				{
					continue;
				}
				result.Add(new FileInfo(info.FullName));
			}
			return result;
		}

		public static void DeleteFromDisk(FileInfo info, bool permanently) 
		{
			try
			{
				DeleteFromDisk(info.FullName, permanently);
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public static void DeleteFromDisk(string fullName, bool permanently)
		{
			try
			{
				if (permanently)
				{
					FileSystem.DeleteFile(fullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
				}
				else
				{
					FileSystem.DeleteFile(fullName, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
				}
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public void RenameTo(FileInfo info, string name)
		{
			foreach (FileInfo fileInfo in GetFileList())
			{
				if (fileInfo != info && fileInfo.FullName.Equals(info.DirectoryName + name))
				{
					throw new FileAlreadyExistException(info, name);
				}
			}
			info.MoveTo(info.DirectoryName + name);
		}
		
		protected FileSystemInfo info;
		protected string path;
	}

	namespace Exceptions
	{

		/// <summary>
		/// 不支持的文件类型异常。（我也不知道为什么需要这个异常，总之我的代码只支持文件和文件夹嘛！）
		/// </summary>
		public class FileNotSupportedException : Exception
		{
			public FileNotSupportedException() : base() { }
			public FileNotSupportedException(String fileName) : base(string.Format("File '{0:1}' is not supported.", fileName)) { }
		}

		/// <summary>
		/// 复制或者重命名是出现重复文件时的异常。
		/// </summary>
		public class FileAlreadyExistException : Exception
		{
			public FileAlreadyExistException() : base() { }
			public FileAlreadyExistException(string fileName) : base(string.Format("File '{0:1}' already exists.", fileName)) { }
			public FileAlreadyExistException(FileInfo fileInfo, string name) : base(string.Format("File '{0:1}' already exists.", fileInfo.DirectoryName + name)) { }
		}
	}
}

