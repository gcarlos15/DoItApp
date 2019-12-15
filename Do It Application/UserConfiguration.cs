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
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Gestión_Universitaria
{
    public partial class UsuarioDataForm : MaterialForm
    {
        Persona persona;
        Cuenta cuenta;
        PersonaController personaController;
        CuentaController cuentaController;
        Validation personaValidation;

        public UsuarioDataForm(Cuenta cuenta)
        {
            InitializeComponent();
            MyThemeManagerClass.defaultTheme(this);
            this.cuenta = cuenta;
            personaController = new PersonaController();
            cuentaController = new CuentaController();
            CargarDatosPersona();
        }

        private void CargarDatosPersona()
        {
            persona = personaController.Get(cuenta.Usuario);
            txtNombre.Text = persona.Nombre;
            txtApellido.Text = persona.Apellido;
            txtEdad.Text = persona.Edad.ToString();

            if(persona.Genero == 1)
            {
                radioHombre.Checked = true;
            } else
            {
                radioMujer.Checked = true;
            }
        }

        private void GuardarCambiosPersona()
        {
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;

            if (radioHombre.Checked)
            {
                persona.Genero = 1;
            }
            else if (radioMujer.Checked)
            {
                persona.Genero = 0;
            }

            try
            {
                persona.Edad = int.Parse(txtEdad.Text);
            }
            catch { };



            personaValidation = new Validation();
            
            if (personaValidation.Validate(persona))
            {
                if (MessageBox.Show("¿Seguro que deséa actualizar su perfil?", "Confirmar proceso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    personaController.Update(persona, cuenta.Usuario); 
                    this.DialogResult = DialogResult.Yes;
                    MessageBox.Show("Acción completada con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }

                
                    
            }
            else
            {
                foreach (ValidationResult feed in personaValidation.getErrorMessages())
                {
                    MessageBox.Show(feed.ErrorMessage, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
        
        private void UsuarioDataForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConfirmarUsuario_Click(object sender, EventArgs e)
        {
            GuardarCambiosPersona();
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deséa elimar su cuenta?: Todos los datos vinculados a ésta cuenta también se verán afectados", "Confirmar proceso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                cuentaController.Delete(cuenta.Usuario);
                this.DialogResult = DialogResult.Yes;
                MessageBox.Show("Acción completada con éxito. La aplicación será cerrada.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
