using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.EntityFrameworkCore;
using Micro.Tasks;

namespace Micro.Tests.Tasks
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
            _context.Tasks.AddRange(
                new Task("Follow the white rabbit", "Follow the white rabbit in order to know the reality."),
                new Task("Clean your room") { State = TaskState.Completed }
            );
        }
    }
}
