
namespace TrabalhoBD
{
    partial class cadastraDisciplina
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textNome = new System.Windows.Forms.TextBox();
            this.Periodo = new System.Windows.Forms.Label();
            this.textPeriodo = new System.Windows.Forms.TextBox();
            this.Horário = new System.Windows.Forms.Label();
            this.textHorario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cadastrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome";
            // 
            // textNome
            // 
            this.textNome.Location = new System.Drawing.Point(55, 61);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(299, 22);
            this.textNome.TabIndex = 2;
            // 
            // Periodo
            // 
            this.Periodo.AutoSize = true;
            this.Periodo.Location = new System.Drawing.Point(55, 90);
            this.Periodo.Name = "Periodo";
            this.Periodo.Size = new System.Drawing.Size(57, 17);
            this.Periodo.TabIndex = 3;
            this.Periodo.Text = "Período";
            // 
            // textPeriodo
            // 
            this.textPeriodo.Location = new System.Drawing.Point(55, 111);
            this.textPeriodo.Name = "textPeriodo";
            this.textPeriodo.Size = new System.Drawing.Size(57, 22);
            this.textPeriodo.TabIndex = 4;
            // 
            // Horário
            // 
            this.Horário.AutoSize = true;
            this.Horário.Location = new System.Drawing.Point(55, 140);
            this.Horário.Name = "Horário";
            this.Horário.Size = new System.Drawing.Size(299, 17);
            this.Horário.TabIndex = 5;
            this.Horário.Text = "Horário (Primeiro, Segundo, Terceiro, Quarto)";
            // 
            // textHorario
            // 
            this.textHorario.Location = new System.Drawing.Point(55, 161);
            this.textHorario.Name = "textHorario";
            this.textHorario.Size = new System.Drawing.Size(174, 22);
            this.textHorario.TabIndex = 6;
            // 
            // cadastraDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 389);
            this.Controls.Add(this.textHorario);
            this.Controls.Add(this.Horário);
            this.Controls.Add(this.textPeriodo);
            this.Controls.Add(this.Periodo);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "cadastraDisciplina";
            this.Text = "Cadastrar Disciplina";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.Label Periodo;
        private System.Windows.Forms.TextBox textPeriodo;
        private System.Windows.Forms.Label Horário;
        private System.Windows.Forms.TextBox textHorario;
    }
}