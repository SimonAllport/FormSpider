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
    /// <summary>
    /// Gets the parameters for the form or view
    /// </summary>
    class Parameters
    {
        public List<SmartFormViewParameters> ArtefactParameters(SourceCode.Forms.Authoring.FormParameterCollection parameters)
        {
            List<SmartFormViewParameters> list = new List<SmartFormViewParameters>();
            foreach (SourceCode.Forms.Authoring.FormParameter parameter in parameters)
            {
                list.Add(new SmartFormViewParameters {
                    name = parameter.Name,
                    type = parameter.DataType.ToString(),
                    defaultvalue = parameter.DefaultValue
                });
            }

            return list;

        }
    }
}
