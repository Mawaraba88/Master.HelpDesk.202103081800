
namespace Master.Helpdesk.Win
{
    partial class FormParametres
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
            this.components = new System.ComponentModel.Container();
            this.labelNiveau = new System.Windows.Forms.Label();
            this.textBoxNiveau = new System.Windows.Forms.TextBox();
            this.comboBoxAdministrateurs = new System.Windows.Forms.ComboBox();
            this.labelAdministrateurs = new System.Windows.Forms.Label();
            this.helpDeskDataSet = new Master.Helpdesk.Win.HelpDeskDataSet();
            this.helpDeskDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.utilisateurBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.utilisateurTableAdapter = new Master.Helpdesk.Win.HelpDeskDataSetTableAdapters.UtilisateurTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.helpDeskDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpDeskDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilisateurBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNiveau
            // 
            this.labelNiveau.AutoSize = true;
            this.labelNiveau.Location = new System.Drawing.Point(95, 81);
            this.labelNiveau.Name = "labelNiveau";
            this.labelNiveau.Size = new System.Drawing.Size(52, 17);
            this.labelNiveau.TabIndex = 0;
            this.labelNiveau.Text = "Niveau";
            // 
            // textBoxNiveau
            // 
            this.textBoxNiveau.AutoCompleteCustomSource.AddRange(new string[] {
            "Visiteur",
            "Utilisateur",
            "Assistant",
            "Administrateur "});
            this.textBoxNiveau.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxNiveau.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxNiveau.Location = new System.Drawing.Point(280, 75);
            this.textBoxNiveau.Name = "textBoxNiveau";
            this.textBoxNiveau.Size = new System.Drawing.Size(320, 22);
            this.textBoxNiveau.TabIndex = 1;
            // 
            // comboBoxAdministrateurs
            // 
            this.comboBoxAdministrateurs.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.utilisateurBindingSource, "Nom", true));
            this.comboBoxAdministrateurs.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.utilisateurBindingSource, "UtilisateurID", true));
            this.comboBoxAdministrateurs.DataSource = this.utilisateurBindingSource;
            this.comboBoxAdministrateurs.FormattingEnabled = true;
            this.comboBoxAdministrateurs.Location = new System.Drawing.Point(280, 154);
            this.comboBoxAdministrateurs.Name = "comboBoxAdministrateurs";
            this.comboBoxAdministrateurs.Size = new System.Drawing.Size(320, 24);
            this.comboBoxAdministrateurs.TabIndex = 2;
            this.comboBoxAdministrateurs.Text = "System.Data.DataViewManagerListItemTypeDescriptor";
            this.comboBoxAdministrateurs.SelectedIndexChanged += new System.EventHandler(this.comboBoxAdministrateurs_SelectedIndexChanged);
            // 
            // labelAdministrateurs
            // 
            this.labelAdministrateurs.AutoSize = true;
            this.labelAdministrateurs.Location = new System.Drawing.Point(98, 160);
            this.labelAdministrateurs.Name = "labelAdministrateurs";
            this.labelAdministrateurs.Size = new System.Drawing.Size(106, 17);
            this.labelAdministrateurs.TabIndex = 3;
            this.labelAdministrateurs.Text = "Administrateurs";
            // 
            // helpDeskDataSet
            // 
            this.helpDeskDataSet.DataSetName = "HelpDeskDataSet";
            this.helpDeskDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // helpDeskDataSetBindingSource
            // 
            this.helpDeskDataSetBindingSource.DataSource = this.helpDeskDataSet;
            this.helpDeskDataSetBindingSource.Position = 0;
            // 
            // utilisateurBindingSource
            // 
            this.utilisateurBindingSource.DataMember = "Utilisateur";
            this.utilisateurBindingSource.DataSource = this.helpDeskDataSet;
            // 
            // utilisateurTableAdapter
            // 
            this.utilisateurTableAdapter.ClearBeforeFill = true;
            // 
            // FormParametres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 525);
            this.Controls.Add(this.labelAdministrateurs);
            this.Controls.Add(this.comboBoxAdministrateurs);
            this.Controls.Add(this.textBoxNiveau);
            this.Controls.Add(this.labelNiveau);
            this.Name = "FormParametres";
            this.Text = "Paramètres";
            this.Load += new System.EventHandler(this.FormParametres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.helpDeskDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.helpDeskDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilisateurBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNiveau;
        private System.Windows.Forms.TextBox textBoxNiveau;
        private System.Windows.Forms.ComboBox comboBoxAdministrateurs;
        private System.Windows.Forms.BindingSource helpDeskDataSetBindingSource;
        private HelpDeskDataSet helpDeskDataSet;
        private System.Windows.Forms.Label labelAdministrateurs;
        private System.Windows.Forms.BindingSource utilisateurBindingSource;
        private HelpDeskDataSetTableAdapters.UtilisateurTableAdapter utilisateurTableAdapter;
    }
}