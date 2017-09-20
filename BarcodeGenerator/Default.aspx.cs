﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarcodeGenerator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PrintBtn.Click += new EventHandler(this.PrintBtn_Click);
            pdfViewer.Text = CreatePdfObjectTag("LabelGen.ashx?dpi=" + DropDownList1.SelectedItem.ToString() + "&prodId=" + TextBox2.Text + "&prodName=" + TextBox1.Text + "&out=PDF");
        }

        private string CreatePdfObjectTag(string pdfUrl)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<object type=\"application/pdf\" ");
            sb.Append("data=\"");
            sb.Append(pdfUrl);
            sb.Append("#toolbar=1&navpanes=0&scrollbar=1&page=1&zoom=100\" width=\"600px\" height=\"400px\" VIEWASTEXT><p>It appears you don't have a PDF plugin for your browser. <a target=\"_blank\" href=\"");
            sb.Append(pdfUrl);
            sb.Append("\">Click here to download the PDF file.</a></p></object>");
            return sb.ToString();
        }

        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            SendToPrinter();
        }

        private void SendToPrinter()
        {
            ProcessStartInfo info = new ProcessStartInfo(@"D:\test.pdf");
            //if (autoPrint)
            //{
                info.Verb = "Print";
                info.WindowStyle = ProcessWindowStyle.Hidden; // not normally required
                Process.Start(info);
                info.Verb = string.Empty;
            //}

            //if (viewOnScreen)
            //{
            //    info.WindowStyle = ProcessWindowStyle.Normal;
            //    Process.Start(info);
            //}

            //ProcessStartInfo info = new ProcessStartInfo();
            //info.Verb = "print";
            //info.FileName = @"D:\test.pdf";
            //info.CreateNoWindow = true;
            //info.WindowStyle = ProcessWindowStyle.Hidden;

            //Process p = new Process();
            //p.StartInfo = info;
            //p.Start();

            //p.WaitForInputIdle();
            //System.Threading.Thread.Sleep(3000);
            //if (false == p.CloseMainWindow())
            //    p.Kill();
        }
    }
}