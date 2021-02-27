﻿namespace Uroboro.Common.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public override string ToString()
        {
            return $"Id=[{Id}],Name=[{Name}],IsComplete=[{IsComplete}]";
        }
    }
}
