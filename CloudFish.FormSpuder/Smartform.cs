using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.Forms.Management;
using SourceCode.Forms.Deployment;
using SourceCode.Forms;
using SourceCode.Forms.Authoring;

/// <summary>
/// Explores the content of the SmartForm
/// </summary>
namespace CloudFish.FormSpider
{
    public class Smartform
    {

       
  
        /// <summary>
        /// Gets the details of the form
        /// </summary>
        /// <param name="FormName"></param>
        public static SmartFormView LoadForm(string formname)
        {

            FormsManager frm = new FormsManager("dlx", 5555);
            FormInfo forminfo = frm.GetForm(formname);


            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetViewDefinition(formname));
   

            SmartFormView sf = new SmartFormView();
            sf.guid = form.Guid;
            sf.description = form.Description;
           
            sf.displayname = form.DisplayName;
            sf.name = form.Name;
            sf.guid = form.Guid;
            sf.theme = form.Theme;

            return sf;
   }
         /// <summary>
         /// Get a list of all the forms
         /// </summary>
         /// <returns></returns>
            public static  List<SmartFormView> GetAllForms()
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = new FormsManager("dlx", 5555);
            FormExplorer formexplorer = frm.GetForms();
            foreach (SourceCode.Forms.Management.FormInfo forminfo in formexplorer.Forms)
            {

             
                list.Add(new SmartFormView
                {
                    name = forminfo.Name,
                    displayname = forminfo.DisplayName,
                    description = forminfo.Description,
                    guid = forminfo.Guid,
                    version = forminfo.Version
                        
                        
                    });

            }
            return list;
        }
