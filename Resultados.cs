using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OtroRegistroCompleto
{
    public partial class Resultados : Form
    {
        public Resultados()
        {
            InitializeComponent();
            ResultadoIngresoDateTimePicker.Format = DateTimePickerFormat.Custom;
            ResultadoIngresoDateTimePicker.CustomFormat = "dd/MM/yyyy";
        }

        private void ResultadosIdLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
