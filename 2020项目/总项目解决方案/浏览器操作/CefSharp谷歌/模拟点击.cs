﻿using CefSharp;
using CefSharp.WinForms;
using System;
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

namespace CefSharp谷歌
{
    public partial class 模拟点击 : Form
    {
        public 模拟点击()
        {
            InitializeComponent();
        }
        public ChromiumWebBrowser browser = new ChromiumWebBrowser("https://shopee.com.my/");
        private void 模拟点击_Load(object sender, EventArgs e)
        {

           // browser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>(FrameEndFunc);
            //browser.Load("https://shopee.com.my/");
            //browser.Parent = tabPage2;
            //browser.Dock = DockStyle.Fill;
            browser.Parent = tabPage2;
            browser.Dock = DockStyle.Fill;
        }

        public void run()
        {
            string keyword = textBox2.Text.Trim();
            browser.Load("https://shopee.com.my/search?keyword="+keyword);
        
          
           

        }

        private void FrameEndFunc(object sender, FrameLoadEndEventArgs e)
        {
            browser.GetBrowser().MainFrame.EvaluateScriptAsync("function _func(){var test=document.documentElement.outerHTML; return test}");//运行页面上js的test方法
            Task<CefSharp.JavascriptResponse> t = browser.EvaluateScriptAsync("_func()");
            t.Wait();// 等待js 方法执行完后，获取返回值 t.Result 是 CefSharp.JavascriptResponse 对象t.Result.Result 是一个 object 对象，来自js的 callTest2() 方法的返回值
            if (t.Result.Result != null)
            {

                string html = t.Result.Result.ToString();
                MatchCollection uids = Regex.Matches(html, @"<a data-sqe=""link"" href=""([\s\S]*?)""");

                MessageBox.Show(uids.Count.ToString());


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
          //  run();

            Thread t = new Thread(new ThreadStart(run));
            Control.CheckForIllegalCrossThreadCalls = false;
            t.Start();
 
        }
    }
}
