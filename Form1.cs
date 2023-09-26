using OfficeOpenXml;
using System.Text;
using System.Windows.Forms;

namespace APA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // �������� ������ Excel ������
            using (ExcelPackage package = new ExcelPackage())
            {
                // ���������� ������ �����
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("����1");

                // ����� �����
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // ��������� ���� � ���������� �����
                    string filePath = openFileDialog.FileName;

                    // ���������� ������ �� ���������� �����
                    using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding(866)))
                    {
                        string line;
                        int row = 1;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // �������� ������ 10 ��������
                            string chars1 = line.Substring(10, 8);

                            
                            string chars2 = line.Substring(20, 8);

                           
                            string remainingChars = line.Substring(29);

                            // ���������� ������ � ������
                            worksheet.Cells[row, 1].Value = chars1;
                            worksheet.Cells[row, 2].Value = chars2;
                            worksheet.Cells[row, 3].Value = remainingChars;

                            row++;
                        }
                    }

                    // ���������� �����
                    string directoryPath = Path.GetDirectoryName(filePath);
                    string excelFilePath = Path.Combine(directoryPath, $"{filePath}.xlsx");
                    FileInfo file = new FileInfo(excelFilePath);
                    package.SaveAs(file);
                }
            }




















        }
    }
}