/// <summary>
/// Get a list of all the forms that contain a certain view
/// </summary>
/// <param name="ViewName"></param>
/// <returns></returns>
        public static List<SmartFormView> GetAllFormsbyView(string ViewName)
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = new FormsManager("dlx", 5555);
          
            FormExplorer formexplorer = frm.GetFormsForView(ViewName);
            foreach (SourceCode.Forms.Management.FormInfo forminfo in formexplorer.Forms)
            {
           
                list.Add(new SmartFormView
                {
                    name = forminfo.Name,
                    displayname = forminfo.DisplayName,
                    description = forminfo.Description,
                    guid = forminfo.Guid,
                    version = forminfo.Version
                   
                });

            }
            return list;
        }

        /// <summary>
        /// Gets forms for a process
        /// </summary>
        /// <param name="WorkflowName"></param>
        /// <returns></returns>
        public static List<SmartFormView> GetAllFormsbyWorkFlow(string WorkflowName)
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = new FormsManager("dlx", 5555);
            
            FormExplorer formexplorer = frm.GetFormsForProcess(WorkflowName);
            foreach (SourceCode.Forms.Management.FormInfo forminfo in formexplorer.Forms)
            {

                list.Add(new SmartFormView
                {
                    name = forminfo.Name,
                    displayname = forminfo.DisplayName,
                    description = forminfo.Description,
                    guid = forminfo.Guid,
                    version = forminfo.Version

                });

            }
            return list;
        }



   
         /// <summary>
         /// List of form properties 
         /// </summary>
         /// <param name="FormName"></param>
         /// <returns></returns>
        public static  List<SmartFormViewProperties> GetFormProperties(string  FormName)
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = new FormsManager("dlx", 5555);
           

                SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            Properties prop = new Properties();
            return  prop.ArtefactProperties( form.Properties);
               
                   
                   
             

            }
         /// <summary>
         /// Gets a list of the form parameters
         /// </summary>
         /// <param name="FormName"></param>
         /// <returns></returns>
        public static List<SmartFormViewParameters> FormParameters(string  FormName)
        {
            List<SmartFormViewParameters> list = new List<SmartFormViewParameters>();
           FormsManager frm = new FormsManager("dlx", 5555);
                SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
        
            foreach (SourceCode.Forms.Authoring.FormParameter parameter in form.Parameters)
            {
                list.Add(new SmartFormViewParameters
                {
                    name = parameter.Name,
                    type = parameter.DataType.ToString(),
                    defaultvalue = parameter.DefaultValue
                });
            }

            return list;

        }

        /// <summary>
        /// Form Controls
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        public static List<SmartFormViewControls> FormControls(string FormName)
        {
            List<SmartFormViewControls> list = new List<SmartFormViewControls>();
            FormsManager frm = new FormsManager("dlx", 5555);
            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
        
            foreach (SourceCode.Forms.Authoring.Control control in form.Controls)
            {
                list.Add(new SmartFormViewControls
                {
                    name = control.Name,
                    type = control.Type,
                guid = control.Guid
                });

            }
            return list;
        }


        public static List<SmartFormViewProperties> GetControlProperties(string FormName,Guid ControlGUID)
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = new FormsManager("dlx", 5555);


            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));

            SourceCode.Forms.Authoring.Control control = form.Controls[ControlGUID];
            
            Properties prop = new Properties();
            return prop.ArtefactProperties(control.Properties);





        }
         /// <summary>
         /// Form Events
         /// </summary>
         /// <param name="FormName"></param>
         /// <returns></returns>
        public static List<SmartFormViewEvents> FormEventsEvents(string FormName)
        {
            List<SmartFormViewEvents> list = new List<SmartFormViewEvents>();
            FormsManager frm = new FormsManager("dlx", 5555);
            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
      
            foreach (SourceCode.Forms.Authoring.Eventing.Event ev in form.Events)
            {
               

               
                    list.Add(new SmartFormViewEvents
                    {
                        name = ev.Name,
                       
                        type = ev.EventType.ToString(),
                        GUID = ev.Guid
                   

                    });

                
            }

            return list;
        }

         /// <summary>
         /// Event Handlers
         /// </summary>
         /// <param name="EventGUID"></param>
         /// <returns></returns>
        public static List<SmartFromViewHandlers> FormHandlers(String FormName,Guid EventGUID)
        {
            List<SmartFromViewHandlers> list = new List<SmartFromViewHandlers>();
            FormsManager frm = new FormsManager("dlx", 5555);
            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            var ev = form.Events[EventGUID];
        
            SourceCode.Forms.Authoring.Eventing.Event e = form.Events[EventGUID]; 
         
                    foreach (SourceCode.Forms.Authoring.Eventing.Handler handle in e.Handlers)
                    {
                        list.Add(new SmartFromViewHandlers
                        {
                          
                            Name = handle.HandlerType.ToString(),
                            GUID = handle.Guid
                        });

                    }
             
           

            return list;

        }

         /// <summary>
         /// Conditions
         /// </summary>
         /// <param name="FormName"></param>
         /// <param name="EventGUID"></param>
         /// <param name="HandleGUID"></param>
         /// <returns></returns>
        public static List<SmartFormViewConditions> ArtefactConditions(String FormName,Guid EventGUID,Guid HandleGUID)
        {
            List<SmartFormViewConditions> list = new List<SmartFormViewConditions>();
            FormsManager frm = new FormsManager("dlx", 5555);
             SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
             var ev = form.Events[EventGUID].Handlers[HandleGUID];
             SourceCode.Forms.Authoring.Eventing.Handler e = form.Events[EventGUID].Handlers[HandleGUID];

            foreach (SourceCode.Forms.Authoring.Eventing.Condition condition in e.Conditions)
            {

                list.Add(new SmartFormViewConditions
                {
                    GUID = condition.Guid,
                    
                });


            }

            return list;
        }
         /// <summary>
         /// Actions
         /// </summary>
         /// <param name="HandleGUID"></param>
         /// <returns></returns>
        public static List<SmartFormViewActions> ArtefactActionss(String FormName, Guid EventGUID, Guid HandleGUID)
        {
            List<SmartFormViewActions> list = new List<SmartFormViewActions>();
            FormsManager frm = new FormsManager("dlx", 5555);

            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            var ev = form.Events[EventGUID].Handlers[HandleGUID];
            SourceCode.Forms.Authoring.Eventing.Handler e = form.Events[EventGUID].Handlers[HandleGUID];

            foreach (SourceCode.Forms.Authoring.Eventing.Action action in e.Actions)
            {
                list.Add(new SmartFormViewActions
                {
                    GUID = action.Guid,
                  //  properties = action.Properties,
                 //   parameters = action.Parameters,
                 //   results = action.Results,
                 //   validation = action.Validation,
                    viewguid = action.ViewGuid,
                    method = action.Method,
                    formguid = action.FormGuid,
                    executiontype = action.ExecutionType.ToString(),
                    controlguid = action.ControlGuid,
                    actiontype = action.ActionType.ToString()
                });
            }
            return list;
        }
         /// <summary>
         /// Actions Parameters
         /// </summary>
         /// <param name="FormName"></param>
         /// <param name="EventGUID"></param>
         /// <param name="HandleGUID"></param>
         /// <param name="ActionGUID"></param>
         /// <returns></returns>
        public static List<SmartFormViewActionParameters> SmartFormViewActionParameters(String FormName, Guid EventGUID, Guid HandleGUID,Guid ActionGUID)
        {
            List<SmartFormViewActionParameters> list = new List<SmartFormViewActionParameters>();
            FormsManager frm = new FormsManager("dlx", 5555);

            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            SourceCode.Forms.Authoring.Eventing.Action e = form.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID];

            foreach (SourceCode.Forms.Authoring.Eventing.Mapping map in e.Parameters)
            {

                list.Add(new SmartFormViewActionParameters
                {

                //    validation = map.Validation,
                    targettype = map.TargetType.ToString(),
                    targetpath = map.TargetPath,
                    targetid = map.TargetID,
                    sourcevalue = map.SourceValue,
                    sourcetype = map.SourceType.ToString(),
                    sourcepath = map.SourcePath,
                    sourceid = map.SourceID

                });
            }

            return list;
        }
         /// <summary>
         /// Actions Results
         /// </summary>
         /// <param name="FormName"></param>
         /// <param name="EventGUID"></param>
         /// <param name="HandleGUID"></param>
         /// <param name="ActionGUID"></param>
         /// <returns></returns>
        public static List<SmartFormViewActionParameters> SmartFormViewActionResults(String FormName, Guid EventGUID, Guid HandleGUID, Guid ActionGUID)
        {
            List<SmartFormViewActionParameters> list = new List<SmartFormViewActionParameters>();
            FormsManager frm = new FormsManager("dlx", 5555);

            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            SourceCode.Forms.Authoring.Eventing.Action e = form.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID];

            foreach (SourceCode.Forms.Authoring.Eventing.Mapping map in e.Results)
            {

                list.Add(new SmartFormViewActionParameters
                {

               //     validation = map.Validation,
                    targettype = map.TargetType.ToString(),
                    targetpath = map.TargetPath,
                    targetid = map.TargetID,
                    sourcevalue = map.SourceValue,
                    sourcetype = map.SourceType.ToString(),
                    sourcepath = map.SourcePath,
                    sourceid = map.SourceID

                });
            }

            return list;
        }
         /// <summary>
         /// Validation Messages
         /// </summary>
         /// <param name="FormName"></param>
         /// <param name="EventGUID"></param>
         /// <param name="HandleGUID"></param>
         /// <param name="ActionGUID"></param>
         /// <returns></returns>
        public static List<SmartFormViewActionValidationMessage> SmartFormViewActionValidation(String FormName, Guid EventGUID, Guid HandleGUID, Guid ActionGUID)
        {
            List<SmartFormViewActionValidationMessage> list = new List<SmartFormViewActionValidationMessage>();
            FormsManager frm = new FormsManager("dlx", 5555);

            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            SourceCode.Forms.Authoring.Eventing.Action e = form.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID];
        
            foreach (SourceCode.Forms.Authoring.ValidationMessage val in e.Validation.Messages)
            {

                list.Add(new SmartFormViewActionValidationMessage
                {
                    message = val.Message
                   


                });
            }

            return list;
        }

    }
}
