namespace Ortopedia.UI
{
    partial class frmDirecciones
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
            this.gvDirecciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvDirecciones)).BeginInit();
            this.SuspendLayout();
            // 
            // gvDirecciones
            // 
            this.gvDirecciones.AllowUserToAddRows = false;
            this.gvDirecciones.AllowUserToDeleteRows = false;
            this.gvDirecciones.AllowUserToResizeColumns = false;
            this.gvDirecciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvDirecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDirecciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDirecciones.Location = new System.Drawing.Point(0, 0);
            this.gvDirecciones.Name = "gvDirecciones";
            this.gvDirecciones.Size = new System.Drawing.Size(548, 174);
            this.gvDirecciones.TabIndex = 0;
            // 
            // frmDirecciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 174);
            this.Controls.Add(this.gvDirecciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDirecciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDirecciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDirecciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvDirecciones;
    }
}