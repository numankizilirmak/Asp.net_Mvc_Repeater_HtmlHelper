using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.Routing;
using System.Web.Mvc;
using System.Collections;
using Mvc5RepeaterHelper.Models;

namespace Mvc5RepeaterHelper.Helpers
{

   public static class Mvc5Repeater
    {
        private static string CurrentController { get; set; }
        private static int PageShowRange = 3;

        public static MvcHtmlString MvcRepeater<TModel>(this HtmlHelper<TModel> htmlHelper, int totalItemCount, int pageIndex, int pageSize = 2, RepeaterOptions options = null, bool hasPaging = true, bool hasExcelExport = true)

        {
            string detailMethodUrl = "/" + CurrentController + "/Detail";

            RouteData rd = htmlHelper.ViewContext.RouteData;
            CurrentController = rd.GetRequiredString("controller");

            TModel model = htmlHelper.ViewData.Model;
            IList list = model as IList;

            StringBuilder builder = new StringBuilder();
            builder.Append("<table class='table'>");
            bool hasExcludedItem = options != null && options.ExcludedList != null;
            object detailParameterValue = null;
            foreach (var item in list)
            {
                builder.Append("<tr>");
                List<PropertyInfo> properties = item.GetType().GetProperties().ToList();
                foreach (var property in properties)
                {
                    object value = item.GetType().GetProperty(property.Name).GetValue(item, null);
                    if (options.ExcludedList == null || !options.ExcludedList.Contains(property.Name))
                    {
                        if (value != null)
                        {
                            builder.Append("<td>");
                            builder.Append(value.ToString());
                            builder.Append("</td>");
                        }
                    }
                    if (options.IsDetailEnabled && property.Name == options.DetailParameterName)
                    {
                        detailParameterValue = value;
                    }
                }
                if (options.IsDetailEnabled)
                {
                    builder.Append("<td>");
                    builder.Append("<a href =" + options.DetailMethodName + "?" + options.DetailParameterName + "=" + detailParameterValue.ToString() + ">Detail</a >");
                    builder.Append("</td>");
                }
                builder.Append("</tr>");
            }
            builder.Append("</table>");
            builder.Append("</br>");
            if (hasPaging)
            {
                builder.Append(GetPaging(totalItemCount, pageSize, pageIndex));
                builder.Append("</br>");
            }
            if (hasExcelExport)
            {
                builder.Append(GetExcelExportBotton());
            }

            return MvcHtmlString.Create(builder.ToString());
        }

        private static string GetExcelExportBotton()
        {
            string excelMethodUrl = "/" + CurrentController + "/ExportExcel";
            return "<a href ='" + excelMethodUrl + "' >Export To Excel </a >";
        }

        public static string GetPaging(int totalItemCount, int pageSize, int pageIndex)
        {
            if (totalItemCount > 0)
            {
                int maxItem = (totalItemCount / pageSize) + (totalItemCount % pageSize == 0 ? 0 : 1);
                bool isLastItem = false;
                int startIndex = 1;
                if (pageIndex != 1)
                {
                    isLastItem = PageShowRange % pageIndex == 0 ? true : false;

                    if (pageIndex >= PageShowRange)
                    {
                        startIndex = pageIndex - ((pageIndex % PageShowRange) - 1);
                    }
                }
                string pagingMethodUrl = "/" + CurrentController + "/Page";
                string items = string.Empty;
                int renderItemsLength = startIndex + PageShowRange - 1;
                if ((pageIndex + 1) >= maxItem)
                {
                    renderItemsLength = maxItem;
                }

                for (int counter = startIndex; counter <= renderItemsLength; counter++)
                {
                    string cssClass = pageIndex == counter ? "active" : "passive";
                    items += "<li class='" + cssClass + "'><a href = '" + pagingMethodUrl + "?pageIndex=" + counter + "'>" + counter + "</a></li>";
                }

                return GetPagerContent(pagingMethodUrl, items, pageIndex, maxItem);
            }
            return string.Empty;
        }

        private static string GetPagerContent(string pagingMethodUrl, string items, int pageIndex, int maxItem)
        {
            return @"<nav class='numbering animated wow slideInRight' data-wow-delay='.5s'><ul class='pagination paging'>
                    <li>
                        <a href = '#' aria-label='Previous'>
                            <span aria-hidden='true'>&laquo;</span>
                        </a>
                    </li>
                    <li ><a href ='" + pagingMethodUrl + "?pageIndex=" + (pageIndex == 1 ? 1 : (pageIndex - 1)) + "'>Previous<span class='sr-only'>(current)</span></a></li>"
                    + items + "<li><a href = '" + pagingMethodUrl + "?pageIndex=" + (maxItem == pageIndex ? pageIndex : pageIndex + 1) + @"' > Next <span class='sr-only'>(current)</span></a></li>
                        <li>
                        <a href = '#' aria-label='Next'>
                            <span aria-hidden='true'>&raquo;</span>
                        </a>
                    </li>
                </ul>
            </nav>";
        }


    }
}
