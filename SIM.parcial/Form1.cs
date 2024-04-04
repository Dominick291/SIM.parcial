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

namespace SIM.parcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Departamentos> departamentos = new List<Departamentos>();
        List<Temperatura> temperaturas = new List<Temperatura>();
        List<Reporte> reportes = new List<Reporte>();

        public void cargarDepartamentos()
        {
            String fileName = "Departamentos.txt";


            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Departamentos departamentoss = new Departamentos();
                departamentoss.Codigo = Convert.ToInt32(reader.ReadLine());
                departamentoss.Nombre = reader.ReadLine();
                

                departamentos.Add(departamentoss);
            }
            reader.Close();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Codigo";
            comboBox1.DataSource = departamentos;
            comboBox1.Refresh();


        }
        public void guardartemp()
        {
            String fileName = "Temperaturas.txt";

            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var temperatura in temperaturas)
            {
                writer.WriteLine(temperatura.Codigo);
                writer.WriteLine(temperatura.Temperaturas);
                writer.WriteLine(temperatura.Fecha);

            }
            writer.Close();
        }

        public void datos()
        {
            foreach (Departamentos departamentoss in departamentos)
            {
                int noDep = departamentoss.Codigo;
                foreach (Temperatura temperatura in temperaturas)
                {
                    if (departamentoss.Codigo == temperatura.Codigo)
                    {
                        Reporte reporte = new Reporte();
                        reporte.Codigo = departamentoss.Codigo;
                        reporte.NombreDep = departamentoss.Nombre;
                        reporte.Fecha = temperatura.Fecha;
                        reporte.Temperatura = temperatura.Temperaturas;

                        reportes.Add(reporte);
                    }
                }
            }
        }


        public void MostrarReporte()
        {
            
            //mostrar la lista de empleados en el gridview 
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();
        }
        private void guardar_Click(object sender, EventArgs e)
        {
            //cargarDepartamentos();
            
            //comboBox1.SelectedValue;
            Temperatura temperatura = new Temperatura();
            temperatura.Codigo = Convert.ToInt32(comboBox1.SelectedValue);
            temperatura.Temperaturas = Convert.ToDecimal(textBox1.Text);
            temperatura.Fecha = DateTime.Now;

            temperaturas.Add(temperatura);
            datos();
            MostrarReporte();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDepartamentos();
        }
    }
}
