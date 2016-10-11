namespace XmlAlpaca
{
	partial class XmlDispForm
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lvStudents = new System.Windows.Forms.ListView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboxGender = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtAge = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.cboxDepartment = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtMajor = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtStuId = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(890, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 文件ToolStripMenuItem
			// 
			this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.退出ToolStripMenuItem});
			this.文件ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
			this.文件ToolStripMenuItem.ShortcutKeyDisplayString = "F";
			this.文件ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.文件ToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
			this.文件ToolStripMenuItem.Text = "文件(F)";
			// 
			// 打开ToolStripMenuItem
			// 
			this.打开ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
			this.打开ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.打开ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
			this.打开ToolStripMenuItem.Text = "打开";
			this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
			// 
			// lvStudents
			// 
			this.lvStudents.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lvStudents.Location = new System.Drawing.Point(13, 31);
			this.lvStudents.Name = "lvStudents";
			this.lvStudents.Size = new System.Drawing.Size(249, 513);
			this.lvStudents.TabIndex = 3;
			this.lvStudents.UseCompatibleStateImageBehavior = false;
			this.lvStudents.View = System.Windows.Forms.View.Details;
			this.lvStudents.SelectedIndexChanged += new System.EventHandler(this.lvStudents_SelectedIndexChanged);
			this.lvStudents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvStudents_MouseDoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtStuId);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtMajor);
			this.groupBox1.Controls.Add(this.cboxDepartment);
			this.groupBox1.Controls.Add(this.cboxGender);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtAge);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(268, 31);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(610, 508);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "详细信息";
			// 
			// cboxGender
			// 
			this.cboxGender.Enabled = false;
			this.cboxGender.FormattingEnabled = true;
			this.cboxGender.Items.AddRange(new object[] {
            "女",
            "男",
            "未知"});
			this.cboxGender.Location = new System.Drawing.Point(65, 131);
			this.cboxGender.Name = "cboxGender";
			this.cboxGender.Size = new System.Drawing.Size(272, 28);
			this.cboxGender.TabIndex = 11;
			this.cboxGender.SelectedIndexChanged += new System.EventHandler(this.cboxGender_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 20);
			this.label4.TabIndex = 10;
			this.label4.Text = "院系";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 134);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 20);
			this.label3.TabIndex = 8;
			this.label3.Text = "性别";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 100);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "年龄";
			// 
			// txtAge
			// 
			this.txtAge.Enabled = false;
			this.txtAge.Location = new System.Drawing.Point(65, 97);
			this.txtAge.Name = "txtAge";
			this.txtAge.Size = new System.Drawing.Size(272, 27);
			this.txtAge.TabIndex = 5;
			this.txtAge.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "姓名";
			// 
			// txtName
			// 
			this.txtName.Enabled = false;
			this.txtName.Location = new System.Drawing.Point(65, 64);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(272, 27);
			this.txtName.TabIndex = 0;
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// cboxDepartment
			// 
			this.cboxDepartment.Enabled = false;
			this.cboxDepartment.FormattingEnabled = true;
			this.cboxDepartment.Items.AddRange(new object[] {
            "文学院",
            "历史学院",
            "法学院",
            "哲学院",
            "新闻传播学院",
            "政府管理学院",
            "软件学院",
            "商学院"});
			this.cboxDepartment.Location = new System.Drawing.Point(65, 165);
			this.cboxDepartment.Name = "cboxDepartment";
			this.cboxDepartment.Size = new System.Drawing.Size(272, 28);
			this.cboxDepartment.TabIndex = 12;
			this.cboxDepartment.SelectedIndexChanged += new System.EventHandler(this.cboxDepartment_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 202);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(39, 20);
			this.label5.TabIndex = 14;
			this.label5.Text = "专业";
			// 
			// txtMajor
			// 
			this.txtMajor.Enabled = false;
			this.txtMajor.Location = new System.Drawing.Point(65, 199);
			this.txtMajor.Name = "txtMajor";
			this.txtMajor.Size = new System.Drawing.Size(272, 27);
			this.txtMajor.TabIndex = 13;
			this.txtMajor.TextChanged += new System.EventHandler(this.txtMajor_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 34);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(39, 20);
			this.label6.TabIndex = 16;
			this.label6.Text = "学号";
			// 
			// txtStuId
			// 
			this.txtStuId.Enabled = false;
			this.txtStuId.Location = new System.Drawing.Point(65, 31);
			this.txtStuId.Name = "txtStuId";
			this.txtStuId.Size = new System.Drawing.Size(272, 27);
			this.txtStuId.TabIndex = 15;
			this.txtStuId.TextChanged += new System.EventHandler(this.txtStuId_TextChanged);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(262, 232);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 29);
			this.button2.TabIndex = 17;
			this.button2.Text = "保存";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(65, 232);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 29);
			this.button1.TabIndex = 18;
			this.button1.Text = "删除";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(166, 232);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 29);
			this.button3.TabIndex = 19;
			this.button3.Text = "新建";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// XmlDispForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(890, 551);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lvStudents);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "XmlDispForm";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
		private System.Windows.Forms.ListView lvStudents;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtAge;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.ComboBox cboxGender;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtMajor;
		private System.Windows.Forms.ComboBox cboxDepartment;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtStuId;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button3;
	}
}

