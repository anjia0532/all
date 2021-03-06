﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using helper;

namespace 价格监控
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        bool zanting = true;

        #region  价格监控 三个网站同时
        public void run()
        {
            try
            {
               


                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    string a = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string b = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string c = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string d = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string e = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string f = dataGridView1.Rows[i].Cells[5].Value.ToString();

                  

                    Match jdid = Regex.Match(a, @"\d{6,}");
                    string JDurl = "https://c0.3.cn/stock?skuId="+jdid.Groups[0].Value+"&area=12_933_3407_0&venderId=1000000140&buyNum=1&choseSuitSkuIds=&cat=670,671,1105&ch=1&callback=jQuery8851179";

                    Match aid = Regex.Match(b, @"com\/([\s\S]*?)\/([\s\S]*?)\.");


                    string snid = aid.Groups[2].Value;
                    int z = aid.Groups[2].Value.Length;

                    while (z < 18)
                    {
                        snid = "0" + snid;
                        z++;
                    }

                    string SNurl = "https://pas.suning.com/nspcsale_0_"+snid+"_"+snid+"_"+ aid.Groups[1].Value + "_100_527_5270101_20268_1000185_9185_11470_Z001___R0401003_76.0_0___000021978___.html?callback=pcData&_=1568892695337";




                    Match tmid = Regex.Match(c, @"&id=([\s\S]*?)&skuId=([\s\S]*?)&");


                    string TMurl = "https://detail.m.tmall.com/item.htm?id="+tmid.Groups[1].Value+"&skuId="+tmid.Groups[2].Value;
                    string JDhtml = method.GetUrl(JDurl, "utf-8");
                    string SNhtml = method.GetUrl(SNurl, "utf-8");
                    string TMhtml = method.GetUrl(TMurl, "utf-8");


                    Match jdprice = Regex.Match(JDhtml, @"""p"":""([\s\S]*?)""");
                    Match snprice = Regex.Match(SNhtml, @"""promotionPrice"":""([\s\S]*?)""");
                    Match tmprice = Regex.Match(TMhtml, @"transmitPrice"":{""priceText"":""([\s\S]*?)""");


                  





                    double min = 0;
                    if (snprice.Groups[1].Value == "" && jdprice.Groups[1].Value != "" && tmprice.Groups[1].Value != "")
                    {
                        if (Convert.ToDouble(jdprice.Groups[1].Value) < Convert.ToDouble(tmprice.Groups[1].Value))
                        {
                            min = Convert.ToDouble(jdprice.Groups[1].Value);

                        }

                        else
                        {
                            min = Convert.ToDouble(tmprice.Groups[1].Value);

                        }
                    }

                    else if (jdprice.Groups[1].Value == "" && snprice.Groups[1].Value != "" && tmprice.Groups[1].Value != "")
                    {
                        if (Convert.ToDouble(snprice.Groups[1].Value) < Convert.ToDouble(tmprice.Groups[1].Value))
                        {
                            min = Convert.ToDouble(snprice.Groups[1].Value);

                        }

                        else
                        {
                            min = Convert.ToDouble(tmprice.Groups[1].Value);

                        }

                    }

                    else if (tmprice.Groups[1].Value == "" && snprice.Groups[1].Value != "" && jdprice.Groups[1].Value != "")
                    {
                        if (Convert.ToDouble(snprice.Groups[1].Value) < Convert.ToDouble(jdprice.Groups[1].Value))
                        {
                            min = Convert.ToDouble(snprice.Groups[1].Value);

                        }

                        else
                        {
                            min = Convert.ToDouble(jdprice.Groups[1].Value);

                        }

                    }

                    else
                    {
                        if (Convert.ToDouble(snprice.Groups[1].Value) < Convert.ToDouble(jdprice.Groups[1].Value))
                        {
                            min = Convert.ToDouble(snprice.Groups[1].Value);
                            if (min > Convert.ToDouble(tmprice.Groups[1].Value))
                            {
                                min = Convert.ToDouble(tmprice.Groups[1].Value);
                            }
                            
                        }

                        else
                        {
                            min = Convert.ToDouble(jdprice.Groups[1].Value);
                            if (min > Convert.ToDouble(tmprice.Groups[1].Value))
                            {
                                min = Convert.ToDouble(tmprice.Groups[1].Value);
                            }
                        }
                    }




                    double cha = min - Convert.ToDouble(f);
                    double lv = cha / Convert.ToDouble(f);

                    ListViewItem listViewItem = this.listView1.Items.Add((listView1.Items.Count + 1).ToString());
                    listViewItem.SubItems.Add(DateTime.Now.ToString());
                    listViewItem.SubItems.Add(d);
                    listViewItem.SubItems.Add(e);
                    listViewItem.SubItems.Add(f);
                    listViewItem.SubItems.Add(cha.ToString());  //价差
                    listViewItem.SubItems.Add(lv.ToString());   //溢价率
                    listViewItem.SubItems.Add(jdprice.Groups[1].Value);
                    listViewItem.SubItems.Add(snprice.Groups[1].Value);
                    listViewItem.SubItems.Add(tmprice.Groups[1].Value);


                    while (this.zanting == false)
                    {
                        Application.DoEvents();//如果loader是false表明正在加载,,则Application.DoEvents()意思就是处理其他消息。阻止当前的队列继续执行。
                    }

                    Thread.Sleep(100);

                }

                    }


                
            




            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }





        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(run));
            thread.Start();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            zanting = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            zanting = true;

           
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            method.DataTableToExcel(method.listViewToDataTable(this.listView1), "Sheet1", true);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
          

        }


        OpenFileDialog Ofile = new OpenFileDialog();


        DataSet ds = new DataSet();
        private void Button5_Click_1(object sender, EventArgs e)
        {
            this.ds.Tables.Clear();
            this.Ofile.FileName = "";
            this.dataGridView1.DataSource = "";
            this.Ofile.ShowDialog();
            string fileName = this.Ofile.FileName;
            if (fileName != null && fileName != "")
            {
                string connectionString = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + fileName + "; Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
                OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
                oleDbConnection.Open();
                DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[]
                {
                    null,
                    null,
                    null,
                    "TABLE"
                });
                string str = oleDbSchemaTable.Rows[0]["TABLE_NAME"].ToString();
                string selectCommandText = "select * from [" + str + "]";
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(selectCommandText, oleDbConnection);
                oleDbDataAdapter.Fill(this.ds, "temp");
                oleDbConnection.Close();
                this.dataGridView1.DataSource = this.ds.Tables[0];

                textBox1.Text = this.Ofile.FileName;
            }

        }











    }
}
