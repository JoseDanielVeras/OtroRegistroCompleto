using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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

        void limpiar()
        {
            IdRolNumericUpDown.Value = 0;
            FechaCreacionDateTimePicker.Value = DateTime.Now;
            DescripcionTextBox.Clear();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {

        }
    }
}
