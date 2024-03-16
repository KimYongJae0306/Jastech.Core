using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Jastech.Framework.Util.Helper
{
    public static class FileHelper
    {
        public static double CheckCapacity(string driveName)
        {
            double useRate = 0.0;

            DriveInfo[] driveInfo = DriveInfo.GetDrives();

            foreach (var drive in driveInfo)
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    if (drive.Name.Contains(driveName))
                    {
                        double totalSize = drive.TotalSize / 1024 / 1024 / 1024;
                        double freeSize = drive.AvailableFreeSpace / 1024 / 1024 / 1024;
                        double usageSize = totalSize - freeSize;

                        useRate = usageSize / totalSize;
                    }
                }
            }

            return useRate * 100;
        }

        public static DirectoryInfo GetOldDirectory(string directory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            return directoryInfo.GetDirectories().OrderBy(x => x.CreationTime).FirstOrDefault();
        }

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
                    DeleteFiles(di[i], searchPattern, day); // 하위 폴더의 파일을 지움
                    Dirs(di[i], searchPattern, day); //  하위 폴더로 재귀호출
                }
            }
        }

        private static void DeleteFiles(DirectoryInfo diinfo, string searchPattern, int day)
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
                            string[] header = sr.ReadLine().Split(',').Where(name => name != "").ToArray();
                            foreach (string columnName in header)
                                dataTable.Columns.Add(columnName);
                        }
                        else
                        {
                            string[] body = sr.ReadLine().Split(',').Where(data => data != "").ToArray();
                            dataTable.Rows.Add(body);
                        }
                    }
                    sr.Close();
                }
            }

            return dataTable;
        }

        public static void FindDirectoriesWithFiles(List<string> paths, DirectoryInfo directory)
        {
            if (directory.GetFiles().Length > 0)
                paths.Add(directory.FullName);
            else
            {
                foreach (var childDirectory in directory.GetDirectories())
                    FindDirectoriesWithFiles(paths, childDirectory);
            }
        }

        public static void FindDirectories(List<string> paths, DirectoryInfo directory)
        {
            foreach (var childDirectory in directory.GetDirectories())
                FindDirectories(paths, childDirectory);
        }

        public static List<string> GetDirectoryList(string directoryPath)
        {
            List<string> directoryList = new List<string>();

            DirectoryInfo path = new DirectoryInfo(directoryPath);
            DirectoryInfo[] dir = path.GetDirectories();

            for (int index = 0; index < dir.Length; index++)
                FindDirectoriesWithFiles(directoryList, dir[index]);

            return directoryList;
        }

        public static void KillViewerProcess(string processName, int durationMinute = 30)
        {
            foreach (var item in System.Diagnostics.Process.GetProcessesByName(processName))
            {
                if (DateTime.Now - item.StartTime >= new TimeSpan(0, durationMinute, 0))
                    item.Kill();

                System.Threading.Thread.Sleep(20);
            }
        }
    }
}
