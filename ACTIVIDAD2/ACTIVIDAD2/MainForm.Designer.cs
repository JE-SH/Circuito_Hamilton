/*
 * Creado por SharpDevelop.
 * Usuario: JESH
 * Fecha: 06/03/2020
 * Hora: 07:59 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ACTIVIDAD2
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button agregar_imaen;
		private System.Windows.Forms.Button analizar;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox textBoxH;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.agregar_imaen = new System.Windows.Forms.Button();
			this.analizar = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.textBoxH = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(688, 464);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1MouseClick);
			// 
			// agregar_imaen
			// 
			this.agregar_imaen.Location = new System.Drawing.Point(784, 24);
			this.agregar_imaen.Name = "agregar_imaen";
			this.agregar_imaen.Size = new System.Drawing.Size(163, 40);
			this.agregar_imaen.TabIndex = 1;
			this.agregar_imaen.Text = "AGREGAR IMAGEN";
			this.agregar_imaen.UseVisualStyleBackColor = true;
			this.agregar_imaen.Click += new System.EventHandler(this.Agregar_imaenClick);
			// 
			// analizar
			// 
			this.analizar.Location = new System.Drawing.Point(784, 80);
			this.analizar.Name = "analizar";
			this.analizar.Size = new System.Drawing.Size(163, 48);
			this.analizar.TabIndex = 2;
			this.analizar.Text = "ANALIZAR";
			this.analizar.UseVisualStyleBackColor = true;
			this.analizar.Click += new System.EventHandler(this.AnalizarClick);
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.textBox1.Location = new System.Drawing.Point(704, 136);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(432, 232);
			this.textBox1.TabIndex = 1;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// textBoxH
			// 
			this.textBoxH.Location = new System.Drawing.Point(712, 376);
			this.textBoxH.Multiline = true;
			this.textBoxH.Name = "textBoxH";
			this.textBoxH.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxH.Size = new System.Drawing.Size(424, 96);
			this.textBoxH.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1152, 493);
			this.Controls.Add(this.textBoxH);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.analizar);
			this.Controls.Add(this.agregar_imaen);
			this.Controls.Add(this.pictureBox1);
			this.ImeMode = System.Windows.Forms.ImeMode.On;
			this.Name = "MainForm";
			this.Text = "ACTIVIDAD2";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
