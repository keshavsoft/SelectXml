using System.Security.Policy;
using System.Text;

namespace SelectXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task<string> HttpToTallyAsync (String inXml){
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
    }
}