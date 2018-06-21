using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFish.FormSpider
{
    public class Controls: Validation
    {

        public List<SmartFormViewControls> ArtefactControls(SourceCode.Forms.Authoring.ControlCollection controls)
        {
            List<SmartFormViewControls> list = new List<SmartFormViewControls>();
            foreach (SourceCode.Forms.Authoring.Control control in controls)
            {
                if (System.Enum.IsDefined(typeof(ControlExcludeList), control.Type) != true)
                {
                    var c = control;

                    list.Add(new SmartFormViewControls
                    {
                        name = control.Name,
                        type = control.Type,
                        guid = control.Guid,
                        Field = control.Field == null ? "Unbound Control" : control.Field.FieldName.ToString(),
                        Result = ValidateControl(control.Type, control.Name)

                            

                    });
                }
            }
            return list;
        }


    }
}
