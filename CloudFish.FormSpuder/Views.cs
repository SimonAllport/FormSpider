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
   public class Views
    {
       

        /// <summary>
        /// Gets all the views on the environment
        /// </summary>
        /// <returns></returns>
        public static List<SmartFormView> GetAllViews()
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = new FormsManager("dlx", 5555);
            ViewExplorer formexplorer = frm.GetViews();
            foreach (SourceCode.Forms.Management.ViewInfo viewinfo in formexplorer.Views)
            {

                SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(viewinfo.Name));

                list.Add(new SmartFormView
                {
                    name = viewinfo.Name,
                    displayname = viewinfo.DisplayName,
                    description = viewinfo.Description,
                    guid = viewinfo.Guid,
                    version = viewinfo.Version,
                 


                });

            }
            return list;
        }

        /// <summary>
        /// Gets all the views that are attached to a form
        /// </summary>
        /// <param name="formname"></param>
        /// <returns></returns>
        public static List<SmartFormView> GetAllViews(string formname)
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = new FormsManager("dlx", 5555);
            ViewExplorer formexplorer = frm.GetViewsForForm(formname);
            foreach (SourceCode.Forms.Management.ViewInfo viewinfo in formexplorer.Views)
            {

                SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(viewinfo.Name));

                list.Add(new SmartFormView
                {
                    name = viewinfo.Name,
                    displayname = viewinfo.DisplayName,
                    description = viewinfo.Description,
                    guid = viewinfo.Guid,
                    version = viewinfo.Version,
                  

                });

            }
            return list;
        }




        /// <summary>
        /// List of form properties 
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        public static List<SmartFormViewProperties> GetViewProperties(string ViewName)
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = new FormsManager("dlx", 5555);


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
            List<SmartFormViewParameters> list = new List<SmartFormViewParameters>();
            FormsManager frm = new FormsManager("dlx", 5555);
            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));

            foreach (SourceCode.Forms.Authoring.ViewParameter parameter in view.Parameters)
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
        public static List<SmartFormViewControls> ViewControls(string ViewName)
        {
            List<SmartFormViewControls> list = new List<SmartFormViewControls>();
            FormsManager frm = new FormsManager("dlx", 5555);
            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));

            foreach (SourceCode.Forms.Authoring.Control control in view.Controls)
            {
                list.Add(new SmartFormViewControls
                {
                    name = control.Name,
                    type = control.Type,
                    guid = control.Guid,
                  

                });

            }
            return list;
        }

        public static List<SmartFormViewProperties> GetControlProperties(string ViewName, Guid ControlGUID)
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = new FormsManager("dlx", 5555);

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
            List<SmartFormViewEvents> list = new List<SmartFormViewEvents>();
            FormsManager frm = new FormsManager("dlx", 5555);
            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));

            foreach (SourceCode.Forms.Authoring.Eventing.Event ev in view.Events)
            {


                if (ev.SourceType == SourceCode.Forms.Authoring.Eventing.EventSourceType.Rule)
                {
                    list.Add(new SmartFormViewEvents
                    {
                        name = ev.Name,
                        type = ev.EventType.ToString(),
                        GUID = ev.Guid
                      

                    });

                }
            }

            return list;
        }

        /// <summary>
        /// Event Handlers
        /// </summary>
        /// <param name="EventGUID"></param>
        /// <returns></returns>
        public static List<SmartFromViewHandlers> ViewHandlers(String ViewName, Guid EventGUID)
        {
            List<SmartFromViewHandlers> list = new List<SmartFromViewHandlers>();
            FormsManager frm = new FormsManager("dlx", 5555);
            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            var ev = view.Events[EventGUID];
          
            SourceCode.Forms.Authoring.Eventing.Event e = view.Events[EventGUID]; 

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
        public static List<SmartFormViewConditions> ArtefactConditions(String ViewName, Guid EventGUID, Guid HandleGUID)
        {
            List<SmartFormViewConditions> list = new List<SmartFormViewConditions>();
            FormsManager frm = new FormsManager("dlx", 5555);
            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            var ev = view.Events[EventGUID].Handlers[HandleGUID];
            SourceCode.Forms.Authoring.Eventing.Handler e = view.Events[EventGUID].Handlers[HandleGUID];

            foreach (SourceCode.Forms.Authoring.Eventing.Condition condition in e.Conditions)
            {

                list.Add(new SmartFormViewConditions
                {
                    GUID = condition.Guid
                    
                });


            }

            return list;
        }
        /// <summary>
        /// Actions
        /// </summary>
        /// <param name="HandleGUID"></param>
        /// <returns></returns>
        public static List<SmartFormViewActions> ArtefactActionss(String ViewName, Guid EventGUID, Guid HandleGUID)
        {
            List<SmartFormViewActions> list = new List<SmartFormViewActions>();
            FormsManager frm = new FormsManager("dlx", 5555);

            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            var ev = view.Events[EventGUID].Handlers[HandleGUID];
            SourceCode.Forms.Authoring.Eventing.Handler e = view.Events[EventGUID].Handlers[HandleGUID];

            foreach (SourceCode.Forms.Authoring.Eventing.Action action in e.Actions)
            {
                list.Add(new SmartFormViewActions
                {
                    GUID = action.Guid,
                    
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
        public static List<SmartFormViewActionParameters> ViewActionParameters(String ViewName, Guid EventGUID, Guid HandleGUID, Guid ActionGUID)
        {
            List<SmartFormViewActionParameters> list = new List<SmartFormViewActionParameters>();
            FormsManager frm = new FormsManager("dlx", 5555);

            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            SourceCode.Forms.Authoring.Eventing.Action e = view.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID];

            foreach (SourceCode.Forms.Authoring.Eventing.Mapping map in e.Parameters)
            {

                list.Add(new SmartFormViewActionParameters
                {

                    
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
        public static List<SmartFormViewActionParameters> ViewActionResults(String ViewName, Guid EventGUID, Guid HandleGUID, Guid ActionGUID)
        {
            List<SmartFormViewActionParameters> list = new List<SmartFormViewActionParameters>();
            FormsManager frm = new FormsManager("dlx", 5555);

            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            SourceCode.Forms.Authoring.Eventing.Action e = view.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID];

            foreach (SourceCode.Forms.Authoring.Eventing.Mapping map in e.Results)
            {

                list.Add(new SmartFormViewActionParameters
                {

                  
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
        public static List<SmartFormViewActionValidationMessage> ViewActionValidation(String ViewName, Guid EventGUID, Guid HandleGUID, Guid ActionGUID)
        {
            List<SmartFormViewActionValidationMessage> list = new List<SmartFormViewActionValidationMessage>();
            FormsManager frm = new FormsManager("dlx", 5555);

            SourceCode.Forms.Authoring.View view = new SourceCode.Forms.Authoring.View(frm.GetViewDefinition(ViewName));
            SourceCode.Forms.Authoring.Eventing.Action e = view.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID];

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
