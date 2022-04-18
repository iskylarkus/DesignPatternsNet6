using ClosedXML.Excel;
using System.Data;

namespace WebApp.ChainOfResponsibility.ChainOfResponsibility
{
    public class ExcelProcessHandler<T> : ProcessHandler
    {
        private DataTable GetTable(object o)
        {
            var table = new DataTable();

            var type = typeof(T);

            type.GetProperties().ToList().ForEach(p => table.Columns.Add(p.Name, p.PropertyType));

            var list = o as List<T>;

            list.ForEach(x =>
            {
                var values = type.GetProperties().Select(p => p.GetValue(x, null)).ToArray();

                table.Rows.Add(values);
            });

            return table;
        }

        public override object handle(object o)
        {
            var wb = new XLWorkbook();

            var ds = new DataSet();

            ds.Tables.Add(GetTable(o));

            wb.Worksheets.Add(ds);

            var excelMemoryStream = new MemoryStream();

            wb.SaveAs(excelMemoryStream);

            return base.handle(excelMemoryStream);
        }
    }
}
