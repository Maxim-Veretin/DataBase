using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace DataBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class DataBase
    {
        public int num { get; set; }
        public string name { get; set; }
        public int phys { get; set; }
        public int math { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SQLiteConnection.CreateFile("D:\\Users\\Admin\\source\\repos\\РИ-88\\DataBase\\db_kek.db");
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var data = new DataBase { num = int.Parse(reader["num"].ToString()), name = reader["name"].ToString(), phys = int.Parse(reader["pyhs"].ToString()), math = int.Parse(reader["math"].ToString()) };
            db.Items.Add(data);
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            //имя базы данных
            string db = dlg.FileName;

            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("db_kek" + db + ";Version=1");

            //открытие соединения с базой даных
            m_dbConnection.Open();

            string sql = "SELECT * FROM db_kek ORDER BY "

            m_dbConnection.Close();
        }
    }
}