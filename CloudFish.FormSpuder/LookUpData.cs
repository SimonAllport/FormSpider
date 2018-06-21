using System;
using SourceCode.Hosting.Client.BaseAPI;
using SourceCode.SmartObjects.Client;
using System.Xml;
using System.IO;

namespace CloudFish.FormSpider
{

    public class SmartObjectSMOConnection
    {


        private string _SmartObjectName = "";
        private string _SmartObjectInputParameter = "ControlType";
        private string _SmartObjectMethod = "Read";
        private string _SmartObjectProperty = "RegularExpression";


        public string SmartObjectName
        {
            get
            {
                return _SmartObjectName;
            }

            set
            {
                _SmartObjectName = value;
            }
        }


        public string SmartObjectInputParameter
        {
            get
            {
                return _SmartObjectInputParameter;
            }

            set
            {
                _SmartObjectInputParameter = value;
            }
        }

        public string SmartObjectMethod
        {
            get
            {
                return _SmartObjectMethod;
            }

            set
            {
                _SmartObjectMethod = value;
            }
        }

        public string SmartObjectProperty
        {
            get
            {
                return _SmartObjectProperty;
            }

            set
            {
                _SmartObjectProperty = value;
            }
        }


        public SmartObjectSMOConnection GetSmartObjectDetails()
        {
            SmartObjectSMOConnection smo = new SmartObjectSMOConnection();
            string assemblyFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string xmlFileName = Path.Combine(assemblyFolder, "settings.xml");

            if (File.Exists(xmlFileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFileName);


                smo.
                _SmartObjectName = doc.ChildNodes[1].ChildNodes[2].InnerText;
                _SmartObjectInputParameter = doc.ChildNodes[1].ChildNodes[3].InnerText;
                _SmartObjectMethod = doc.ChildNodes[1].ChildNodes[4].InnerText;
                _SmartObjectProperty = doc.ChildNodes[1].ChildNodes[5].InnerText;

            }
            else
            {
                throw new Exception("Can't find Settings.xml");

            }
            return smo;
        }
    }
        public class LookUpData : Connection
        {




            public string GetRegularExpression(string control)
            {
                SmartObjectSMOConnection smoConnection = new SmartObjectSMOConnection();
                smoConnection.GetSmartObjectDetails();


                string Result = string.Empty;
                SmartObjectClientServer soServer = new SmartObjectClientServer();
                soServer.CreateConnection();
                try
                {
                    soServer.Connection.Open(ConnectToK2());
                    SourceCode.SmartObjects.Client.SmartObject ControlExpressionLibrary = soServer.GetSmartObject(smoConnection.SmartObjectName);
                    ControlExpressionLibrary.Properties[smoConnection.SmartObjectInputParameter].Value = control;
                    ControlExpressionLibrary.MethodToExecute = smoConnection.SmartObjectMethod;
                    soServer.ExecuteScalar(ControlExpressionLibrary);
                    Result = ControlExpressionLibrary.Properties[smoConnection.SmartObjectProperty].Value;
                }
                catch (Exception ex)
                {
                    Result = ex.Message;
                }
                finally
                {

                    soServer.Connection.Close();
                }

                return Result;
            }



        }
    }

