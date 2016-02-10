using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFish.FormSpider
{
     class Properties
    {

        public List<SmartFormViewProperties> ArtefactProperties(SourceCode.Forms.Authoring.PropertyCollection properties)
        {
            List<SmartFormViewProperties> list = new List<SmartFormViewProperties>();
            foreach (SourceCode.Forms.Authoring.Property prop in properties)
            {
                list.Add(new SmartFormViewProperties
                {
                    name = prop.Name,
                    value = prop.Value,
                  

                });

            }
            return list;
        }
    }
}
