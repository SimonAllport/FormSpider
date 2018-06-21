using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.Forms;
using SourceCode.Workflow.Client;
using SourceCode.Hosting.Client.BaseAPI;
using SourceCode.Forms.Management;
using SourceCode.Forms.Deployment;
using SourceCode.Forms;
using SourceCode.Forms.Authoring;
using SourceCode.SmartObjects.Management;

namespace CloudFish.FormSpider
{
    public class SmartObjects:Connection
    {




        private static SmartObject SmartObjectBuilder(SmartObjectInfo smartobject)
        {
            SmartObject smo = new SmartObject();
            smo.Description = smartobject.Metadata.Description.ToString();
            smo.Name = smartobject.Name;
            smo.guid = smartobject.Guid;
            smo.ArtefactType = "SmartObject";
            smo.displayname = smartobject.Metadata.DisplayName;
            smo.Version = smartobject.Version.ToString();
            smo.Service = smartobject.ServiceObjectName;
            smo.ServiceGUID = smartobject.ServiceInstanceGuid;

            return smo;
        }



        public static List<SmartObject> SmartObjectExplorer()
        {
            List<SmartObject> list = new List<SmartObject>();

            SmartObjectManagementServer smomgt = new SmartObjectManagementServer();
            smomgt.CreateConnection();
            try
            {
                smomgt.Connection.Open(ConnectToK2());
               
                SourceCode.SmartObjects.Management.SmartObjectExplorer smartobjects = smomgt.GetSmartObjects();
                
                foreach (SourceCode.SmartObjects.Management.SmartObjectInfo info in smartobjects.SmartObjectList)
                {

                    list.Add(SmartObjectBuilder(info));

                }

            }
            catch (Exception ex)
            {
                list.Add(new SmartObject
                {

                    Description = ex.Message,
                    Name = ex.Source,
                    ArtefactType = "SmartObject Error"


                });
            }
            finally
            {
                smomgt.Connection.Close();
            }
            return list;
        }

        public static List<SmartObjectProperty> SmartObjectPropertiesExplorer(Guid SmartObjectGUID)
        {
            List<SmartObjectProperty> list = new List<SmartObjectProperty>();
            SmartObjectManagementServer smomgt = new SmartObjectManagementServer();
            smomgt.CreateConnection();
            try
            {
                smomgt.Connection.Open(ConnectToK2());

                Properties prop = new Properties();

               list = prop.GetSmartObjectProperties(smomgt.GetSmartObjectInfo(smomgt.GetSmartObjectDefinition(SmartObjectGUID).ToString()).Properties);
               
            }
            catch (Exception ex)
            {
                list.Add(new SmartObjectProperty
                {

                    Description = ex.Message,
                    Name = ex.Source,
                    displayname = "SmartObject Property Error"


                });
            }
            finally
            {
                smomgt.Connection.Close();
            }
            return list;
        }

        public static List<SmartObjectProperty> SmartObjectMethodsExplorer(Guid SmartObjectGUID)
        {
            List<SmartObjectProperty> list = new List<SmartObjectProperty>();

            SmartObjectManagementServer smomgt = new SmartObjectManagementServer();
            smomgt.CreateConnection();
            try
            {
                smomgt.Connection.Open(ConnectToK2());
                Properties prop  = new Properties();

                list =  prop.GetSmartObjectMethods(smomgt.GetSmartObjectInfo(smomgt.GetSmartObjectDefinition(SmartObjectGUID).ToString()).Methods);
               

            }
            catch (Exception ex)
            {
                list.Add(new SmartObjectProperty
                {

                    Description = ex.Message,
                    Name = ex.Source,
                    displayname = "SmartObject Property Error"


                });
            }
            finally
            {
                smomgt.Connection.Close();
            }
            return list;
        }

   
       
    }


}
