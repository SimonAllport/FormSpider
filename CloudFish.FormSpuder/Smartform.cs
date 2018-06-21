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
    public class Smartform : Connection
    {
        private static FormsManager formmanager()
        {
            FormsManager frm = new FormsManager(ConnectToK2());
            return frm;
        }


        private static SmartFormView BuildFormListItem(FormInfo forminfo)
        {

            SmartFormView sf = new SmartFormView();
            FormInfo form = forminfo;
            Validation validation = new Validation();

            sf.guid = form.Guid;
            sf.description = form.Description;

            sf.displayname = form.DisplayName;
            sf.name = form.Name;
            sf.guid = form.Guid;

            sf.CheckedOutBy = form.CheckedOutBy;
            sf.CheckedOut = form.IsCheckedOut;
            sf.ModifiedBy = form.ModifiedBy;
            sf.ModifiedDate = form.ModifiedDate;
            sf.CreatedBy = form.CreatedBy;
            sf.CreatedDate = form.CreatedDate;
            sf.Result = validation.ValidateControl("Smartform", form.Name);

            return sf;

        }


        /// <summary>
        /// Gets the details of the form
        /// </summary>
        /// <param name="FormName"></param>
        public static SmartFormView GetForm(string FormName)
        {
            FormsManager frm = formmanager();

            SmartFormView sf = new SmartFormView();
            try
            {

                FormInfo forminfo = frm.GetForm(FormName);
                sf = BuildFormListItem(forminfo);



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

        public static SmartFormView GetForm(Guid FormGuid)
        {
            FormsManager frm = formmanager();

            SmartFormView sf = new SmartFormView();
            try
            {

                FormInfo forminfo = frm.GetForm(FormGuid);
                sf = BuildFormListItem(forminfo);



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

        public static List<SmartFormView> GetAllFormsByView(string viewname)
        {

            return BuildFormList(viewname, "View");
        }

        public static List<SmartFormView> GetAllFormsByWorkflow(string workflow)
        {

            return BuildFormList(workflow, "Workflow");
        }

        public static List<SmartFormView> GetAllForms()
        {

            return BuildFormList("", "");
        }

        private static List<SmartFormView> BuildFormList(string name, string type)
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = formmanager();
            try
            {

                FormExplorer formexplorer;

                switch (type)
                {
                    case "View":
                        formexplorer = frm.GetFormsForView(name);
                        break;
                    case "Workflow":
                        formexplorer = frm.GetFormsForProcess(name);
                        break;

                    default:
                        formexplorer = frm.GetForms();
                        break;
                }


                foreach (SourceCode.Forms.Management.FormInfo forminfo in formexplorer.Forms)
                {

                    list.Add(BuildFormListItem(forminfo));

                }

            }
            catch (Exception ex)
            {
                list.Add(new SmartFormView
                {
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
        /// List of form properties 
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        public static List<SmartFormViewProperties> GetFormProperties(string FormName)
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = formmanager();


            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            Properties prop = new Properties();
            return prop.ArtefactProperties(form.Properties);
        }




        /// <summary>
        /// Gets a list of the form parameters
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        public static List<SmartFormViewParameters> FormParameters(string FormName)
        {
            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            Parameters parameters = new Parameters();
            return parameters.ArtefactParameters(form.Parameters);

        }

        /// <summary>
        /// Form Controls
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        public static List<SmartFormViewControls> FormControls(string FormName)
        {
            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));

            Controls control = new Controls();
            return control.ArtefactControls(form.Controls);
        }



        public static List<SmartFormViewProperties> GetControlProperties(string FormName, Guid ControlGUID)
        {
     
            FormsManager frm = formmanager();


            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));

            SourceCode.Forms.Authoring.Control control = form.Controls[ControlGUID];

            Properties prop = new Properties();

            return prop.ArtefactProperties(control.Properties);

        }


        public static List<SmartFormViewProperties> GetControlStyleProperties(string FormName, Guid ControlGUID)
        {
          
            FormsManager frm = formmanager();

           

            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));

            SourceCode.Forms.Authoring.Control control = form.Controls[ControlGUID];



            Properties prop = new Properties();

            return prop.ArtefactStyleProperties(control.Styles);

        }

        public static List<SmartFormViewProperties> GetCondtionalStyleProperties(string FormName, Guid ControlGUID)
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = formmanager();


            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));

            SourceCode.Forms.Authoring.Control control = form.Controls[ControlGUID];

            Properties prop = new Properties();

            return prop.ArtefactConditionalStyleProperties(control.ConditionalStyles);

        }


        public static SmartFormViewProperties GetControlExpressions(string FormName, Guid ControlGUID)
        {
            List<SmartFormView> list = new List<SmartFormView>();
            FormsManager frm = formmanager();


            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));

            SourceCode.Forms.Authoring.Control control = form.Controls[ControlGUID];

            Properties prop = new Properties();

            return prop.ArtefactControlExpressions(control.Expression);

        }

        /// <summary>
        /// Form Events
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        public static List<SmartFormViewEvents> FormEventsEvents(string FormName)
        {
            
            Rules rules = new Rules();

            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));

            return rules.Events(form.Events);
        }

        /// <summary>
        /// Event Handlers
        /// </summary>
        /// <param name="EventGUID"></param>
        /// <returns></returns>
        public static List<SmartFromViewHandlers> FormHandlers(String FormName, Guid EventGUID)
        {
            Rules rules = new Rules();
            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            return rules.Handlers(form.Events[EventGUID]);

        }

        /// <summary>
        /// Conditions
        /// </summary>
        /// <param name="FormName"></param>
        /// <param name="EventGUID"></param>
        /// <param name="HandleGUID"></param>
        /// <returns></returns>
        public static List<SmartFormViewConditions> ArtefactConditions(String FormName, Guid EventGUID, Guid HandleGUID)
        {
            Rules rules = new Rules();
            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            return  rules.Conditions(form.Events[EventGUID].Handlers[HandleGUID]);
           
        }
        /// <summary>
        /// Actions
        /// </summary>
        /// <param name="HandleGUID"></param>
        /// <returns></returns>
        public static List<SmartFormViewActions> ArtefactActionss(String FormName, Guid EventGUID, Guid HandleGUID)
        {
            Rules rules = new Rules();
            FormsManager frm = formmanager();

            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            return rules.Actions(form.Events[EventGUID].Handlers[HandleGUID]);

        }
        /// <summary>
        /// Actions Parameters
        /// </summary>
        /// <param name="FormName"></param>
        /// <param name="EventGUID"></param>
        /// <param name="HandleGUID"></param>
        /// <param name="ActionGUID"></param>
        /// <returns></returns>
        public static List<SmartFormViewActionParameters> SmartFormViewActionParameters(String FormName, Guid EventGUID, Guid HandleGUID, Guid ActionGUID)
        {
            Rules rules = new Rules();
            FormsManager frm = formmanager();

            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            return  rules.Parameters(form.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID]);
    
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
            Rules rules = new Rules();
            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
           return rules.Results(form.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID]);
          
        }
        /// <summary>
        /// Validation Messages
        /// </summary>
        /// <param name="FormName"></param>
        /// <param name="EventGUID"></param>
        /// <param name="HandleGUID"></param>
        /// <param name="ActionGUID"></param>
        /// <returns></returns>
        public static List<SmartFormViewActionValidation> SmartFormViewActionValidation(String FormName, Guid EventGUID, Guid HandleGUID, Guid ActionGUID)
        {
            Rules rules = new Rules(); 
            FormsManager frm = formmanager();

            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            return rules.Validations(form.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID]);
          
        }

        public static List<SmartFormViewActionValidationMessage> ViewActionValidationMessages(String FormName, Guid EventGUID, Guid HandleGUID, Guid ActionGUID)
        {
            Rules rules = new Rules();
            FormsManager frm = formmanager();
            SourceCode.Forms.Authoring.Form form = new SourceCode.Forms.Authoring.Form(frm.GetFormDefinition(FormName));
            return rules.Messages(form.Events[EventGUID].Handlers[HandleGUID].Actions[ActionGUID]);

        }

    }
}

