using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using MaterialSkin;
using DoIt;
using DoIt.Modelos;
using DoIt.Controladores;

namespace Sistema_de_Gestión_Universitaria
{
    public partial class PrincipalForm : MaterialForm
    {
        CuentaController cuentaController;
        PersonaController personaController;
        TareaController tareaController;
        DataView dataView;
        Cuenta cuenta;
        Tarea tarea;
        int selectedRow;

        public PrincipalForm(Cuenta cuenta)
        {
            InitializeComponent();

            MyThemeManagerClass.defaultTheme(this);
            this.cuenta = cuenta;
            tarea = new Tarea();
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
            cuentaController = new CuentaController();
            personaController = new PersonaController();
            tareaController = new TareaController();
  
            RefreshTareasDashboard();
            RefreshProfile();
            selectedRow = -1;
            dgvTareas.ClearSelection();
        }

        private void RefreshProfile()
        {
            lblUsuario.Text = cuenta.Usuario;
        }

        private void RefreshTareasDashboard()
        {
            dataView = new DataView(tareaController.Dashboard());
            dgvTareas.DataSource = dataView;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (UsuarioDataForm usuarioDataForm = new UsuarioDataForm(cuenta))
            {

                if (usuarioDataForm.ShowDialog() == DialogResult.Yes)
                {
                    RefreshProfile();
                    usuarioDataForm.Close();
                }
            }
        }

        private void btnCrearTarea_Click(object sender, EventArgs e)
        {
                using (TaskInfo taskInfoForm = new TaskInfo(null, cuenta))
                {
                    if (taskInfoForm.ShowDialog() == DialogResult.Yes)
                    {
                        RefreshTareasDashboard();
                        taskInfoForm.Close();
                    }
                }          
        }

        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Seguro que deséa eliminar ésta tarea?", "Confirmar proceso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                tareaController.Delete(int.Parse(dgvTareas.Rows[selectedRow].Cells["Id"].Value.ToString()));
                RefreshTareasDashboard();
                MessageBox.Show("Acción completada con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void btnEditarTarea_Click(object sender, EventArgs e)
        {
          
            tarea.Id = int.Parse(dgvTareas.Rows[selectedRow].Cells["Id"].Value.ToString());
            tarea.Titulo = dgvTareas.Rows[selectedRow].Cells["Titulo"].Value.ToString();
            tarea.Descripcion = dgvTareas.Rows[selectedRow].Cells["Descripcion"].Value.ToString();
            tarea.Hecho = (bool) dgvTareas.Rows[selectedRow].Cells["Hecho"].Value ? 1 : 0;
            tarea.Fecha = DateTime.Parse(dgvTareas.Rows[selectedRow].Cells["Fecha"].Value.ToString());

            using(TaskInfo taskInfoForm = new TaskInfo(tarea))
            {
                if(taskInfoForm.ShowDialog() == DialogResult.Yes)
                {
                    RefreshTareasDashboard();
                    taskInfoForm.Close();
                } 

            }
        }

        private void dgvTareas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {               
                selectedRow = e.Row.Index;

                if(dgvTareas.Rows[selectedRow].Cells["Usuario"].Value.ToString() == cuenta.Usuario)
                {
                    btnEliminarTarea.Enabled = true;
                    btnEditarTarea.Enabled = true;
                } else
                {
                    btnEliminarTarea.Enabled = false;
                    btnEditarTarea.Enabled = false;
                }
            }
        
        }

        private void btnRefrescarDashboard_Click(object sender, EventArgs e)
        {
            RefreshTareasDashboard();
        }

        private void cmbFiltroTareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFiltroTareas.SelectedIndex)
            {
                case 0:
                    dataView.RowFilter = "";
                    break;
                case 1:
                    dataView.RowFilter = "Usuario = '" + cuenta.Usuario +"'";
                    break;
        

            }
        }
    }
}
