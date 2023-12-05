using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tymakov14
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DeveloperAndOrganisationInfoAttribute : Attribute
    {
        private string developerName;
        private string developmentOrganisation;
        public string DeveloperName 
        {
            get
            {
                return developerName;
            }
        }
        public string DevelopmentOrganisation 
        { 
            get
            {
                return developmentOrganisation;
            }
        }

        public DeveloperAndOrganisationInfoAttribute(string developer, string organisation)
        {
            developerName = developer;
            developmentOrganisation = organisation;
        }
    }
}
