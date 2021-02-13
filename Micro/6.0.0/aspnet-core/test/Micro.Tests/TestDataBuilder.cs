using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Entities;
using Micro.EntityFrameworkCore;
using Micro.Tasks;

namespace Micro.Tests
{
    public class TestDataBuilder
    {
        private readonly MicroDbContext _context;

        public TestDataBuilder(MicroDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            var neo = new Person("Neo");
            _context.People.Add(neo);
            _context.SaveChanges();

            _context.Tasks.AddRange(
                new Task("Follow the white rabbit", "Follow the white rabbit in order to know the reality.", neo.Id),
                new Task("Clean your room") { State = TaskState.Completed }
            );
        }
    }
}
