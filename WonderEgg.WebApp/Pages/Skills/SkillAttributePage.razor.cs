using Microsoft.AspNetCore.Components;
using WonderEgg.Core;
using WonderEgg.Core.Models;

namespace WonderEgg.WebApp.Pages.Skills
{
    public partial class SkillAttributePage
    {
        [Parameter]
        public required string AttributeName { get; set; }

        private bool dataLoaded => (skills is not null);

        private Skill[]? skills;

        protected override async Task OnParametersSetAsync()
        {
            AttributeName = Uri.UnescapeDataString(AttributeName);

            if (Enum.IsDefined(typeof(SkillAttribute), AttributeName) || Enum.IsDefined(typeof(SkillAttribute), int.TryParse(AttributeName, out var value) ? value : string.Empty))
            {
                var _attribute = Enum.Parse<SkillAttribute>(AttributeName);
                AttributeName = _attribute.ToJsonString();
                skills = await DataService.GetSkillsByAttributeAsync(_attribute);
            }

            if (!dataLoaded)
            {
                NavigationManager.NavigateTo("/404");
            }
        }
    }
}
