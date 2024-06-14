using Microsoft.AspNetCore.Components;

namespace PachiArmy.Pages
{
    public partial class TestCell<TItem>
    {
        [CascadingParameter]
        public Test<TItem> Owner { get; set; } = default!;

        [Parameter]
        public TestRow<TItem> Row { get; set; } = default!;

        [Parameter]
        public RenderFragment ChildContent { get; set; } = default!;

        public void OnCheckChanged(object checkedValue)
        {
            Row.Checked = (bool)checkedValue;
            Owner.Refresh();
        }
    }
}