using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtroRegistroCompleto.IU.Registros.Menu
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        private void RegistroRolesButton_Click(object sender, EventArgs e)
        {
            IU.Registros.RegistroRoles registroRoles = new IU.Registros.RegistroRoles();
            registroRoles.Show();
        }

        private void RegistrosUsuariosButton_Click(object sender, EventArgs e)
        {
            RegistroUsuariosForm registroUsuariosForm = new RegistroUsuariosForm();
            registroUsuariosForm.Show();
        }
    }
}
