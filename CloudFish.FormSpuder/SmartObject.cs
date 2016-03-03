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

namespace CloudFish.FormSpider
{
    public class SmartObjects
    {
        public static List<SmartObject> SmartObjectExplorer()
        {
            List<SmartObject> list = new List<SmartObject>();

            SCConnectionStringBuilder hostServerConnectionString = new SCConnectionStringBuilder();
            hostServerConnectionString.Host = "dlx";
            hostServerConnectionString.Port = 5555;
            hostServerConnectionString.IsPrimaryLogin = true;
            hostServerConnectionString.Integrated = true;
            SourceCode.SmartObjects.Management.SmartObjectManagementServer smomgt = new SourceCode.SmartObjects.Management.SmartObjectManagementServer();
            smomgt.CreateConnection();
            try
            {
                smomgt.Connection.Open(hostServerConnectionString.ConnectionString.ToString());

                SourceCode.SmartObjects.Management.SmartObjectExplorer smartobjects = smomgt.GetSmartObjects();

                foreach (SourceCode.SmartObjects.Management.SmartObjectInfo info in smartobjects.SmartObjectList)
                {

                    list.Add(new SmartObject
                    {

                        Description = info.Metadata.Description.ToString(),
                        Name = info.Name,
                        guid = info.Guid,
                        ArtefactType = "SmartObject",
                        displayname = info.Metadata.DisplayName,
                       
                        Version = info.Version.ToString(),
                       Service =  info.ServiceObjectName,
                       ServiceGUID =  info.ServiceInstanceGuid
                      


                    });

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

            SCConnectionStringBuilder hostServerConnectionString = new SCConnectionStringBuilder();
            hostServerConnectionString.Host = "dlx";
            hostServerConnectionString.Port = 5555;
            hostServerConnectionString.IsPrimaryLogin = true;
            hostServerConnectionString.Integrated = true;
            SourceCode.SmartObjects.Management.SmartObjectManagementServer smomgt = new SourceCode.SmartObjects.Management.SmartObjectManagementServer();
            smomgt.CreateConnection();
            try
            {
                smomgt.Connection.Open(hostServerConnectionString.ConnectionString.ToString());
               
        
              
                foreach (SourceCode.SmartObjects.Management.SmartPropertyInfo info in smomgt.GetSmartObjectInfo(smomgt.GetSmartObjectDefinition(SmartObjectGUID).ToString()).Properties)
                {

                    list.Add(new SmartObjectProperty
                    {

                        Description = info.Metadata.Description.ToString(),
                        Name = info.Name,
                        Type = info.Type.ToString(),
                        isUnique =  info.IsUnique,
                        displayname = info.Metadata.DisplayName
                      });

                }

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

            SCConnectionStringBuilder hostServerConnectionString = new SCConnectionStringBuilder();
            hostServerConnectionString.Host = "dlx";
            hostServerConnectionString.Port = 5555;
            hostServerConnectionString.IsPrimaryLogin = true;
            hostServerConnectionString.Integrated = true;
            SourceCode.SmartObjects.Management.SmartObjectManagementServer smomgt = new SourceCode.SmartObjects.Management.SmartObjectManagementServer();
            smomgt.CreateConnection();
            try
            {
                smomgt.Connection.Open(hostServerConnectionString.ConnectionString.ToString());



                foreach (SourceCode.SmartObjects.Management.SmartMethodInfo info in smomgt.GetSmartObjectInfo(smomgt.GetSmartObjectDefinition(SmartObjectGUID).ToString()).Methods)
                {

                    list.Add(new SmartObjectProperty
                    {
                        
                        Description = info.Metadata.Description.ToString(),
                        Name = info.Name,
                        Type = info.Type.ToString(),
                        Transaction = info.Transaction.ToString(),
                        displayname = info.Metadata.DisplayName
                    });

                }

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

   public class Workflow
    {
        public static List<WorkFlow> WorkflowExplorer()
        {
            List<WorkFlow> list = new List<WorkFlow>();
            SourceCode.Workflow.Management.WorkflowManagementServer wrkmgt = new SourceCode.Workflow.Management.WorkflowManagementServer("dlx", 5555);
            try
            {
                wrkmgt.Open();
                SourceCode.Workflow.Management.Criteria.ProcessCriteriaFilter cf = new SourceCode.Workflow.Management.Criteria.ProcessCriteriaFilter();

                SourceCode.Workflow.Management.Processes processes = wrkmgt.GetProcesses(cf);

               

                foreach (SourceCode.Workflow.Management.Process process in processes)
                {
                    if (process.DefaultVersion == true)
                    {
                        list.Add(new WorkFlow
                        {
                            Description = process.VersionDesc,
                            Name = process.FullName,
                            guid = process.ProcGuid,
                            displayname = process.FullName,
                            Instances = process.Instances.Count,
                            Version = process.VersionNumber.ToString(),
                            ProcessId = process.ProcID,
                            MetaData = process.MetaData,
                            Priority = process.Priority,
                            ProcSetID = process.ProcSetID
                            
                        });
                    }

                }

            }
            catch (Exception ex)
            {
                list.Add(new WorkFlow
                {

                    Description = ex.Message,
                    Name = ex.Source,
                    MetaData = "Workflow Error"


                });
            }
            finally
            {

                wrkmgt.Connection.Close();
            }
            return list;
        }

        public static List<WorkFlowDataFields> WorkflowDataFieldsExplorer(int ProcessId)
        {
            List<WorkFlowDataFields> list = new List<WorkFlowDataFields>();
            SourceCode.Workflow.Management.WorkflowManagementServer wrkmgt = new SourceCode.Workflow.Management.WorkflowManagementServer("dlx", 5555);
            try
            {
                wrkmgt.Open();
               

                foreach (SourceCode.Workflow.Management.ProcessDataField df in  wrkmgt.GetProcessDataFields(ProcessId))
                {
                   
                        list.Add(new WorkFlowDataFields
                        {
                           Audit =  df.Audit,
                          Category =   df.Category,
                          Hidden =  df.Hidden,
                          InitialValue =  df.InitialValue.ToString(),
                          MetaData = df.MetaData,
                          Name =  df.Name,
                         OnDemand =   df.OnDemand,
                           Type = df.Type.ToString()

                        });
                    }

                

            }
            catch (Exception ex)
            {
                list.Add(new WorkFlowDataFields
                {

                    MetaData = ex.Message,
                    Name = ex.Source,
                    Category = "Workflow DataField Error"


                });
            }
            finally
            {

                wrkmgt.Connection.Close();
            }
            return list;
        }

        public static List<WorkFlowDataFields> WorkflowXMLDataFieldsExplorer(int ProcessId)
        {
            List<WorkFlowDataFields> list = new List<WorkFlowDataFields>();
            SourceCode.Workflow.Management.WorkflowManagementServer wrkmgt = new SourceCode.Workflow.Management.WorkflowManagementServer("dlx", 5555);
            try
            {
                wrkmgt.Open();
                SourceCode.Workflow.Management.Criteria.ProcessCriteriaFilter cf = new SourceCode.Workflow.Management.Criteria.ProcessCriteriaFilter();

             

                foreach (SourceCode.Workflow.Management.ProcessXMLField df in wrkmgt.GetProcessXMLFields(ProcessId))
                {

                    list.Add(new WorkFlowDataFields
                    {
                        Audit = df.Audit,
                        Category = df.Category,
                        Hidden = df.Hidden,
                        InitialValue = df.InitialValue.ToString(),
                        MetaData = df.MetaData,
                        Name = df.Name,
                        OnDemand = df.OnDemand,
                        Type = df.Type.ToString()

                    });
                }



            }
            catch (Exception ex)
            {
                list.Add(new WorkFlowDataFields
                {

                    MetaData = ex.Message,
                    Name = ex.Source,
                    Category = "Workflow XML Datafield Error"


                });
            }
            finally
            {

                wrkmgt.Connection.Close();
            }
            return list;
        }

        public static List<WorkFlowActivities> WorkflowActivitiesExplorer(int ProcessId)
        {
            List<WorkFlowActivities> list = new List<WorkFlowActivities>();
            SourceCode.Workflow.Management.WorkflowManagementServer wrkmgt = new SourceCode.Workflow.Management.WorkflowManagementServer("dlx", 5555);
            try
            {
                wrkmgt.Open();
            

                foreach (SourceCode.Workflow.Management.Activity act in wrkmgt.GetProcActivities(ProcessId))
                {

                    list.Add(new WorkFlowActivities
                    {
                      Description =  act.Description,
                      ExpectedDuration =  act.ExpectedDuration,
                       ID = act.ID,
                      IsStart =  act.IsStart,
                       MetaData = act.MetaData,
                       Name = act.Name,
                       Priority = act.Priority

                    });
                }



            }
            catch (Exception ex)
            {
                list.Add(new WorkFlowActivities
                {

                    MetaData = ex.Message,
                    Name = ex.Source,
                    Description = "Workflow Activity Error"


                });
            }
            finally
            {

                wrkmgt.Connection.Close();
            }
            return list;
        }

        public static List<WorkFlowEvents> WorkflowEventsExplorer(int ActivityId)
        {
            List<WorkFlowEvents> list = new List<WorkFlowEvents>();
            SourceCode.Workflow.Management.WorkflowManagementServer wrkmgt = new SourceCode.Workflow.Management.WorkflowManagementServer("dlx", 5555);
            try
            {
                wrkmgt.Open();


                foreach (SourceCode.Workflow.Management.Event act in wrkmgt.GetActivityEvents(ActivityId))
                {

                    list.Add(new WorkFlowEvents
                    {
                       UseTrans = act.UseTrans,
                       Pos = act.Pos,
                       Excep = act.Excep,
                       EventType = act.EventType.ToString(),
                        CredentialUser = act.CredentialUser,
                       Code = act.Code,
                         Description = act.Description,
                        ExpectedDuration = act.ExpectedDuration,
                        ID = act.ID,
                         MetaData = act.MetaData,
                        Name = act.Name,
                        Priority = act.Priority

                    });
                }



            }
            catch (Exception ex)
            {
                list.Add(new WorkFlowEvents
                {

                    MetaData = ex.Message,
                    Name = ex.Source,
                    Description = "Workflow Activity Error"


                });
            }
            finally
            {

                wrkmgt.Connection.Close();
            }
            return list;
        }


     


    }
}
