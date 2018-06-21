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
 public class Rules
    {

        public List<SmartFormViewEvents> Events(SourceCode.Forms.Authoring.Eventing.EventCollection events)
        {
            List<SmartFormViewEvents> list = new List<SmartFormViewEvents>();
            foreach (SourceCode.Forms.Authoring.Eventing.Event ev in events)
            {

                if (ev.SourceType == SourceCode.Forms.Authoring.Eventing.EventSourceType.Rule)
                {
                    list.Add(new SmartFormViewEvents
                    {
                        name = ev.Name,
                        type = ev.EventType.ToString(),
                        SourceType = ev.SourceType.ToString(),
                        GUID = ev.Guid,
                    
                   });

                }
            }

            return list;
        }

        public List<SmartFromViewHandlers> Handlers(SourceCode.Forms.Authoring.Eventing.Event artefactevent)
        {
            List<SmartFromViewHandlers> list = new List<SmartFromViewHandlers>();
            foreach (SourceCode.Forms.Authoring.Eventing.Handler handle in artefactevent.Handlers)
            {
                list.Add(new SmartFromViewHandlers
                {
                
                    Name = handle.HandlerType.ToString(),
                    GUID = handle.Guid
                });

            }

            return list;

        }

        public List<SmartFormViewConditions> Conditions(SourceCode.Forms.Authoring.Eventing.Handler handler)
        {
            List<SmartFormViewConditions> list = new List<SmartFormViewConditions>();
            foreach (SourceCode.Forms.Authoring.Eventing.Condition condition in handler.Conditions)
            {

                list.Add(new SmartFormViewConditions
                {
                    GUID = condition.Guid
                   
                });


            }

            return list;
        }

        public List<SmartFormViewActions> Actions(SourceCode.Forms.Authoring.Eventing.Handler handler)
        {
            List<SmartFormViewActions> list = new List<SmartFormViewActions>();

            foreach (SourceCode.Forms.Authoring.Eventing.Action action in handler.Actions)
            {
                list.Add(new SmartFormViewActions
                {
                    viewguid = action.ViewGuid,
                    view = Views.GetView(action.ViewGuid).name,
                    GUID = action.Guid,
                    method = action.Method,
                    formguid = action.FormGuid,
                    form = Smartform.GetForm(action.FormGuid).name,
                    executiontype = action.ExecutionType.ToString(),
                    controlguid = action.ControlGuid,
                    actiontype = action.ActionType.ToString()
                });
            }
            return list;
        }

        public List<SmartFormViewActionParameters> Parameters(SourceCode.Forms.Authoring.Eventing.Action action)
        {
            List<SmartFormViewActionParameters> list = new List<SmartFormViewActionParameters>();
            foreach (SourceCode.Forms.Authoring.Eventing.Mapping map in action.Parameters)
            {

                list.Add(new SmartFormViewActionParameters
                {

                    targetInstanceGuid = map.TargetInstanceGuid,
                    targetSubFormGuid = map.TargetSubFormGuid,
                    targettype = map.TargetType.ToString(),
                    targetpath = map.TargetPath,
                    targetid = map.TargetID,
                    sourcevalue = map.SourceValue,
                    sourcetype = map.SourceType.ToString(),
                    sourcepath = map.SourcePath,
                    sourceid = map.SourceID,
                    sourceInstanceGuid = map.SourceInstanceGuid,
                    sourceSubFormGuid =  map.SourceSubFormGuid

                });
            }

            return list;
        }

        public List<SmartFormViewActionParameters> Results(SourceCode.Forms.Authoring.Eventing.Action action)
        {
            List<SmartFormViewActionParameters> list = new List<SmartFormViewActionParameters>();
            foreach (SourceCode.Forms.Authoring.Eventing.Mapping result in action.Results)
            {

                list.Add(new SmartFormViewActionParameters
                {
                    targetInstanceGuid = result.TargetInstanceGuid,
                    targetSubFormGuid = result.TargetSubFormGuid,
                    targettype = result.TargetType.ToString(),
                    targetpath = result.TargetPath,
                    targetid = result.TargetID,
                    sourcevalue = result.SourceValue,
                    sourcetype = result.SourceType.ToString(),
                    sourcepath = result.SourcePath,
                    sourceid = result.SourceID,
                    sourceInstanceGuid = result.SourceInstanceGuid,
                    sourceSubFormGuid = result.SourceSubFormGuid

                });


            }
            return list;
        }


        public List<SmartFormViewActionValidation> Validations(SourceCode.Forms.Authoring.Eventing.Action action)
        {

            List<SmartFormViewActionValidation> list = new List<SmartFormViewActionValidation>();

            SourceCode.Forms.Authoring.ValidationResult validation = action.Validation;

            list.Add(new SmartFormViewActionValidation
            { 
              ValidationGuid = validation.Guid,
              status = validation.Status.ToString()
            });
            return list;
        }

        public List<SmartFormViewActionValidationMessage> Messages(SourceCode.Forms.Authoring.Eventing.Action action)
        {
          
            List<SmartFormViewActionValidationMessage> list = new List<SmartFormViewActionValidationMessage>();
            foreach (ValidationMessage message in action.Validation.Messages)
            {
                list.Add(new SmartFormViewActionValidationMessage
                {
                    message = message.Message
                });
            }
            return list;
        }

    }    
}
