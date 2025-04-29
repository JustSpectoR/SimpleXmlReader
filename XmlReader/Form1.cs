using System.Windows.Forms;
using System.Xml;

namespace XmlReader
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //listBox1.Items.Clear(); // Очистка перед загрузкой

                // Путь к XML
                string xmlPath = "C:/MyStuff/csharp/info.xml";

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);

                XmlNodeList carNodes = xmlDoc.SelectNodes("//Car");
                foreach (XmlNode node in carNodes)
                {
                    string manufacturer = node.SelectSingleNode("Manufacturer")?.InnerText;
                    string model = node.SelectSingleNode("Model")?.InnerText;
                    string year = node.SelectSingleNode("Year")?.InnerText;
                    listBox1.Items.Add($"{manufacturer} {model}, {year} года выпуска");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка Кнопка: {ex.Message}");
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "XML Files|*.xml";
                openFileDialog.Title = "Выберите XML файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    listBox1.Items.Clear(); // Очистка списка перед загрузкой

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(filePath);

                    XmlNodeList carNodes = xmlDoc.SelectNodes("//Person");
                    foreach (XmlNode node in carNodes)
                    {
                        string manufacturer = node.SelectSingleNode("Manufacturer")?.InnerText;
                        string model = node.SelectSingleNode("Model")?.InnerText;
                        string year = node.SelectSingleNode("Year")?.InnerText;
                        listBox1.Items.Add($"{manufacturer} {model}, {year} года выпуска");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка Бокс: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
