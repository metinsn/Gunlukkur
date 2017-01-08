using System;
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

        Boolean Dolardurum = false, Eurodurum = false, Pounddurum = false;
        private void btngetir_Click(object sender, EventArgs e)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
            DateTime Tarih= Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
            label1.Text = Tarih.ToString("dd/MM/yyyy");

            if (cBoxDovizTuru.SelectedItem.ToString() == "Dolar" && !Dolardurum)
            {
                string USD = xmlDoc.SelectSingleNode("//Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
                dGridKurlar.Rows.Add("Dolar", USD);
                Dolardurum = true;
            }
            if (cBoxDovizTuru.SelectedItem.ToString() == "Euro" && !Eurodurum)
            {
                string EUR = xmlDoc.SelectSingleNode("//Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
                dGridKurlar.Rows.Add("Euro", EUR);
                Eurodurum = true;
            }

            if (cBoxDovizTuru.SelectedItem.ToString() == "Pound" && !Pounddurum)
            {
                string GBP = xmlDoc.SelectSingleNode("//Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
                dGridKurlar.Rows.Add("Pound", GBP);
                Pounddurum = true;
            }
            
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            cBoxDovizTuru.Items.Add("Dolar");
            cBoxDovizTuru.Items.Add("Euro");
            cBoxDovizTuru.Items.Add("Pound");
        }
    }
}
