using System;
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
            DateTime Tarih = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
            label1.Text = Tarih.ToString("dd/MM/yyyy");

            #region Kur_deger_getir

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


            #endregion

        }

        private void cBoxDovizTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgridTemizle();
            if (cBoxDovizTuru.SelectedItem.ToString()== "Dolar")
            {
                Satirsec("Dolar");
            }
            if (cBoxDovizTuru.SelectedItem.ToString() == "Euro")
            {
                Satirsec("Euro");
            }
            if (cBoxDovizTuru.SelectedItem.ToString() == "Pound")
            {
                Satirsec("Pound");
            }


        }

        public void DgridTemizle()
        {
            for (int i = 0; i < dGridKurlar.RowCount - 1; i++)
            {
                dGridKurlar.Rows[i].Selected = false;
            }
        }

        private void Satirsec(string parabirimi)
        {
            for (int i = 0; i < dGridKurlar.RowCount - 1; i++)
            {
                if (dGridKurlar.Rows[i].Cells[0].Value.ToString() == parabirimi)
                {
                    dGridKurlar.Rows[i].Selected = true;
                }
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
