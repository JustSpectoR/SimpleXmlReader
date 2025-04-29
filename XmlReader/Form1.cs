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
                // ���� � XML
                string xmlPath = "C:/MyStuff/csharp/info.xml";

                // ��������� ��������
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);

                // �������� ������ �����
                XmlNodeList carNodes = xmlDoc.SelectNodes("//Car");
                foreach (XmlNode node in carNodes)
                {
                    // �������� �� ����������
                    string manufacturer = node.SelectSingleNode("Manufacturer")?.InnerText;
                    string model = node.SelectSingleNode("Model")?.InnerText;
                    string year = node.SelectSingleNode("Year")?.InnerText;
                    listBox1.Items.Add($"{manufacturer} {model}, {year} ���� �������");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ������: {ex.Message}");
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // ��� ����� ���������� �������� �������� ������ �������� XML
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "XML Files|*.xml";
                openFileDialog.Title = "�������� XML ����";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string filePath = openFileDialog.FileName;
                    // ������� ������ ����� ���������
                    listBox1.Items.Clear();

                    // ��������� ��������
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(filePath);

                    // �������� ������ �����
                    XmlNodeList carNodes = xmlDoc.SelectNodes("//Car");
                    foreach (XmlNode node in carNodes)
                    {
                        // �������� �� ����������
                        string manufacturer = node.SelectSingleNode("Manufacturer")?.InnerText;
                        string model = node.SelectSingleNode("Model")?.InnerText;
                        string year = node.SelectSingleNode("Year")?.InnerText;
                        listBox1.Items.Add($"{manufacturer} {model}, {year} ���� �������");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ����: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
