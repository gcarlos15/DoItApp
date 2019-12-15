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
using DoIt.Controladores;
using DoIt.Modelos;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Sistema_de_Gestión_Universitaria
{
    public partial class Form1 : MaterialForm
    {
        Persona persona;
        Cuenta cuenta;
        PersonaController personaController;
        CuentaController cuentaController;
        Validation personaValidation, cuentaValidation;

        public Form1()
        {
            InitializeComponent();

            MyThemeManagerClass.defaultTheme(this);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            personaController = new PersonaController();
            cuentaController = new CuentaController();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            cuenta = new Cuenta();
            cuenta.Usuario = txtUsuario.Text;
            cuenta.Contrasena = txtContrasena.Text;

            if(cuentaController.UserExists(cuenta))
            {
                Thread thread = new Thread(new ThreadStart(() =>
                {
                    new PrincipalForm(cuenta).ShowDialog();

                }));

                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                this.Dispose();

            } else
            {
                MessageBox.Show("Usuario o Contraseña Incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void ClearControls()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            txtNuevoUsuario.Clear();
            txtNuevaContrasena.Clear();
            radioHombre.Checked = false;
            radioHombre.Checked = false;
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            this.persona = new Persona();
            this.cuenta = new Cuenta();

            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
           
            if (radioHombre.Checked)
            {
                persona.Genero = 1;
            } else if (radioMujer.Checked)
            {
                persona.Genero = 0;
            }

            try { 
                persona.Edad = int.Parse(txtEdad.Text);
            } catch { };



            cuenta.Usuario = txtNuevoUsuario.Text;
            cuenta.Contrasena = txtNuevaContrasena.Text;


            personaValidation = new Validation();
            cuentaValidation = new Validation();

           
            if(personaValidation.Validate(persona) || cuentaValidation.Validate(cuenta))
            {

                if(cuentaController.UserExists(cuenta))
                {
                    MessageBox.Show("Usuario o Contraseña Existentes. Intente con otros datos","Advertencia",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {
                    cuentaController.Add(cuenta);
                    personaController.Add(persona, cuenta.Usuario);
                    MessageBox.Show("Nuevo usuario creado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearControls();
                }    

            } else
            {
                foreach (ValidationResult feed in personaValidation.getErrorMessages())
                {
                    MessageBox.Show(feed.ErrorMessage, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                foreach (ValidationResult feed in cuentaValidation.getErrorMessages())
                {
                    MessageBox.Show(feed.ErrorMessage, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
  
        }
    }
}
