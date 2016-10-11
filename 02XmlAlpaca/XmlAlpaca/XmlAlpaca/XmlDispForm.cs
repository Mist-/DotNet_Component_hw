using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Xml.Schema;

using XmlAlpaca.Xml;
using StudentVO = XmlAlpaca.Xml.StudentXml.StudentVO;

namespace XmlAlpaca
{
	public partial class XmlDispForm : Form
	{
		public XmlDispForm()
		{
			InitializeComponent();
			StudentXml studentXml;
			try
			{
				studentXml = new StudentXml("../../Student.xml");
			}
			catch (XmlSchemaValidationException e)
			{
				MessageBox.Show(e.Message);
				return;
			}
			StudentXml.StudentVO vo = new StudentXml.StudentVO();
			vo.Name = "stu3";
			vo.Major = "99999";
			vo.StuId = "6666";
			vo.Department = StudentXml.Department.FaXueYuan;
			vo.Gender = StudentXml.Gender.Female;
			vo.Age = 66;
			studentXml.modifyStudent(vo);
		}

		private void initData(string xmlPath)
		{
			lvStudents.Clear();
			xml = new StudentXml(xmlPath);
			lvStudents.Columns.Add("学号", 50, HorizontalAlignment.Left);
			lvStudents.Columns.Add("姓名", 50, HorizontalAlignment.Left);
			lvStudents.Columns.Add("性别", 30, HorizontalAlignment.Left);
			lvStudents.Columns.Add("院系", 50, HorizontalAlignment.Left);

			lvStudents.BeginUpdate();
			foreach (StudentXml.StudentVO vo in xml.getDataList())
			{
				ListViewItem item = new ListViewItem();
				item.Text = vo.StuId;
				item.SubItems.Add(vo.Name);
				item.SubItems.Add(StudentXml.getGenderString(vo.Gender));
				item.SubItems.Add(StudentXml.getDepartmentString(vo.Department));
				
				lvStudents.Items.Add(item);
			}
			lvStudents.EndUpdate();	
		}

		private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Xml文件|*.xml";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				xmlPath = dialog.FileName;
				initData(dialog.FileName);
			}
			button3.Enabled = true;
		}

		private StudentXml xml;

		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void lvStudents_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void lvStudents_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListViewHitTestInfo info = lvStudents.HitTest(e.X, e.Y);
			ListViewItem item = info.Item;
			if (item == null)
			{
				return;
			}
			StudentXml.StudentVO vo = xml.getStudentById(item.Text);
			if (vo == null)
			{
				MessageBox.Show("无法找到这个项目。");
				return;
			}
			txtName.Enabled = true;
			txtAge.Enabled = true;
			txtMajor.Enabled = true;
			cboxDepartment.Enabled = true;
			cboxGender.Enabled = true;

			txtStuId.Text = vo.StuId;
			txtName.Text = vo.Name;
			txtAge.Text = vo.Age + "";
			txtMajor.Text = vo.Major;
			cboxGender.SelectedIndex = (int) vo.Gender;
			cboxDepartment.SelectedIndex = (int) vo.Department;

			button1.Enabled = true;
			button3.Enabled = true;
			button2.Enabled = false;
		}
		private string xmlPath;

		private void button2_Click(object sender, EventArgs e)
		{
			bool exist = true;
			button2.Enabled = false;
			StudentVO vo = xml.getStudentById(txtStuId.Text);
			if (vo == null)
			{
				exist = false;
				vo = new StudentVO();
			}
			try
			{
				vo.StuId = txtStuId.Text;
				vo.Name = txtName.Text;
				vo.Major = txtMajor.Text;
				vo.Gender = (StudentXml.Gender)cboxGender.SelectedIndex;
				vo.Department = (StudentXml.Department)cboxDepartment.SelectedIndex;
				vo.Age = int.Parse(txtAge.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n信息保存失败", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				button2.Enabled = true;
				return;
			}
			txtStuId.Enabled = false;
			if (exist)
			{
				xml.modifyStudent(vo);
			}
			else
			{
				xml.insertStudent(vo);
			}
			initData(xmlPath);
		}

		private void txtStuId_TextChanged(object sender, EventArgs e)
		{
			button2.Enabled = true;
			button3.Enabled = false;
			button1.Enabled = false;
		}

		private void txtName_TextChanged(object sender, EventArgs e)
		{
			button2.Enabled = true;
			button3.Enabled = false;
			button1.Enabled = false;
		}

		private void txtAge_TextChanged(object sender, EventArgs e)
		{
			button2.Enabled = true;
			button3.Enabled = false;
			button1.Enabled = false;
		}

		private void cboxGender_SelectedIndexChanged(object sender, EventArgs e)
		{
			button2.Enabled = true;
			button3.Enabled = false;
			button1.Enabled = false;
		}

		private void cboxDepartment_SelectedIndexChanged(object sender, EventArgs e)
		{
			button2.Enabled = true;
			button3.Enabled = false;
			button1.Enabled = false;
		}

		private void txtMajor_TextChanged(object sender, EventArgs e)
		{
			button2.Enabled = true;
			button3.Enabled = false;
			button1.Enabled = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			button1.Enabled = false;
			button3.Enabled = true;
			if (!xml.deleteStudent(txtStuId.Text))
			{
				MessageBox.Show("删除失败，项目可能已经被删除", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			initData(xmlPath);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			txtStuId.Enabled = true;
			txtStuId.Text = "";
			txtName.Enabled = true;
			txtName.Text = "";
			txtAge.Enabled = true;
			txtAge.Text = "";
			txtMajor.Enabled = true;
			txtMajor.Text = "";
			cboxDepartment.Enabled = true;
			cboxDepartment.Text = "";
			cboxGender.Enabled = true;
			cboxGender.Text = "";
		}
	}
}
