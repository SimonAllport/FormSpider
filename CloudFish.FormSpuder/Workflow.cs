using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.Workflow.Client;
using SourceCode.Hosting.Client.BaseAPI;

namespace CloudFish.FormSpider
{
    public class Workflow : Connection
    {
        private static Process BuildWorkflow(SourceCode.Workflow.Management.Process process)
        {

            Validation validation = new Validation();

            Process workflow = new Process();
            workflow.Description = process.VersionDesc;
            workflow.Name = process.FullName;
            workflow.guid = process.ProcGuid;
            workflow.displayname = process.FullName;
            workflow.Instances = process.Instances.Count;
            workflow.Version = process.VersionNumber.ToString();
            workflow.ProcessId = process.ProcID;
            workflow.MetaData = process.MetaData;
            workflow.Priority = process.Priority;
            workflow.ProcSetID = process.ProcSetID;
            workflow.Result = validation.ValidateControl("Workflow", process.FullName);

            return workflow;
        }


        private static ProcessDataFields DataFields(SourceCode.Workflow.Management.ProcessDataField df)
        {
            ProcessDataFields datafields = new ProcessDataFields();
            datafields.Audit = df.Audit;
            datafields.Category = df.Category;
            datafields.Hidden = df.Hidden;
            datafields.InitialValue = df.InitialValue.ToString();
            datafields.MetaData = df.MetaData;
            datafields.Name = df.Name;
            datafields.OnDemand = df.OnDemand;
            datafields.Type = df.Type.ToString();

            return datafields;
        }

        private static ProcessDataFields DataFields(SourceCode.Workflow.Management.ProcessXMLField df)
        {
            ProcessDataFields datafields = new ProcessDataFields();
            datafields.Audit = df.Audit;
            datafields.Category = df.Category;
            datafields.Hidden = df.Hidden;
            datafields.InitialValue = df.InitialValue.ToString();
            datafields.MetaData = df.MetaData;
            datafields.Name = df.Name;
            datafields.OnDemand = df.OnDemand;
            datafields.Type = df.Type.ToString();

            return datafields;
        }
        /// <summary>
        /// Gets the details of particular workflow
        /// </summary>
        /// <param name="ProcessId"></param>
        /// <returns></returns>
        public static Process GetWorkflow(int ProcessId)
       {

           Process wkf = new Process();
          SourceCode.Workflow.Management.WorkflowManagementServer wrkmgt = new SourceCode.Workflow.Management.WorkflowManagementServer();
            wrkmgt.Connection.Open(ConnectToK2());
            try
            {
                wrkmgt.Open();


                wkf = BuildWorkflow(wrkmgt.GetProcess(ProcessId));


            

            }
            catch (Exception ex)
            {
                
                             wkf.Description = ex.Message;
                             wkf.Name = ex.Source;
                             wkf.MetaData = "Workflow Error";


              
            }
            finally
            {

                wrkmgt.Connection.Close();
            }
            return wkf;
       }

        /// <summary>
        /// Returns a list of all the workflows on the environment
        /// </summary>
        /// <returns></returns>
        public static List<Process> WorkflowExplorer()
        {
            List<Process> list = new List<Process>();
            SourceCode.Workflow.Management.WorkflowManagementServer wrkmgt = new SourceCode.Workflow.Management.WorkflowManagementServer();
            wrkmgt.Connection.Open(ConnectToK2());
            try
            {
                wrkmgt.Open();
                SourceCode.Workflow.Management.Criteria.ProcessCriteriaFilter cf = new SourceCode.Workflow.Management.Criteria.ProcessCriteriaFilter();

                SourceCode.Workflow.Management.Processes processes = wrkmgt.GetProcesses(cf);


                foreach (SourceCode.Workflow.Management.Process process in processes)
                {
                    if (process.DefaultVersion == true)
                    {
                        list.Add(BuildWorkflow(process));
                    }

                }

            }
            catch (Exception ex)
            {
                list.Add(new Process
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

        public static List<ProcessDataFields> WorkflowDataFieldsExplorer(int ProcessId)
        {
            List<ProcessDataFields> list = new List<ProcessDataFields>();
               SourceCode.Workflow.Management.WorkflowManagementServer wrkmgt = new SourceCode.Workflow.Management.WorkflowManagementServer();
               wrkmgt.Connection.Open(ConnectToK2());
            try
            {
                wrkmgt.Open();


                foreach (SourceCode.Workflow.Management.ProcessDataField df in wrkmgt.GetProcessDataFields(ProcessId))
                {

                    list.Add(DataFields(df));
                }



            }
            catch (Exception ex)
            {
                list.Add(new ProcessDataFields
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

        public static List<ProcessDataFields> WorkflowXMLDataFieldsExplorer(int ProcessId)
        {
            List<ProcessDataFields> list = new List<ProcessDataFields>();
            SourceCode.Workflow.Management.WorkflowManagementServer wrkmgt = new SourceCode.Workflow.Management.WorkflowManagementServer("dlx", 5555);
            try
            {
                wrkmgt.Open();
                SourceCode.Workflow.Management.Criteria.ProcessCriteriaFilter cf = new SourceCode.Workflow.Management.Criteria.ProcessCriteriaFilter();



                foreach (SourceCode.Workflow.Management.ProcessXMLField df in wrkmgt.GetProcessXMLFields(ProcessId))
                {

                   list.Add(DataFields(df));
                }



            }
            catch (Exception ex)
            {
                list.Add(new ProcessDataFields
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

        public static List<ProcessActivities> WorkflowActivitiesExplorer(int ProcessId)
        {
            List<ProcessActivities> list = new List<ProcessActivities>();
            SourceCode.Workflow.Management.WorkflowManagementServer wrkmgt = new SourceCode.Workflow.Management.WorkflowManagementServer("dlx", 5555);
            try
            {
                wrkmgt.Open();


                foreach (SourceCode.Workflow.Management.Activity act in wrkmgt.GetProcActivities(ProcessId))
                {

                    list.Add(new ProcessActivities
                    {
                        Description = act.Description,
                        ExpectedDuration = act.ExpectedDuration,
                        ID = act.ID,
                        IsStart = act.IsStart,
                        MetaData = act.MetaData,
                        Name = act.Name,
                        Priority = act.Priority

                    });
                }



            }
            catch (Exception ex)
            {
                list.Add(new ProcessActivities
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

        public static List<ProcessEvents> WorkflowEventsExplorer(int ActivityId)
        {
            List<ProcessEvents> list = new List<ProcessEvents>();
            SourceCode.Workflow.Management.WorkflowManagementServer wrkmgt = new SourceCode.Workflow.Management.WorkflowManagementServer("dlx", 5555);
            try
            {
                wrkmgt.Open();


                foreach (SourceCode.Workflow.Management.Event act in wrkmgt.GetActivityEvents(ActivityId))
                {

                    list.Add(new ProcessEvents
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
                list.Add(new ProcessEvents
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
