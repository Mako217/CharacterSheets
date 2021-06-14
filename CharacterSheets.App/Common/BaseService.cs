using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheets.App.Abstract;
using CharacterSheets.Domain;
using CharacterSheets.Domain.Common;
using Newtonsoft.Json;


namespace CharacterSheets.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }
        protected string path;
        protected string directory;
        protected string fileName;

        public BaseService()
        {
            Items = new List<T>();
            directory = @"CharacterSheets.App\Data\";
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
            SaveDataToFile();

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
            if (path != null)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                var resultJson = JsonConvert.SerializeObject(Items, settings);
                File.WriteAllText(path, resultJson.ToString());
            }

        }



        public void CreateFileIfNotExists()
        {

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (File.Exists(path))
            {
                ReadDataFromFile();
            }
            else
            {
                File.Create(path);
            }
        }

        public virtual IEnumerable<T> GetValidItems()
        {
            throw new NotImplementedException();
        }

        public void ReadDataFromFile()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            List<T> list = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path), settings);
            if (list != null)
            {
                Items = list;
            }
        }

    }
}
