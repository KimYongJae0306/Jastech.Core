﻿using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jastech.Framework.Users
{
    public class UserHandler
    {
        [JsonProperty]
        public List<User> UserList { get; set; } = new List<User>();

        public void AddUser(User user)
        {
            UserList.Add(user);
        }

        public void ClearUser()
        {
            UserList.Clear();
        }

        public User GetUser(AuthorityType type)
        {
            foreach (var user in UserList)
            {
                if (user.Type == type)
                    return user;
            }

            User tempUser = new User();
            UserList.Add(tempUser);

            return tempUser;
        }

        public User GetUser(string id)
        {
            foreach (var user in UserList)
            {
                if (user.Id == id)
                    return user;
            }
            return null;
        }

        public void Save(string filePath)
        {
            JsonConvertHelper.Save(filePath, this);
        }

        public void Load(string filePath)
        {
            if (File.Exists(filePath))
            {
                UserHandler temp = new UserHandler();
                JsonConvertHelper.LoadToExistingTarget(filePath, this);
            }
        }

        public void RemoveMaker()
        {
            List<User> makerList = UserList.Where(x => x.Type == AuthorityType.Maker).ToList();
            foreach (var maker in makerList)
                UserList.Remove(maker);
        }

        public UserHandler DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as UserHandler;
        }
    }
}
