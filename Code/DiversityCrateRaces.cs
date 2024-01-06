using System;
using System.Linq;
using System.Collections.Generic;
using NCMS.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using ReflectionUtility;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Beebyte.Obfuscator;
using HarmonyLib;

namespace DiversityCrate{
    class DiversityCrateRaces
    {
        public static void init(){

            var goblin = AssetManager.actor_library.clone("unit_goblin", "unit_human");
            goblin.base_stats[S.max_age] = 25;
            goblin.base_stats[S.max_children] = 8f;
            goblin.setBaseStats(100, 15, 65, 5, 10, 50, 5);
            goblin.base_stats[S.attack_speed] = 60;
            goblin.nameLocale = "Goblins";
            goblin.nameTemplate = "orc_name";
            goblin.race = "goblin";
            goblin.icon = "iconGoblins";
            goblin.zombieID = "zombie";
		    goblin.fmod_spawn = "event:/SFX/UNITS/Orc/OrcSpawn";
		    goblin.fmod_attack = "event:/SFX/UNITS/Orc/OrcAttack";
		    goblin.fmod_idle = "event:/SFX/UNITS/Orc/OrcIdle";
		    goblin.fmod_death = "event:/SFX/UNITS/Orc/OrcDeath";
            goblin.body_separate_part_head = false;
            goblin.disableJumpAnimation = true;
            goblin.color = Toolbox.makeColor("#FFC984");
            AssetManager.actor_library.CallMethod("loadShadow", goblin);
            Localization.addLocalization(goblin.nameLocale, goblin.nameLocale);

            var babygoblin = AssetManager.actor_library.clone("baby_goblin", "unit_goblin");
            babygoblin.base_stats[S.speed] = 10f;
            babygoblin.animation_idle = "walk_3";
            babygoblin.growIntoID = "unit_goblin";
            babygoblin.body_separate_part_head = false;
            babygoblin.body_separate_part_hands = false;
            babygoblin.take_items = false;
            babygoblin.baby = true;
            babygoblin.disableJumpAnimation = true;
            babygoblin.color_sets = goblin.color_sets;
            AssetManager.actor_library.CallMethod("addTrait", "peaceful");
            AssetManager.actor_library.CallMethod("loadShadow", babygoblin);


            var hive = AssetManager.actor_library.clone("unit_hive", "unit_human");
            hive.base_stats[S.max_age] = 40;
            hive.base_stats[S.max_children] = 4f;
            hive.setBaseStats(100, 15, 40, 0, 5, 92, 0);
            hive.nameLocale = "Hives";
            hive.nameTemplate = "dwarf_name";
            hive.race = "hive";
            hive.icon = "iconHive";
            hive.zombieID = "zombie";
            hive.fmod_spawn = "event:/SFX/UNITS/Dwarf/DwarfSpawn";
		    hive.fmod_attack = "event:/SFX/UNITS/Dwarf/DwarfAttack";
		    hive.fmod_idle = "event:/SFX/UNITS/Dwarf/DwarfIdle";
		    hive.fmod_death = "event:/SFX/UNITS/Dwarf/DwarfDeath";
            hive.disableJumpAnimation = true;
            hive.body_separate_part_head = false;
            hive.color = Toolbox.makeColor("#FFCDB9");
            AssetManager.actor_library.CallMethod("loadShadow", hive);
            Localization.addLocalization(hive.nameLocale, hive.nameLocale);

            var babyhive = AssetManager.actor_library.clone("baby_hive", "unit_hive");
            babyhive.base_stats[S.speed] = 10f;
            babyhive.body_separate_part_head = false;
            babyhive.body_separate_part_hands = false;
            babyhive.take_items = false;
            babyhive.baby = true;
            babyhive.can_turn_into_demon_in_age_of_chaos = false;
            babyhive.canTurnIntoIceOne = true;
            babyhive.disableJumpAnimation = true;
            babyhive.animation_idle = "walk_3";
            babyhive.growIntoID = "unit_hive";
            babyhive.color_sets = hive.color_sets;
            AssetManager.actor_library.CallMethod("addTrait", "peaceful");
            AssetManager.actor_library.CallMethod("addTrait", "evil");
            AssetManager.actor_library.CallMethod("loadShadow", babyhive);


            var lizard = AssetManager.actor_library.clone("unit_lizard", "unit_human");
            lizard.base_stats[S.max_age] = 80;
            lizard.base_stats[S.max_children] = 3f;
            lizard.setBaseStats(70, 20, 50, 0, 10, 85, 0);
            lizard.nameLocale = "Lizard";
            lizard.nameTemplate = "elf_name";
            lizard.race = "lizard";
            lizard.icon = "iconLizards";
            lizard.zombieID = "zombie";
            lizard.fmod_spawn = "event:/SFX/UNITS/Elf/ElfSpawn";
		    lizard.fmod_attack = "event:/SFX/UNITS/Elf/ElfAttack";
		    lizard.fmod_idle = "event:/SFX/UNITS/Elf/ElfIdle";
		    lizard.fmod_death = "event:/SFX/UNITS/Elf/ElfDeath";
            lizard.color = Toolbox.makeColor("#1EC3A5");
            lizard.disableJumpAnimation = true;
            lizard.body_separate_part_head = false;
            AssetManager.actor_library.CallMethod("loadShadow", lizard);
            Localization.addLocalization(lizard.nameLocale, lizard.nameLocale);

            var babylizard = AssetManager.actor_library.clone("baby_lizard", "unit_lizard");
            babylizard.base_stats[S.speed] = 10f;
            babylizard.body_separate_part_head = false;
            babylizard.body_separate_part_hands = false;
            babylizard.take_items = false;
            babylizard.baby = true;
            babylizard.can_turn_into_demon_in_age_of_chaos = false;
            babylizard.canTurnIntoIceOne = true;
            babylizard.disableJumpAnimation = true;
            babylizard.animation_idle = "walk_3";
            babylizard.growIntoID = "unit_lizard";
            babylizard.color_sets = lizard.color_sets;
            AssetManager.actor_library.CallMethod("addTrait", "peaceful");
            AssetManager.actor_library.CallMethod("addTrait", "savage");
            AssetManager.actor_library.CallMethod("loadShadow", babylizard);
        }
    }
}