using System.Security.Policy;
using System.Text;
using System.Xml;

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

        }

        private async void button2_Click(object sender, EventArgs e)
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

            string fileName = "Inventory.xml";
            string customPath = @"C:\KeshavSoft\CycleKKd";
            string filePath = Path.Combine(customPath, fileName);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            XmlNodeList nodes = xmlDoc.SelectNodes("//ALLINVENTORYENTRIES.LIST");
            if (nodes.Count > 0)
            {
                foreach (XmlNode node in nodes)
                {
                    XmlNode NodeToChangeItemName = node.SelectSingleNode("//STOCKITEMNAME");
                    string newContentItemName = "99 Tubes";
                    NodeToChangeItemName.InnerText = newContentItemName;

                    XmlNode NodeToChange = node.SelectSingleNode("//RATE");
                    string newContent = "0.00/pcs";
                    NodeToChange.InnerText = newContent;

                    XmlNodeList AmountNodes = node.SelectNodes("//AMOUNT");
                    foreach (XmlNode AmountNode in AmountNodes)
                    {
                        string newContentAmount = "0";
                        AmountNode.InnerText = newContentAmount;
                    }

                    XmlNodeList ACTUALQTYNodes = node.SelectNodes("//ACTUALQTY");
                    foreach (XmlNode ACTUALQTYNode in ACTUALQTYNodes)
                    {
                        string newContentACTUALQTY = "7 pcs";
                        ACTUALQTYNode.InnerText = newContentACTUALQTY;
                    }

                    XmlNodeList BILLEDQTYNodes = node.SelectNodes("//BILLEDQTY");
                    foreach (XmlNode BILLEDQTYNode in BILLEDQTYNodes)
                    {
                        string newContentBILLEDQTY = "4 pcs";
                        BILLEDQTYNode.InnerText = newContentBILLEDQTY;
                    }

                }
            }
            if (nodes != null)
            {

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    xmlDoc.Save(writer);
                }
            }
            else
            {
                Console.WriteLine("Node not found.");
            }

            OpenFileDialog openFileDialog2 = new OpenFileDialog();

            openFileDialog2.InitialDirectory = "c:\\KeshavSoft\\CycleKKd";
            openFileDialog2.Filter = "Database files (*.xml)|*.xml";
            openFileDialog2.FilterIndex = 0;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string selectedFileName1 = openFileDialog2.FileName;

            var fileStream1 = openFileDialog2.OpenFile();
            String fileContent1;

            using (StreamReader reader = new StreamReader(fileStream1))
            {
                fileContent1 = reader.ReadToEnd();
            }

            string fileName1 = "AddItem.xml";
            string customPath1 = @"C:\KeshavSoft\CycleKKd";
            string filePath1 = Path.Combine(customPath1, fileName1);

            XmlDocument xmlDoc1 = new XmlDocument();
            xmlDoc1.Load(filePath1);

            XmlNodeList nodesToAppend = xmlDoc.SelectNodes("//ALLINVENTORYENTRIES.LIST");

            XmlNode parentNodeInHead = xmlDoc1.SelectSingleNode("//VOUCHER");
            foreach (XmlNode nodeToAppend in nodesToAppend)
            {
                if (nodeToAppend != null && parentNodeInHead != null)
                {
                    XmlNode importedNode = xmlDoc1.ImportNode(nodeToAppend, true);
                    parentNodeInHead.AppendChild(importedNode);
                    xmlDoc1.Save("Head.xml");

                }

            }

            using (StreamWriter writer = new StreamWriter(filePath1))
            {
                xmlDoc1.Save(writer);

            }


            String LocalTestString = await HttpToTallyAsync(fileContent);
        }
    }
}