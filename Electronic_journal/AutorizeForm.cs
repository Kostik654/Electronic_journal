using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_journal
{
    public partial class AutorizeForm : UserControl
    {
        public static AutorizeForm Main;//внешняя ссылка для обращения
        public AutorizeForm()
        {
            InitializeComponent();
            
            Main = this;

            SetAppearance();
        }

        public void SetAppearance()
        {
            pass_box.PasswordChar = '*';
            this.Anchor = AnchorStyles.None;
            this.Top = 0;
            this.Left = 0;
        }

        public void enter_button_Click(object sender, EventArgs e)
        {
            bool res;
            DataTable table; //результат поиска лица
            this.Enabled = false;
            
            if (isStudent_box.Checked)//смотреть студента или персонал
                res = DataWork.CheckSetUserData(login_box.Text, pass_box.Text, "students", out table);
            else
                res = DataWork.CheckSetUserData(login_box.Text, pass_box.Text, "staff", out table);
            
            if (res)//если успешная авторизация
            {
                 //загружаем все необходимые таблицы
                TablesData.LoadAllTables(table, login_box.Text, pass_box.Text, isStudent_box.Checked);

            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Возможно, вы (не)студент?");
            }
            this.Enabled = true;
        }

    }
}
