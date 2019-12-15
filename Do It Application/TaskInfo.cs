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
using DoIt.Modelos;
using DoIt.Controladores;
using System.ComponentModel.DataAnnotations;

namespace DoIt
{
    public partial class TaskInfo : MaterialForm
    {
        private Tarea tarea;
        private Cuenta cuenta;
        private TareaController tareaController;
        private Validation tareaValidation;
        private TareaManipulationType tareaManipuationType;

        private enum TareaManipulationType {
            Insert,
            Update
        }

        public TaskInfo(Tarea tarea=null, Cuenta cuenta=null)
        {
            InitializeComponent();
            MyThemeManagerClass.defaultTheme(this);
            tareaController = new TareaController();

            if(tarea != null)
            {
                this.tarea = tarea;
                this.Text = "Editar Tarea";
                CargarDatosTarea();
                tareaManipuationType = TareaManipulationType.Update;

            } else
            {
                this.Text = "Crear Tarea";
                this.tarea = new Tarea();
                this.cuenta = cuenta;
                tareaManipuationType = TareaManipulationType.Insert;
            }
            
        }

        private void MakeManipulation(TareaManipulationType tareaManipulationType)
        {

            if (tareaManipulationType == TareaManipulationType.Update)
            {
                tareaController.Update(tarea);
            } else if(tareaManipulationType == TareaManipulationType.Insert)
            {
                tareaController.Add(tarea, cuenta);
            } else
            {
                throw new Exception();
            }
        }

        private void CargarDatosTarea()
        {
            txtTituloTarea.Text = tarea.Titulo;
            txtDescripcionTarea.Text = tarea.Descripcion;
            fechaTareaPicker.Value = tarea.Fecha;
            checkHecho.Checked = tarea.Hecho == 1 ? true : false;
        }

        private void TaskInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmarTarea_Click(object sender, EventArgs e)
        {
            tareaValidation = new Validation();
            tarea.Titulo = txtTituloTarea.Text;
            tarea.Descripcion = txtDescripcionTarea.Text;
            tarea.Hecho = checkHecho.Checked ? 1 : 0;
            tarea.Fecha = fechaTareaPicker.Value;

            if (tareaValidation.Validate(tarea))
            {
                if(MessageBox.Show("¿Seguro que deséa ejecutar este proceso?", "Confirmar proceso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    MakeManipulation(tareaManipuationType);
                    this.DialogResult = DialogResult.Yes;
                    MessageBox.Show("Acción completada con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    this.DialogResult = DialogResult.No;
                }
                
            }
            else
            {
                foreach (ValidationResult feed in tareaValidation.getErrorMessages())
                {
                    MessageBox.Show(feed.ErrorMessage, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
