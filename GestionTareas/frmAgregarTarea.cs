using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GestionTareas
{
    public partial class frmAgregarTarea : Form
    {
        private string filePath = "C:\\Users\\Rey\\Desktop\\GestionTareas\\tareas.json";

        public frmAgregarTarea()
        {
            InitializeComponent();
        }

        private void AgregarTarea()
        {
            List<Tarea> tareas = new List<Tarea>();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                tareas = JsonConvert.DeserializeObject<List<Tarea>>(json);
            }

            Tarea nuevaTarea = new Tarea
            {
                NombreClave = txtNombreClave.Text,
                Materia = txtMateria.Text,
                Descripcion = txtDescripcion.Text,
                FechaEntrega = dtpFechaEntrega.Value.ToString("yyyy-MM-dd")
            };

            tareas.Add(nuevaTarea);

            string updatedJson = JsonConvert.SerializeObject(tareas, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);

            MessageBox.Show("Tarea agregada con éxito");
            Limpiar();
        }

        private void Limpiar()
        {
            txtNombreClave.Clear();
            txtMateria.Clear();
            txtDescripcion.Clear();
            dtpFechaEntrega.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarTarea();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
