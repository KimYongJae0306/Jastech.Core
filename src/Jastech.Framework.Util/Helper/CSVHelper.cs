using System;
using System.Collections.Generic;
using System.IO;

namespace Jastech.Framework.Util.Helper
{
    public class CSVHelper
    {
        #region 필드
        private static string _csvDir = "";

        private static object _objLock = new object();
        #endregion

        #region 메서드
        public static void Initialize(string filePath = "")
        {
            if (filePath == "")
                _csvDir = Path.Combine(Directory.GetCurrentDirectory(), "History");
            else
                _csvDir = filePath;

            if (!Directory.Exists(_csvDir))
                Directory.CreateDirectory(_csvDir);
        }

        public static void WriteHeader(string csvPath, List<String> headerList)
        {
            try
            {
                string csvDirectory = csvPath.Substring(0, csvPath.LastIndexOf('\\'));
                string outputData = string.Empty;

                KillProcess(csvPath);

                if (!Directory.Exists(csvDirectory))
                    Directory.CreateDirectory(csvDirectory);

                if (!File.Exists(csvPath))
                {
                    lock (_objLock)
                    {
                        StreamWriter csv = new StreamWriter(csvPath, true);
                        using (csv)
                        {
                            for (int i = 0; i < headerList.Count; i++)
                            {
                                if (headerList.Count == i)
                                    outputData += headerList[i];
                                else
                                    outputData += headerList[i] + ",";
                            }
                            csv.WriteLine(outputData);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        //public static string GetCsvPath(string fileName)
        //{
        //    string csvPath = string.Format(@"{0}\{1}_{2:0000}{3:00}{4:00}.csv", _csvDir, fileName, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        //    return csvPath;
        //}

        public static void WriteData(string csvPath, List<string> inputData)
        {
            try
            {
                string outputData = string.Empty;

                KillProcess(csvPath);

                lock (_objLock)
                {
                    StreamWriter csvStreaWriter = new StreamWriter(csvPath, true);
                    using (csvStreaWriter)
                    {
                        for (int i = 0; i < inputData.Count; i++)
                        {
                            if (inputData.Count == i)
                                outputData += inputData[i];
                            else
                                outputData += inputData[i] + ",";
                        }

                        csvStreaWriter.WriteLine(outputData);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public static void WriteData(string csvPath, List<List<string>> inputDataList)
        {
            try
            {
                KillProcess(csvPath);

                lock (_objLock)
                {
                    StreamWriter csvStreaWriter = new StreamWriter(csvPath, true);
                    using (csvStreaWriter)
                    {
                        foreach (var datas in inputDataList)
                        {
                            string outputData = string.Empty;

                            for (int i = 0; i < datas.Count; i++)
                            {
                                if (datas.Count - 1 == i)
                                    outputData += datas[i].ToString();
                                else
                                    outputData += datas[i].ToString() + ",";
                            }

                            csvStreaWriter.WriteLine(outputData);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public static void WriteAllData(string csvPath, string[] headers, List<string[]> rowData)
        {
            try
            {
                KillProcess(csvPath);

                
                lock (_objLock)
                {
                    StreamWriter csvStreaWriter = new StreamWriter(csvPath, false);
                    using (csvStreaWriter)
                    {
                        string header = string.Empty;

                        for (int i = 0; i < headers.Length; i++)
                        {
                            if (i == headers.Length)
                                header += headers[i];
                            else
                                header += headers[i] + ",";
                        }

                        csvStreaWriter.WriteLine(header);

                        for (int rowIndex = 0; rowIndex < rowData.Count; rowIndex++)
                        {
                            string row = string.Empty;

                            for (int i = 0; i < rowData[rowIndex].Length; i++)
                            {
                                if (i == rowData[rowIndex].Length)
                                    row += rowData[rowIndex][i];
                                else
                                    row += rowData[rowIndex][i] + ",";

                            }

                            csvStreaWriter.WriteLine(row);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public static int GetRowCount(string csvPath)
        {
            try
            {
                //string strDir = csvpath.Substring(0, csvpath.LastIndexOf('\\'));

                if (!File.Exists(csvPath))
                    return 0;

                int ColCount;
                int RowCount;
                string[] Header;
                List<string[]> Rows;

                KillProcess(csvPath);

                lock (_objLock)
                {
                    StreamReader csvStreamReader = new StreamReader(csvPath);
                    using (csvStreamReader)
                    {
                        Rows = new List<string[]>();
                        Header = csvStreamReader.ReadLine().TrimEnd().Split(',');

                        while (!csvStreamReader.EndOfStream)
                        {
                            string[] Items = csvStreamReader.ReadLine().Trim().Split(',');
                            Rows.Add(Items);
                        }

                        ColCount = Header.Length;
                        RowCount = Rows.Count;
                    }
                }

                return RowCount;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
                return 0;
            }
        }

        public static Tuple<string[], List<string[]>> ReadData(string fileName)
        {
            try
            {
                //string csvPath = GetCsvPath(fileName);
                KillProcess(fileName);

                int ColCount;
                int RowCount;
                string[] Header;
                List<string[]> Rows;

                lock (_objLock)
                {
                    StreamReader csvStreamReader = new StreamReader(fileName);
                    using (csvStreamReader)
                    {
                        Rows = new List<string[]>();
                        Header = csvStreamReader.ReadLine().TrimEnd().Split(',');

                        while (!csvStreamReader.EndOfStream)
                        {
                            string[] Items = csvStreamReader.ReadLine().Trim().Split(',');
                            Rows.Add(Items);
                        }

                        ColCount = Header.Length;
                        RowCount = Rows.Count;
                    }
                }

                return new Tuple<string[], List<string[]>>(Header, Rows);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
                return null;
            }
        }

        private static void KillProcess(string filePath)
        {
            string fileName = Path.GetFileName(filePath);

            foreach (var item in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
            {
                if (item.MainWindowTitle.Contains(fileName))
                    item.Kill();
            }

            System.Threading.Thread.Sleep(100);
        }
        #endregion
    }
}
