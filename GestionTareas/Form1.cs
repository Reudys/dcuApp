using System;
using System.Windows.Forms;

namespace GestionTareas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarFormularioPrederminado();
        }

        public void CargarFormularioPrederminado()
        {
            Inicio form = new Inicio();
            panelContenedor.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(form);

            form.Show();
        }


        public void CargarFormulario(Form formularioHijo)
        {
            panelContenedor.Controls.Clear();

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formularioHijo);

            formularioHijo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verTareas verTareas = new verTareas();

            CargarFormulario(verTareas);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAgregarTarea frmAgregarTarea = new frmAgregarTarea();
            CargarFormulario(frmAgregarTarea);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            CargarFormulario(inicio);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmEditarTarea frmEditarTarea = new frmEditarTarea();
            CargarFormulario(frmEditarTarea);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmTareaRealizada frmTareaRealizada = new frmTareaRealizada();
            CargarFormulario(frmTareaRealizada);
        }
    }
}
