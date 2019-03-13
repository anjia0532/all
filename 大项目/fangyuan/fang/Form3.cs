﻿using Microsoft.Win32;
using System;
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

namespace fang
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            method.get58CityName(comboBox1);


          
        }

        int a = 0;


        #region  58经纪人
        public void jingjiren()
        {

            try
            {


               

                    string city = method.Get58pinyin(comboBox1.SelectedItem.ToString());

                    for (int i = 2; i <141; i++)
                    {
                        String Url = "https://broker.58.com/"+city+"/list/pn"+i+"/";

                        string html = method.GetUrl(Url,"utf-8");


                        MatchCollection TitleMatchs = Regex.Matches(html, @"detail\/([\s\S]*?)\.", RegexOptions.IgnoreCase | RegexOptions.Multiline);

                        ArrayList lists = new ArrayList();
                        foreach (Match NextMatch in TitleMatchs)
                        {
                            lists.Add("https://broker.58.com/"+city+"/detail/" + NextMatch.Groups[1].Value + ".shtml");

                        }

                    

                        if (lists.Count == 0)  //当前页没有网址数据跳过之后的网址采集，进行下个foreach采集

                            break;

                        foreach (string list in lists)

                        {
                        if (button2.Text == "已停止")
                            return;

                        textBox1.Text += DateTime.Now.ToString()+ "正在采集第"+i+"页"+list + "\r\n";

                        this.textBox1.Select(this.textBox1.TextLength, 0);//光标定位到文本最后
                        this.textBox1.ScrollToCaret();//滚动到光标处


                        string strhtml = method.GetUrl(list,"utf-8");                                                                                //定义的GetRul方法 返回 reader.ReadToEnd()
                                                                            

                        string rxg1 = @"<div class=""user-name"">([\s\S]*?)<";
                        
                        string rxg3 = @"所属公司<span class=""u-msg"">([\s\S]*?)<";
                        string rxg4 = @"target=""_blank"">([\s\S]*?)</a>";
                        string rxg5 = @"cityId = ""([\s\S]*?)""";
                        string rxg6 = @"brokerId = ""([\s\S]*?)""";
                       string rxg7 = @"<div class=""user-pic""><img src=""([\s\S]*?)""";


                        string rxg2 = @"data"":""([\s\S]*?)""";

                        Match name = Regex.Match(strhtml, rxg1);
                        Match company = Regex.Match(strhtml, rxg3);
                        Match xiaoqu = Regex.Match(strhtml, rxg4);
                        Match cityid = Regex.Match(strhtml, rxg5);
                        Match broid = Regex.Match(strhtml, rxg6);
                         Match img = Regex.Match(strhtml, rxg7);
                        
                       a= a+1;
                       method.downloadFile(img.Groups[1].Value, comboBox1.SelectedItem.ToString(),name.Groups[1].Value.Trim()+a+".jpg");


                        string Url2 = "https://broker.58.com/api/encphone?brokerId="+broid.Groups[1].Value.Trim()+"&cityId="+cityid.Groups[1].Value.Trim();
                        string strhtml2 = method.GetUrl(Url2,"utf-8");
                        Match tell = Regex.Match(strhtml2, rxg2);





                        ListViewItem lv1= listView1.Items.Add(name.Groups[1].Value.Trim()); //使用Listview展示数据

                        lv1.SubItems.Add(tell.Groups[1].Value.Trim());
                        lv1.SubItems.Add(company.Groups[1].Value.Trim());
                        lv1.SubItems.Add(comboBox1.SelectedItem.ToString());
                        // lv1.SubItems.Add(Regex.Replace(xiaoqu.Groups[1].Value.Trim(), "<[^>]*>", ""));
                        lv1.SubItems.Add(xiaoqu.Groups[1].Value);

                        listView1.EnsureVisible(listView1.Items.Count-1);  //滚动到指定位置

                        Application.DoEvents();
                        System.Threading.Thread.Sleep(Convert.ToInt32(500));   //内容获取间隔，可变量                     

                        }


                    }
                
            }


            catch (System.Exception ex)
            {

              textBox1.Text=  ex.ToString();
            }

        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            method.DataTableToExcel(method.listViewToDataTable(this.listView1), "Sheet1", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Text = "停止";


            //读取注册码信息才能运行软件！
            RegistryKey rsg = Registry.CurrentUser.OpenSubKey("zhucema"); //true表可修改                
            if (rsg != null && rsg.GetValue("mac") != null)  //如果值不为空
            {
                Thread thread = new Thread(new ThreadStart(jingjiren));
                Control.CheckForIllegalCrossThreadCalls = false;
                thread.Start();

            }

            else
            {
                MessageBox.Show("请注册软件！");
                login lg = new login();
                lg.Show();
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "已停止";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

          
        }
    }
}
