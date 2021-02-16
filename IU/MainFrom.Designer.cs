
namespace OtroRegistroCompleto.IU.Registros.Menu
{
    partial class MainFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
            this.RegistroRolesButton = new System.Windows.Forms.Button();
            this.RegistrosUsuariosButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RegistroRolesButton
            // 
            this.RegistroRolesButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RegistroRolesButton.Location = new System.Drawing.Point(77, 70);
            this.RegistroRolesButton.Name = "RegistroRolesButton";
            this.RegistroRolesButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RegistroRolesButton.Size = new System.Drawing.Size(78, 54);
            this.RegistroRolesButton.TabIndex = 0;
            this.RegistroRolesButton.Text = "Registro Roles";
            this.RegistroRolesButton.UseVisualStyleBackColor = true;
            this.RegistroRolesButton.Click += new System.EventHandler(this.RegistroRolesButton_Click);
            // 
            // RegistrosUsuariosButton
            // 
            this.RegistrosUsuariosButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RegistrosUsuariosButton.Location = new System.Drawing.Point(191, 70);
            this.RegistrosUsuariosButton.Name = "RegistrosUsuariosButton";
            this.RegistrosUsuariosButton.Size = new System.Drawing.Size(78, 54);
            this.RegistrosUsuariosButton.TabIndex = 1;
            this.RegistrosUsuariosButton.Text = "Registro Usuarios";
            this.RegistrosUsuariosButton.UseVisualStyleBackColor = true;
            this.RegistrosUsuariosButton.Click += new System.EventHandler(this.RegistrosUsuariosButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccione El Registro Que Desea";
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 164);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RegistrosUsuariosButton);
            this.Controls.Add(this.RegistroRolesButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrom";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegistroRolesButton;
        private System.Windows.Forms.Button RegistrosUsuariosButton;
        private System.Windows.Forms.Label label1;
    }
}