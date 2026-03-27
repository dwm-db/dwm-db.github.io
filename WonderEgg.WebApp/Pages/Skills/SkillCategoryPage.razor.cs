using Microsoft.AspNetCore.Components;
using WonderEgg.Core;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Pages.Skills
{
    public partial class SkillCategoryPage
    {
        [Parameter]
        public required string CategoryName { get; set; }

        private bool dataLoaded => (skills is not null);

        private Skill[]? skills;

        protected override async Task OnParametersSetAsync()
        {
            CategoryName = Uri.UnescapeDataString(CategoryName);

            if (Enum.IsDefined(typeof(SkillCategory), CategoryName) || Enum.IsDefined(typeof(SkillCategory), int.TryParse(CategoryName, out var value) ? value : string.Empty))
            {
                var _category = Enum.Parse<SkillCategory>(CategoryName);
                CategoryName = _category.ToJsonString();
                skills = await DataService.GetSkillsByCategoryAsync(_category);
            }

            if (!dataLoaded)
            {
                NavigationManager.NavigateTo("/404");
            }
        }
    }
}
