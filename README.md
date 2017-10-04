# Konabos.SharedSource.MenuItemRules
## Rules-based Context Item Menu Visibility

1. Add a new class and create a command, inheriting from `Konabos.CMS.MenuItemRules.Command.RulesBasedMenuCommand` and implement the `Execute` method.

```csharp
using Konabos.CMS.MenuItemRules.Command;
using Sitecore.Shell.Framework.Commands;

namespace Konabos.CMS.MenuItemRules
{
    public class MenuCustom : RulesBasedMenuCommand
    {
        public override void Execute(CommandContext context)
        {
            throw new NotImplementedException();
        }
    }
}
```

2. Register the command in config, for example:
 
```xml
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
  <sitecore>
    <commands>
      <command name="menu:custom" type="Konabos.CMS.MenuItemRules.CustomMenu, Konabos.CMS.MenuItemRules"/>
      <command name="menu:another" type="Konabos.CMS.MenuItemRules.AnotherMenu, Konabos.CMS.MenuItemRules"/>
    </commands>
  </sitecore>
</configuration>
```
 
3. Create the menu item in the `Core` database under: `/sitecore/content/Applications/Content Editor/Context Menues/Default`. Set the **Message** field to your command, e.g. `menu:custom(id=$Target)`


4. Create a `Rule` under `/sitecore/system/Settings/Rules/Context Menu Items/Rules` in the master database. The Rule name should match the sanitized command name which does not include any invaid item name characters. Using the above as an example: **menucustom** and **menuanother**.

5. Edit the rule, set your Conditions and then set the Action to **"set the command state to enabled"** in order to make the menu item visible.

If you want to integrate the code into your own project - the items have been serialized or there is a TDS project or there is an items-only package. You need to update the `Type` field in **/sitecore/system/Settings/Rules/Definitions/Elements/Context Menu Rules/Set Command State** in master database.
