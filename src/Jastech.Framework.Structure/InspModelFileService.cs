using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Structure
{
    public class InspModelFileService
    {
        public List<InspModel> GetModelList(string modelPath)
        {
            List<InspModel> modelList = new List<InspModel>();

            string[] dirs = Directory.GetDirectories(modelPath);
            for (int i = 0; i < dirs.Length; i++)
            {
                InspModel inspModel = new InspModel();
                string path = Path.Combine(dirs[i], "InspModel.json");
                JsonConvertHelper.LoadToExistingTarget<InspModel>(path, inspModel);
                modelList.Add(inspModel);
            }

            return modelList;
        }

        public bool IsExistModel(string modelPath, string modelName)
        {
            string[] dirs = Directory.GetDirectories(modelPath);
            for (int i = 0; i < dirs.Length; i++)
            {
                if(Path.GetFileName(dirs[i]) == modelName)
                {
                    return true;
                }
            }
            return false;
        }

        public void CreateModel(string modelPath, InspModel inspModel)
        {
            if (modelPath == "")
                return;

            string folderPath = Path.Combine(modelPath, inspModel.Name);

            if (Directory.Exists(folderPath) == false)
                Directory.CreateDirectory(folderPath);

            Save(modelPath, inspModel);
        }

        public bool Save(string modelPath, InspModel model)
        {
            if (model == null)
                return false;

            string dir = Path.Combine(modelPath, model.Name);

            if (Directory.Exists(dir) == false)
                Directory.CreateDirectory(dir);

            string fileName = Path.Combine(dir, "InspModel.json");
            JsonConvertHelper.Save(fileName, model);

            return true;
        }

        public bool Edit(string modelPath, string prevModelName, string newModelName, string newDescription)
        {
            string prevDir = Path.Combine(modelPath, prevModelName);
            string prevFilePath = Path.Combine(prevDir, "InspModel.json");

            InspModel inspModel = new InspModel();
            if (File.Exists(prevFilePath))
            {
                JsonConvertHelper.LoadToExistingTarget(prevFilePath, inspModel);

                inspModel.Name = newModelName;
                inspModel.ModifiedDate = DateTime.Now;
                inspModel.Description = newDescription;

                Save(modelPath, inspModel);
                Directory.Delete(prevDir, true);

                return true;
            }

            return false;
        }

        public void Delete(string modelPath, string modelName)
        {
            string prevDir = Path.Combine(modelPath, modelName);
            Directory.Delete(prevDir, true);
        }

        public bool Copy(string modelPath, string prevModelName, string newModelName)
        {
            string prevDir = Path.Combine(modelPath, prevModelName);
            string prevFilePath = Path.Combine(prevDir, "InspModel.json");

            InspModel inspModel = new InspModel();
            if (File.Exists(prevFilePath))
            {
                JsonConvertHelper.LoadToExistingTarget(prevFilePath, inspModel);

                DateTime time = DateTime.Now;
                inspModel.Name = newModelName;
                inspModel.CreateDate = time;
                inspModel.ModifiedDate = time;

                Save(modelPath, inspModel);

                return true;
            }

            return false;
        }
    }
}
