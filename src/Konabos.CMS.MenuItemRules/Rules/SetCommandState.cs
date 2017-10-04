using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Rules.Actions;
using Sitecore.Shell.Framework.Commands;

namespace Konabos.CMS.MenuItemRules.Rules
{
    public class SetCommandState<T> : RuleAction<T> where T : CommandRuleContext
    {
        public ID CommandStateId { get; set; }

        public override void Apply(T ruleContext)
        {
            var item = ruleContext.Item.Database.Items[this.CommandStateId];
            Assert.IsNotNull(item, "CommandState must be specfied in order to apply the SetCommandState action.");
            var commandState = CommandState.Hidden;
            switch (item.Name)
            {
                case "disabled":
                    commandState = CommandState.Disabled;
                    break;
                case "down":
                    commandState = CommandState.Down;
                    break;
                case "enabled":
                    commandState = CommandState.Enabled;
                    break;
                case "hidden":
                    commandState = CommandState.Hidden;
                    break;
            }
            ruleContext.CommandState = commandState;
        }
    }
}