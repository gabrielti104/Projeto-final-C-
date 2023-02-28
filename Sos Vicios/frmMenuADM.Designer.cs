
namespace Sos_Vicios
{
    partial class frmMenuADM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuADM));
            this.lblmenuprincipal = new System.Windows.Forms.Label();
            this.btncadastrausuario = new System.Windows.Forms.Button();
            this.btncadastrafuncionario = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblmenuprincipal
            // 
            this.lblmenuprincipal.AutoSize = true;
            this.lblmenuprincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmenuprincipal.Location = new System.Drawing.Point(84, 35);
            this.lblmenuprincipal.Name = "lblmenuprincipal";
            this.lblmenuprincipal.Size = new System.Drawing.Size(175, 25);
            this.lblmenuprincipal.TabIndex = 3;
            this.lblmenuprincipal.Text = "Menu do Admin";
            // 
            // btncadastrausuario
            // 
            this.btncadastrausuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncadastrausuario.Location = new System.Drawing.Point(200, 95);
            this.btncadastrausuario.Name = "btncadastrausuario";
            this.btncadastrausuario.Size = new System.Drawing.Size(122, 101);
            this.btncadastrausuario.TabIndex = 5;
            this.btncadastrausuario.Text = "Cadastra Usuário";
            this.btncadastrausuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btncadastrausuario.UseVisualStyleBackColor = true;
            this.btncadastrausuario.Click += new System.EventHandler(this.btncadastrausuario_Click);
            // 
            // btncadastrafuncionario
            // 
            this.btncadastrafuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncadastrafuncionario.Location = new System.Drawing.Point(24, 95);
            this.btncadastrafuncionario.Name = "btncadastrafuncionario";
            this.btncadastrafuncionario.Size = new System.Drawing.Size(122, 101);
            this.btncadastrafuncionario.TabIndex = 4;
            this.btncadastrafuncionario.Text = "Cadastra Funcionário";
            this.btncadastrafuncionario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btncadastrafuncionario.UseVisualStyleBackColor = true;
            this.btncadastrafuncionario.Click += new System.EventHandler(this.btncadastrafuncionario_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(89, 211);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(173, 43);
            this.btnVoltar.TabIndex = 15;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // frmMenuADM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 266);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btncadastrausuario);
            this.Controls.Add(this.btncadastrafuncionario);
            this.Controls.Add(this.lblmenuprincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMenuADM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu ADM";
            this.Load += new System.EventHandler(this.frmMenuADM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblmenuprincipal;
        private System.Windows.Forms.Button btncadastrausuario;
        private System.Windows.Forms.Button btncadastrafuncionario;
        private System.Windows.Forms.Button btnVoltar;
    }
}