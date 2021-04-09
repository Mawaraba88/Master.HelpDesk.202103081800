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
    public partial class FormAccueil : Form
    {
        public FormAccueil()
        {
            InitializeComponent();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(                
                "Version 1.0",
                "Information version",                
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );

        }

        private void listeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListeTicket frm = new FormListeTicket();
            frm.Show();
        }
        /// <summary>
        /// Gestion centralisée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exporterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Gestion centralisée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GestionCentralisee(object sender, EventArgs e)
        {
            // recherche du type 
            string nom = "";
            

            if (sender is ToolStripMenuItem)
                nom = ((ToolStripMenuItem)sender).Name;

            //todo : idem pour boutons, etc 

            // action selon composant
            switch (nom)  // sw
            {
                case "utilisateursToolStripMenuItem":
                    FormUtilisateurs fu = new FormUtilisateurs();
                    fu.Show();

                    break;
                case "exporterToolStripMenuItem":
                    //    MessageBox.Show("Exporter"); // mb

                    FormExporter formExporter = new FormExporter();
                    formExporter.Show();

                    break; 

                default:
                    break;
            }


        }

        private void timerDateHeure_Tick(object sender, EventArgs e)
        {
            // affichage de la date/heure
            toolStripStatusLabelDateHeure.Text = 
                DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        }
        /// <summary>
        /// Gestion des utilisateurs. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void utilisateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUtilisateurs fu = new FormUtilisateurs();
            fu.Show();
        }
    }
}
