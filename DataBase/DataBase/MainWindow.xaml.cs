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
using System.IO;

namespace DataBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        SQLiteConnection m_dbConnection;

        public class DataBase1
        {
            public int num { get; set; }
            public string name { get; set; }
            public int phys { get; set; }
            public int math { get; set; }
        }
        
        public MainWindow()
        {
            InitializeComponent();

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            //имя базы данных
            string db1 = dlg.FileName;

           // SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source = " + db1 + ";Version = 3");

            //открытие соединения с базой даных
            m_dbConnection.Open();

            string sql = "SELECT * FROM score,name WHERE score.№=name.№ ORDER BY №";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var data = new DataBase1 { num = int.Parse(reader["№"].ToString()), name = reader["FIO"].ToString(), phys = int.Parse(reader["Physics"].ToString()), math = int.Parse(reader["Mathematics"].ToString()) };
                db.Items.Add(data);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string sql = "INSERT INTO name (№, FIO) VALUES (" + num.Text.ToString() + ",'" + name.Text.ToString() + "')";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            string sql1 = "INSERT INTO score (Physics, Mathematics, №) VALUES (" + ph.Text.ToString() + "," + mth.Text.ToString() + "," + num.Text.ToString() + ")";

            SQLiteCommand command1 = new SQLiteCommand(sql1, m_dbConnection);
            command1.ExecuteNonQuery();

            var data = new DataBase1 { num = int.Parse(num.Text.ToString()), name = name.Text.ToString(), phys = int.Parse(ph.Text.ToString()), math = int.Parse(mth.Text.ToString()) };
            db.Items.Add(data);
        }
        
        private void Red_Click(object sender, RoutedEventArgs e)
        {
            DataBase1 selected = (DataBase1)db.SelectedItem;
            string sql = ("UPDATE name SET № = " + int.Parse(num.Text.ToString()) + ", FIO = '" + name.Text.ToString() + "' WHERE № = " + selected.num.ToString());

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            string sql1 = ("UPDATE score SET Physics = " + int.Parse(ph.Text.ToString()) + ", Mathematics = " + int.Parse(mth.Text.ToString()) + " WHERE № = " + selected.num.ToString());

            SQLiteCommand command1 = new SQLiteCommand(sql1, m_dbConnection);
            command1.ExecuteNonQuery();

            var data = new DataBase1 { num = int.Parse(num.Text.ToString()), name = name.Text.ToString(), phys = int.Parse(ph.Text.ToString()), math = int.Parse(mth.Text.ToString()) };
            db.Items.RemoveAt(int.Parse(db.SelectedIndex.ToString()));
            db.Items.Add(data);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            DataBase1 selected = (DataBase1)db.SelectedItem;
            string sql = ("DELETE FROM name WHERE(№ = " + selected.num.ToString() + ")");

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            string sql1 = ("DELETE FROM score WHERE(№ = " + selected.num.ToString() + ")");

            SQLiteCommand command1 = new SQLiteCommand(sql1, m_dbConnection);
            db.Items.RemoveAt(int.Parse(db.SelectedIndex.ToString()));
            command1.ExecuteNonQuery();
        }

        //private void Base_Click(object sender, RoutedEventArgs e)
        //{
        //    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        //    dlg.ShowDialog();

        //    имя базы данных
        //    string db1 = dlg.FileName;

        //    SQLiteConnection m_dbConnection;
        //    m_dbConnection = new SQLiteConnection("Data Source = " + db1 + ";Version = 3");

        //    открытие соединения с базой даных
        //    m_dbConnection.Open();

        //    string sql = "SELECT * FROM score,name WHERE score.№=name.№ ORDER BY №";
        //    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        //    SQLiteDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        var data = new DataBase1 { num = int.Parse(reader["№"].ToString()), name = reader["Ф.И.О."].ToString(), phys = int.Parse(reader["Физика"].ToString()), math = int.Parse(reader["Матеша"].ToString()) };
        //        db.Items.Add(data);
        //    }

        //    m_dbConnection.Close();
        //}
    }
}