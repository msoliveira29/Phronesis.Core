using OfficeOpenXml;
using System.Data;
using System.Reflection;

namespace Phronesis.Core.Infra.CrossCutting
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 31/05/2022.
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public static class ExcelTools
    {
        #region Attributes

        private static ExcelWorksheet? _worksheet;

        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pathExcelFile"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<T> ReadFromExcel<T>(MemoryStream stream) where T : new()
        {
            List<T> list = new();

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using ExcelPackage package = new(stream);
                ExcelWorkbook workbook = package.Workbook;
                if (workbook != null)
                {
                    _worksheet = workbook.Worksheets.FirstOrDefault();
                    if (_worksheet != null)
                    {
                        list = ReadExcelToList<T>();
                    }
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <remarks></remarks>
        private static List<T> ReadExcelToList<T>() where T : new()
        {
            List<T> collection = new();

            try
            {
                DataTable dt = new();

                foreach (var firstRowCell in new T().GetType().GetProperties().ToList())
                {
                    //Add table colums with properties of T
                    dt.Columns.Add(firstRowCell.Name);
                }

                for (int rowNum = 2; rowNum <= _worksheet.Dimension.End.Row; rowNum++)
                {
                    var wsRow = _worksheet.Cells[rowNum, 1, rowNum, _worksheet.Dimension.End.Column];
                    DataRow row = dt.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }

                //Get the colums of table
                var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();

                //Get the properties of T
                List<PropertyInfo> properties = new T().GetType().GetProperties().ToList();

                collection = dt.AsEnumerable().Select(row =>
                {
                    T item = Activator.CreateInstance<T>();
                    foreach (var pro in properties)
                    {
                        if (columnNames.Contains(pro.Name) || columnNames.Contains(pro.Name.ToUpper()))
                        {
                            PropertyInfo pI = item.GetType().GetProperty(pro.Name);
                            pro.SetValue(item, (row[pro.Name] == DBNull.Value) ? null : Convert.ChangeType(row[pro.Name], (Nullable.GetUnderlyingType(pI.PropertyType) == null) ? pI.PropertyType : Type.GetType(pI.PropertyType.GenericTypeArguments[0].FullName)));
                        }
                    }
                    return item;
                }).ToList();

            }
            catch (Exception)
            {
                throw;
            }

            return collection;
        }

        #endregion
    }
}
