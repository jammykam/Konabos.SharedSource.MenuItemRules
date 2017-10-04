using Sitecore.Rules;
using Sitecore.Shell.Framework.Commands;

namespace Konabos.CMS.MenuItemRules.Rules
{
    public class CommandRuleContext : RuleContext
    {
        public CommandState CommandState { get; set; } = CommandState.Hidden;
    }
}