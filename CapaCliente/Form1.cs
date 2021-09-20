using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Data.SqlClient;


namespace CapaCliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Limpiar() {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();                      
        }

        private void mensajeError(string Mensaje) {

            MessageBox.Show(Mensaje, "Control de Alumno", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void mensajeOK(string Mensaje) {

            MessageBox.Show(Mensaje, "Control De Alumno", MessageBoxButtons.OK, MessageBoxIcon.Information);        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try 
            {
                string Respuesta = " ";
                if ((textBox1.Text == string.Empty) || (textBox2.Text == string.Empty) || (textBox3.Text == string.Empty) || (textBox4.Text == string.Empty) || (textBox5.Text == string.Empty) || (textBox6.Text == string.Empty)) 
                {
                    this.mensajeError("Faltan Datos.");
                    return;
                }

                Respuesta = Negocios.insertar(textBox1.Text, Convert.ToInt32(textBox2.Text));
                Respuesta = Negocios.AgregarNotaAlumno(textBox3.Text, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), textBox6.Text);

                if (Respuesta.Equals("OK"))
                {
                    this.mensajeOK(" Se Inserto De Forma Correcta. ");
                    this.Limpiar();
                }
                else 
                {
                    mensajeError(Respuesta);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255)) 
            {
                e.Handled = true;
                return;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void mostrar() 
        {
            try
            {
                dataGridView2.DataSource = Negocios.mostrar();
                //this.formato();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void mostrars()
        {
            try
            {
                dataGridView1.DataSource = Negocios.mostrars();
                //this.formato();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void formato() 
        {
           // dataGridView1.Columns[0].Width = 200;
            //dataGridView1.Columns[1].Width = 200;
            //dataGridView1.Columns[2].Width = 200;
            //dataGridView1.Columns[3].Width = 200;
           // dataGridView1.Columns[4].Width = 200;
            //dataGridView1.Columns[5].Width = 200;
            //dataGridView1.Columns[6].Width = 200;
            //dataGridView1.Columns[7].Width = 200;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.mostrar();
            //this.mostrars();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.mostrar();
            this.mostrars();
        }
    }
}
