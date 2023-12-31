using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;

namespace SelectXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task<string> HttpToTallyAsync(String inXml)
        {
            try
            {

                var url = "http://localhost:9000/";

                using var client = new HttpClient();


                var BodyForPost = new StringContent(inXml, Encoding.UTF8, "text/xml");
                var response = await client.PostAsync(url, BodyForPost);

                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception error)
            {
                return null;
            };
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\KeshavSoft\\Datas";
            openFileDialog1.Filter = "Database files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string selectedFileName = openFileDialog1.FileName;

            var fileStream = openFileDialog1.OpenFile();
            String fileContent;

            using (StreamReader reader = new StreamReader(fileStream))
            {
                fileContent = reader.ReadToEnd();
            }

            String LocalTestString = await HttpToTallyAsync(fileContent);
            System.IO.File.WriteAllText(@"C:\KeshavSoft\Output\csc7.XML", LocalTestString);
            string fileName = "csc7.xml";
            string customPath = @"C:\KeshavSoft\Output\";
            string filePath = Path.Combine(customPath, fileName);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            XmlNodeList AmountNodes = xmlDoc.SelectNodes("//LEDGER");
            foreach (XmlNode AmountNode in AmountNodes)
            {
                var attribute = AmountNode.Attributes["NAME"];
                if (attribute != null)
                {
                    string AccountName = attribute.Value;
                    //Console.WriteLine("Value", AccountName);
                    //AmountNode.InnerText = AccountName;
                }

            }
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                xmlDoc.Save(writer);
            }

            String title = "Alert";
            MessageBox.Show(LocalTestString, title);
            String k1 = "";
        }

        private String ReadHead()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\KeshavSoft\\Datas";
            openFileDialog1.Filter = "Database files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return "";
            }


            var fileStream = openFileDialog1.OpenFile();
            String fileContent;

            using (StreamReader reader = new StreamReader(fileStream))
            {
                fileContent = reader.ReadToEnd();
            }

            return fileContent;
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            String fileContent = ReadHead();
            String fileContent1 = ReadHead();

            XmlDocument xmlDocHead = new XmlDocument();
            xmlDocHead.LoadXml(fileContent);


            XmlDocument xmlDocInv = new XmlDocument();
            xmlDocInv.LoadXml(fileContent1);

            XmlNode parentNodeInHead = xmlDocHead.SelectSingleNode("//VOUCHER");
            XmlNode parentNodeInv = xmlDocInv.SelectSingleNode("//ALLINVENTORYENTRIES.LIST");


            XmlNode importedNode = xmlDocHead.ImportNode(parentNodeInv, true);
            parentNodeInHead.AppendChild(importedNode);


            String LocalTestString = await HttpToTallyAsync(xmlDocHead.OuterXml);
            String title = "Alert";
            MessageBox.Show(LocalTestString, title);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\KeshavSoft\\Datas";
            openFileDialog1.Filter = "Database files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string selectedFileName = openFileDialog1.FileName;

            var fileStream = openFileDialog1.OpenFile();
            String fileContent;

            using (StreamReader reader = new StreamReader(fileStream))
            {
                fileContent = reader.ReadToEnd();
            }

            String LocalTestString = await HttpToTallyAsync(fileContent);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(LocalTestString);

            XmlNodeList AmountNodes = xmlDoc.SelectNodes("//LEDGER");
            foreach (XmlNode AmountNode in AmountNodes)
            {
                var attribute = AmountNode.Attributes["NAME"];
                if (attribute != null)
                {
                    string AccountName = attribute.Value;
                    comboBox3.Items.Add(AccountName);
                }

            }
            String k1 = "";
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\KeshavSoft\datas\kkdcycle\LedgerNamesOnly.xml";
            XmlDocument xmlDoc = new XmlDocument();

            if (File.Exists(filePath))
            {
                xmlDoc.Load(filePath);
            };

            var Output = await HttpToTallyAsync(xmlDoc.InnerXml);

            richTextBox1.Text = Output;
            //System.IO.File.WriteAllText(@"C:\KeshavSoft\Output\Firm.XML", Output);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\KeshavSoft\datas\kkdcycle\LedgerNamesOnly.xml";
            XmlDocument xmlDoc = new XmlDocument();

            if (File.Exists(filePath))
            {
                xmlDoc.Load(filePath);
            };

            var Output = await HttpToTallyAsync(xmlDoc.InnerXml);
            List<String> strings = new List<String>();

            XmlDocument xmlTallyDoc = new XmlDocument();
            xmlTallyDoc.LoadXml(Output);

            XmlNodeList AmountNodes = xmlTallyDoc.SelectNodes("//LEDGER");
            foreach (XmlNode AmountNode in AmountNodes)
            {
                var attribute = AmountNode.Attributes["NAME"];
                if (attribute != null)
                {
                    string AccountName = attribute.Value;
                    strings.Add(AccountName);
                }

            };
            var json = JsonSerializer.Serialize(strings);

            //richTextBox1.Text = json;
            richTextBox1.Text = AmountNodes.Count.ToString();

        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var filePath = SelectXml.Properties.Resources.StockTdlSimple;
            //richTextBox1.Text = filePath;

            var Output = await HttpToTallyAsync(filePath);

            richTextBox1.Text = Output;

            List<String> strings = new List<String>();

            XmlDocument xmlTallyDoc = new XmlDocument();
            xmlTallyDoc.LoadXml(Output);

            XmlNodeList AmountNodes = xmlTallyDoc.SelectNodes("//KSSTOCKITEMNAME");
            foreach (XmlNode AmountNode in AmountNodes)
            {
                string AccountName = AmountNode.InnerText;
                strings.Add(AccountName);

            };
            var json = JsonSerializer.Serialize(strings);

            richTextBox1.Text = AmountNodes.Count.ToString();


        }

        private async void button7_Click(object sender, EventArgs e)
        {
            var filePath = SelectXml.Properties.Resources.StockItemsOnly;
          var Output = await HttpToTallyAsync(filePath);
            
            XmlDocument xmlTallyDoc = new XmlDocument();
            xmlTallyDoc.LoadXml(Output);

            XmlNodeList AmountNodes = xmlTallyDoc.SelectNodes("//STOCKITEM");

            richTextBox1.Text = AmountNodes.Count.ToString();

        }
    }
}
