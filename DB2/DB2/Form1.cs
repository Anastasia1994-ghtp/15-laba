using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DB2
{

    public partial class Form1 : Form
    {
        OleDbDataAdapter adapter;

        DataSet dataset;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бДDataSet.Владельцы". При необходимости она может быть перемещена или удалена.
            this.владельцыTableAdapter.Fill(this.бДDataSet.Владельцы);
            adapter = new OleDbDataAdapter("Select * from Владельцы", new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\Проектирование ИС\\Задания\\DB2\\БД.mdb"));
            dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conn_param = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\Проектирование ИС\\Задания\\DB2\\БД.mdb";
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command = connection.CreateCommand();

            command.CommandText = "INSERT INTO Владельцы VALUES (\"" + textBox1.Text + "\", \"" + textBox2.Text + "\", \"" + textBox3.Text + "\",\"" + textBox4.Text + "\", \"" + textBox5.Text + "\", \"" + textBox6.Text + "\", \"" + textBox7.Text + "\", \"" + textBox8.Text + "\");";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conn_param = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\Проектирование ИС\\Задания\\DB2\\БД.mdb";
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Владельцы WHERE Код = " + textBox1.Text +";";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string conn_param = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\Проектирование ИС\\Задания\\DB2\\БД.mdb";
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Владельцы SET Фамилия = \"" + textBox2.Text + "\", Имя = \"" + textBox3.Text + "\", Отчество = \"" + textBox4.Text + "\", Код_улицы = \"" + textBox5.Text + "\", Номер_дома = \"" + textBox6.Text + "\", Дробная_часть_номера = \"" + textBox7.Text + "\", Телефон = \"" + textBox8.Text + "\" WHERE Код = "+textBox1.Text+"";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.владельцыTableAdapter.Fill(this.бДDataSet.Владельцы);
            adapter = new OleDbDataAdapter("Select * from Владельцы", new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\Проектирование ИС\\Задания\\DB2\\БД.mdb"));
            dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
        }
    }
}
