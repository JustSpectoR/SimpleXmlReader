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
                // Путь к XML
                string xmlPath = "C:/MyStuff/csharp/info.xml";

                // Открываем документ
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);

                // Получаем список машин
                XmlNodeList carNodes = xmlDoc.SelectNodes("//Car");
                foreach (XmlNode node in carNodes)
                {
                    // Получаем их информацию
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
                // При смене выбранного элемента вызываем диалог открытия XML
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "XML Files|*.xml";
                openFileDialog.Title = "Выберите XML файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string filePath = openFileDialog.FileName;
                    // Очистка списка перед загрузкой
                    listBox1.Items.Clear();

                    // Открываем документ
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(filePath);

                    // Получаем список машин
                    XmlNodeList carNodes = xmlDoc.SelectNodes("//Car");
                    foreach (XmlNode node in carNodes)
                    {
                        // Получаем их информацию
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
