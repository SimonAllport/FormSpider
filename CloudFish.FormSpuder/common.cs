using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFish.FormSpider
{


    public class SmartFormViewSml
    {
        public string name
        {
            get;
            set;
        }
        public string displayname
        {
            get;
            set;
        }

        public string description
        {
            get;
            set;
        }

        public Guid guid
        {
            get;
            set;
        }
        public int version
        {
            get;
            set;
        }


    }

  public   class SmartFormView
    {
        public string name
        {
            get;
            set;
        }
        public string displayname
        {
            get;
            set;
        }

        public string description
        {
            get;
            set;
        }

        public Guid guid
        {
            get;
            set;
        }


        public int version
        {
            get;
            set;
        }

        public string theme
        {
            get;
            set;
        }

    }

    public class SmartFormViewProperties
    {
        public string name
        {

            get;
            set;
        }

        public string value
        {

            get;
            set;
        }
    }


    public class SmartFormViewControls
    {
        public string name
        {
            get;
            set;
        }

        public string type
        {
            get;
            set;
        }

        public Guid guid
        {
            get;
            set;
        }
       
    }

    public class SmartFormViewParameters
    {
        public string name
        {
            get;
            set;
        }

        public string type
        {
            get;
            set;
        }

        public string defaultvalue
        {
            get;
            set;
        }
    }

    public class SmartFormViewEvents
    {
        public string name
        {
            get;
            set;
        }

        public string type
        {
            get;
            set;
        }

        public Guid GUID
        {
            get;
            set;
        }

        


    }
    public class SmartFromViewHandlers
    {

        public string Name
        {

            get;
            set;
        }

        public Guid GUID
        {

            get;
            set;
        }

    }

    public class SmartFormViewConditions
    {
       

        public Guid GUID
        {

            get;
            set;
        }

    }

    public class SmartFormViewActions
    {
        public Guid GUID
        {

            get;
            set;
        }

      

        public Guid viewguid
        {
            get;
            set;
        }

        public Guid formguid
        {
            get;
            set;
        }

        public string method
        {
            get;
            set;
        }

        public string executiontype
        {
            get;
            set;
        }

        public Guid controlguid
        {
            get;
            set;
        }

        public string actiontype
        {
            get;
            set;
        }
    }


    public class SmartFormViewActionParameters
    {

      



        public string targettype
        {

            get;
            set;
        }
        public string targetpath
        {

            get;
            set;
        }
        public string targetid
        {

            get;
            set;
        }

        public string sourcevalue
        {

            get;
            set;
        }

        public string sourcetype
        {

            get;
            set;
        }
        public string sourcepath
        {

            get;
            set;
        }

        public string sourceid
        {

            get;
            set;
        }
    }


    public class SmartFormViewActionValidation
    {

        public string status
        {
            get;
            set;
        }

       
    }

    public class SmartFormViewActionValidationMessage
    {

        public string message { get; set; }
    }

}