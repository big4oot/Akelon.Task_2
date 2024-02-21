using System.Reflection;
using Akelon.Task_2.Domain.Common;
using Akelon.Task_2.Domain.Enums;
using Akelon.Task_2.Domain.Models;
using Akelon.Task_2.Utils;
using Akelon.Task_2.Utils.Attributes;
using ClosedXML.Excel;

namespace Akelon.Task_2.DAL
{
    public class ExcelContext : IDisposable
    {
        private readonly XLWorkbook _workbook;

        public ExcelContext(Config config)
        {
            try
            {
                _workbook = new XLWorkbook(config.FilePath);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Ошибка открытия файла. Проверьте правильность указанного пути до файла. \nЗакройте программы, использующие файл");
                return;
            }

            

            Products = GetTableData<Product>();
            Orders = GetTableData<Order>();
            Clients = GetTableData<Client>();
        }

        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Client> Clients { get; set; }

        public IEnumerable<T> GetTableData<T>() where T : ExcelData
        {
            var worksheet = GetWorksheet<T>();
            var properties = typeof(T).GetProperties();

            var data = new List<T>();

            var headers = worksheet.FirstRow().CellsUsed().Select(c => c.Value.ToString()).ToList();

            for (int row = 2; row <= worksheet.RowsUsed().Count(); row++)
            {
                var item = Activator.CreateInstance<T>();


                foreach (var prop in properties)
                {
                    var columnNameAttr =
                        (ColumnNameAttribute)prop.GetCustomAttribute(typeof(ColumnNameAttribute));

                    if (columnNameAttr != null)
                    {
                        var columnName = columnNameAttr.Name;
                        var columnIndex = headers.IndexOf(columnName);

                        if (columnIndex != -1)
                        {
                            var cellValue = worksheet.Cell(row, columnIndex + 1).Value.ToString();

                            if (prop.PropertyType == typeof(int))
                            {
                                prop.SetValue(item, int.Parse(cellValue));
                            }
                            else if (prop.PropertyType == typeof(string))
                            {
                                prop.SetValue(item, cellValue);
                            }
                            else if (prop.PropertyType == typeof(Unit))
                            {
                                prop.SetValue(item, (Unit)Enum.Parse(typeof(Unit), cellValue));
                            }
                            else if (prop.PropertyType == typeof(decimal))
                            {
                                prop.SetValue(item, decimal.Parse(cellValue));
                            }

                            if (prop.PropertyType == typeof(DateTimeOffset))
                            {
                                prop.SetValue(item, DateTimeOffset.Parse(cellValue));
                            }
                        }
                    }
                }

                item.Row = row;

                data.Add(item);
            }

            return data;
        }

        public bool UpdateValues<T>(T item) where T : ExcelData
        {
            var worksheet = GetWorksheet<T>();
            var properties = typeof(T).GetProperties();
            var headers = worksheet.FirstRow().CellsUsed().Select(c => c.Value.ToString()).ToList();

            var rowIdxToUpdate = item.Row;


            foreach (var prop in properties)
            {
                var columnNameAttr = (ColumnNameAttribute)prop.GetCustomAttribute(typeof(ColumnNameAttribute));

                if (columnNameAttr != null)
                {
                    var columnName = columnNameAttr.Name;
                    var columnIndex = headers.IndexOf(columnName);

                    if (columnIndex != -1)
                    {
                        var cellValue = "";

                        if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(decimal))
                        {
                            worksheet.Cell(rowIdxToUpdate, columnIndex + 1).Value = Convert.ToInt32(prop.GetValue(item));
                            continue;
                        }
                        else if (prop.PropertyType == typeof(string))
                        {
                            cellValue = (string)prop.GetValue(item);
                        }
                        else if (prop.PropertyType == typeof(Unit))
                        {
                            cellValue = ((Unit)prop.GetValue(item)).ToString();
                        }
                        else if (prop.PropertyType == typeof(DateTimeOffset))
                        {
                            cellValue = ((DateTimeOffset)prop.GetValue(item)).ToString();
                        }

                        worksheet.Cell(rowIdxToUpdate, columnIndex + 1).Value = cellValue;
                    }

                }
            }
            _workbook.Save();
            return true;
        }

        private IXLWorksheet GetWorksheet<T>() where T : ExcelData
        {
            var worksheetName = GetDisplayName<T>();
            var worksheet = _workbook.Worksheet(worksheetName);
            return worksheet;
        }

        private string GetDisplayName<T>() where T : ExcelData
        {
            WorksheetNameAttribute displayAttr =
                (WorksheetNameAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(WorksheetNameAttribute));
            return displayAttr.Name;
        }

        public void Dispose()
        {
            _workbook.Dispose();
        }
    }
}
