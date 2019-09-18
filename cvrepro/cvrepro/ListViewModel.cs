using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace cvrepro
{
    public class Item
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }

    public class ListViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Item> _items;
        private int _counter = 0;

        public ObservableRangeCollection<Item> Items {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public ICommand AddItemsCommand { get; set; }
        public ICommand ClearItemsCommand { get; set; }

        private IEnumerable<Item> Build(int number)
        {
            return Enumerable.Range(0, number).Select(_ => new Item
            {
                Id = (_counter++).ToString("D5"),
                Description = $"Created @ {DateTime.Now.ToLongTimeString()}"
            });
        }

        public ListViewModel()
        {
            // works
            // _items = new ObservableRangeCollection<Item>(Build(1));

            // blank view and scroll to top
            _items = new ObservableRangeCollection<Item>();

            AddItemsCommand = new AsyncCommand(async () => {
                await Task.Delay(500);
                var batch = Build(20);
                _items.AddRange(batch);
            });

            ClearItemsCommand = new MvvmHelpers.Commands.Command(() => {
                _items.Clear();
            });
        }
    }
}
