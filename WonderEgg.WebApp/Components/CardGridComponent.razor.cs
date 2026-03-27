using Microsoft.AspNetCore.Components;

namespace WonderEgg.WebApp.Components;

public partial class CardGridComponent
{
    [Parameter]
    public required Tuple<string, string>[] categories { get; set; }

    [Parameter]
    public required string href { get; set; }

    [Parameter]
    public bool halfSize { get; set; } = false;

    private bool dataLoaded => (categories is not null && categories.Length > 0);

    private string css => halfSize ? "col-6 col-sm-6 col-md-4 col-lg-6 col-xl-4 col-xxl-4" : "col-6 col-sm-6 col-md-4 col-lg-3 col-xl-2 col-xxl-2";
}
