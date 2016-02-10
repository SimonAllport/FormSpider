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
    class Rules
    {

        public List<SmartFormViewEvents> ArtefactEvents(SourceCode.Forms.Authoring.Eventing.EventCollection events)
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
                        handlers = ev.Handlers,
                        properties = ev.Properties

                    });

                }
            }

            return list;
        }

        public List<SmartFromViewHandlers> ArtefactHandlers(SourceCode.Forms.Authoring.Eventing.HandlerCollection handlers)
        {
            List<SmartFromViewHandlers> list = new List<SmartFromViewHandlers>();
            foreach (SourceCode.Forms.Authoring.Eventing.Handler handle in handlers)
            {
                list.Add(new SmartFromViewHandlers
                {
                    Actions = handle.Actions,
                    Conditions = handle.Conditions,
                    Name = handle.HandlerType.ToString()
                });

            }

            return list;

        }

        public List<SmartFormViewConditions> ArtefactConditions(SourceCode.Forms.Authoring.Eventing.ConditionCollection conditions)
        {
            List<SmartFormViewConditions> list = new List<SmartFormViewConditions>();
            foreach (SourceCode.Forms.Authoring.Eventing.Condition condition in conditions)
            {

                list.Add(new SmartFormViewConditions
                {
                    Property = condition.Properties
                });


            }

            return list;
        }

        public List<SmartFormViewActions> ArtefactActionss(SourceCode.Forms.Authoring.Eventing.ActionCollection actions)
        {
            List<SmartFormViewActions> list = new List<SmartFormViewActions>();

            foreach (SourceCode.Forms.Authoring.Eventing.Action action in actions)
            {
                list.Add(new SmartFormViewActions
                {
                    properties = action.Properties,
                    parameters = action.Parameters,
                    results = action.Results,
                    validation = action.Validation,
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

        public List<SmartFormViewActionParameters> SmartFormViewActionParameters(SourceCode.Forms.Authoring.Eventing.MappingCollection parameters)
        {
            List<SmartFormViewActionParameters> list = new List<SmartFormViewActionParameters>();
            foreach (SourceCode.Forms.Authoring.Eventing.Mapping map in parameters)
            {

                list.Add(new SmartFormViewActionParameters
                {

                    validation = map.Validation,
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

        public List<SmartFormViewActionParameters> SmartFormViewActionResults(SourceCode.Forms.Authoring.Eventing.MappingCollection Results)
        {
            List<SmartFormViewActionParameters> list = new List<SmartFormViewActionParameters>();
            foreach (SourceCode.Forms.Authoring.Eventing.Mapping result in Results)
            {

                list.Add(new SmartFormViewActionParameters
                {

                    validation = result.Validation,
                    targettype = result.TargetType.ToString(),
                    targetpath = result.TargetPath,
                    targetid = result.TargetID,
                    sourcevalue = result.SourceValue,
                    sourcetype = result.SourceType.ToString(),
                    sourcepath = result.SourcePath,
                    sourceid = result.SourceID

                });


            }
            return list;
        }


        public List<SmartFormViewActionValidation> SmartFormViewActionValidations(SourceCode.Forms.Authoring.ValidationResult validations)
        {

            List<SmartFormViewActionValidation> list = new List<SmartFormViewActionValidation>();

            SourceCode.Forms.Authoring.ValidationResult validation = validations;

            list.Add(new SmartFormViewActionValidation
            {
                messages = validation.Messages,
                status = validation.Status.ToString()
            });
            return list;
        }

        public List<SmartFormViewActionValidationMessage> SmartFormViewActionValidationMessages(ValidationMessageCollection messages)
        {
            List<SmartFormViewActionValidationMessage> list = new List<SmartFormViewActionValidationMessage>();
            foreach (ValidationMessage message in messages)
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
