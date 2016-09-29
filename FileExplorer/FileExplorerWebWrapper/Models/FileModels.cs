using System;
using FileExplorer;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FileExplorerWebWrapper.VO;

namespace FileExplorerWebWrapper.Models
{
	public class FileModel : FileExplorerModel
	{
		public FileModel(string path) : base(path) { }

		public List<object> FileList
		{
			get
			{
				if (path == null || path.Equals(""))
				{
					List<object> result = new List<object>();
					for (char p = 'A'; p <= 'Z'; ++p)
					{
						if (Directory.Exists(p + ":\\"))
						{
							result.Add(new DirectoryInfoVO(new DirectoryInfo(p + ":\\"), "Name"));
						}
					}
					return result;
				}
				if (Directory.Exists(info.FullName))
				{
					List<object> result = new List<object>();
					try
					{
						FileSystemInfo[] infos = new DirectoryInfo(info.FullName).GetFileSystemInfos();
						foreach (FileSystemInfo info in infos)
						{
							if (File.Exists(info.FullName))
								result.Add(new FileInfoVO(new FileInfo(info.FullName), keyField));
							if (Directory.Exists(info.FullName))
								result.Add(new DirectoryInfoVO(new DirectoryInfo(info.FullName), keyField));
						}
					} catch (Exception e)
					{
						error = 1;
						message = e.Message;
					}
					Array tmp = result.ToArray();
					Array.Sort(tmp);
					result.Clear();
					foreach (object o in tmp)
					{
						result.Add(o);
					}
					return result;
				}
				else
				{
					return new List<object>();
				}
			}
		}

		public int Error
		{
			get
			{
				return error;
			}
		}

		public String Message
		{
			get
			{
				return message;
			}
		}

		public string KeyField
		{
			get
			{
				return keyField;
			}
			set
			{
				keyField = value;
			}
		}

		private string message = "";
		private int error = 0;
		private string keyField;
	}
}

namespace FileExplorerWebWrapper.VO
{
	public class FileInfoVO : IComparable
	{
		public FileInfoVO(FileInfo info, string keyField)
		{
			this.Name = info.Name;
			this.FullName = info.FullName;
			this.Directory = info.DirectoryName;
			this.Extension = info.Extension;
			this.CreationTime = info.CreationTime.ToLongDateString();
			this.LastAccessTime = info.LastAccessTime.ToLongDateString();
			this.LastWriteTime = info.LastWriteTime.ToLongDateString();
			this.Length = info.Length;
			this.keyField = keyField;
		}
		public string Name;
		public string FullName;
		public string Directory;
		public string Extension;
		public string CreationTime;
		public string LastAccessTime;
		public string LastWriteTime;
		public long Length;
		public string keyField;

		public int CompareTo(object other)
		{
			if (other is FileInfoVO)
			{
				if (keyField.Equals("Name"))
				{
					return this.Name.CompareTo((other as FileInfoVO).Name);
				}
				else if (keyField.Equals("CreationTime"))
				{
					return this.CreationTime.CompareTo((other as FileInfoVO).CreationTime);
				}
				else if (keyField.Equals("Length"))
				{
					return this.Length.CompareTo((other as FileInfoVO).Length);
				}
				return this.Name.CompareTo((other as FileInfoVO).Name);
			}
			else
			{
				return 1;
			}
		}
	}

	public class DirectoryInfoVO : IComparable
	{
		public DirectoryInfoVO(DirectoryInfo info, string keyField)
		{
			this.Name = info.Name;
			this.FullName = info.FullName;
			this.Extension = info.Extension;
			this.CreationTime = info.CreationTime.ToLongDateString();
			this.LastAccessTime = info.LastAccessTime.ToLongDateString();
			this.LastWriteTime = info.LastWriteTime.ToLongDateString();
			this.keyField = keyField;
		}

		public string Name;
		public string FullName;
		public string Directory;
		public string Extension;
		public string CreationTime;
		public string LastAccessTime;
		public string LastWriteTime;
		public string keyField;

		public int CompareTo(object obj)
		{
			if (obj is DirectoryInfoVO)
			{
				if (keyField.Equals("Name"))
				{
					return Name.CompareTo((obj as DirectoryInfoVO).Name);
				}
				else if (keyField.Equals("CreationTime"))
				{
					return CreationTime.CompareTo((obj as DirectoryInfoVO).CreationTime);
				}
				return Name.CompareTo((obj as DirectoryInfoVO).Name);
			}
			else
			{
				return -1;
			}
		}
	}
}

namespace FileExplorerWebWrapper.VO
{
	public class ResultMessage
	{
		public ResultMessage()
		{
		}

		public ResultMessage(int error, string message)
		{
			this.error = error;
			this.message = message;
		}

		public int Error
		{
			get
			{
				return error;
			}
		}
		public string Message
		{
			get
			{
				return message;
			}
		}
		int error = 0;
		string message = "";
	}
}