using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml;
using System.IO;

namespace WCD_Package_Customiser
{

    // Contains custom static methods for use within this application. Only a few custom methods aren't in this class (that require interaction with the form - part of the frm_Main.cs file)
    class Custom
    {
        
        // Creates a file if it doesn't exist
        public static void FileInitialize(string file)
        {
            // Create the file if it doesn't exist
            if (!File.Exists(file))
            {
                FileStream filestream = File.Create(file);
                filestream.Close();
            }
        }

        // Creates a directory if it doesn't exist
        public static void DirectoryInitialize(string directory)
        {
            // Create the dir if it doesn't exist
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        // Builds the Xml used with application lists
        public static XmlDocument BuildApplicationListXml(List<Hashtable> applications)
        {

            // Build the Xml data for the packager
            XmlDocument xml = new XmlDocument();
            XmlElement parent_element = (XmlElement)xml.AppendChild(xml.CreateElement("Applications"));

            foreach (Hashtable application in applications)
            {
                XmlElement child_element = (XmlElement)parent_element.AppendChild(xml.CreateElement("Application"));
                child_element.SetAttribute("name", application["Name"].ToString());
                child_element.SetAttribute("selected", application["Selected"].ToString());
            }

            return xml;
        }

        // Gets the list of applications defined by the package developer for this application (the applications.xml file located with this programs executable)
        public static List<Hashtable> GetApplications(string application_list)
        {

            // Applications will be stored as hashtable items in a list
            List<Hashtable> applications = new List<Hashtable>();

            try
            {
                // Read the xml file
                string xml = File.ReadAllText($"ApplicationLists\\{application_list}.xml");
                XmlReader reader = XmlReader.Create(new StringReader(xml));

                // Iterate through the applications and create the hashtable list items
                reader.ReadToFollowing("Applications");
                if (reader.ReadToDescendant("Application"))
                {
                    do
                    {
                        Hashtable application = new Hashtable();

                        application.Add("Name", reader.GetAttribute("name"));
                        application.Add("Selected", reader.GetAttribute("selected"));
                        application.Add("Script", reader.GetAttribute("script"));

                        applications.Add(application);

                    } while (reader.ReadToNextSibling("Application"));
                }
            }
            catch
            {
                Microsoft.VisualBasic.Interaction.MsgBox("Error loading the application list. Please delete it from the file system and then recreate it in this app");
            }

            // return the hashtable list of applications
            return applications;
        }

        // Returns a list of application lists from the file system
        public static List<string> GetApplicationLists()
        {
            List<string> application_lists = new List<string>();

            try
            {

                string[] files = Directory.GetFiles("ApplicationLists");

                foreach (string file in files)
                {

                    string file_name = file.Substring("ApplicationLists\\".Length);

                    if (file_name.IndexOf(".xml") != -1)
                    {
                        file_name = file_name.Substring(0, file_name.IndexOf(".xml"));
                        application_lists.Add(file_name);
                    }

                }
            } catch { }

            return application_lists;

        }

        // Creates a new application list
        public static bool CreateApplicationList(string application_list)
        {

            List<Hashtable> applications = new List<Hashtable>();
            bool application_list_was_created = false;

            try
            {

                string[] application_strings = Directory.GetDirectories("Applications");

                foreach (string application in application_strings)
                {
                    string application_name = application.Substring("Applications\\".Length);

                    Hashtable application_hash = new Hashtable();
                    application_hash.Add("Name", application_name);
                    application_hash.Add("Selected", "false");
                    applications.Add(application_hash);
                }

                XmlDocument xml = BuildApplicationListXml(applications);

                File.WriteAllText($"ApplicationLists\\{application_list}.xml", xml.OuterXml);

                Custom.DirectoryInitialize($"Customisations\\Scripts\\{application_list}");

                application_list_was_created = true;

            }
            catch { application_list_was_created = false; }

            return application_list_was_created;

        }

        // Updates the content of an existing application list
        public static void UpdateApplicationList(string application_list, List<Hashtable> applications)
        {
            XmlDocument xml = BuildApplicationListXml(applications);
            File.WriteAllText($"ApplicationLists\\{application_list}.xml", xml.OuterXml);
        }

        // Save the list of checked applications and their install script names on the machine ready for packaging
        public static void ApplyApplications(List<Hashtable> applications)
        {

            // Define the directories and file paths here
            string program_data = System.Environment.GetEnvironmentVariable("ProgramData");
            // string app_path = $"{program_data}\\WCD\\Config";
            // string app_file = $"{app_path}\\applications.xml";
            // string app_path = $"{program_data}\\WCD\\Config";
            string app_file = $".\\applications.xml";

            try
            {
                // Custom.DirectoryInitialize(app_path);
                Custom.FileInitialize(app_file);

                XmlDocument xml = BuildApplicationListXml(applications);

                // Save the Xml data above to the appropriate file / dir
                File.WriteAllText(app_file, xml.OuterXml);
            }
            catch
            {
                Microsoft.VisualBasic.Interaction.MsgBox("There was an error applying the settings. Please try again.");
            }

        }

    }
}