﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Uroboro.Common.Models;
using Uroboro.DAL.InMemory.Repos.Todo;

namespace Uroboro.BL.Managers.Todo
{
    public class TodoItemsManager : ITodoItemsManager
    {
        private readonly ITodoItemsRepo _repo;

        public TodoItemsManager(ITodoItemsRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<TodoItem>> Read()
        {
            var result = await _repo.Read();
            return result;
        }

        public async Task<TodoItem> Details(long? id)
        {
            var result = await _repo.Details(id);
            return result;
        }

        public async Task<TodoItem> Create(TodoItem todoItem)
        {
            var result = await _repo.Create(todoItem);
            return result;
        }

        public async Task<TodoItem> Update(TodoItem todoItem)
        {
            var itemById = await _repo.Details(todoItem.Id);
            if (itemById == null)
            {
                return itemById;
            }
            var result = await _repo.Update(todoItem);
            return result;
        }

        public async Task<long?> Delete(long id)
        {
            var itemById = await _repo.Details(id);
            if (itemById == null)
            {
                return null;
            }
            var result = await _repo.Delete(id);
            return result;
        }
    }
}