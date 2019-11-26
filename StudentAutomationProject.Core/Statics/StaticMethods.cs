using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAutomationProject.Core.Statics
{
    public static class StaticMethods
    {
        public static string LayoutPicker(int userType)
        {
            var layout = "";
            switch (userType)
            {
                case 1:
                    return layout = "~/Views/_StudentAffairsLayout.cshtml";
                case 2:
                    return layout = "~/Views/_TeacherLayout.cshtml";
                case 3:
                    return layout = "~/Views/_StudentLayout.cshtml";
                default:
                    break;
            }
            return layout;
        }
    }
}
