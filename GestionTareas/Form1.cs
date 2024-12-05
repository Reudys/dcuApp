using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTareas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void CargarFormulario(Form formularioHijo)
        {
            // Limpiar el panel antes de agregar un nuevo formulario
            panelContenedor.Controls.Clear();

            // Configurar el formulario hijo
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            // Agregar el formulario hijo al panel
            panelContenedor.Controls.Add(formularioHijo);

            // Mostrar el formulario hijo
            formularioHijo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verTareas formularioHijo = new verTareas();

            // Cargar el formulario hijo en el contenedor
            CargarFormulario(formularioHijo);
        }
    }
}
