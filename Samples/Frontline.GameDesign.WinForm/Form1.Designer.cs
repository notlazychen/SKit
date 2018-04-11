namespace Frontline.GameDesign.WinForm
{
    partial class Form1
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.buttonImprotDb = new System.Windows.Forms.Button();
            this.buttonCheckShips = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.textBoxRootPath = new System.Windows.Forms.TextBox();
            this.buttonOpenDir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 28);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(187, 404);
            this.checkedListBox1.TabIndex = 1;
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(12, 6);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(48, 16);
            this.checkBoxSelectAll.TabIndex = 2;
            this.checkBoxSelectAll.Text = "全选";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // buttonImprotDb
            // 
            this.buttonImprotDb.Location = new System.Drawing.Point(345, 111);
            this.buttonImprotDb.Name = "buttonImprotDb";
            this.buttonImprotDb.Size = new System.Drawing.Size(75, 23);
            this.buttonImprotDb.TabIndex = 3;
            this.buttonImprotDb.Text = "导入数据库";
            this.buttonImprotDb.UseVisualStyleBackColor = true;
            this.buttonImprotDb.Click += new System.EventHandler(this.buttonImprotDb_Click);
            // 
            // buttonCheckShips
            // 
            this.buttonCheckShips.Location = new System.Drawing.Point(224, 111);
            this.buttonCheckShips.Name = "buttonCheckShips";
            this.buttonCheckShips.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckShips.TabIndex = 4;
            this.buttonCheckShips.Text = "检查表关联";
            this.buttonCheckShips.UseVisualStyleBackColor = true;
            this.buttonCheckShips.Click += new System.EventHandler(this.buttonCheckShips_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 12;
            this.listBoxLog.Location = new System.Drawing.Point(436, 16);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(352, 424);
            this.listBoxLog.TabIndex = 5;
            // 
            // textBoxRootPath
            // 
            this.textBoxRootPath.Location = new System.Drawing.Point(224, 28);
            this.textBoxRootPath.Name = "textBoxRootPath";
            this.textBoxRootPath.ReadOnly = true;
            this.textBoxRootPath.Size = new System.Drawing.Size(196, 21);
            this.textBoxRootPath.TabIndex = 6;
            // 
            // buttonOpenDir
            // 
            this.buttonOpenDir.Location = new System.Drawing.Point(345, 55);
            this.buttonOpenDir.Name = "buttonOpenDir";
            this.buttonOpenDir.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenDir.TabIndex = 7;
            this.buttonOpenDir.Text = "选择根目录";
            this.buttonOpenDir.UseVisualStyleBackColor = true;
            this.buttonOpenDir.Click += new System.EventHandler(this.buttonOpenDir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonOpenDir);
            this.Controls.Add(this.textBoxRootPath);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonCheckShips);
            this.Controls.Add(this.buttonImprotDb);
            this.Controls.Add(this.checkBoxSelectAll);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "Form1";
            this.Text = "数值表格导入工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.Button buttonImprotDb;
        private System.Windows.Forms.Button buttonCheckShips;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.TextBox textBoxRootPath;
        private System.Windows.Forms.Button buttonOpenDir;
    }
}

