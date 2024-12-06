using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace GestionTareas
{
    public partial class verTareas : Form
    {
        public verTareas()
        {
            InitializeComponent();
            CargarDatosJson();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns["Descripcion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        private void CargarDatosJson()
        {
            // Ruta del archivo JSON
            string filePath = "C:\\Users\\Rey\\Desktop\\GestionTareas\\tareas.json";

            // Leer el archivo JSON y convertirlo en una lista de objetos
            List<Tarea> tareas = new List<Tarea>();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                tareas = JsonConvert.DeserializeObject<List<Tarea>>(json);
            }

            // Vincular los datos al DataGridView
            dataGridView1.DataSource = tareas;
        }
    }
}
