
namespace Sos_Vicios
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.btnOng = new System.Windows.Forms.Button();
            this.lblmenuprincipal = new System.Windows.Forms.Label();
            this.btnadministrador = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOng
            // 
            this.btnOng.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOng.Image = ((System.Drawing.Image)(resources.GetObject("btnOng.Image")));
            this.btnOng.Location = new System.Drawing.Point(51, 113);
            this.btnOng.Name = "btnOng";
            this.btnOng.Size = new System.Drawing.Size(173, 136);
            this.btnOng.TabIndex = 0;
            this.btnOng.Text = "ONGs";
            this.btnOng.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOng.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOng.UseVisualStyleBackColor = true;
            this.btnOng.Click += new System.EventHandler(this.btnOng_Click);
            // 
            // lblmenuprincipal
            // 
            this.lblmenuprincipal.AutoSize = true;
            this.lblmenuprincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmenuprincipal.Location = new System.Drawing.Point(167, 38);
            this.lblmenuprincipal.Name = "lblmenuprincipal";
            this.lblmenuprincipal.Size = new System.Drawing.Size(169, 25);
            this.lblmenuprincipal.TabIndex = 2;
            this.lblmenuprincipal.Text = "Menu Principal";
            // 
            // btnadministrador
            // 
            this.btnadministrador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadministrador.Image = ((System.Drawing.Image)(resources.GetObject("btnadministrador.Image")));
            this.btnadministrador.Location = new System.Drawing.Point(285, 113);
            this.btnadministrador.Name = "btnadministrador";
            this.btnadministrador.Size = new System.Drawing.Size(173, 136);
            this.btnadministrador.TabIndex = 3;
            this.btnadministrador.Text = "Administrador";
            this.btnadministrador.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnadministrador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnadministrador.UseVisualStyleBackColor = true;
            this.btnadministrador.Click += new System.EventHandler(this.btnadministrador_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(285, 309);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(173, 43);
            this.btnSair.TabIndex = 13;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(51, 309);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(173, 43);
            this.btnVoltar.TabIndex = 14;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 389);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnadministrador);
            this.Controls.Add(this.lblmenuprincipal);
            this.Controls.Add(this.btnOng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOng;
        private System.Windows.Forms.Label lblmenuprincipal;
        private System.Windows.Forms.Button btnadministrador;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnVoltar;
    }
}