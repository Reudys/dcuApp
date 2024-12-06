using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GestionTareas
{
    public partial class frmEditarTarea : Form
    {
        public frmEditarTarea()
        {
            InitializeComponent();
        }

        private void BuscarYMostrarTarea(string nombreClave)
        {
            List<Tarea> tareas = CargarTareasDesdeJson();

            Tarea tarea = tareas.FirstOrDefault(t => t.NombreClave == nombreClave);

            if (tarea != null)
            {
                txtNombreClave.Text = tarea.NombreClave;
                txtMateria.Text = tarea.Materia;
                txtDescripcion.Text = tarea.Descripcion;

                DateTime fecha;
                if (DateTime.TryParse(tarea.FechaEntrega, out fecha))
                {
                    dtpFechaEntrega.Value = fecha;  
                }
                else
                {
                    MessageBox.Show("La fecha no es válida.");
                }
            }
            else
            {
                MessageBox.Show("No se encontró una tarea con el Nombre Clave especificado.");
            }
        }

        private void ActualizarTarea(string nombreClave)
        {
            List<Tarea> tareas = CargarTareasDesdeJson();

            Tarea tarea = tareas.FirstOrDefault(t => t.NombreClave == nombreClave);

            if (tarea != null)
            {
                tarea.Materia = txtMateria.Text;
                tarea.Descripcion = txtDescripcion.Text;
                tarea.FechaEntrega = dtpFechaEntrega.Value.ToString("yyyy-MM-dd");  

                GuardarTareasEnJson(tareas);

                MessageBox.Show("Tarea actualizada correctamente.");
            }
            else
            {
                MessageBox.Show("No se encontró una tarea con el Nombre Clave especificado.");
            }
        }

        private List<Tarea> CargarTareasDesdeJson()
        {
            string archivoJson = @"C:\Users\Rey\Desktop\GestionTareas\tareas.json";
            if (File.Exists(archivoJson))
            {
                string json = File.ReadAllText(archivoJson);
                return JsonConvert.DeserializeObject<List<Tarea>>(json);
            }
            return new List<Tarea>();
        }

        private void GuardarTareasEnJson(List<Tarea> tareas)
        {
            string archivoJson = @"C:\Users\Rey\Desktop\GestionTareas\tareas.json";
            string json = JsonConvert.SerializeObject(tareas, Formatting.Indented);
            File.WriteAllText(archivoJson, json);
        }

        private void Limpiar()
        {
            txtNombreClave.Clear();
            txtMateria.Clear();
            txtDescripcion.Clear();
            dtpFechaEntrega.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nombreClave = txtNombreClave.Text;

            if (!string.IsNullOrEmpty(nombreClave))
            {
                ActualizarTarea(nombreClave);
            }
            else
            {
                MessageBox.Show("Por favor, busque una tarea primero antes de editar.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreClave = txtNombreClave.Text;

            if (!string.IsNullOrEmpty(nombreClave))
            {
                BuscarYMostrarTarea(nombreClave);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un Nombre Clave para buscar.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
