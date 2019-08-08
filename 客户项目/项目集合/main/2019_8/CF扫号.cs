﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace main._2019_8
{
    public partial class CF扫号 : Form
    {
        public CF扫号()
        {
            InitializeComponent();
        }

        Dictionary<string, string> dic = new Dictionary<string, string>();


        ArrayList QQs = new ArrayList();
        private void button4_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;

                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入手机号文本");
                    label1.Text = "请输入手机号文本";
                    return;
                }
                StreamReader sr = new StreamReader(textBox1.Text, Encoding.Default);
                //一次性读取完 
                string texts = sr.ReadToEnd();
               string[]  text = texts.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                for (int i = 0; i < text.Length; i++)
                {
                    ListViewItem lv1 = listView1.Items.Add((listView1.Items.Count).ToString()); //使用Listview展示数据         
                    lv1.SubItems.Add(text[i].Trim());   
                    lv1.SubItems.Add(" ");   

                }

                }

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                QQs.Add(listView1.Items[i].SubItems[1].Text);
            }
            }
        bool zanting = true;
        int yipao = 0;
        ArrayList finishes = new ArrayList();

        public void run()
        {

           
            for (int i = 0; i < QQs.Count; i++)
            {
                
                if (!finishes.Contains(QQs[i].ToString()))
                {
                   
                    
                    ArrayList daqus = new ArrayList();
                    yipao = yipao + 1;
                  
                    finishes.Add(QQs[i].ToString());

                   
                    foreach (string key in dic.Keys)
                    {
                        label1.Text = "正在验证" + listView1.Items[i].SubItems[1].Text + key+"累计已验证"+yipao;
                        string URL = "https://api.unipay.qq.com/v1/r/1450000251/get_role_list?pf=mds_pay-__mds_webpay_iframe.pay-website&pfkey=pfkey&aid=pay.index.cf&from_h5=1&pc_st=E2D80D51-48B1-4240-A654-919166A6CBE21565238778900&r=0.7314007353164214&openid=852266010&openkey=%409yx6R0I7F&session_id=uin&session_type=skey&sck=A9B0470293274E3B604AE58C46F37425&anti_auto_script_token_id=E34436CBB13DFA9AD8585CD634A2339C87B32152C86AD0EA7ECE6B593DB5993CCC8060CF2A5D46A338A1C5A774AE16DFC4AD5056C880BFA3AB13D036D3028D3E&isusempaymode=1&zoneid="+dic[key]+"&game_scene=dq_pay&provide_uin="+listView1.Items[i].SubItems[1].Text+"&webversion=minipayv2&from_https=1&t=1565238808154&__refer=https%3A%2F%2Fpay.qq.com%2Fmidas%2Fminipay_v2%2Fviews%2Fpayindex%2Fpcgame.shtml%3Fcode%3Dcfdq%26aid%3Dpay.index.cf%26pf%3Dmds_pay-__mds_webpay_iframe.pay-website%26extend%3DeditableForTeam%253D0%26openid%3D%26openkey%3D%26session_id%3Duin%26session_type%3Dvask_27";

                        string html = method.GetUrl(URL, "utf-8");

                        if (html.Contains("role"))
                        {
                           
                            // listView1.Items[i].SubItems[2].Text=key;
                            daqus.Add(key);
                        }

                  

                        while (this.zanting == false)
                        {
                            label1.Text = "已暂停....";
                            Application.DoEvents();//如果loader是false表明正在加载,,则Application.DoEvents()意思就是处理其他消息。阻止当前的队列继续执行。
                        }

                    }

                    if (daqus.Count == 0)
                    {
                        listView1.Items[i].SubItems[2].Text = "未创建";
                    }
                    else
                    {
                        for (int j = 0; j < daqus.Count; j++)
                        {
                            listView1.Items[i].SubItems[2].Text += daqus[j].ToString();
                        }
                    }


                }
            }

            label1.Text = "全部验证结束";

        }
       
    private void button1_Click(object sender, EventArgs e)
        {



            for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
            {
                Thread thread = new Thread(new ThreadStart(run));
                thread.Start();
                Control.CheckForIllegalCrossThreadCalls = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zanting = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zanting = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            method.ListviewToTxt(listView1);
        }

        private void CF扫号_Load(object sender, EventArgs e)
        {
            dic.Add("教育网专区", "361");
            dic.Add("移动专区", "360");
            dic.Add("河北一区", "355");
            dic.Add("河南二区", "359");
            dic.Add("河南一区", "345");
            dic.Add("山西网通一区", "354");
            dic.Add("山东网通二区", "358");
            dic.Add("山东网通一区", "346");
            dic.Add("北京网通四区", "335");
            dic.Add("北京网通三区", "334");
            dic.Add("北京网通二区", "321");
            dic.Add("北京网通一区", "319");
            dic.Add("吉林网通一区", "351");
            dic.Add("黑龙江网通区", "350");
            dic.Add("辽宁网通三区", "336");
            dic.Add("辽宁网通二区", "323");
            dic.Add("辽宁网通一区", "322");
            dic.Add("北方网通大区", "343");
            dic.Add("云南电信一区", "348");
            dic.Add("安徽电信一区", "347");
            dic.Add("重庆电信一区", "332");
            dic.Add("四川电信二区", "356");
            dic.Add("四川电信一区", "333");
            dic.Add("陕西电信一区", "330");
            dic.Add("江西电信一区", "352");
            dic.Add("福建电信一区", "324");
            dic.Add("江苏电信二区", "357");
            dic.Add("江苏电信一区", "344");
            dic.Add("浙江电信二区", "349");
            dic.Add("浙江电信一区", "325");
            dic.Add("湖北电信二区", "329");
            dic.Add("湖北电信一区", "328");
            dic.Add("湖南电信二区", "340");
            dic.Add("湖南电信一区", "341");
            dic.Add("南方电信大区", "342");
            dic.Add("广西电信一区", "353");
            dic.Add("广东电信四区", "339");
            dic.Add("广东电信三区", "338");
            dic.Add("广东电信二区", "327");
            dic.Add("广东电信一区", "318");
            dic.Add("上海电信二区", "326");
            dic.Add("上海电信一区", "320");


        }
    }
}
