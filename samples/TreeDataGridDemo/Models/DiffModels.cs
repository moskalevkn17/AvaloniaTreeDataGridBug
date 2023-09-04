using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDataGridDemo.Models
{
    public class Diff
    {
        public virtual string Name { get; set; } = "Base";
        public List<Diff> Children => new List<Diff>() { new(), new() };
    }

    public class DiffA : Diff
    {
        public override string Name { get; set; } = "Class A";
    }

    public class DiffB : Diff
    { public override string Name { get; set; } = "B B B"; }
}
