using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OtroRegistroCompleto.BLL;
using OtroRegistroCompleto.Entidades;

namespace OtroRegistroCompleto.IU.Registros
{
    public partial class RegistroRoles : Form
    {
        public RegistroRoles()
        {
            InitializeComponent();
            FechaCreacionDateTimePicker.Format = DateTimePickerFormat.Custom;
            FechaCreacionDateTimePicker.CustomFormat = "dd/MM/yyyy";
        }

        private Roles LlenaClase()
        {
            Roles roles = new Roles();
            roles.RolId = Convert.ToInt32(IdRolNumericUpDown.Value);
            roles.Descripcion = DescripcionTextBox.Text;
            roles.FechaCreacion = FechaCreacionDateTimePicker.Value;

            return roles;
        }

        private bool LLenaCampos(Roles roles)
        {
            IdRolNumericUpDown.Value = roles.RolId;
            DescripcionTextBox.Text = roles.Descripcion;
            return true;
        }

        private bool ExisteEnBaseDeDatos()
        {
            Roles roles = RolesBLL.Buscar((int)IdRolNumericUpDown.Value);
            return (roles != null);
        }

        private bool Validar()
        {
            bool paso = true;
            if (IdRolNumericUpDown.Value == 0)
            {
                RolErrorProvider.SetError(IdRolNumericUpDown, "Obligatorio");
                paso = false;
            }

            if (DescripcionTextBox.Text == "")
            {
                RolErrorProvider.SetError(DescripcionTextBox, "Obligatorio");
                paso = false;
            }

            return paso;
        }

        void Limpiar()
        {
            IdRolNumericUpDown.Value = 0;
            FechaCreacionDateTimePicker.Value = DateTime.Now;
            DescripcionTextBox.Clear();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Roles roles;
            bool paso = false;

            if (!Validar())
                return;

            roles = LlenaClase();

            //Determinar si es guardar o modificar
            if (IdRolNumericUpDown.Value != 0)
                paso = RolesBLL.Guardar(roles);
            else
            {
                if (!ExisteEnBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un usuario que no existe");
                    return;
                }
                paso = RolesBLL.Modificar(roles);

            }

            if (paso)
                MessageBox.Show("Se ha guardado correctamente");
            else
                MessageBox.Show("No fue posible guardar");
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            RolErrorProvider.Clear();
            int id;
            int.TryParse(IdRolNumericUpDown.Text, out id);
            Limpiar();
            if (RolesBLL.Eliminar(id))
                MessageBox.Show("Usuario eliminado");
            else
                RolErrorProvider.SetError(IdRolNumericUpDown, "Este rol no existe");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Roles roles = new Roles();
            int.TryParse(IdRolNumericUpDown.Text, out id);

            Limpiar();
            roles = RolesBLL.Buscar(id);
            if (roles != null)
            {
                LLenaCampos(roles);
            }
            else
            {
                MessageBox.Show("Usuario no encontrado");
            }
        }
    }
}
