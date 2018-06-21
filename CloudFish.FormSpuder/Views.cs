using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.Forms.Management;
using SourceCode.Forms.Deployment;
using SourceCode.Forms;
using SourceCode.Forms.Authoring;

namespace CloudFish.FormSpider
{
   public class Views: Connection
    {

   /// <summary>
   /// Builds the connection the server
   /// </summary>
   /// <returns></returns>
       private static FormsManager formmanager()
       {
           FormsManager frm = new FormsManager(ConnectToK2());
           return frm;
       }

        
       /// <summary>
       /// Adds view details to the object
       /// </summary>
       /// <param name="viewinfo"></param>
       /// <returns></returns>
       private static SmartFormView BuildViewListItem(ViewInfo viewinfo)
       {

           SmartFormView sf = new SmartFormView();
           ViewInfo view = viewinfo;
              Validation validation = new Validation();

           sf.guid = viewinfo.Guid;
           sf.description = viewinfo.Description;

           sf.displayname = viewinfo.DisplayName;
           sf.name = viewinfo.Name;
           sf.guid = viewinfo.Guid;

           sf.CheckedOutBy = viewinfo.CheckedOutBy;
           sf.CheckedOut = viewinfo.IsCheckedOut;
           sf.ModifiedBy = viewinfo.ModifiedBy;
           sf.ModifiedDate = viewinfo.ModifiedDate;
           sf.CreatedBy = viewinfo.CreatedBy;
           sf.CreatedDate = viewinfo.CreatedDate;
           sf.Result = validation.ValidateControl("View", viewinfo.Name);


           return sf;

       }


       /// <summary>
       /// Builds the view list based on differernt criteria
       /// </summary>
       /// <param name="name"></param>
       /// <param name="type"></param>
       /// <returns></returns>
       private static List<SmartFormView> BuildViewList(string name, string type)
       {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = formmanager();
            try
            {
             
                ViewExplorer formexplorer;

                switch (type)
                {
                    case "Smartform":
                        formexplorer = frm.GetViewsForForm(name);
                        break;
                    case "Workflow":
                        formexplorer = frm.GetViewsForProcess(name);
                        break;
                    case "SmartObject":
                        Guid newGuid = Guid.Parse(name);
                        formexplorer = frm.GetViewsForObject(newGuid);
                        break;
                    default:
                        formexplorer = frm.GetViews();
                        break;
                }


                foreach (SourceCode.Forms.Management.ViewInfo viewinfo in formexplorer.Views)
                {

                    list.Add(BuildViewListItem(viewinfo));

                }

            }
           catch(Exception ex)
           {
               list.Add(new SmartFormView { 
                  description = ex.Message,
                  displayname = ex.Source,
                  name = ex.Source
               });
           }
           finally
            {
                frm.Connection.Close();
                
            }

             return list;


       }

        /// <summary>
        /// Gets all the views on the environment
        /// </summary>
        /// <returns></returns>
        public static List<SmartFormView> GetAllViews()
        {
          
             return BuildViewList("","");
        }

       /// <summary>
       /// Gets the details for a particular view
       /// </summary>
       /// <param name="ViewName"></param>
       /// <returns></returns>
        public static SmartFormView GetView(string ViewName)
        {
             FormsManager frm = formmanager();

            SmartFormView sf = new SmartFormView();
            try
            {

                ViewInfo viewinfo = frm.GetView(ViewName);
                sf = BuildViewListItem(viewinfo);

           

            }
            catch(Exception ex)
            {
                sf.description = ex.Message;
                sf.displayname = ex.Source;
                sf.name = ex.Source;
            }
            finally
            {
                frm.Connection.Close();
            }
            return sf;

        }


        public static SmartFormView GetView(Guid ViewGuid)
        {
            FormsManager frm = formmanager();

            SmartFormView sf = new SmartFormView();
            try
            {

                ViewInfo viewinfo = frm.GetView(ViewGuid);
                sf = BuildViewListItem(viewinfo);



            }
            catch (Exception ex)
            {
                sf.description = ex.Message;
                sf.displayname = ex.Source;
                sf.name = ex.Source;
            }
            finally
            {
                frm.Connection.Close();
            }
            return sf;

        }

        /// <summary>
        /// Gets all the views that are attached to a form
        /// </summary>
        /// <param name="formname"></param>
        /// <returns></returns>
        public static List<SmartFormView> GetAllViews(string formname)
        {
       
            return BuildViewList(formname,"Smartform");
        }

       /// <summary>
       /// Views connected to workflow
       /// </summary>
       /// <param name="workflow"></param>
       /// <returns></returns>
        public static List<SmartFormView> GetViewsByProcess(string workflow)
        {
            
            return  BuildViewList(workflow,"Workflow");
        }


