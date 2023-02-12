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
    public partial class Form1 : Form
    {
        public static Form1 Main;//внешняя ссылка на класс
        public Form1()
        {

            TablesData.isDebug = false;

            DataWork.Connect();

            InitializeComponent();

            Main = this;
           
            TablesData.buildingN = "building1"; //пока корпус определеяется только изнутри кода, поскольку неизвестна дальнейшая судьба проекта
            
            panel1.Controls.Add(new AutorizeForm()); //добавляем форму авторизации

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
