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


        public List<SmartFormViewProperties> ArtefactStyleProperties(SourceCode.Forms.Authoring.Styling.StyleCollection styles)
        {
            List<SmartFormViewProperties> list = new List<SmartFormViewProperties>();
            foreach (SourceCode.Forms.Authoring.Property prop in styles)
            {
                list.Add(new SmartFormViewProperties
                {
                    name = prop.Name,
                    value = prop.Value,


                });

            }
            return list;
        }


        public List<SmartFormViewProperties> ArtefactConditionalStyleProperties(SourceCode.Forms.Authoring.Styling.ConditionalStyleCollection styles)
        {
            List<SmartFormViewProperties> list = new List<SmartFormViewProperties>();
            foreach (SourceCode.Forms.Authoring.Property prop in styles)
            {
                list.Add(new SmartFormViewProperties
                {
                    name = prop.Name,
                    value = prop.Value,


                });

            }
            return list;
        }

        public SmartFormViewProperties ArtefactControlExpressions(SourceCode.Forms.Authoring.ControlExpression expression)
        {
            SmartFormViewProperties prop = new SmartFormViewProperties();


            prop.name = expression.Name;
            prop.value = expression.Expression.ExpressionType.ToString();


             
            return prop;
        }


        public List<SmartObjectProperty> GetSmartObjectMethods(SourceCode.SmartObjects.Management.SmartMethodInfoCollection methods)
        {
            List<SmartObjectProperty> list = new List<SmartObjectProperty>();
            foreach (SourceCode.SmartObjects.Management.SmartMethodInfo info in methods)
            {

                list.Add(new SmartObjectProperty
                {

                    Description = info.Metadata.Description.ToString(),
                    Name = info.Name,
                    Type = info.Type.ToString(),
                    Transaction = info.Transaction.ToString(),
                    displayname = info.Metadata.DisplayName
                });

            }

            return list;
        }


         public List<SmartObjectProperty> GetSmartObjectProperties(SourceCode.SmartObjects.Management.SmartPropertyInfoCollection properties)
        {

            List<SmartObjectProperty> list = new List<SmartObjectProperty>();

            foreach (SourceCode.SmartObjects.Management.SmartPropertyInfo info in properties)
            {

                list.Add(new SmartObjectProperty
                {

                    Description = info.Metadata.Description.ToString(),
                    Name = info.Name,
                    Type = info.Type.ToString(),
                    isUnique = info.IsUnique,
                    displayname = info.Metadata.DisplayName

                });

            }

            return list;
        }
    }
}
