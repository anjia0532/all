﻿namespace 主程序202005
{
    partial class 豆丁过滤
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("宋体", 9F);
            this.button7.Location = new System.Drawing.Point(120, 150);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(45, 29);
            this.button7.TabIndex = 55;
            this.button7.Text = "导入";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(10, 20);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(104, 159);
            this.textBox8.TabIndex = 52;
            this.textBox8.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Location = new System.Drawing.Point(11, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 185);
            this.groupBox2.TabIndex = 106;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "导入关键字";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(112, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 105;
            this.label2.Text = "~";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(11, 478);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(206, 123);
            this.textBox3.TabIndex = 104;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(837, 583);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(843, 589);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(837, 583);
            this.listView1.TabIndex = 33;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "docid";
            this.columnHeader2.Width = 240;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "标题";
            this.columnHeader4.Width = 300;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全选ToolStripMenuItem,
            this.取消全选ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // 取消全选ToolStripMenuItem
            // 
            this.取消全选ToolStripMenuItem.Name = "取消全选ToolStripMenuItem";
            this.取消全选ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.取消全选ToolStripMenuItem.Text = "取消全选";
            this.取消全选ToolStripMenuItem.Click += new System.EventHandler(this.取消全选ToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(843, 589);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "登录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(223, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(851, 615);
            this.tabControl1.TabIndex = 103;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 320);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 21);
            this.textBox1.TabIndex = 94;
            this.textBox1.Text = "1";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(115, 346);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(40, 21);
            this.textBox4.TabIndex = 102;
            this.textBox4.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(19, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 101;
            this.label3.Text = "删除间隔(秒)：";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.MistyRose;
            this.button5.Location = new System.Drawing.Point(12, 406);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(77, 30);
            this.button5.TabIndex = 100;
            this.button5.Text = "清空";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.MistyRose;
            this.button4.Location = new System.Drawing.Point(97, 406);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 30);
            this.button4.TabIndex = 99;
            this.button4.Text = "继续";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.MistyRose;
            this.button3.Location = new System.Drawing.Point(95, 370);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 30);
            this.button3.TabIndex = 98;
            this.button3.Text = "暂停";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("宋体", 10F);
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(12, 442);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 30);
            this.button2.TabIndex = 97;
            this.button2.Text = "删除选中文档";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.Location = new System.Drawing.Point(12, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 30);
            this.button1.TabIndex = 96;
            this.button1.Text = "开始筛选";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(132, 320);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 21);
            this.textBox2.TabIndex = 95;
            this.textBox2.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(19, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 93;
            this.label1.Text = "页码：";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(12, 238);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(179, 62);
            this.textBox5.TabIndex = 110;
            this.textBox5.Text = "其他其他其他其他其他其他其他其他其他其他其他其他其他其他其他其他其他其他其他其他其他其他其他其他他其他其他其他其他\r\n他其他其他其他其他\r\n他其他其他其他其他\r\n" +
    "他其他其他其他其他\r\n他其他其他其他其他\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 111;
            this.label4.Text = "删除说明：";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(120, 97);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 16);
            this.radioButton1.TabIndex = 56;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "不设置关键字";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // 豆丁过滤
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 615);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Name = "豆丁过滤";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "豆丁过滤";
            this.Load += new System.EventHandler(this.豆丁过滤_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消全选ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}