//using System.Collections.Generic;
//using BugTracker2.DataAccess;
//using BugTracker2.Models;

//namespace BugTracker2.BusinessLogic
//{
//    public class BugProcessor
//    {
//        public static int CreateBug(BugModel bug)
//        {
//            BugModel data = new BugModel
//            {
//                BugStatus = "New",
//                BugDescription = bug.BugDescription,
//            };

//            string sqlCreateBug = @$"INSERT INTO dbo.bugs (BugStatus, BugDescription) VALUES(@BugStatus, @BugDescription)";

//            return SqlDataAccess.SaveData(sqlCreateBug, data);
//        }   

//        public static List<BugModel> LoadBugs()
//        {
//            string sql = @"SELECT BugID, BugStatus, BugDescription, CreatedOn FROM dbo.bugs";

//            return SqlDataAccess.LoadData<BugModel>(sql);
//        }
//    }
//}






