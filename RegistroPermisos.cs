using OtroRegistroCompleto.BLL;
using OtroRegistroCompleto.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OtroRegistroCompleto
{
    public partial class RegistroPermisos : Form
    {
        public RegistroPermisos()
        {
            InitializeComponent();
        }

        private Permisos LlenaClase()
        {
            Permisos permisos = new Permisos();
            permisos.PermisoId = Convert.ToInt32(IdRolNumericUpDown.Value);
            permisos.Descripcion = DescripcionTextBox.Text;

            return permisos;
        }

        private bool LLenaCampos(Permisos permisos)
        {
            IdRolNumericUpDown.Value = permisos.PermisoId;
            DescripcionTextBox.Text = permisos.Descripcion;
            return true;
        }

        private bool ExisteEnBaseDeDatos()
        {
            Permisos permisos = PermisosBLL.Buscar((int)IdRolNumericUpDown.Value);
            return (permisos != null);
        }

        private bool Validar()
        {
            bool paso = true;
            if (IdRolNumericUpDown.Value == 0)
            {
                errorProvider1.SetError(IdRolNumericUpDown, "Obligatorio");
                paso = false;
            }

            if (DescripcionTextBox.Text == "")
            {
                errorProvider1.SetError(DescripcionTextBox, "Obligatorio");
                paso = false;
            }

            return paso;
        }

        void Limpiar()
        {
            IdRolNumericUpDown.Value = 0;
            DescripcionTextBox.Clear();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Permisos permisos;
            bool paso = false;

            if (!Validar())
                return;

            permisos = LlenaClase();

            //Determinar si es guardar o modificar
            if (IdRolNumericUpDown.Value != 0)
                paso = PermisosBLL.Guardar(permisos);
            else
            {
                if (!ExisteEnBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un usuario que no existe");
                    return;
                }
                paso = PermisosBLL.Modificar(permisos);

            }

            if (paso)
                MessageBox.Show("Se ha guardado correctamente");
            else
                MessageBox.Show("No fue posible guardar");
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int id;
            int.TryParse(IdRolNumericUpDown.Text, out id);
            Limpiar();
            if (PermisosBLL.Eliminar(id))
                MessageBox.Show("Usuario eliminado");
            else
                errorProvider1.SetError(IdRolNumericUpDown, "Este rol no existe");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Permisos permisos= new Permisos();
            int.TryParse(IdRolNumericUpDown.Text, out id);

            Limpiar();
            permisos = PermisosBLL.Buscar(id);
            if (permisos != null)
            {
                LLenaCampos(permisos);
            }
            else
            {
                MessageBox.Show("Usuario no encontrado");
            }
        }
    }
}
