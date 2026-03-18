using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Layout;

public partial class MainLayout
{
    private bool collapseNavMenu = true;
    private Tuple<string, string>[]? breadcrumbLinks;

    private ErrorBoundary? errorBoundary;

    protected override void OnParametersSet()
    {
        errorBoundary?.Recover();

        GetBreadcrumbLinks();

        base.OnParametersSet();
    }

    private void GetBreadcrumbLinks()
    {
        var currentUrl = NavigationManager.Uri;
        var myUrl = currentUrl.Replace(NavigationManager.BaseUri, "");
        var path = myUrl.Split('/');
        var lastLink = new Tuple<string, string>(string.Empty, "Home".ToLower());

        var count = 1;
        breadcrumbLinks = [lastLink, .. path.Where(link => !string.IsNullOrWhiteSpace(link)).Select(link =>
        {
            count++;
            lastLink = new Tuple<string, string>($"{lastLink.Item1}/{link}", Uri.UnescapeDataString(link));
            return lastLink;
        })];
    }

    private void HandleFadeClick()
    {
        collapseNavMenu = true;
    }

    private void HandleChildClicks(bool value)
    {
        collapseNavMenu = value;
    }
}