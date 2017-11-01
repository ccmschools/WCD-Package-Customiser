using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;

namespace WCD_Package_Customiser
{

    public partial class frm_Main : Form
    {

        // Initializer for the form
        public frm_Main()
        {
            InitializeComponent();
        }

        // Ensures appropriate directories and files exist for use by this app
        private void Initialize()
        {

            // Holds application installers and scripts
            Custom.DirectoryInitialize("Applications");

            // Application lists used by this program to tell the packager what to install
            Custom.DirectoryInitialize("ApplicationLists");

            // Ensure a default application list exists, else generate one
            if (!File.Exists("ApplicationLists\\Default.xml"))
            {
                Custom.CreateApplicationList("Default");
            }

        }

        // Upon loading the form, get the list of apps and display them
        private void frmMain_Load(object sender, EventArgs e)
        {

            // initialize the app, ensure there's a default application list
            Initialize();

            // Populate application lists and place them in the combo box
            PopulateComboBox(Custom.GetApplicationLists());

            // Set the combo box to default, by default
            cbx_ApplicationLists.Text = "Default";

            // Load the applications into the combo list box for default
            LoadApplications("Default");

        }

        // On clicking apply, get all the checked items and save their name and install script info to the machine for the packager (clear any previous info too)
        private void btn_Apply_Click(object sender, EventArgs e)
        {

            // Will hold a list of hashes related to applications
            List<Hashtable> applications = new List<Hashtable>();

            // Go through all combo list box items (applications)
            foreach (Object item in clb_Applications.Items)
            {

                // Get the app name and it's checked state
                string name = item.ToString();
                CheckState status = clb_Applications.GetItemCheckState(clb_Applications.Items.IndexOf(item));

                // Save apps to the list that are checked
                if (status.Equals(CheckState.Checked))
                {
                    Hashtable application = new Hashtable();
                    application.Add("Name", name);
                    application.Add("Selected", status.Equals(CheckState.Checked));
                    applications.Add(application);
                }

            }

            // Write the list to the machines file system for use by the packager
            Custom.ApplyApplications(applications);
            
            // Show a status message in the GUI to provide feedback to the user on action taken
            lbl_Status.Text = $"Application List applied: {cbx_ApplicationLists.Text}";

        }

        // When the new button is clicked, ask for a new application list name and create it
        private void btn_New_Click(object sender, EventArgs e)
        {

            // Ask for a name for the new application list
            string application_list = Microsoft.VisualBasic.Interaction.InputBox("Please input the name of the new application list.", "New Application List");

            // Create it (return if the action was successful or not)
            bool application_list_was_created = Custom.CreateApplicationList(application_list);

            // If successful
            if (application_list_was_created)
            {
                // Update the combobox (including the newly created list)
                PopulateComboBox(Custom.GetApplicationLists());

                // Set the combobox to the text of this new list
                cbx_ApplicationLists.Text = application_list;

                // Load the new app lists apps into the combolistbox
                LoadApplications(application_list);

                // Provide feedback to the user that all the above happened
                lbl_Status.Text = $"Application List created: {application_list}";
            }

        }

        // When the save button is clicked
        private void btn_Save_Click(object sender, EventArgs e)
        {

            // Will hold a list of apps as hashtable objects
            List<Hashtable> applications = new List<Hashtable>();

            // Go through applications in the combolistbox
            foreach (Object item in clb_Applications.Items)
            {

                // Get app name and checked status
                string name = item.ToString();
                CheckState status = clb_Applications.GetItemCheckState(clb_Applications.Items.IndexOf(item));

                // Record the above in a hashtable
                Hashtable application = new Hashtable();
                application.Add("Name", name);
                application.Add("Selected", status.Equals(CheckState.Checked));
                applications.Add(application);

            }

            // Write the list of hashes / apps into the application list xml file on disk
            Custom.UpdateApplicationList(cbx_ApplicationLists.SelectedItem.ToString(), applications);

            // Provide feedback to the user
            lbl_Status.Text = $"Application List updated: {cbx_ApplicationLists.Text}";
        }

        // When the combobox is changed to a new application list
        private void cbx_ApplicationLists_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Clear the list of applications in the combolistbox
            clb_Applications.Items.Clear();

            // Load the applications for the newly selected list
            LoadApplications(cbx_ApplicationLists.SelectedItem.ToString());
        }

        // Simply add a list of strings to a combobox
        public void PopulateComboBox(List<string> application_lists)
        {
            foreach (string application_list in application_lists)
            {
                cbx_ApplicationLists.Items.Add(application_list);
            }
        }

        // Load a list of strings into a combolistbox
        public void LoadApplications(string application_list)
        {

            List<Hashtable> applications = Custom.GetApplications(application_list);

            clb_Applications.Items.Clear();

            foreach (Hashtable application in applications)
            {
                clb_Applications.Items.Add(application["Name"].ToString(), Convert.ToBoolean(application["Selected"].ToString()));
            }

        }

    }
}