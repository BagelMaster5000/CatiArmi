using Microsoft.AspNetCore.Components;

namespace PachiArmy.Pages
{
    public class TestRow<TItem>
    {
        public TItem Item { get; set; } = default!;
        public int Id { get; set; } = default!;
        public bool Checked = false;
    }

    public partial class Test<TItem>
    {
        [Parameter]
        public IList<TItem> Items { get; set; } = default!;

        [Parameter]
        public RenderFragment<TestRow<TItem>> TestBody { get; set; } = default!;

        public List<TestRow<TItem>> Rows { get; set; } = new();

        protected override void OnInitialized()
        {
            int i = 1;
            foreach (var item in Items)
            {
                var gridRow = new TestRow<TItem>()
                {
                    Id = i,
                    Item = item,
                };
                Rows.Add(gridRow);
                i++;
            }
        }
    }
}