using OtroRegistroCompleto.BLL;
using OtroRegistroCompleto.DAL;
using OtroRegistroCompleto.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtroRegistroCompleto.IU.Registros;

namespace OtroRegistroCompleto
{
    public partial class RegistroUsuariosForm : Form
    {
        public RegistroUsuariosForm()
        {
            InitializeComponent();
            IngresoDateTimePicker.Format = DateTimePickerFormat.Custom;
            IngresoDateTimePicker.CustomFormat = "dd/MM/yyyy";
        }

        void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            AliasTextBox.Clear();
            NombresTextBox.Clear();
            ClaveMaskedTextBox.Clear();
            ConfirmarMaskedTextBox.Clear();
            EmailTextBox.Clear();
            ActivoCheckBox.Checked = false;
            IngresoDateTimePicker.Value = DateTime.Now;
            errorProvider1.Clear();
        }

        private Usuarios LlenarClase()
        {
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = Convert.ToInt32(IdNumericUpDown.Value);
            usuarios.Alias = AliasTextBox.Text;
            usuarios.Email = EmailTextBox.Text;
            usuarios.Clave = ClaveMaskedTextBox.Text;
            usuarios.FechaIngreso = IngresoDateTimePicker.Value;
            usuarios.Activo = ActivoCheckBox.Checked;
            usuarios.Nombres = NombresTextBox.Text;
            //usuarios.Rol = rolComboBox.Text;

            return usuarios;
        }

        private bool LlenarCampos(int id)
        {
            Usuarios usuarios = UsuarioBLL.Buscar(id);

            if (usuarios != null)
            {
                IdNumericUpDown.Value = usuarios.UsuarioId;
                NombresTextBox.Text = usuarios.Nombres;
                AliasTextBox.Text = usuarios.Alias;
                EmailTextBox.Text = usuarios.Email;
                ConfirmarMaskedTextBox.Text = usuarios.Clave;
                IngresoDateTimePicker.Value = usuarios.FechaIngreso;
                ClaveMaskedTextBox.Text = usuarios.Clave;
                ActivoCheckBox.Checked = usuarios.Activo;
                return true;
            }
            else
                return false;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Usuarios usuarios = UsuarioBLL.Buscar((int)IdNumericUpDown.Value);
            return (usuarios != null);
        }

        //Esta funcion reficia todo todos lo campos del formulario
        private bool Validar()
        {
            bool Paso = true;
            errorProvider1.Clear();

            if (IdNumericUpDown.Value == 0)
            {
                errorProvider1.SetError(IdNumericUpDown, "Obligatorio");
                Paso = true;
            }

            if (NombresTextBox.Text == "")
            {
                errorProvider1.SetError(NombresTextBox, "Obligatorio");
                Paso = true;
            }

            if (ClaveMaskedTextBox.Text == "")
            {
                errorProvider1.SetError(ClaveMaskedTextBox, "Obligatorio");
                Paso = true;
            }

            if (ConfirmarMaskedTextBox.Text == "")
            {
                errorProvider1.SetError(ConfirmarMaskedTextBox, "Obligatorio");
                Paso = true;
            }

            if (EmailTextBox.Text == "")
            {
                errorProvider1.SetError(EmailTextBox, "Obligatorio");
                Paso = true;
            }

            if (RolComboBox.Text == "")
            {
                errorProvider1.SetError(RolComboBox, "Obligatorio");
                Paso = true;
            }

            if (ConfirmarMaskedTextBox.Text != ClaveMaskedTextBox.Text && ConfirmarMaskedTextBox.Text != "")
            { 
                errorProvider1.SetError(ConfirmarMaskedTextBox, "La Clave no coincide");
                Paso = true;
            }

            return Paso;
        }

        //El boton Nuevo limpia los campos y los errores.
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //Esta funcino tiene doble funcionalidad, esta puede modificar y guardar usuarios.
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuarios;
            bool paso = false;

            if (!Validar())
                return;

            usuarios = LlenarClase();

            //determinar si es guardar o modificar
            if (IdNumericUpDown.Value != 0)
            {
                paso = UsuarioBLL.Guardar(usuarios);
                MessageBox.Show("Se ha guardado correctamente");
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un usuario que no existe");
                    return;
                }
                paso = UsuarioBLL.Modificar(usuarios);
            }
        }

        //Esta funcion elimina usiarios
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (UsuarioBLL.Eliminar(id))
                MessageBox.Show("Usuario eliminado");
            else
                errorProvider1.SetError(IdNumericUpDown, "Este usuario no existe");
        }

        //Esta funcion busca un usuario con su id.
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Usuarios usuarios = new Usuarios();
            id = (int)IdNumericUpDown.Value;

            Limpiar();

            usuarios = UsuarioBLL.Buscar(id);

            if (usuarios != null)
            {
                LlenarCampos(Convert.ToInt32(id));
            }
            else
            {
                MessageBox.Show("Usuario no encontrado");
            }
        }

        private void RegistroUsuariosForm_Load(object sender, EventArgs e)
        {
            RolComboBox.DataSource = RolesBLL.GetRoles();
            RolComboBox.DisplayMember = "Descripcion";
            RolComboBox.ValueMember = "RolId";
        }
    }
}
