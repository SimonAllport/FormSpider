using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFish.FormSpider
{
    class Controls
    {
        
        public List<SmartFormViewControls> ArtefactControls(SourceCode.Forms.Authoring.ControlCollection controls)
        {
            List<SmartFormViewControls> list = new List<SmartFormViewControls>();
            foreach (SourceCode.Forms.Authoring.Control control in controls)
            {
                list.Add(new SmartFormViewControls {
                    name = control.Name,
                    type = control.Type,
                    guid = control.Guid,
                    properties = control.Properties

                });

            }
            return list;
        }


    }
}
