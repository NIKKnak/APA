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

            // Создание нового Excel пакета
            using (ExcelPackage package = new ExcelPackage())
            {
                // Добавление нового листа
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Лист1");

                // Выбор файла
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Получение пути к выбранному файлу
                    string filePath = openFileDialog.FileName;

                    // Считывание данных из выбранного файла
                    using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding(866)))
                    {
                        string line;
                        int row = 1;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Отрезаем первые 10 символов
                            string chars1 = line.Substring(10, 8);

                            
                            string chars2 = line.Substring(20, 8);

                           
                            string remainingChars = line.Substring(29);

                            // Записываем данные в ячейки
                            worksheet.Cells[row, 1].Value = chars1;
                            worksheet.Cells[row, 2].Value = chars2;
                            worksheet.Cells[row, 3].Value = remainingChars;

                            row++;
                        }
                    }

                    // Сохранение файла
                    string directoryPath = Path.GetDirectoryName(filePath);
                    string excelFilePath = Path.Combine(directoryPath, $"{filePath}.xlsx");
                    FileInfo file = new FileInfo(excelFilePath);
                    package.SaveAs(file);
                }
            }




















        }
    }
}