using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master.Helpdesk.Win
{
    public partial class FormUtilisateurs : Form
    {
        public FormUtilisateurs()
        {
            InitializeComponent();
        }

        private void utilisateurBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.utilisateurBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.helpDeskDataSet);

        }

        private void FormUtilisateurs_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'helpDeskDataSet.Utilisateur'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.utilisateurTableAdapter.Fill(this.helpDeskDataSet.Utilisateur);

        }
    }
}
