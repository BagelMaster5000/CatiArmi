using Microsoft.AspNetCore.Components;
using PachiArmy.Scripts;

namespace PachiArmy.Pages
{
    //public class TestRow<Pachimari>
    //{
    //    public Pachimari Pachi { get; set; } = default!;
    //    public int Id { get; set; } = default!;
    //    public bool Checked = false;
    //}

    public partial class Test
    {
        [Parameter]
        public List<Pachimari> Items { get; set; } = default!;

        //[Parameter]
        //public RenderFragment<Pachimari> TestBody { get; set; } = default!;

        public List<Pachimari> Rows { get; set; } = new();

        protected override void OnInitialized()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Rows.Add(Items[i]);
            }
        }

        public void Refresh()
        {
            StateHasChanged();
        }
    }
}