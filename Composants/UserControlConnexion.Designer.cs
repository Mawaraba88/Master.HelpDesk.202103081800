
namespace Composants
{
    partial class UserControlConnexion
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitred = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelPW = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxPW = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelTitred
            // 
            this.labelTitred.AutoSize = true;
            this.labelTitred.Font = new System.Drawing.Font("Montserrat", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitred.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelTitred.Location = new System.Drawing.Point(54, 47);
            this.labelTitred.Name = "labelTitred";
            this.labelTitred.Size = new System.Drawing.Size(332, 54);
            this.labelTitred.TabIndex = 0;
            this.labelTitred.Text = "Se Connecter";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(54, 128);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(69, 17);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "Identifiant";
            // 
            // labelPW
            // 
            this.labelPW.AutoSize = true;
            this.labelPW.Location = new System.Drawing.Point(54, 187);
            this.labelPW.Name = "labelPW";
            this.labelPW.Size = new System.Drawing.Size(93, 17);
            this.labelPW.TabIndex = 0;
            this.labelPW.Text = "Mot de passe";
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(274, 276);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(152, 45);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "Connexion";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Location = new System.Drawing.Point(431, 276);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(152, 45);
            this.buttonAnnuler.TabIndex = 1;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(205, 122);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(378, 22);
            this.textBoxID.TabIndex = 2;
            // 
            // textBoxPW
            // 
            this.textBoxPW.Location = new System.Drawing.Point(205, 187);
            this.textBoxPW.Name = "textBoxPW";
            this.textBoxPW.Size = new System.Drawing.Size(378, 22);
            this.textBoxPW.TabIndex = 2;
            // 
            // UserControlConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxPW);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelPW);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelTitred);
            this.Name = "UserControlConnexion";
            this.Size = new System.Drawing.Size(601, 337);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitred;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelPW;
        public System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.Button buttonAnnuler;
        public System.Windows.Forms.TextBox textBoxID;
        public System.Windows.Forms.TextBox textBoxPW;
    }
}
