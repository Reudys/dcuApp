using Newtonsoft.Json;
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

namespace GestionTareas
{
    public partial class frmTareaRealizada : Form
    {
        public frmTareaRealizada()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreClave = txtNombreClave.Text;

            if (!string.IsNullOrEmpty(nombreClave))
            {
                EliminarTarea(nombreClave);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un Nombre Clave para eliminar.");
            }
        }

        private void EliminarTarea(string nombreClave)
        {
            List<Tarea> tareas = CargarTareasDesdeJson();

            Tarea tarea = tareas.FirstOrDefault(t => t.NombreClave == nombreClave);

            if (tarea != null)
            {
                tareas.Remove(tarea);

                GuardarTareasEnJson(tareas);

                MessageBox.Show("Tarea eliminada correctamente.");
                Limpiar(); 
            }
            else
            {
                MessageBox.Show("No se encontró una tarea con el Nombre Clave especificado.");
            }
        }

        private void GuardarTareasEnJson(List<Tarea> tareas)
        {
            string json = JsonConvert.SerializeObject(tareas, Formatting.Indented);
            File.WriteAllText("C:\\Users\\Rey\\Desktop\\GestionTareas\\tareas.json", json);
        }


        private List<Tarea> CargarTareasDesdeJson()
        {
            string json = File.ReadAllText("C:\\Users\\Rey\\Desktop\\GestionTareas\\tareas.json");
            return JsonConvert.DeserializeObject<List<Tarea>>(json);
        }

        private void Limpiar()
        {
            txtNombreClave.Clear();
        }
    }
}
