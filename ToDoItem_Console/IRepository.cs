using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToDoItem_Console
{
    public interface IRepository
    {
        Task<ToDoItem> CreateAsync(ToDoItem toDoItem);
        Task<ToDoItem> GetAsync(long id);
        Task<List<ToDoItem>> QueryAsync(long id, bool? done);
        Task<List<ToDoItem>> QueryAllAsync();

    }
}
