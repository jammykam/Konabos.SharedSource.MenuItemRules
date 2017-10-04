using System.Collections.Generic;
using Sitecore.Data.Items;
using Sitecore.Rules;
using Sitecore.SecurityModel;
using Sitecore.Shell.Framework.Commands;
using Konabos.CMS.MenuItemRules.Rules;

namespace Konabos.CMS.MenuItemRules.Command
{
    public abstract class RulesBasedMenuCommand : Sitecore.Shell.Framework.Commands.Command
    {
        private readonly string rulesFolder = "/sitecore/system/Settings/Rules/Context Menu Items/Rules";

        public override CommandState QueryState(CommandContext context)
        {
            if (context.Items.Length != 1)
                return CommandState.Hidden;

            Item ruleItem;
            var ruleContext = new CommandRuleContext { Item = context.Items[0] };
            string cotextRulesFolder = string.Format("{0}/{1}", rulesFolder, ItemUtil.ProposeValidItemName(this.Name));

            using (new SecurityDisabler())
            {
                ruleItem = ruleContext.Item.Database.GetItem(cotextRulesFolder);
                if (ruleItem == null)
                    return CommandState.Hidden;
            }

            RuleList<CommandRuleContext> rules = RuleFactory.GetRules<CommandRuleContext>(new List<Item> { ruleItem },  "Rule");

            if (rules == null)
                return CommandState.Hidden;

            rules.Run(ruleContext);
            return ruleContext.CommandState;
        }
    }
}