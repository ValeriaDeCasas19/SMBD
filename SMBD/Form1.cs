using System.Data.SqlClient;
using System.Data;
using Db4objects.Db4o;
namespace SMBD
{

    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand com;
        SqlDataReader lector;
        DataColumn tabla;
        IObjectContainer db;
        Tipo tip;

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection("Data source = localhost;" +
                                    "Initial Catalog = Netflix;" +
                                    "Integrated security = True;");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //agregar
        {
            Tipo tip = new Tipo();
            tip.ShowDialog();
            int v = tip.valor;
            comboBox1.SelectedIndex = v;
            if (v == 0 || v == 2)
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                com = new SqlCommand();
                com.CommandText = "Insert into Contenido values("
                                  + Convert.ToInt32(textBox1.Text) +
                                  ", '" + textBox2.Text + "','" + comboBox1.Text +
                                  "', '" + textBox4.Text + "', " +
                                  Convert.ToInt32(textBox5.Text) + "," +
                                  Convert.ToInt32(textBox6.Text) + "," +
                                  Convert.ToInt32(textBox7.Text) + ")";
                com.CommandType = CommandType.Text;
                com.Connection = conn;
                try
                {
                    com.ExecuteNonQuery();
                    MessageBox.Show("Contenido registrado!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();

            }
            else if (v == 1 || v == 3)
            {
                db = Db4oEmbedded.OpenFile("BDOO.dat");
                Contenido c = new Contenido();
                c.Guardar(Convert.ToInt32(textBox1.Text),
                    textBox2.Text, comboBox1.Text, textBox4.Text,
                    Convert.ToInt32(textBox5.Text),
                    Convert.ToInt32(textBox6.Text),
                    Convert.ToInt32(textBox7.Text));
                db.Store(c);
                MessageBox.Show("Datos registrados");
                db.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e) //buscar
        {
            Tipo tip = new Tipo();
            tip.ShowDialog();
            int v = tip.valor;
            comboBox1.SelectedIndex = v;
            if (v == 0 || v == 2)
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                com = new SqlCommand();
                com.CommandText = "select * from Contenido where Id_Con ="
                                  + Convert.ToInt32(textBox1.Text);
                com.CommandType = CommandType.Text;
                com.Connection = conn;
                try
                {
                    lector = com.ExecuteReader();
                    if (lector.Read())
                    {
                        textBox2.Text = lector.GetString(1);
                        textBox4.Text = lector.GetString(3);
                        textBox5.Text = lector.GetDecimal(4).ToString();
                        textBox6.Text = lector.GetDecimal(5).ToString();
                        textBox7.Text = lector.GetDecimal(6).ToString();
                    }
                    else
                        MessageBox.Show("No se encontraron datos...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
            else if (v == 1 || v == 3)
            {
                db = Db4oEmbedded.OpenFile("BDOO.dat");
                Contenido cont = new Contenido(Convert.ToInt32(textBox1.Text));
                IObjectSet<Contenido> res = db.QueryByExample(cont);
                foreach (Contenido obj in res)
                {
                    textBox2.Text = obj.VerTitulo();
                    comboBox1.Text = obj.VerTipo();
                    textBox4.Text = obj.VerGenero();
                    textBox5.Text = obj.VerTemporadas().ToString();
                    textBox6.Text = obj.VerCapitulos().ToString();
                    textBox7.Text = obj.VerDuracion().ToString();
                }
                db.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e) //actualizar
        {
            Tipo tip = new Tipo();
            tip.ShowDialog();
            int v = tip.valor;
            comboBox1.SelectedIndex = v;
            if (v == 0 || v == 2)
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                com = new SqlCommand();
                com.CommandText = "update Contenido set " +
                                  "Titulo = '" + textBox2.Text + "', " +
                                  "Genero = '" + textBox4.Text + "', " +
                                  "Duracion = " + Convert.ToInt32(textBox7.Text) + " " +
                                  "where Id_Con = " + Convert.ToInt32(textBox1.Text);

                com.CommandType = CommandType.Text;
                com.Connection = conn;
                try
                {
                    com.ExecuteNonQuery();
                    MessageBox.Show("Contenido actualizado!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
            else if (v == 1 || v == 3)
            {
                db = Db4oEmbedded.OpenFile("BDOO.dat");
                Contenido con = new Contenido(Convert.ToInt32(textBox1.Text));
                IObjectSet<Contenido> res = db.QueryByExample(con);
                foreach (Contenido obj in res)
                {
                    obj.Actualizar(textBox2.Text, comboBox1.Text,
                        textBox4.Text, Convert.ToInt32(textBox5.Text),
                        Convert.ToInt32(textBox6.Text),
                        Convert.ToInt32(textBox7.Text));
                    db.Store(obj);
                }
                db.Close();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 2)
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                com = new SqlCommand();
                com.CommandText = "delete from Contenido where Id_Con =" + textBox1.Text;
                com.CommandType = CommandType.Text;
                com.Connection = conn;
                try
                {
                    com.ExecuteNonQuery();
                    MessageBox.Show("Contenido eliminado!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
            else if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 3)
            {
                db = Db4oEmbedded.OpenFile("BDOO.dat");
                Contenido con = new Contenido(Convert.ToInt32(textBox1.Text));
                IObjectSet<Contenido> res = db.QueryByExample(con);
                foreach (Contenido obj in res)
                {
                    db.Delete(obj);
                }
                MessageBox.Show("Datos Eliminados!");
                db.Close();
            }
        }
    }
}