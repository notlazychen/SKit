using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Frontline.GameDesign
{
    public class ExcelReader
    {
        public static List<T> ReadFromFile<T>(string filename) where T : class, new()
        {
            string excelFileName = filename;
            string tmpFile = "~toolxlsx.tmp";
            File.Copy(excelFileName, tmpFile, true);
            IWorkbook workbook = null;
            try
            {
                workbook = new XSSFWorkbook(tmpFile);
                ISheet sheet = workbook.GetSheetAt(0);
                List<T> configInfos = new List<T>();
                Dictionary<PropertyInfo, int> properties = new Dictionary<PropertyInfo, int>();
                var props = typeof(T).GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    if (prop.GetCustomAttribute<IgnoreAttribute>() != null)
                    {
                        properties[prop] = -1;
                    }
                    else
                    {
                        properties[prop] = 0;
                    }
                }
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    var row = sheet.GetRow(i);
                    if (row == null)
                    {
                        continue;
                    }
                    if (i == 1)
                    {
                        foreach (var cell in row.Cells)
                        {
                            string cellName = cell.StringCellValue;
                            if (string.IsNullOrEmpty(cellName))
                            {
                                continue;
                            }
                            string propName = cellName.Substring(0, cellName.IndexOf(":", StringComparison.Ordinal));
                            var prop = properties.Keys.FirstOrDefault(p => p.Name == propName);

                            if (prop != null)
                            {
                                properties[prop] = cell.ColumnIndex;
                            }
                        }
                    }
                    else
                    {
                        var ladderConfig = new T();
                        bool failed = false;
                        foreach (var prop in properties)
                        {
                            if (prop.Value == -1)
                            {
                                continue;
                            }
                            var cell = row.GetCell(prop.Value);
                            if (cell == null)
                            {
                                continue;
                                //throw new Exception($"第{row.RowNum}行 缺失列{cellPair.Key.Name}:{cellPair.Value}");
                            }
                            try
                            {
                                if (prop.Key.PropertyType == typeof(int))
                                {
                                    if (cell.CellType == CellType.String)
                                    {
                                        int numb = int.Parse(cell.StringCellValue);
                                        prop.Key.SetValue(ladderConfig, numb);
                                    }
                                    else
                                    {
                                        prop.Key.SetValue(ladderConfig, Convert.ToInt32(cell.NumericCellValue));
                                    }
                                }
                                else if (prop.Key.PropertyType == typeof(double))
                                {
                                    prop.Key.SetValue(ladderConfig, Convert.ToDouble(cell.NumericCellValue));
                                }
                                else if (prop.Key.PropertyType == typeof(float))
                                {
                                    prop.Key.SetValue(ladderConfig, Convert.ToSingle(cell.NumericCellValue));
                                }
                                else if (prop.Key.PropertyType == typeof(bool))
                                {
                                    prop.Key.SetValue(ladderConfig, Convert.ToBoolean(cell.NumericCellValue));
                                }
                                //else if (cellPair.Key.PropertyType == typeof(int[]))
                                //{
                                //    string str = Convert.ToString(cell.StringCellValue).Trim(new[] { '[', ']' });
                                //    cellPair.Key.SetValue(ladderConfig, str);
                                //    //string[] val = str.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                //    //int[] valInts = val.Select(int.Parse).ToArray();
                                //    //cellPair.Key.SetValue(ladderConfig, valInts);
                                //}
                                else if (prop.Key.PropertyType == typeof(string))
                                {
                                    prop.Key.SetValue(ladderConfig, cell.StringCellValue);
                                }
                                else if (prop.Key.PropertyType == typeof(TimeSpan))
                                {
                                    if (cell.CellType == CellType.Numeric)
                                    {
                                        TimeSpan ts = TimeSpan.FromDays(cell.NumericCellValue);
                                        prop.Key.SetValue(ladderConfig, ts);
                                    }
                                    else
                                    {
                                        TimeSpan ts = TimeSpan.Parse(cell.StringCellValue);
                                        prop.Key.SetValue(ladderConfig, ts);
                                        string[] hms = cell.StringCellValue.Substring(cell.StringCellValue.IndexOf(".") + 1).Split(":");
                                        int h = int.Parse(hms[0]);
                                        int m = int.Parse(hms[1]);
                                        int s = int.Parse(hms[2]);
                                        if (h >= 24 || m >= 60 || s >= 60)
                                        {
                                            throw new Exception($"表格{filename} 第{cell.RowIndex}行 第{prop.Key.Name}:{prop.Value}列 [{ cell.StringCellValue }]时间格式不对");
                                        }
                                    }
                                }
                                else if (prop.Key.PropertyType == typeof(TimeSpan?))
                                {
                                    if (!string.IsNullOrEmpty(cell.StringCellValue))
                                    {
                                        TimeSpan ts = TimeSpan.Parse(cell.StringCellValue);
                                        prop.Key.SetValue(ladderConfig, ts);
                                        string[] hms = cell.StringCellValue.Substring(cell.StringCellValue.IndexOf(".") + 1).Split(":");
                                        int h = int.Parse(hms[0]);
                                        int m = int.Parse(hms[1]);
                                        int s = int.Parse(hms[2]);
                                        if (h >= 24 || m >= 60 || s >= 60)
                                        {
                                            throw new Exception($"表格{filename} 第{cell.RowIndex}行 第{prop.Key.Name}:{prop.Value}列 [{ cell.StringCellValue }]时间格式不对");
                                        }
                                    }
                                }
                                else if (prop.Key.PropertyType == typeof(DateTime?))
                                {
                                    if (!string.IsNullOrEmpty(cell.StringCellValue))
                                    {
                                        DateTime ts = DateTime.Parse(cell.StringCellValue);
                                        prop.Key.SetValue(ladderConfig, ts);
                                    }
                                }
                                else if (prop.Key.PropertyType == typeof(JsonObject<int[]>))
                                {
                                    if (!string.IsNullOrEmpty(cell.StringCellValue))
                                    {
                                        var arr = cell.StringCellValue.Trim(new[] { '[', ']' }).Split(',');
                                        var ts = arr.Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToArray();
                                        prop.Key.SetValue(ladderConfig, new JsonObject<int[]>(ts));
                                    }
                                }
                                else if (prop.Key.PropertyType == typeof(JsonObject<float[]>))
                                {
                                    if (!string.IsNullOrEmpty(cell.StringCellValue))
                                    {
                                        var arr = cell.StringCellValue.Trim(new[] { '[', ']' }).Split(',');
                                        var ts = arr.Where(x => !string.IsNullOrEmpty(x)).Select(float.Parse).ToArray();
                                        prop.Key.SetValue(ladderConfig, new JsonObject<float[]>(ts));
                                    }
                                }
                                else if (prop.Key.PropertyType == typeof(JsonObject<List<int>>))
                                {
                                    if (!string.IsNullOrEmpty(cell.StringCellValue))
                                    {
                                        var arr = cell.StringCellValue.Trim(new[] { '[', ']' }).Split(',');
                                        var ts = arr.Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToList();
                                        prop.Key.SetValue(ladderConfig, new JsonObject<List<int>>(ts));
                                    }
                                }
                                else
                                {
                                    throw new Exception("不支持的类型");
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception($"表格{filename} 第{cell.RowIndex}行 第{prop.Key.Name}:{prop.Value}列 [{ cell.StringCellValue }]有问题请查看", ex);
                            }
                        }
                        if (!failed)
                        {
                            configInfos.Add(ladderConfig);
                        }
                    }
                }
                return configInfos;
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close();
                    var files = Directory.GetFiles("./");
                    foreach (var file in files)
                    {
                        if (file.EndsWith(".tmp"))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
        }
    }
}