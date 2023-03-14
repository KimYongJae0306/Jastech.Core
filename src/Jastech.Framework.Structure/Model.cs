using Jastech.Framework.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Structure
{
    public class Model
    {
        public List<Recipe> RecipeList { get; set; } = new List<Recipe>();

        public void Load()
        {

        }

        public void Save(string filePath)
        {
            if (Directory.Exists(filePath) == false)
            {
                Directory.CreateDirectory(filePath);
            }
            //JsonHelper.Load<Model>(modelPath);
           //JsonHelper.Save(Path.Combine(filePath, "Model.cfg"), this);
        }
    }
}