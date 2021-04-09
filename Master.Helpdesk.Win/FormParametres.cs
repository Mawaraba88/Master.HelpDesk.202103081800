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
    public partial class FormParametres : Form
    {
        public FormParametres()
        {
            InitializeComponent();
        }

        private void FormParametres_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'helpDeskDataSet.Utilisateur'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.utilisateurTableAdapter.Fill(this.helpDeskDataSet.Utilisateur);

        }

        private void comboBoxAdministrateurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO 
        }
    }
}
