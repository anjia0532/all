﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fang.直播平台软件
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        bool status = true;

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        #region  奇秀平台
        public void run()
        {

            try
            {

                for (int i = 1; i < 20; i++)
                {
                    String Url = "https://x.pps.tv/category/newIndex/alllive/s0-a0-f0-b1-p" + i;

                    string strhtml = method.GetUrl(Url, "utf-8");
                  
                    MatchCollection TitleMatchs = Regex.Matches(strhtml, @"<a href=""/room/([\s\S]*?)""", RegexOptions.IgnoreCase | RegexOptions.Multiline);

                    ArrayList lists = new ArrayList();
                    foreach (Match NextMatch in TitleMatchs)
                    {
                        lists.Add("https://x.pps.tv/room/" + NextMatch.Groups[1].Value);
                      
                    }

                    if (lists.Count == 0)  //当前页没有网址数据跳过之后的网址采集，进行下个foreach采集

                        break;


                    foreach (string url in lists)
                    {
                        

                        string html = method.GetUrl(url, "utf-8");



                        Match infos = Regex.Match(html, @"notice_msg"":""([\s\S]*?)""");
                        Match name = Regex.Match(html, @"<title>([\s\S]*?)-");

                        ListViewItem lv1 = listView1.Items.Add(listView1.Items.Count.ToString());
                        lv1.SubItems.Add(url);
                        lv1.SubItems.Add(method.UnicodeToStr(infos.Groups[1].Value.Trim()));
                        lv1.SubItems.Add(name.Groups[1].Value.Trim());


                        if (listView1.Items.Count > 1)
                        {
                            listView1.EnsureVisible(listView1.Items.Count - 1);  //滚动到指定位置
                        }
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(Convert.ToInt32(1000));

                        while (this.status == false)
                        {
                            Application.DoEvents();//如果loader是false表明正在加载,,则Application.DoEvents()意思就是处理其他消息。阻止当前的队列继续执行。
                        }

                    }


                }
            }


            catch (System.Exception ex)
            {

                MessageBox.Show( ex.ToString());
            }

        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.status = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.status = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            method.DataTableToExcel(method.listViewToDataTable(this.listView1), "Sheet1", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.status = true;

            Thread thread = new Thread(new ThreadStart(run));
            Control.CheckForIllegalCrossThreadCalls = false;
            thread.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
    }
}
