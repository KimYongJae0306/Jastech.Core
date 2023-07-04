using Jastech.Framework.Util.Helper;
using System;
using System.IO;

namespace Jastech.Framework.Structure.Helper
{
    public static class ModelFileHelper
    {
        public static bool IsExistModel(string modelPath, string modelName)
        {
            string[] dirs = Directory.GetDirectories(modelPath);
            for (int i = 0; i < dirs.Length; i++)
            {
                if (Path.GetFileName(dirs[i]) == modelName)
                {
                    return true;
                }
            }
            return false;
        }

        public static void Save(string modelPath, InspModel inspModel)
        {
            if (modelPath == "")
                return;

            string folderPath = Path.Combine(modelPath, inspModel.Name);
            string fullPath = Path.Combine(folderPath, InspModel.FileName);

            if (Directory.Exists(folderPath) == false)
                Directory.CreateDirectory(folderPath);

            JsonConvertHelper.Save(fullPath, inspModel);
        }

        public static bool Edit(string modelPath, InspModel prevModel, InspModel editModel)
        {
            string prevDir = Path.Combine(modelPath, prevModel.Name);
            string prevFilePath = Path.Combine(prevDir, InspModel.FileName);

            if (File.Exists(prevFilePath))
            {
                string editDir = Path.Combine(modelPath, editModel.Name);

                if(prevDir != editDir)
                    Directory.Move(prevDir, editDir);

                // model 정보 변경
                prevModel.Name = editModel.Name;
                prevModel.ModifiedDate = DateTime.Now;
                prevModel.Description = editModel.Description;

                // 정보 변경 후 다시 저장
                Save(modelPath, prevModel);

                return true;
            }

            return false;
        }

        public static void Delete(string modelPath, string modelName)
        {
            string prevDir = Path.Combine(modelPath, modelName);
            Directory.Delete(prevDir, true);
        }
    }
}

