using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Text;
using System.Threading.Tasks;

namespace XmlAlpaca.Xml
{
	class XmlBaseModel
	{
		public XmlBaseModel(string xmlPath)
		{
			mDoc = new XmlDocument();
			try
			{
				mDoc.Load(xmlPath);
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public static string CheckXmlValidation(string xsdPath, string xmlPath, string namespaceUrl = null)
		{
			StringBuilder stringbuilder = new StringBuilder();
			XmlReaderSettings xrs = new XmlReaderSettings();
			xrs.ValidationType = ValidationType.Schema;
			xrs.Schemas.Add(namespaceUrl, xsdPath);
			xrs.ValidationEventHandler += (sender, e) =>
			{
				stringbuilder.Append(e.Message);
			};
			using (XmlReader reader = XmlReader.Create(xmlPath, xrs))
			{
				try
				{
					while (reader.Read())
					{
					};
				}
				catch (XmlException e)
				{
					stringbuilder.Append(e.Message);
				}
			}
			return stringbuilder.ToString();
		}

		protected XmlDocument mDoc;
	}

	class StudentXml : XmlBaseModel
	{
		public StudentXml(string xmlPath) : base(xmlPath)
		{
			this.xmlPath = xmlPath;
			xsdPath = "../../Student.xsd";
			// check validation and load data
			string result = CheckXmlValidation("../../Student.xsd", "../../Student.xml");
			if (!result.Equals(""))
			{
				throw new XmlSchemaValidationException(result);
			}
			loadStudents();
		}

		public StudentVO getStudentById(string stuId)
		{
			foreach (StudentVO vo in stuList)
			{
				if (vo.StuId.Equals(stuId))
				{
					return vo;
				}
			}
			return null;
		}

		public List<StudentVO> getDataList()
		{
			return stuList;
		}

		public static string getGenderString(Gender gender)
		{
			switch (gender)
			{
			case (Gender.Female):
				return "女";
			case (Gender.Male):
				return "男";
			case (Gender.Unknow):
				return "未知";
			}
			return "未知";
		}

		public static string getDepartmentString(Department department)
		{
			switch (department)
			{
			case (Department.FaXueYuan):
				return "法学院";
			case (Department.LiShiXueYuan):
				return "历史学院";
			case (Department.RuanJianXueYuan):
				return  "软件学院";
			case (Department.ShangXueYuan):
				return "商学院";
			case (Department.WenXueYuan):
				return "文学院";
			case (Department.XinWenChuanBoXueYuan):
				return "新闻传播学院";
			case (Department.ZhengFuGuanLiXueYuan):
				return "政府管理学院";
			case (Department.ZheXueYuan):
				return "哲学院";
			}
			return "";
		}

		public static Gender parseGender(string gender)
		{
			if (gender.Equals("女"))
			{
				return Gender.Female;
			}
			else if (gender.Equals("男"))
			{
				return Gender.Male;
			}
			else if (gender.Equals("未知"))
			{
				return Gender.Unknow;
			}
			return Gender.Unknow;
		}

		public static Department parseDepartment(string department)
		{
			if (department.Equals("文学院"))
			{
				return Department.WenXueYuan;
			}
			else if (department.Equals("历史学院"))
			{
				return Department.LiShiXueYuan;
			}
			else if (department.Equals("法学院"))
			{
				return Department.FaXueYuan;
			}
			else if (department.Equals("哲学院"))
			{
				return Department.ZhengFuGuanLiXueYuan;
			}
			else if (department.Equals("新闻传播学院"))
			{
				return Department.XinWenChuanBoXueYuan;
			}
			else if (department.Equals("政府管理学院"))
			{
				return Department.ZhengFuGuanLiXueYuan;
			}
			else if (department.Equals("软件学院"))
			{
				return Department.RuanJianXueYuan;
			}
			else if (department.Equals("商学院"))
			{
				return Department.ShangXueYuan;
			}
			return 0;
		}

		public bool modifyStudent(StudentVO student)
		{
			bool result = false;
			XmlNode students = mDoc.LastChild;
			XmlNodeList studentNodes = students.ChildNodes;

			foreach (XmlNode node in studentNodes)
			{
				XmlNodeList attrs = node.ChildNodes;
				if (attrs[3].InnerText.Equals(student.StuId))
				{
					attrs[0].InnerText = student.Name;
					attrs[1].InnerText = student.Age + "";
					attrs[2].InnerText = getGenderString(student.Gender);
					attrs[4].ChildNodes[0].InnerText = getDepartmentString(student.Department);
					attrs[4].ChildNodes[1].InnerText = student.Major;
					result = true;
				}
			}

			if (result)
				mDoc.Save(xmlPath);

			return false;
		}

		public bool insertStudent(StudentVO student)
		{
			foreach (StudentVO vo in stuList)
			{
				if (vo.StuId.Equals(student.StuId))
				{
					return false;
				}
			}
			XmlNode students = mDoc.LastChild;
			XmlElement singleStudent = mDoc.CreateElement("student", mDoc.DocumentElement.NamespaceURI);
			XmlElement eleName = mDoc.CreateElement("name", mDoc.DocumentElement.NamespaceURI);
			eleName.InnerText = student.Name;
			XmlElement eleAge = mDoc.CreateElement("age", mDoc.DocumentElement.NamespaceURI);
			eleAge.InnerText = student.Age.ToString();
			XmlElement eleGender = mDoc.CreateElement("gender", mDoc.DocumentElement.NamespaceURI);
			eleGender.InnerText = getGenderString(student.Gender);
			XmlElement eleMAJOR = mDoc.CreateElement("major", mDoc.DocumentElement.NamespaceURI);
			XmlElement eleStuId = mDoc.CreateElement("stuId", mDoc.DocumentElement.NamespaceURI);
			eleStuId.InnerText = student.StuId;
			XmlElement eleDepartment = mDoc.CreateElement("department", mDoc.DocumentElement.NamespaceURI);
			eleDepartment.InnerText = getDepartmentString(student.Department);
			XmlElement eleMajor = mDoc.CreateElement("major", mDoc.DocumentElement.NamespaceURI);
			eleMajor.InnerText = student.Major;
			eleMAJOR.AppendChild(eleDepartment);
			eleMAJOR.AppendChild(eleMajor);
			singleStudent.AppendChild(eleName);
			singleStudent.AppendChild(eleAge);
			singleStudent.AppendChild(eleGender);
			singleStudent.AppendChild(eleStuId);
			singleStudent.AppendChild(eleMAJOR);
			students.AppendChild(singleStudent);

			mDoc.Save(xmlPath);
			stuList.Add(student);

			return true;
		}

		public bool deleteStudent(string stuId)
		{
			bool result = false;
			for (int i = 0; i < stuList.Count; ++i)
			{
				if (stuList.ElementAt(i).StuId.Equals(stuId))
				{
					stuList.RemoveAt(i);
					--i;
					result = true;
				}
			}

			XmlNode students = mDoc.LastChild;
			XmlNodeList studentNodes = students.ChildNodes;
			for (int i = 0; i < studentNodes.Count; ++i)
			{
				if (studentNodes[i].ChildNodes[3].InnerText.Equals(stuId))
				{
					students.RemoveChild(studentNodes[i]);
					--i;
				}
			}

			if (result)
			{
				mDoc.Save(xmlPath);
			}

			return result;
		}

		public enum Department
		{
			WenXueYuan, LiShiXueYuan, FaXueYuan, ZheXueYuan, XinWenChuanBoXueYuan, ZhengFuGuanLiXueYuan, RuanJianXueYuan, ShangXueYuan
		}

		public enum Gender
		{
			Female, Male, Unknow
		}

		public class StudentVO
		{
			public string Name
			{
				get
				{
					return name;
				}
				set
				{
					name = value;
				}
			}

			public int Age
			{
				get
				{
					return age;
				}
				set
				{
					if (value <= 0 || value >= 120)
					{
						throw new Exception("Age should be between 0 and 120");
					}
					age = value;
				}
			}

			public Gender Gender
			{
				get
				{
					return gender;
				}
				set
				{
					gender = value;
				}
			}

			public string StuId
			{
				get
				{
					return stuId;
				}
				set
				{
					stuId = value;
				}
			}

			public Department Department
			{
				get
				{
					return department;
				}
				set
				{
					department = value;
				}
			}

			public string Major
			{
				get
				{
					return major;
				}
				set
				{
					major = value;
				}
			}
			string name;
			int age;
			Gender gender;
			string stuId;
			Department department;
			string major;
		}

		private void loadStudents()
		{
			XmlNode students = mDoc.LastChild;
			XmlNodeList studentNodes = students.ChildNodes;

			if (stuList == null)
			{
				stuList = new List<StudentVO>();
			}
			else
			{
				stuList.Clear();
			}
			foreach (XmlNode node in studentNodes)
			{

				StudentVO stu = new StudentVO();
				XmlNodeList attrs = node.ChildNodes;
				stu.Name = attrs[0].InnerText;
				stu.Age = int.Parse(attrs[1].InnerText);
				stu.Gender = parseGender(attrs[2].InnerText);
				stu.StuId = attrs[3].InnerText;
				stu.Department = parseDepartment(attrs[4].ChildNodes[0].InnerText);
				stu.Major = attrs[4].ChildNodes[1].InnerText;

				stuList.Add(stu);
			}
		}

		private string xmlPath;
		private string xsdPath;
		private List<StudentVO> stuList;
	}
}
