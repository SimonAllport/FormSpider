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

    public class Smartformlist
    {

        public string Name
        { get; set; }

        public string Description
        { get; set; }

        public Guid guid
        { get; set; }

        public string displayname
        { get; set; }

        public string Url
        { get; set; }

        public string ArtefactType
        { get; set; }

        public string Service
        { get; set; }
        public string Version
        { get; set; }

        public string FormNumber
        { get; set; }

        public string ProcessMapNumber
        { get; set; }
    }

    public class SmartObject
    {

        public string Name
        { get; set; }

        public string Description
        { get; set; }

        public Guid guid
        { get; set; }

        public string displayname
        { get; set; }

        public Guid ServiceGUID
        { get; set; }

        public string ArtefactType
        { get; set; }

        public string Service
        { get; set; }
        public string Version
        { get; set; }

    }


    public class SmartObjectProperty
    {

        public string Name
        { get; set; }

        public string Description
        { get; set; }

       

        public string displayname
        { get; set; }

        public Boolean isUnique
        { get; set; }
        public string Transaction
        { get; set; }

        public string Type
        { get; set; }
        
    }



    public class WorkFlow
    {
        public int ProcessId
        { get; set; }

        public int Instances
        { get; set; }
        public string Name
        { get; set; }

        public string Description
        { get; set; }

        public Guid guid
        { get; set; }

        public string displayname
        { get; set; }

        public string MetaData
        { get; set; }

        public int Priority
        { get; set; }

        public int ProcSetID
        { get; set; }
        public string Version
        { get; set; }

    }

       public class WorkFlowDataFields
    {

        public string Name
        { get; set; }

        public string Category
        { get; set; }

       public string InitialValue
        { get; set; }

 public string Type
        { get; set; }

        public string MetaData
        { get; set; }

        public Boolean Hidden
        { get; set; }
       
            public Boolean Audit
        { get; set; }

            public Boolean OnDemand
            { get; set; }
    }


       public class WorkFlowActivities
    {

        public string Name
        { get; set; }

        public string Description
        { get; set; }

       public int ExpectedDuration
        { get; set; }

 public int ID
        { get; set; }

        public string MetaData
        { get; set; }

        public Boolean IsStart
        { get; set; }
       
            public int Priority
        { get; set; }

    }


       public class WorkFlowEvents
    {

        public string Name
        { get; set; }

        public string Description
        { get; set; }

       public int ExpectedDuration
        { get; set; }

 public int ID
        { get; set; }

        public string MetaData
        { get; set; }

        public Boolean IsStart
        { get; set; }
       
            public int Priority
        { get; set; }

                public Boolean UseTrans
        { get; set; }

              public int Pos
        { get; set; }

              public Guid Excep
        { get; set; }

               public string EventType
        { get; set; }

                public string CredentialUser
        { get; set; }

                public Guid Code
        { get; set; }
    }

}

