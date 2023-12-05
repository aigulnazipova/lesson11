using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tymakov14
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class DeveloperInfoAttribute : Attribute
    {
        private string developerName;
        private DateTime developmentDate;
        public string DeveloperName 
        {
            get
            {
                return developerName;   
            } 
        }
        public DateTime DevelopmentDate 
        {
            get
            {
                return developmentDate;
            }
     
        }

        public DeveloperInfoAttribute(string developerName, DateTime developmentDate)
        {
            this.developerName = developerName;
            this.developmentDate = developmentDate;
        }
        public DeveloperInfoAttribute(string developerName)
        {
            this.developerName = developerName;
            developmentDate = DateTime.Now;
        }
    }
}
