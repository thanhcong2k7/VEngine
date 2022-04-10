using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace VEngine
{
    public partial class VEngine: UserControl
    {
        //ulong line = 10;
        public string url = "info.cern.ch";
        public VEngine()
        {
            if (!url.StartsWith("https://") || !url.StartsWith("http://"))
                url = "http://" + url;
            InitializeComponent();
            //string htmlTxt = code(url);
            string htmlTxt = "<html><body><h1>Title</h1><div id=\"main\" class=\"test\"><p>Hello<em> world</em>!</p></div></body></html>";
            label1.Text = htmlTxt;
            parseHtmlToObj prs = new parseHtmlToObj(htmlTxt);
            prs.deserializeObj();
        }
        public void processControls()
		{
            //
		}
        public static String code(string Url)
        {

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            return result;
        }
    }
}
