namespace Ortopedia.UI
{
    partial class frmTelefonoMail
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
            this.gvTelefonos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvTelefonos)).BeginInit();
            this.SuspendLayout();
            // 
            // gvTelefonos
            // 
            this.gvTelefonos.AllowUserToAddRows = false;
            this.gvTelefonos.AllowUserToDeleteRows = false;
            this.gvTelefonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTelefonos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvTelefonos.Location = new System.Drawing.Point(0, 0);
            this.gvTelefonos.Name = "gvTelefonos";
            this.gvTelefonos.Size = new System.Drawing.Size(347, 169);
            this.gvTelefonos.TabIndex = 0;
            // 
            // frmTelefonoMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 169);
            this.Controls.Add(this.gvTelefonos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTelefonoMail";
            this.Load += new System.EventHandler(this.frmTelefonos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTelefonos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvTelefonos;
    }
}