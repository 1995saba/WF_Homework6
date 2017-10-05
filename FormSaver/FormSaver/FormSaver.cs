using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FormSaver
{
    public partial class FormSaver : Form
    {
        public FormSaver()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            using(FileStream fstream=new FileStream(@"form.txt", FileMode.OpenOrCreate))
            {
                fstream.Seek(0, SeekOrigin.End);

                byte[] information = Encoding.Default.GetBytes(textBoxSurname.Text + " "
                    + textBoxName.Text + " " + textBoxLastName.Text
                    + " Пол: " + comboBoxGender.Text
                    + " Дата рождения: " + dateTimePickerBirthday.Text
                    + " Статус: " + textBoxIsMarried.Text
                    + " Дополнительная информация: " + richTextBoxOtherInfo.Text);

                fstream.Write(information, 0, information.Length);

                textBoxSurname.Text = "";
                textBoxName.Text = "";
                textBoxLastName.Text = "";
                comboBoxGender.Text = "";
                dateTimePickerBirthday.Text = "";
                textBoxIsMarried.Text = "";
                richTextBoxOtherInfo.Text = "";
                
                MessageBox.Show("Данные успешно сохранены");
            }
        }
    }
}
