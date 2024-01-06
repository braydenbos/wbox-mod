using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ReflectionUtility;
using System.Reflection;
using HarmonyLib;
using Newtonsoft.Json;
using static Config;

namespace DiversityCrate
{
    class DiversityCrateButtons
    {
        public static void init()
        {
            DiversityCrateTab.createTab("Button Tab_DiversityCrate", "Tab_DiversityCrate", "DiversityCrate", "Spawn Diversity Crate races directly in your world!!", -150);
            loadButtons();
        }

        private static void loadButtons()
        {
            PowersTab diversitycrateTab = getPowersTab("DiversityCrate");

            #region races

            var goblin = new GodPower();
            goblin.id = "spawngoblin";
            goblin.showSpawnEffect = true;
            goblin.multiple_spawn_tip = true;
            goblin.actorSpawnHeight = 3f;
            goblin.name = "spawngoblin";
            goblin.spawnSound = "spawnelf";
            goblin.actor_asset_id = "unit_goblin";
            goblin.click_action = new PowerActionWithID(callSpawnUnit);
            AssetManager.powers.add(goblin);

            var buttongoblin = NCMS.Utils.PowerButtons.CreateButton(
            "spawngoblin",
            Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.units.icongoblins.png"),
            "The Goblins",
            "The Great Race of Goblins",
            new Vector2(72, 18),
            ButtonType.GodPower, 
            diversitycrateTab.transform, 
            null
            );

            var hive = new GodPower();
            hive.id = "spawnhive";
            hive.showSpawnEffect = true;
            hive.multiple_spawn_tip = true;
            hive.actorSpawnHeight = 3f;
            hive.name = "spawnhive";
            hive.spawnSound = "spawnelf";
            hive.actor_asset_id = "unit_hive";
            hive.click_action = new PowerActionWithID(callSpawnUnit);
            AssetManager.powers.add(hive);

            var buttonhive = NCMS.Utils.PowerButtons.CreateButton(
            "spawnhive",
            Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.units.iconhive.png"),
            "The Hives",
            "The Great Race of Hives",
            new Vector2(72, -18),
            ButtonType.GodPower, 
            diversitycrateTab.transform,
            null
            );

            var lizard = new GodPower();
            lizard.id = "spawnlizard";
            lizard.showSpawnEffect = true;
            lizard.multiple_spawn_tip = true;
            lizard.actorSpawnHeight = 3f;
            lizard.name = "spawnlizard";
            lizard.spawnSound = "spawnelf";
            lizard.actor_asset_id = "unit_lizard";
            lizard.click_action = new PowerActionWithID(callSpawnUnit);
            AssetManager.powers.add(lizard);

            var buttonlizard = NCMS.Utils.PowerButtons.CreateButton(
            "spawnlizard",
            Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.units.iconlizards.png"),
            "The Lizard",
            "The Great Race Of Lizard",           
            new Vector2(108, 18),
            ButtonType.GodPower, 
            diversitycrateTab.transform,
            null
            );

            #endregion

        }
        public static bool callSpawnUnit(WorldTile pTile, string pPowerID)
        {
            AssetManager.powers.CallMethod("spawnUnit", pTile, pPowerID);
            return true;
        }
        private static PowersTab getPowersTab(string id)
		{
		GameObject gameObject = GameObjects.FindEvenInactive("Tab_" + id);
		return gameObject.GetComponent<PowersTab>();
        }
    }
}