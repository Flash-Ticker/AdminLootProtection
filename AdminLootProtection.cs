using System;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("AdminLootProtection", "RustFlash", "1.0.0")]
    [Description("Prevents looting admins and specified groups")]

    class AdminLootProtection : CovalencePlugin
    {
        private Dictionary<string, bool> lootProtection = new Dictionary<string, bool>();
        private const string permissionName = "adminlootprotection.use";

        private void Init()
        {
            permission.RegisterPermission(permissionName, this);
        }

        private object CanLootPlayer(BasePlayer looter, BasePlayer target)
        {
            if (looter == null || target == null)
                return true;

            if (permission.UserHasPermission(looter.UserIDString, permissionName))
                return "You are not allowed to loot this player.";

            if (IsAdmin(target))
                return "You are not allowed to loot this admin.";


            return null;
        }

        private bool IsAdmin(BasePlayer player)
        {
            if (player == null)
                return false;

            if (player.IsAdmin)
                return true;


            return false;
        }
    }
}
