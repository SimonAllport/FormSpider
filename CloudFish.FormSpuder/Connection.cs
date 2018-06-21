using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.Forms.Management;
using System.Xml;
using System.IO;
using SourceCode.Hosting.Client.BaseAPI;

namespace CloudFish.FormSpider
{



    public class Connection
    {
        public string Server
        {
            get { return _Server; }
            set { _Server = value; }
        }

        public uint Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        private static string _Server = "localhost";
        private static uint _Port = 5555;


        /// <summary>
        /// Gets the server details from the settings file
        /// </summary>
        private static void GetDetails()
        {
            //Gets the settings file 
            string assemblyFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string xmlFileName = Path.Combine(assemblyFolder, "settings.xml");

            if (File.Exists(xmlFileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFileName);



                _Server = doc.ChildNodes[1].ChildNodes[0].InnerText;
                _Port = uint.Parse(doc.ChildNodes[1].ChildNodes[1].InnerText);


            }
            else
            {
                throw new Exception("Can't find Settings.xml");
            }
        }

        /// <summary>
        /// Builds the connection string
        /// </summary>
        /// <returns></returns>
       public static string ConnectToK2()
                {
                    GetDetails();

                    SCConnectionStringBuilder connectionstring = new SCConnectionStringBuilder();
                    connectionstring.Host = _Server;
                    connectionstring.Port = _Port;
                    connectionstring.IsPrimaryLogin = true;
                    connectionstring.Integrated = true;


                    return connectionstring.ToString();

                }
        }

    }

