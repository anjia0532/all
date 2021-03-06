﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 主程序202010
{
    public partial class 拼接访问 : Form
    {
        public 拼接访问()
        {
            InitializeComponent();
        }
        #region GET请求
        /// <summary>
        /// GET请求
        /// </summary>
        /// <param name="Url">网址</param>
        /// <returns></returns>
        public static string GetUrl(string Url)
        {


            try
            {
               
                string COOKIE = "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);  //创建一个链接
                request.Referer = "";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36";
                //request.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 12_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/7.0.10(0x17000a21) NetType/4G Language/zh_CN";
                request.AllowAutoRedirect = true;
                request.Headers.Add("Cookie", COOKIE);

                request.KeepAlive = true;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;  //获取反馈
                request.Timeout = 5000;
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")); //reader.ReadToEnd() 表示取得网页的源码流 需要引用 using  IO
                string content = reader.ReadToEnd();


                reader.Close();
                response.Close();
                return content;



            }
            catch (System.Exception ex)
            {
                ex.ToString();

            }
            return "";
        }
        #endregion

        int value = 0;
        public string getcardcode()
        {
            value = value + 1;
            label10.Text = value.ToString();
            StreamReader sr = new StreamReader(textBox8.Text, Encoding.GetEncoding("utf-8"));
            //一次性读取完 
            string texts = sr.ReadToEnd();

            string[] text = texts.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            if (text.Length > value)
            {
                
                return text[value];
            }
            else
            {
                MessageBox.Show("身份证号码不足");
                return "";
            }
            
        }
        private void 拼接访问_Load(object sender, EventArgs e)
        {
            this.Height = 200;
            // method.EncodingType.GetTxtType("path");
        }
        public void run()
        {
            StreamReader sr = new StreamReader(textBox1.Text, EncodingType.GetTxtType(textBox1.Text));
            //一次性读取完 
            string texts = sr.ReadToEnd();
          
            //string[] text = texts.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            //for (int i = 0; i < text.Length; i++)
            //{

            //    ListViewItem lv1 = listView1.Items.Add(listView1.Items.Count.ToString()); //使用Listview展示数据
            //    lv1.SubItems.Add(text[i]);


            //}

            MatchCollection names = Regex.Matches(texts, @"客户姓名：.*");
            MatchCollection codes = Regex.Matches(texts, @"营销站点：.*");
            MatchCollection tels = Regex.Matches(texts, @"客户电话：.*");
            MatchCollection times = Regex.Matches(texts, @"营销时间：.*");
            for (int i = 0; i < names.Count; i++)
            {
                
                string cardno = getcardcode();

                string name = names[i].Groups[0].Value.Replace("客户姓名：","").Trim();
                string code = Regex.Match(codes[i].Groups[0].Value, @"\d{5,}").Groups[0].Value.Trim();
                string tel = tels[i].Groups[0].Value.Replace("客户电话：", "").Trim();
                string time = times[i].Groups[0].Value.Replace("营销时间：", "").Replace(":","").Replace("-","").Replace(" ","").Trim();
                 ListViewItem lv1 = listView1.Items.Add(name); //使用Listview展示数据
                string url = "http://219.146.167.66:2100/qdyx/bg/m/ReadCardResult.aspx?CPhone=" + tel + "&UNum=" + code + "&ITime=" + time + "&UType=1&UCardID=" + cardno + "&UName=" + name + "&UAddress=" + textBox9.Text.Trim() + "&UNational=汉族";
                string html = GetUrl(url);
                Match msg = Regex.Match(html, @"alert\('([\s\S]*?)'");
                lv1.SubItems.Add(msg.Groups[1].Value);
                Thread.Sleep(Convert.ToInt32(textBox10.Text));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            string url = "http://219.146.167.66:2100/qdyx/bg/m/ReadCardResult.aspx?CPhone=" + textBox3.Text.Trim() + "&UNum=37020496" + textBox4.Text.Trim() + "&ITime=" + textBox5.Text.Trim() + "&UType=1&UCardID=" + textBox6.Text.Trim() + "&UName=" + textBox2.Text.Trim() + "&UAddress=" + textBox7.Text.Trim() + "&UNational=汉族";
            string html = GetUrl(url);
            Match msg = Regex.Match(html, @"alert\('([\s\S]*?)'");
            MessageBox.Show(msg.Groups[1].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = this.openFileDialog1.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                this.textBox1.Text = this.openFileDialog1.FileName;
            }

           
        }

        #region 获取txt编码
        //调用：EncodingType.GetTxtType(textBox1.Text)
        public class EncodingType
        {
            /// <summary> 
            /// 给定文件的路径，读取文件的二进制数据，判断文件的编码类型 
            /// </summary> 
            /// <param name=“FILE_NAME“>文件路径</param> 
            /// <returns>文件的编码类型</returns> 
            public static System.Text.Encoding GetTxtType(string FILE_NAME)
            {
                FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read);
                Encoding r = GetType(fs);
                fs.Close();
                return r;
            }

            /// <summary> 
            /// 通过给定的文件流，判断文件的编码类型 
            /// </summary> 
            /// <param name=“fs“>文件流</param> 
            /// <returns>文件的编码类型</returns> 
            public static System.Text.Encoding GetType(FileStream fs)
            {
                byte[] Unicode = new byte[] { 0xFF, 0xFE, 0x41 };
                byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF, 0x00 };
                byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF }; //带BOM 
                Encoding reVal = Encoding.Default;

                BinaryReader r = new BinaryReader(fs, System.Text.Encoding.Default);
                int i;
                int.TryParse(fs.Length.ToString(), out i);
                byte[] ss = r.ReadBytes(i);
                if (IsUTF8Bytes(ss) || (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF))
                {
                    reVal = Encoding.UTF8;
                }
                else if (ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00)
                {
                    reVal = Encoding.BigEndianUnicode;
                }
                else if (ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41)
                {
                    reVal = Encoding.Unicode;
                }
                r.Close();
                return reVal;

            }

            /// <summary> 
            /// 判断是否是不带 BOM 的 UTF8 格式 
            /// </summary> 
            /// <param name=“data“></param> 
            /// <returns></returns> 
            private static bool IsUTF8Bytes(byte[] data)
            {
                int charByteCounter = 1; //计算当前正分析的字符应还有的字节数 
                byte curByte; //当前分析的字节. 
                for (int i = 0; i < data.Length; i++)
                {
                    curByte = data[i];
                    if (charByteCounter == 1)
                    {
                        if (curByte >= 0x80)
                        {
                            //判断当前 
                            while (((curByte <<= 1) & 0x80) != 0)
                            {
                                charByteCounter++;
                            }
                            //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X 
                            if (charByteCounter == 1 || charByteCounter > 6)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //若是UTF-8 此时第一位必须为1 
                        if ((curByte & 0xC0) != 0x80)
                        {
                            return false;
                        }
                        charByteCounter--;
                    }
                }
                if (charByteCounter > 1)
                {
                    throw new Exception("非预期的byte格式");
                }
                return true;
            }
        }

        #endregion
        Thread thread;
        private void button3_Click(object sender, EventArgs e)
        {
         

            if (textBox1.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("请完善信息");
                return;
            }
            listView1.Items.Clear();

            if (thread == null || !thread.IsAlive)
            {
                thread = new Thread(run);
                thread.Start();
                Control.CheckForIllegalCrossThreadCalls = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool flag = this.openFileDialog1.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                this.textBox8.Text = this.openFileDialog1.FileName;
            }
        }
    }
}
