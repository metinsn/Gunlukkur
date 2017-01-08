﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Gunlukkur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btngetir_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
            DateTime Tarih= Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
            label1.Text = Tarih.ToString("dd/MM/yyyy");
            string USD = xmlDoc.SelectSingleNode("//Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            label1.Text += " - USD : " + USD;
            string EUR = xmlDoc.SelectSingleNode("//Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            label2.Text = Tarih.ToString("dd/MM/yyyy");
            label2.Text += " - EUR : " + EUR;
        }
    }
}