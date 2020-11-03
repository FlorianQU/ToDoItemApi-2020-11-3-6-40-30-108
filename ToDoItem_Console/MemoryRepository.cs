using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoItem_Console
{
    public class MemoryRepository : IRepository
    {
        private readonly Dictionary<long, ToDoItem> _dic = new Dictionary<long, ToDoItem>();
        public MemoryRepository()
        {
            Init();
        }


        public async Task<ToDoItem> CreateAsync(ToDoItem toDoItem)
        {
            _dic[toDoItem.Id] = toDoItem;
            return toDoItem;
        }

        public async Task<ToDoItem> GetAsync(long id)
        {
            _dic.TryGetValue(id, out var item);
            return item;
        }



        public async Task<List<ToDoItem>> QueryAsync(long id, bool? done)
        {
            IEnumerable<ToDoItem> models = _dic.Values.ToList();

            models = models.Where(v => v.Id == id);

            if (done != null)
                models = models.Where(v => v.IsComplete == done.Value);

            return models.ToList();
        }

        public async Task<List<ToDoItem>> QueryAllAsync()
        {
            IEnumerable<ToDoItem> models = _dic.Values.ToList();
            return models.ToList();

        }

        private void Init()
        {
            for (var i = 0; i < 2; i++)
            {
                var item = new ToDoItem()
                {
                    Id = i,
                    Name = "${i}-item",
                    IsComplete = false
                };
                _dic[item.Id] = item;
            }
        }
    }
}
