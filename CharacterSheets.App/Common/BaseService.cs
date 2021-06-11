using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheets.App.Abstract;
using CharacterSheets.Domain.Common;
using Newtonsoft.Json;


namespace CharacterSheets.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }
        protected string path;

        public BaseService()
        {
            Items = new List<T>();
        }

        public int GetNewId()
        {
            int newId;
            if (Items.Any())
            {
                newId = Items.OrderBy(p => p.Id).LastOrDefault().Id + 1;
            }
            else
            {
                newId = 1;
            }

            return newId;
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public int AddItem(T item)
        {
            Items.Add(item);
            if(path!=null)
            {
                SaveDataToFile();
            }
            return item.Id;
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
            SaveDataToFile();
        }

        public T GetItemById(int id)
        {
            var entity = Items.FirstOrDefault(p => p.Id == id);
            return entity;
        }

        public void SaveDataToFile()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var resultJson = JsonConvert.SerializeObject(Items, settings);
            File.WriteAllText(path, resultJson.ToString());
        }

        protected void ReadDataFromFile()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            Items = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path), settings);
        }

        protected void CreateFileIfNotExists()
        {
            if (File.Exists(path))
            {
                ReadDataFromFile();
            }
            else
            {
                File.Create(path);
            }
        }
    }
}
