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
using helper;

namespace 启动程序
{
    public partial class 群抓取 : Form
    {
        public 群抓取()
        {
            InitializeComponent();
        }

        private void SplitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        bool zanting = true;




        #region POST请求
        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postData">发送的数据包</param>
        /// <param name="COOKIE">cookie</param>
        /// <param name="charset">编码格式</param>
        /// <returns></returns>
        public static string PostUrl(string url, string postData, string COOKIE, string charset,string token)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; //获取不到加上这一条
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "Post";
                //request.ContentType = "application/x-www-form-urlencoded";

                //添加头部
                WebHeaderCollection headers = request.Headers;
              
                headers.Add("x-access-token:"+token);
                //添加头部
                request.ContentType = "application/json";
                request.ContentLength = postData.Length;
                //request.ContentLength = Encoding.UTF8.GetBytes(postData).Length;
                request.AllowAutoRedirect = false;
                request.KeepAlive = true;

                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36";
                request.Headers.Add("Cookie", COOKIE);
                //request.Headers.Add("origin","https://www.nike.com");
                request.Referer = "https://accounts.ebay.com/acctxs/user";
                StreamWriter sw = new StreamWriter(request.GetRequestStream());
                sw.Write(postData);
                sw.Flush();

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;  //获取反馈
                response.GetResponseHeader("Set-Cookie");
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(charset)); //reader.ReadToEnd() 表示取得网页的源码流 需要引用 using  IO

