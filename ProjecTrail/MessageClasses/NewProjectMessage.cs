using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjecTrail.Models;

namespace ProjecTrail.MessageClasses
{
    public class NewProjectMessage
    {
        public Project Project { get; }

        public NewProjectMessage(Project project)
        {
            Project = project;
        }
    }

}
