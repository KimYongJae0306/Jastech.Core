using System;
using System.Data;
using System.IO;
using System.Linq;

namespace Jastech.Framework.Util.Helper
{
    public static class FileHelper
    {
        public static void DeleteFilesInDirectory(string directory, string searchPattern, int day)
        {
            DirectoryInfo di = new DirectoryInfo(directory);    // 인자값으로 들어온 절대 주소를 객체로 정의합니다.
            Dirs(di, searchPattern, day);                 // 삭제를 시작합니다.
        }

        private static void Dirs(DirectoryInfo dirinfo, string searchPattern, int day)
        {
            DirectoryInfo[] di = dirinfo.GetDirectories(); // 받은 주소의 하위 폴더 주소들을 반환합니다.

            if (di.Length < 1) // 반환받은 주소가 없을 경우 빠져나갑니다.
            {
                return;
            }

            for (int i = 0; i < di.Length; i++) // 반환받은 주소의 수 만큼 반복문을 실행시킵니다.
            {
                if (di[i].GetFiles().Count<FileInfo>() < 1 && di[i].GetDirectories().Count<DirectoryInfo>() < 1) // 하위 폴더가 빈 폴더면 삭제
                {
                    di[i].Delete();
                }
                else
                {
                    DelFiles(di[i], searchPattern, day); // 하위 폴더의 파일을 지움
                    Dirs(di[i], searchPattern, day); //  하위 폴더로 재귀호출
                }
            }
        }

        private static void DelFiles(DirectoryInfo diinfo, string searchPattern, int day)
        {
            try
            {
                DateTime dayAgoTime = DateTime.Now.AddSeconds(-(day * 3600 * 24)); // 인자로 받은 날을 객체로 정의합니다.
                DateTime agoTime = DateTime.Now.AddSeconds(-(1 * 3600 * 24)); // bmp 삭제를 위해 1일 지나면 삭제
                foreach (FileInfo fileName in diinfo.GetFiles()) // 해당 폴더에 파일 갯수 만큼 반복합니다.
                {
                    if (searchPattern.Equals(".*")) //확장명이 .*일 경우 모든 파일을 제거합니다.
                    {
                        DateTime dt = fileName.CreationTime; // 파일을 만들었던 시간을 객체로 정의합니다.

                        if (dayAgoTime > dt) // 사용자가 설정한 날보다 더 이전에 만들었을 경우
                        {
                            fileName.Delete(); // 파일을 제거합니다.
                        }
                    }
                    else if (fileName.Extension.Equals(searchPattern)) // 인자값의 확장명이 반복문의 확장명과 같을 경우 제거합니다.
                    {
                        DateTime dt = fileName.CreationTime; // 파일을 만들었던 시간을 객체로 정의합니다.
                        if (dayAgoTime > dt) // 사용자가 설정한 날보다 더 이전에 만들었을 경우
                        {
                            fileName.Delete(); // 파일을 제거합니다.
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public static DataTable CsvToDataTable(string fullPath)
        {
            DataTable dataTable = new DataTable();

            if (fullPath.ToLower().Contains(".csv") == false)
                return dataTable;

            using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    for (int rowIndex = 0; !sr.EndOfStream; rowIndex++)
                    {
                        if (rowIndex == 0)
                        {
                            string[] header = sr.ReadLine().Split(',');
                            foreach (string columnName in header.Where(name => name != ""))
                                dataTable.Columns.Add(columnName);
                        }
                        else
                        {
                            string[] body = sr.ReadLine().Split(',');
                            dataTable.Rows.Add(body);
                        }
                    }
                    sr.Close();
                }
            }

            return dataTable;
        }
    }
}