       /// <summary>
       /// Get views by smartobject
       /// </summary>
       /// <param name="SmartObjectGUID"></param>
       /// <returns></returns>
        public static List<SmartFormView> GetViewsBySmartObject(Guid SmartObjectGUID)
        {
           
            return BuildViewList(SmartObjectGUID.ToString(), "SmartObject");
        }


    
        /// <summary>
        /// List of form properties 
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        public static List<SmartFormViewProperties> GetViewProperties(string ViewName)
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = formmanager();

            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            Properties prop = new Properties();
            return prop.ArtefactProperties(view.Properties);

         }


        /// <summary>
        /// Gets a list of the form parameters
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        public static List<SmartFormViewParameters> ViewParameters(string ViewName)
        {
            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            Parameters parameters = new Parameters();
            return parameters.ArtefactParameters(view.Parameters);
           
        }


        /// <summary>
        /// Form Controls
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        public static List<SmartFormViewControls> ViewControls(string ViewName)
        {
           
            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            Controls control = new Controls();
            return control.ArtefactControls(view.Controls);
         }

        public static List<SmartFormViewProperties> GetControlProperties(string ViewName, Guid ControlGUID)
        {
          
            FormsManager frm = formmanager();

            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));

            SourceCode.Forms.Authoring.Control control = view.Controls[ControlGUID];

            Properties prop = new Properties();
            return prop.ArtefactProperties(control.Properties);





        }
        /// <summary>
        /// Form Events
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        public static List<SmartFormViewEvents> ViewEventsEvents(string ViewName)
        {

            Rules rules = new Rules();

            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));

            return rules.Events(view.Events);
        }

        /// <summary>
        /// Event Handlers
        /// </summary>
        /// <param name="EventGUID"></param>
        /// <returns></returns>
        public static List<SmartFromViewHandlers> ViewHandlers(String ViewName, Guid EventGUID)
        {
      
            Rules rules = new Rules();
            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            return rules.Handlers(view.Events[EventGUID]);

          
        }

        /// <summary>
        /// Conditions
        /// </summary>
        /// <param name="FormName"></param>
        /// <param name="EventGUID"></param>
        /// <param name="HandleGUID"></param>
        /// <returns></returns>
        public static List<SmartFormViewConditions> ArtefactConditions(String ViewName, Guid EventGUID, Guid HandleGUID)
        {
            Rules rules = new Rules();
            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            return rules.Conditions(view.Events[EventGUID].Handlers[HandleGUID]);
        }
        /// <summary>
        /// Actions
        /// </summary>
        /// <param name="HandleGUID"></param>
        /// <returns></returns>
        public static List<SmartFormViewActions> ArtefactActionss(String ViewName, Guid EventGUID, Guid HandleGUID)
        {
            Rules rules = new Rules();
            FormsManager frm = formmanager();

            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            return rules.Actions(view.Events[EventGUID].Handlers[HandleGUID]);
        }
        /// <summary>
        /// Actions Parameters
        /// </summary>
        /// <param name="FormName"></param>
        /// <param name="EventGUID"></param>
        /// <param name="HandleGUID"></param>
        /// <param name="ActionGUID"></param>
        /// <returns></returns>
        public static List<SmartFormViewActionParameters> ViewActionParameters(String ViewName, Guid EventGUID, Guid HandleGUID, Guid ActionGUID)
        {
            Rules rules = new Rules();
            FormsManager frm = formmanager();

            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            return rules.Parameters(view.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID]);
    
        }
        /// <summary>
        /// Actions Results
        /// </summary>
        /// <param name="FormName"></param>
        /// <param name="EventGUID"></param>
        /// <param name="HandleGUID"></param>
        /// <param name="ActionGUID"></param>
        /// <returns></returns>
        public static List<SmartFormViewActionParameters> ViewActionResults(String ViewName, Guid EventGUID, Guid HandleGUID, Guid ActionGUID)
        {
            Rules rules = new Rules(); 
            FormsManager frm = formmanager();

            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
         
          return  rules.Results(view.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID]);
          
        }
        /// <summary>
        /// Validation Messages
        /// </summary>
        /// <param name="FormName"></param>
        /// <param name="EventGUID"></param>
        /// <param name="HandleGUID"></param>
        /// <param name="ActionGUID"></param>
        /// <returns></returns>
        public static List<SmartFormViewActionValidation> ViewActionValidation(String ViewName, Guid EventGUID, Guid HandleGUID, Guid ActionGUID)
        {
            Rules rules = new Rules(); 
             FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            return rules.Validations(view.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID]);
          
        }

        public static List<SmartFormViewActionValidationMessage> ViewActionValidationMessages(String ViewName, Guid EventGUID, Guid HandleGUID, Guid ActionGUID)
        {
            Rules rules = new Rules();
            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            return rules.Messages(view.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID]);

        }

    }
}
