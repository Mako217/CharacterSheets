using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheets.App.Abstract;
using CharacterSheets.Domain.Common;

namespace CharacterSheets.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

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
            return item.Id;
        }


        public int UpdateItem(T item)
        {
            var entity = GetItemById(item.Id);
            if (entity != null)
            {
                entity = item;
            }

            return entity.Id;
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        public T GetItemById(int id)
        {
            var entity = Items.FirstOrDefault(p => p.Id == id);
            return entity;
        }

    }
}