                string html = reader.ReadToEnd();
                reader.Close();
                response.Close();
                return html;
            }
            catch (WebException ex)
            {

                return ex.ToString();
            }


        }

        #endregion

        #region GET请求
        /// <summary>
        /// GET请求
        /// </summary>
        /// <param name="Url">网址</param>
        /// <returns></returns>
        public static string GetUrl(string Url, string charset)
        {


            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; //在GetUrl()函数前加上这一句就可以
                string COOKIE = "pgv_info=ssid=s6213364120; pgv_pvid=3922950760; qq_locale_id=2052; skey=MEkNEYphE2; uin=o0852266010; o_cookie=852266010; XWINDEXGREY=0; qz_gdt=r3wy6xq5byabsz637rwq; pac_uid=1_852266010; pvid=7405547776";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);  //创建一个链接
                request.Referer = " https://qqweb.qq.com/m/relativegroup/index.html?_bid=165&source=qun_rec&_wv=16777216&_cwv=8&keyword=%E6%B8%B8%E6%88%8F";
                request.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 12_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/16F203 QQ/8.2.9.604 V1_IPH_SQ_8.2.9_1_APP_A Pixel/1080 MiniAppEnable SimpleUISwitch/0 QQTheme/1000 Core/WKWebView Device/Apple(iPhone 7Plus) NetType/4G QBWebViewType/1 WKType/1";
               
                request.AllowAutoRedirect = true;
                request.Headers.Add("Cookie", COOKIE);
                //添加头部
                WebHeaderCollection headers = request.Headers;
                headers.Add("sec-fetch-mode:navigate");
                headers.Add("sec-fetch-site:same-origin");
                headers.Add("sec-fetch-user:?1");
                headers.Add("upgrade-insecure-requests: 1");
                //添加头部
                // request.KeepAlive = true;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;  //获取反馈
                request.Timeout = 5000;
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(charset)); //reader.ReadToEnd() 表示取得网页的源码流 需要引用 using  IO
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

        string token = "";
        string cookie = "Hm_lvt_5cf1009b3f74aa0e7508611f719e561c=1586663370; Hm_lpvt_5cf1009b3f74aa0e7508611f719e561c=1586663556";
        /// <summary>
        /// 主程序
        /// </summary>
        public void wxqun()
        {
            
            string  tokenhtml = method.PostUrl("http://app.jiaqun8.cn/portal/user/login", "{\"username\":\"17606117606\",\"password\":\"zhoukaige00\"}", cookie, "utf-8");
           
            Match token = Regex.Match(tokenhtml, @"data"":""([\s\S]*?)""");
            this.token = token.Groups[1].Value;
            try
            {
                string[] array = textBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 1; j < 9999; j++)
                    {


                        string url = "http://app.jiaqun8.cn/portal/group/search/"+j+"?keyword="+System.Web.HttpUtility.UrlEncode(array[i]);
                        string postdata = "keyword: "+ System.Web.HttpUtility.UrlEncode(array[i]);
                        string html =PostUrl(url,postdata,cookie ,"utf-8",token.Groups[1].Value);

                        Match time = Regex.Match(html, @"publishTime"":""([\s\S]*?)""");
                        Match image = Regex.Match(html, @"image"":""([\s\S]*?)""");
                        if (image.Groups[1].Value == "")
                        {
                            
                            break;
                        }

                        ListViewItem lv1 = listView1.Items.Add((listView1.Items.Count + 1).ToString()); //使用Listview展示数据  
                        lv1.SubItems.Add(time.Groups[1].Value);
                        lv1.SubItems.Add(image.Groups[1].Value);
                        lv1.SubItems.Add(array[i]);
                     
                       

                        while (this.zanting == false)
                        {
                            Application.DoEvents();//如果loader是false表明正在加载,,则Application.DoEvents()意思就是处理其他消息。阻止当前的队列继续执行。
                        }
                        
                    }
                }

                button4.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }



        /// <summary>
        /// 主程序
        /// </summary>
        public void QQqun()
        {
            try
            {
                string[] array = textBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != "")
                    {


                        string url = "https://qun.qq.com/cgi-bin/group_search/group_search?retype=2&keyword=游戏&page=0&wantnum=20&city_flag=0&distance=1&ver=1&from=9&bkn=765861501&style=1";
                        string html = GetUrl(url, "utf-8");

                        textBox1.Text = html;
                        Match Userid = Regex.Match(html, @"encryptedUserId\\"":\\""([\s\S]*?)\\");
                      


                        ListViewItem lv1 = listView1.Items.Add((listView1.Items.Count + 1).ToString()); //使用Listview展示数据  
                        lv1.SubItems.Add(array[i]);
                       




                        while (this.zanting == false)
                        {
                            Application.DoEvents();//如果loader是false表明正在加载,,则Application.DoEvents()意思就是处理其他消息。阻止当前的队列继续执行。
                        }
                        Thread.Sleep(2000);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string tokenhtml = method.PostUrl("http://app.jiaqun8.cn/portal/user/login", "{\"username\":\"17606117606\",\"password\":\"zhoukaige00\"}", cookie, "utf-8");

            Match token = Regex.Match(tokenhtml, @"data"":""([\s\S]*?)""");
            this.token = token.Groups[1].Value;
            webBrowser1.Navigate("http://app.jiaqun8.cn/#/home/list","",null, "x-access-token:" + token+"");

            //#region 通用检测

            //string html = method.GetUrl("http://www.acaiji.com/index/index/vip.html", "utf-8");

            //if (html.Contains(@"qunzhuaqu"))
            //{
            //    button1.Enabled = false;
            //    Thread thread = new Thread(new ThreadStart(wxqun));
            //    thread.Start();
            //    Control.CheckForIllegalCrossThreadCalls = false;

            //}

            //else
            //{
            //    MessageBox.Show("验证失败");
            //    return;
            //}


            //#endregion


        }

        private void ceshi(object sender, EventArgs e)
        {

        }

        private void 群抓取_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zanting = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            zanting = false;
        }
        #region 下载文件  【好用】
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="URLAddress">图片地址</param>
        /// <param name="subPath">图片所在文件夹</param>
        /// <param name="name">图片名称</param>
        public  void downloadFile(string URLAddress, string subPath, string name, string COOKIE)
        {
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory();

                WebClient client = new WebClient();
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36");
                client.Headers.Add("Cookie", COOKIE);
                client.Headers.Add("x-access-token", this.token);
                client.Headers.Add("Referer", "http://app.jiaqun8.cn/");
                if (false == System.IO.Directory.Exists(subPath))
                {
                    //创建pic文件夹
                    System.IO.Directory.CreateDirectory(subPath);
                }

                client.DownloadFile(URLAddress, subPath + "\\" + name);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }



        #endregion
        private void button5_Click(object sender, EventArgs e)
        {
            method.DataTableToExcel(method.listViewToDataTable(this.listView1), "Sheet1", true);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            button1.Enabled = true;
            string path = AppDomain.CurrentDomain.BaseDirectory+"image\\";
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                label1.Text = "正在下载第" + i + "个二维码";
                downloadFile(listView1.Items[i].SubItems[2].Text, path, i + ".jpg", "");
            }
            label1.Text = "下载完成";
            


        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }
    }
}
