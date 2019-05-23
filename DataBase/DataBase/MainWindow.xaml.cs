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


    public partial class MainWindow : Window
    {

        public class DataBase
        {
            public int num { get; set; }
            public string name { get; set; }
            public int phys { get; set; }
            public int math { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();

        }

        SQLiteConnection m_dbConnection;

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.ShowDialog();

            ////имя базы данных
            //string db1 = dlg.FileName;

            //SQLiteConnection m_dbConnection;
            //m_dbConnection = new SQLiteConnection("Data Source = " + db1 + ";Version = 3");

            ////открытие соединения с базой даных
            //m_dbConnection.Open();

            string sql = "INSERT INTO score,name (№, Ф.И.О., Физика, Матеша) VALUES (" + num.Text + ",'" + name.Text + ",'" + ph.Text + ",'" + mth.Text + "')";
            //SQLiteConnection m_dbConnection;
            //m_dbConnection = new SQLiteConnection("Data Source = " + db + ";Version = 1");
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            //SQLiteDataReader reader = command.ExecuteReader();

            var data = new DataBase { num = int.Parse(num.Text.ToString()), name = name.Text.ToString(), phys = int.Parse(ph.Text.ToString()), math = int.Parse(mth.Text.ToString()) };
            db.Items.Add(data);
            /*SQLiteDataReader reader = */command.ExecuteReader();
            m_dbConnection.Close();
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Base_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            //имя базы данных
            string db1 = dlg.FileName;

            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source = " + db1 + ";Version = 3");

            //открытие соединения с базой даных
            m_dbConnection.Open();

            string sql = "SELECT * FROM score,name WHERE score.№=name.№ ORDER BY №";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var data = new DataBase { num = int.Parse(reader["№"].ToString()), name = reader["Ф.И.О."].ToString(), phys = int.Parse(reader["Физика"].ToString()), math = int.Parse(reader["Матеша"].ToString()) };
                db.Items.Add(data);
            }

            m_dbConnection.Close();
        }
    }
}