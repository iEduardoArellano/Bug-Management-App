﻿using Bug_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Management_App.Interfaces
{
    public interface IProjects
    {
        IEnumerable<Projects> GetProjectsInDb();

        void CreateProject(Projects projectToCreate);
    }
}
