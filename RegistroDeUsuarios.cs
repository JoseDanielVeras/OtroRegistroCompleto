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

        //Esta funcion es para verificar si el Id ya existe y guardar
        public static bool BuscarUsuario(int id)
        {
            Contexto contexto = new Contexto();
            bool existe = false;

            try
            {
                existe = contexto.Usuarios.Any(e => e.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return existe;
        }

        //El liminar borra entidades atraves del boton eliminar.
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var usuarios = contexto.Usuarios.Find(id);

                if (usuarios != null)
                {
                    contexto.Usuarios.Remove(usuarios);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        //Esta funcion busca un usuario
        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuarios;

            try
            {
                usuarios = contexto.Usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return usuarios;
        }

        //Esta funcion reficia todo todos lo campos del formulario
        void Validar(ref bool Paso)
        {
            if (IdTextBox.Text == "")
            {
                errorProvider1.SetError(IdTextBox, "Obligatorio");
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

            if (CostoXHoraTextBox.Text == "")
            {
                errorProvider1.SetError(CostoXHoraTextBox, "Obligatorio");
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
        }

        //El boton Nuevo limpia los campos y los errores.
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            IdTextBox.Text = "";
            AliasTextBox.Text = "";
            NombresTextBox.Text = "";
            ClaveMaskedTextBox.Text = "";
            ConfirmarMaskedTextBox.Text = "";
            CostoXHoraTextBox.Text = "";
            EmailTextBox.Text = "";
            RolComboBox.Text = "";
            CostoXHoraTextBox.Text = "";
            IngresoDateTimePicker.Value = DateTime.Now;
            errorProvider1.Clear();
        }

        //Esta funcino tiene doble funcionalidad, esta puede modificar y guardar usuarios.
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();
            Usuarios usuarios = new Usuarios();
            bool Paso = false;

            Validar(ref Paso);
            if (!Paso)
            {
                //Si el usuario exite lo modifica, sino lo agrega.
                if (BuscarUsuario(Convert.ToInt32(IdTextBox.Text)))
                {
                    Eliminar(Convert.ToInt32(IdTextBox.Text));
                    usuarios.UsuarioId = Convert.ToInt32(IdTextBox.Text);
                    usuarios.Alias = AliasTextBox.Text;
                    usuarios.Nombres = NombresTextBox.Text;
                    usuarios.Email = EmailTextBox.Text;
                    usuarios.Clave = ClaveMaskedTextBox.Text;
                    usuarios.FechaIngreso = IngresoDateTimePicker.Value;
                    usuarios.Activo = ActivoCheckBox.Checked;
                    usuarios.RolId = Convert.ToInt32(RolComboBox.Text);
                    contexto.Usuarios.Add(usuarios);
                    contexto.SaveChanges();
                    contexto.Dispose();
                    errorProvider1.Clear();
                    MessageBox.Show("Usuario Modificado.");
                }
                else
                {
                    usuarios.UsuarioId = Convert.ToInt32(IdTextBox.Text);
                    usuarios.Email = EmailTextBox.Text;
                    usuarios.Activo = ActivoCheckBox.Checked;
                    usuarios.Alias = AliasTextBox.Text;
                    usuarios.Nombres = NombresTextBox.Text;
                    usuarios.Clave = ClaveMaskedTextBox.Text;
                    usuarios.FechaIngreso = IngresoDateTimePicker.Value;
                    contexto.Usuarios.Add(usuarios);
                    usuarios.RolId = Convert.ToInt32(RolComboBox.Text);
                    contexto.SaveChanges();
                    contexto.Dispose();
                    errorProvider1.Clear();
                    MessageBox.Show("Usuario Agregado.");
                }
            }
        }

        //Esta funcion elimina usiarios
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                errorProvider1.SetError(IdTextBox, "Obligatorio");
            }
            else
            {
                if (BuscarUsuario(Convert.ToInt32(IdTextBox.Text)))
                {
                    Eliminar(Convert.ToInt32(IdTextBox.Text));
                    MessageBox.Show("Usuario Eliminado.");
                }
                else
                    MessageBox.Show("Este Usuario No Existe.");
            }
        }

        //Esta funcion busca un usuario con su id.
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            Contexto contexto = new Contexto();
            Resultados ventana = new Resultados();
            contexto.Dispose();

            if (IdTextBox.Text == "")
            {
                errorProvider1.SetError(IdTextBox, "Obligatorio");
            }
            else
            {
                if (BuscarUsuario(Convert.ToInt32(IdTextBox.Text)))
                {
                    usuarios = Buscar(Convert.ToInt32(IdTextBox.Text));
                    ventana.ResultadoIdTextBox.Text = Convert.ToString(usuarios.UsuarioId);
                    ventana.ResultadoAliasTextBox.Text = usuarios.Alias;
                    ventana.ResultadoNombresTextBox.Text = usuarios.Nombres;
                    ventana.ResultadoActivoCheckBox.Checked = usuarios.Activo;
                    ventana.ResultadoEmailTextBox.Text = usuarios.Email;
                    ventana.ResultadoIngresoDateTimePicker.Value = usuarios.FechaIngreso;
                    ventana.ResultadoRolTextBox.Text = Convert.ToString(usuarios.RolId);
                    ventana.Show();
                }
                else
                {
                    MessageBox.Show("Este Usuario No Existe.");
                }
            }
        }
    }
}
