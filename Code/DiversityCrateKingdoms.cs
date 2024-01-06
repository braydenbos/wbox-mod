using System;
using System.Linq;
using System.Collections.Generic;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using ReflectionUtility;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using HarmonyLib;

namespace DiversityCrate{
    class DiversityCrateKingdoms
    {
        public static void init(){

            KingdomAsset human = AssetManager.kingdoms.get("human");
			KingdomAsset elf = AssetManager.kingdoms.get("elf");
			KingdomAsset orc = AssetManager.kingdoms.get("orc");
			KingdomAsset dwarf = AssetManager.kingdoms.get("dwarf");
            KingdomAsset nomads_human = AssetManager.kingdoms.get("nomads_human");
			KingdomAsset nomads_elf = AssetManager.kingdoms.get("nomads_elf");
			KingdomAsset nomads_orc = AssetManager.kingdoms.get("nomads_orc");
			KingdomAsset nomads_dwarf = AssetManager.kingdoms.get("nomads_dwarf");

            human.addEnemyTag("goblin");
            human.addEnemyTag("hive");
            human.addEnemyTag("lizard");
            human.addEnemyTag("nomads_goblin");
            human.addEnemyTag("nomads_hive");
            human.addEnemyTag("nomads_lizard");
            nomads_human.addEnemyTag("goblin");
            nomads_human.addEnemyTag("hive");
            nomads_human.addEnemyTag("lizard");
            nomads_human.addEnemyTag("nomads_goblin");
            nomads_human.addEnemyTag("nomads_hive");
            nomads_human.addEnemyTag("nomads_lizard");

            elf.addEnemyTag("goblin");
            elf.addEnemyTag("hive");
            elf.addEnemyTag("lizard");
            elf.addEnemyTag("nomads_goblin");
            elf.addEnemyTag("nomads_hive");
            elf.addEnemyTag("nomads_lizard");
            nomads_elf.addEnemyTag("goblin");
            nomads_elf.addEnemyTag("hive");
            nomads_elf.addEnemyTag("lizard");
            nomads_elf.addEnemyTag("nomads_goblin");
            nomads_elf.addEnemyTag("nomads_hive");
            nomads_elf.addEnemyTag("nomads_lizard");

            dwarf.addEnemyTag("goblin");
            dwarf.addEnemyTag("hive");
            dwarf.addEnemyTag("lizard");
            dwarf.addEnemyTag("nomads_goblin");
            dwarf.addEnemyTag("nomads_hive");
            dwarf.addEnemyTag("nomads_lizard");
            nomads_dwarf.addEnemyTag("goblin");
            nomads_dwarf.addEnemyTag("hive");
            nomads_dwarf.addEnemyTag("lizard");
            nomads_dwarf.addEnemyTag("nomads_goblin");
            nomads_dwarf.addEnemyTag("nomads_hive");
            nomads_dwarf.addEnemyTag("nomads_lizard");

            orc.addEnemyTag("goblin");
            orc.addEnemyTag("hive");
            orc.addEnemyTag("lizard");
            orc.addEnemyTag("nomads_goblin");
            orc.addEnemyTag("nomads_hive");
            orc.addEnemyTag("nomads_lizard");
            nomads_orc.addEnemyTag("goblin");
            nomads_orc.addEnemyTag("hive");
            nomads_orc.addEnemyTag("lizard");
            nomads_orc.addEnemyTag("nomads_goblin");
            nomads_orc.addEnemyTag("nomads_hive");
            nomads_orc.addEnemyTag("nomads_lizard");
            
            var goblin = new KingdomAsset();
            goblin.id = "goblin";
            goblin.civ = true;
            goblin.addTag("goblin");
            goblin.addFriendlyTag("goblin");
            goblin.addEnemyTag("good");
            goblin.addEnemyTag("neutral");
            goblin.addEnemyTag("bandits");
            goblin.addEnemyTag("human");
            goblin.addEnemyTag("dwarf");
            goblin.addEnemyTag("elf");
            goblin.addEnemyTag("orc");
            goblin.addEnemyTag("hive");
            goblin.addEnemyTag("lizard");
            AssetManager.kingdoms.add(goblin);
            World.world.kingdoms.CallMethod("newHiddenKingdom", goblin);

            var nomadsgoblin = new KingdomAsset();
            nomadsgoblin.id = "nomads_goblin";
            nomadsgoblin.nomads = true;
            nomadsgoblin.mobs = true;
            nomadsgoblin.addTag("goblin");
            nomadsgoblin.addFriendlyTag("goblin");
            nomadsgoblin.addEnemyTag("good");
            nomadsgoblin.addEnemyTag("neutral");
            nomadsgoblin.addEnemyTag("bandits");
            nomadsgoblin.addEnemyTag("human");
            nomadsgoblin.addEnemyTag("dwarf");
            nomadsgoblin.addEnemyTag("elf");
            nomadsgoblin.addEnemyTag("orc");
            nomadsgoblin.addEnemyTag("hive");
            nomadsgoblin.addEnemyTag("lizard");
            nomadsgoblin.default_kingdom_color = new ColorAsset("#38705C", "#38705C", "#38705C");
            AssetManager.kingdoms.add(nomadsgoblin);
            World.world.kingdoms.CallMethod("newHiddenKingdom", nomadsgoblin);


            var hive = new KingdomAsset();
            hive.id = "hive";
            hive.civ = true;
            hive.addTag("hive");
            hive.addFriendlyTag("hive");
            hive.addEnemyTag("neutral");
            hive.addEnemyTag("good");
            hive.addEnemyTag("bandits");
            hive.addEnemyTag("human");
            hive.addEnemyTag("elf");
            hive.addEnemyTag("orc");
            hive.addEnemyTag("dwarf");
            hive.addEnemyTag("goblin");
            hive.addEnemyTag("lizard");
            AssetManager.kingdoms.add(hive);
            World.world.kingdoms.CallMethod("newHiddenKingdom", hive);

            var nomadshives = new KingdomAsset();
            nomadshives.id = "nomads_hive";
            nomadshives.nomads = true;
            nomadshives.mobs = true;
            nomadshives.addTag("hive");
            nomadshives.addFriendlyTag("hive");
            nomadshives.addEnemyTag("neutral");
            nomadshives.addEnemyTag("good");
            nomadshives.addEnemyTag("bandits");
            nomadshives.addEnemyTag("human");
            nomadshives.addEnemyTag("dwarf");
            nomadshives.addEnemyTag("elf");
            nomadshives.addEnemyTag("orc");
            nomadshives.addEnemyTag("goblin");
            nomadshives.addEnemyTag("lizard");
            nomadshives.default_kingdom_color = new ColorAsset("#705338", "#705338", "#705338");
            AssetManager.kingdoms.add(nomadshives);
            World.world.kingdoms.CallMethod("newHiddenKingdom", nomadshives);


            var lizard = new KingdomAsset();
            lizard.id = "lizard";
            lizard.civ = true;
            lizard.addTag("lizard");
            lizard.addFriendlyTag("lizard");
            lizard.addEnemyTag("neutral");
            lizard.addEnemyTag("good");
            lizard.addEnemyTag("bandits");
            lizard.addEnemyTag("human");
            lizard.addEnemyTag("elf");
            lizard.addEnemyTag("dwarf");
            lizard.addEnemyTag("orc");
            lizard.addEnemyTag("goblin");
            lizard.addEnemyTag("hive");
            AssetManager.kingdoms.add(lizard);
            World.world.kingdoms.CallMethod("newHiddenKingdom", lizard);

            var nomadslizard = new KingdomAsset();
            nomadslizard.id = "nomads_lizard";
            nomadslizard.nomads = true;
            nomadslizard.mobs = true;
            nomadslizard.addTag("lizard");
            nomadslizard.addFriendlyTag("lizard");
            nomadslizard.addEnemyTag("neutral");
            nomadslizard.addEnemyTag("good");
            nomadslizard.addEnemyTag("bandits");
            nomadslizard.addEnemyTag("human");
            nomadslizard.addEnemyTag("dwarf");
            nomadslizard.addEnemyTag("elf");
            nomadslizard.addEnemyTag("orc");
            nomadslizard.addEnemyTag("goblin");
            nomadslizard.addEnemyTag("hive");
            nomadslizard.default_kingdom_color = new ColorAsset("#077049", "#077049", "#077049");
            AssetManager.kingdoms.add(nomadslizard);
            World.world.kingdoms.CallMethod("newHiddenKingdom", nomadslizard);
        }
    }
}