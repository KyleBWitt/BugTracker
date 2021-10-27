using BugTracker2.DataAccess;
using BugTracker2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugTracker2.Models
{
    public class BugModel : IBugModel
    {
        public int BugID { get; set; }
        public string BugStatus { get; set; }
        public string BugDescription { get; set; }
        public DateTime CreatedOn { get; set; }

        public static int CreateBug(BugModel bug)
        {
            BugModel data = new()
            {
                BugStatus = "New",
                BugDescription = bug.BugDescription,
            };
            

            string sqlCreateBug = @$"INSERT INTO dbo.bugs (BugStatus, BugDescription) VALUES(@BugStatus, @BugDescription)";

            return SqlDataAccess.SaveData(sqlCreateBug, data);
        }

        public static List<BugModel> LoadBugs()
        {
            string sql = @"SELECT BugID, BugStatus, BugDescription, CreatedOn FROM dbo.bugs";

            return SqlDataAccess.LoadData<BugModel>(sql);
        }
    }
}
