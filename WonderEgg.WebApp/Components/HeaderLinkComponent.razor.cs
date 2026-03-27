using Microsoft.AspNetCore.Components;

namespace WonderEgg.WebApp.Components;

public partial class HeaderLinkComponent
{
    [Parameter]
    public required string href { get; set; }

    [Parameter]
    public required string text { get; set; }

    [Parameter]
    public required bool h1 { get; set; } = false;

    private string css => "col-12 justify-content-center align-content-center align-items-center" + " " + (h1 ? "h1" : "h2");
}