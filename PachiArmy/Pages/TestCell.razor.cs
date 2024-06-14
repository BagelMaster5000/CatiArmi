using Microsoft.AspNetCore.Components;

namespace PachiArmy.Pages
{
    public partial class TestCell<TItem>
    {
        [Parameter]
        public TestRow<TItem> Row { get; set; } = default!;

        [Parameter]
        public RenderFragment ChildContent { get; set; } = default!;

        public void OnCheckChanged(object checkedValue)
        {
            System.Console.WriteLine((bool)checkedValue); // this reflects the correct state of the checkbox
            Row.Checked = (bool)checkedValue;
            StateHasChanged();
        }
    }
}