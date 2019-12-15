namespace DoIt
{
    partial class TaskInfo
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
            this.txtTituloTarea = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtDescripcionTarea = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.fechaTareaPicker = new System.Windows.Forms.DateTimePicker();
            this.btnConfirmarTarea = new System.Windows.Forms.Button();
            this.checkHecho = new MaterialSkin.Controls.MaterialCheckBox();
            this.SuspendLayout();
            // 
            // txtTituloTarea
            // 
            this.txtTituloTarea.Depth = 0;
            this.txtTituloTarea.Hint = "Título";
            this.txtTituloTarea.Location = new System.Drawing.Point(69, 93);
            this.txtTituloTarea.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTituloTarea.Name = "txtTituloTarea";
            this.txtTituloTarea.PasswordChar = '\0';
            this.txtTituloTarea.SelectedText = "";
            this.txtTituloTarea.SelectionLength = 0;
            this.txtTituloTarea.SelectionStart = 0;
            this.txtTituloTarea.Size = new System.Drawing.Size(172, 23);
            this.txtTituloTarea.TabIndex = 0;
            this.txtTituloTarea.UseSystemPasswordChar = false;
            // 
            // txtDescripcionTarea
            // 
            this.txtDescripcionTarea.Depth = 0;
            this.txtDescripcionTarea.Hint = "Descripción";
            this.txtDescripcionTarea.Location = new System.Drawing.Point(69, 137);
            this.txtDescripcionTarea.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDescripcionTarea.Name = "txtDescripcionTarea";
            this.txtDescripcionTarea.PasswordChar = '\0';
            this.txtDescripcionTarea.SelectedText = "";
            this.txtDescripcionTarea.SelectionLength = 0;
            this.txtDescripcionTarea.SelectionStart = 0;
            this.txtDescripcionTarea.Size = new System.Drawing.Size(172, 23);
            this.txtDescripcionTarea.TabIndex = 1;
            this.txtDescripcionTarea.UseSystemPasswordChar = false;
            // 
            // fechaTareaPicker
            // 
            this.fechaTareaPicker.Location = new System.Drawing.Point(69, 179);
            this.fechaTareaPicker.Name = "fechaTareaPicker";
            this.fechaTareaPicker.Size = new System.Drawing.Size(200, 20);
            this.fechaTareaPicker.TabIndex = 2;
            // 
            // btnConfirmarTarea
            // 
            this.btnConfirmarTarea.Location = new System.Drawing.Point(69, 274);
            this.btnConfirmarTarea.Name = "btnConfirmarTarea";
            this.btnConfirmarTarea.Size = new System.Drawing.Size(200, 23);
            this.btnConfirmarTarea.TabIndex = 3;
            this.btnConfirmarTarea.Text = "Confirmar";
            this.btnConfirmarTarea.UseVisualStyleBackColor = true;
            this.btnConfirmarTarea.Click += new System.EventHandler(this.btnConfirmarTarea_Click);
            // 
            // checkHecho
            // 
            this.checkHecho.AutoSize = true;
            this.checkHecho.Depth = 0;
            this.checkHecho.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkHecho.Location = new System.Drawing.Point(69, 213);
            this.checkHecho.Margin = new System.Windows.Forms.Padding(0);
            this.checkHecho.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkHecho.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkHecho.Name = "checkHecho";
            this.checkHecho.Ripple = true;
            this.checkHecho.Size = new System.Drawing.Size(99, 30);
            this.checkHecho.TabIndex = 4;
            this.checkHecho.Text = "Finalizada?";
            this.checkHecho.UseVisualStyleBackColor = true;
            // 
            // TaskInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 336);
            this.Controls.Add(this.checkHecho);
            this.Controls.Add(this.btnConfirmarTarea);
            this.Controls.Add(this.fechaTareaPicker);
            this.Controls.Add(this.txtDescripcionTarea);
            this.Controls.Add(this.txtTituloTarea);
            this.MaximizeBox = false;
            this.Name = "TaskInfo";
            this.Sizable = false;
            this.Text = "Tarea - Info";
            this.Load += new System.EventHandler(this.TaskInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtTituloTarea;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDescripcionTarea;
        private System.Windows.Forms.DateTimePicker fechaTareaPicker;
        private System.Windows.Forms.Button btnConfirmarTarea;
        private MaterialSkin.Controls.MaterialCheckBox checkHecho;
    }
}