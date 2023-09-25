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

            OpenFileDialog open = new OpenFileDialog();
            
            

            if (open.ShowDialog() == DialogResult.OK)
            {

                string path = open.FileName;

                string fileName = Path.GetFileNameWithoutExtension(path);



                StreamReader read = new StreamReader(path,Encoding.ASCII);
               
                string newFilePath = Path.Combine(Path.GetDirectoryName(path), $"{fileName}123.txt");

                File.WriteAllText(newFilePath, read.ReadToEnd(),Encoding.UTF8);



            }
                

        }
    }
}