using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSpiderTest
{
    class Program
    {
        static void Main(string[] args)
        {

            CloudFish.FormSpider.Views.ViewControls("Ad Hoc Task Details Edit");


            //foreach (CloudFish.FormSpider.SmartFormView form in CloudFish.FormSpider.Smartform.GetAllForms())
            //{

            //    Console.WriteLine("Form Name:" + form.displayname);

            //}

           Console.ReadLine();

        }
    }
}
