using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Controls;
using TreeDataGridDemo.Models;

namespace TreeDataGridDemo.ViewModels
{
    public class DiffVM
    {
        public ObservableCollection<Diff> Diffs { get; set; } = new();
        public DiffVM() 
        {
            var rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                Diffs.Add(rand.Next()%2 == 0 ? new DiffA(): new DiffB());
            }

            var source = new HierarchicalTreeDataGridSource<Diff>(Diffs)
            {
                Columns =
                {
                    new HierarchicalExpanderColumn<Diff>(
                        new TemplateColumn<Diff>(
                            "Names", "Names"),
                        x => x.Children),
                }
            };

            source.RowSelection!.SingleSelect = false;
            Source = source;
        }

        public ITreeDataGridSource<Diff> Source { get; }
    }
}
