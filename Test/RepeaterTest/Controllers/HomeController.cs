using RepeaterTest.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RepeaterTest.Controllers
{
    public class HomeController : Controller
    {
        public int PageIndex
        {
            get
            {
                if (TempData["pageIndex"] != null)
                {
                    return (int)TempData["pageIndex"];
                }
                return 1;
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RepeaterTest()
        {
            List<RepeaterTestModel> testList = GetData();
            ViewBag.TotalCount = 22;
            return View(testList);
        }
        /// <summary>
        /// paging action method
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult Page(int pageIndex = 1)
        {
            TempData["pageIndex"] = pageIndex;
            return RedirectToAction("RepeaterTest");
        }
        /// <summary>
        /// row detail action method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int id = 1)
        {
            return RedirectToAction("RepeaterTest");
        }
        /// <summary>
        /// excel export action method
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportExcel()
        {
            Export();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// gets test data 
        /// </summary>
        /// <returns></returns>
        public List<RepeaterTestModel> GetData()
        {
            List<RepeaterTestModel> testList = new List<RepeaterTestModel>();
            if (PageIndex == 1)
            {
                testList.Add(new RepeaterTestModel { Id = 1, Name = "Numan", Surname = "Kızılırmak" });
                testList.Add(new RepeaterTestModel { Id = 3, Name = "Ayşe", Surname = "Kızılırmak" });
            }
            if (PageIndex == 2)
            {
                testList.Add(new RepeaterTestModel { Id = 2, Name = "Ali", Surname = "Kızılırmak" });
                testList.Add(new RepeaterTestModel { Id = 4, Name = "Merve", Surname = "Kızılırmak" });
            }
            if (PageIndex == 3)
            {
                testList.Add(new RepeaterTestModel { Id = 2, Name = "3", Surname = "3" });
                testList.Add(new RepeaterTestModel { Id = 4, Name = "3", Surname = "3" });
            }
            if (PageIndex == 4)
            {
                testList.Add(new RepeaterTestModel { Id = 2, Name = "4", Surname = "4" });
                testList.Add(new RepeaterTestModel { Id = 4, Name = "4", Surname = "4" });
            }
            if (PageIndex == 5)
            {
                testList.Add(new RepeaterTestModel { Id = 2, Name = "5", Surname = "5" });
                testList.Add(new RepeaterTestModel { Id = 4, Name = "5", Surname = "5" });
            }
            if (PageIndex == 6)
            {
                testList.Add(new RepeaterTestModel { Id = 2, Name = "6", Surname = "6" });
                testList.Add(new RepeaterTestModel { Id = 4, Name = "6", Surname = "6" });
            }
            if (PageIndex == 7)
            {
                testList.Add(new RepeaterTestModel { Id = 2, Name = "7", Surname = "7" });
                testList.Add(new RepeaterTestModel { Id = 4, Name = "7", Surname = "7" });
            }
            if (PageIndex == 8)
            {
                testList.Add(new RepeaterTestModel { Id = 2, Name = "8", Surname = "8" });
                testList.Add(new RepeaterTestModel { Id = 4, Name = "8", Surname = "8" });
            }
            return testList;
        }
        private void Export()
        {
            //var dataTable = new DataTable("bla Raporu");

            //DataColumn[] columns = new DataColumn[2];

            //columns[0] = new DataColumn("Id", typeof(string));
            //columns[1] = new DataColumn("İsim", typeof(string));

            //dataTable.Columns.AddRange(columns);

            //var list = GetExcelData();

            //list.ForEach(forbiddenImeiItem =>
            //{
            //    DataRow row = dataTable.NewRow();
            //    row["Id"] = forbiddenImeiItem.Id;
            //    row["İsim"] = forbiddenImeiItem.Name;

            //    dataTable.Rows.Add(row);
            //});

            //WebHelper.ExportExcelFromDataTable(dataTable, string.Format("bla_Raporu_{0}", DateTime.Now));
        }
    }
}