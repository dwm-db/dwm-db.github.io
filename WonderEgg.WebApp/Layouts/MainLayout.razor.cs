namespace WonderEgg.WebApp.Layouts;

public partial class MainLayout
{
    private ErrorBoundary? ErrorBoundary { get; set; }

    private readonly OrderedDictionary<string, string> BreadcrumbLinks = [];

    protected override void OnParametersSet()
    {
        ErrorBoundary?.Recover();

        GetBreadcrumbLinks();

        base.OnParametersSet();
    }

    private void GetBreadcrumbLinks()
    {
        var currentUrl = NavigationManager.Uri;
        var myUrl = currentUrl.Replace(NavigationManager.BaseUri, "");
        var path = myUrl.Split('/');
        var lastLink = string.Empty;

        BreadcrumbLinks.Clear();
        BreadcrumbLinks.Add("home", lastLink);
        foreach (var link in path.Where(p => !string.IsNullOrWhiteSpace(p)))
        {
            lastLink = $"{lastLink}/{link}";
            BreadcrumbLinks.Add(Uri.UnescapeDataString(link.Split('?').FirstOrDefault() ?? string.Empty), lastLink);
        }
    }
}