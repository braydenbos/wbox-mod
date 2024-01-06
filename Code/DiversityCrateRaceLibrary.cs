using HarmonyLib;
using System;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;
using ReflectionUtility;
using System.Threading;
using System.Text;
using System.IO;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System.Reflection.Emit;
using ai;

namespace DiversityCrate{
    class DiversityCrateRaceLibrary
    {
        internal static List<string> defaultRaces = new List<string>(){
            "human", "elf", "orc", "dwarf"
        };

        internal static List<string> human = new List<string>(){
            "human"
        };

        internal static List<string> additionalRaces = new List<string>(){
            "goblin", "hive", "lizard"
        };
        
        internal void init(){

            var goblin = AssetManager.raceLibrary.clone("goblin", "human");
            goblin.civ_baseCities = 2;
            goblin.civ_base_army_mod  = 0.9f;
            goblin.civ_base_zone_range = 3;
            goblin.culture_rate_tech_limit = 5;
            goblin.culture_knowledge_gain_per_intelligence = 1.0f;
            goblin.build_order_id = "kingdom_base";
            goblin.path_icon = "ui/Icons/iconGoblins";
            goblin.nameLocale = "Goblins";
            goblin.banner_id= "orc";
            goblin.main_texture_path = "races/goblin/";
            goblin.name_template_city = "orc_city";
            goblin.name_template_kingdom = "orc_kingdom";
            goblin.name_template_culture = "orc_culture";
            goblin.name_template_clan = "orc_clan";
            goblin.hateRaces = List.Of<string>(new string[]
		    {
			SK.human,SK.elf,SK.orc,SK.dwarf
		    });
            goblin.production = new string[] { "bread","ale","tea" };
            goblin.skin_citizen_male = List.Of<string>(new string[] {	
			"unit_male_1"});
            goblin.skin_citizen_female = List.Of<string>(new string[] {
 			"unit_female_1"});
            goblin.skin_warrior = List.Of<string>(new string[] {
  			"unit_warrior_1"});
            goblin.nomad_kingdom_id = $"nomads_{goblin.id}";
            goblin.preferred_weapons.Clear();
            AssetManager.raceLibrary.CallMethod("setPreferredStatPool", "diplomacy#1,warfare#5,stewardship#1,intelligence#2" );
            AssetManager.raceLibrary.CallMethod("setPreferredFoodPool", "meat#5,fish#4,ale#3,bread#2,berries#1");
            AssetManager.raceLibrary.CallMethod("addPreferredWeapon", "bow", 5);
            AssetManager.raceLibrary.CallMethod("addPreferredWeapon", "stick", 4);
            AssetManager.raceLibrary.CallMethod("addPreferredWeapon", "spear", 3);
            AssetManager.raceLibrary.CallMethod("addPreferredWeapon", "sword", 2);
            AssetManager.raceLibrary.addBuildingOrderKey(SB.order_tent, "tent_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_0, "house_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_1, "1house_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_2, "2house_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_3, "3house_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_4, "4house_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_5, "5house_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_hall_0, "hall_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_hall_1, "1hall_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_hall_2, "2hall_goblin");
            AssetManager.raceLibrary.addBuildingOrderKey(SB.order_windmill_0, "windmill_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_windmill_1, "windmill_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_docks_0, "fishing_docks_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_docks_1, "docks_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_watch_tower, "watch_tower_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_barracks, "barracks_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_temple, "temple_goblin");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_statue, SB.statue);
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_well, SB.well);
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_bonfire, SB.bonfire);
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_mine, SB.mine);
            //Reflection.CallStaticMethod(typeof(BannerGenerator), "loadTexturesFromResources", "goblin");

            
            var hive = AssetManager.raceLibrary.clone("hive", "human");
            hive.civ_baseCities =  7;
            hive.civ_base_army_mod  = 0.9f;
            hive.civ_base_zone_range = 6;
            hive.culture_rate_tech_limit = 7;
            hive.culture_knowledge_gain_per_intelligence = 2.0f;
            hive.build_order_id = "kingdom_base";
            hive.path_icon = "ui/Icons/iconHive";
            hive.nameLocale = "Hives";
            hive.banner_id= "dwarf";
            hive.main_texture_path = "races/hive/";
            hive.name_template_city = "dwarf_city";
            hive.name_template_kingdom = "dwarf_kingdom";
            hive.name_template_culture = "dwarf_culture";
            hive.name_template_clan = "dwarf_clan";
            hive.production = new string[] { "tea" };
            hive.skin_citizen_male = List.Of<string>(new string[] {	
			"unit_male_1"});
            hive.skin_citizen_female = List.Of<string>(new string[] {
 			"unit_female_1"});
            hive.skin_warrior = List.Of<string>(new string[] {
  			"unit_warrior_1"});
            hive.nomad_kingdom_id = $"nomads_{hive.id}";
            hive.preferred_weapons.Clear();
            AssetManager.raceLibrary.CallMethod("setPreferredStatPool", "diplomacy#2,warfare#5,stewardship#1,intelligence#2" );
            AssetManager.raceLibrary.CallMethod("setPreferredFoodPool", "meat#5,fish#4,berries#1");
            AssetManager.raceLibrary.CallMethod("addPreferredWeapon", "stick", 5);
            AssetManager.raceLibrary.CallMethod("addPreferredWeapon", "spear", 10);
            AssetManager.raceLibrary.CallMethod("addPreferredWeapon", "sword", 2);
            AssetManager.raceLibrary.CallMethod("addPreferredWeapon", "bow", 1);
            AssetManager.raceLibrary.addBuildingOrderKey(SB.order_tent, "tent_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_0, "house_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_1, "1house_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_2, "2house_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_3, "3house_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_4, "4house_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_5, "5house_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_hall_0, "hall_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_hall_1, "1hall_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_hall_2, "2hall_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_windmill_0, "windmill_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_windmill_1, "windmill_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_docks_0, "fishing_docks_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_docks_1, "docks_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_watch_tower, "watch_tower_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_barracks, "barracks_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_temple, "temple_hive");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_statue, SB.statue);
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_well, SB.well);
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_bonfire, SB.bonfire);
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_mine, SB.mine);


            var lizard = AssetManager.raceLibrary.clone("lizard", "human");
            lizard.civ_baseCities =  4;
            lizard.civ_base_army_mod  = 0.5f;
            lizard.civ_base_zone_range = 5;
            lizard.culture_rate_tech_limit = 5;
            lizard.culture_knowledge_gain_per_intelligence = 1.0f;
            lizard.build_order_id = "kingdom_base";
            lizard.path_icon = "ui/Icons/iconLizards";
            lizard.nameLocale = "Lizard";
            lizard.banner_id= "elf";
            lizard.main_texture_path = "races/lizard/";
            lizard.name_template_city = "elf_city";
            lizard.name_template_kingdom = "elf_kingdom";
            lizard.name_template_culture = "elf_culture";
            lizard.name_template_clan = "elf_clan";
            lizard.production = new string[] { "jam","pie","tea" };
            lizard.skin_citizen_male = List.Of<string>(new string[] {	
			"unit_male_1"});
            lizard.skin_citizen_female = List.Of<string>(new string[] {
 			"unit_female_1"});
            lizard.skin_warrior = List.Of<string>(new string[] {
  			"unit_warrior_1"});
            lizard.nomad_kingdom_id = $"nomads_{lizard.id}";
            lizard.preferred_weapons.Clear();
            AssetManager.raceLibrary.CallMethod("setPreferredStatPool", "diplomacy#3,warfare#5,stewardship#4,intelligence#2");
            AssetManager.raceLibrary.CallMethod("setPreferredFoodPool", "meat#5,fish#4,berries#1");
            AssetManager.raceLibrary.CallMethod("addPreferredWeapon", "axe", 10);
            AssetManager.raceLibrary.CallMethod("addPreferredWeapon", "sword", 5);
            AssetManager.raceLibrary.addBuildingOrderKey(SB.order_tent, "tent_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_0, "house_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_1, "1house_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_2, "2house_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_3, "3house_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_4, "4house_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_house_5, "5house_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_hall_0, "hall_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_hall_1, "1hall_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_hall_2, "2hall_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_windmill_0, "windmill_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_windmill_1, "windmill_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_docks_0, "fishing_docks_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_docks_1, "docks_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_watch_tower, "watch_tower_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_barracks, "barracks_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_temple, "temple_lizard");
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_statue, SB.statue);
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_well, SB.well);
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_bonfire, SB.bonfire);
		    AssetManager.raceLibrary.addBuildingOrderKey(SB.order_mine, SB.mine);

            var human = AssetManager.raceLibrary.get("human");
            human.hateRaces = List.Of<string>(new string[]
		    {
			goblin.id,SK.orc
		    });

            var elf = AssetManager.raceLibrary.get("elf");
            elf.hateRaces = List.Of<string>(new string[]
		    {
			goblin.id,SK.orc,SK.dwarf
		    });

            var orc = AssetManager.raceLibrary.get("orc");
            orc.hateRaces = List.Of<string>(new string[]
		    {
			goblin.id,SK.human,SK.elf,SK.dwarf
		    });

            var dwarf = AssetManager.raceLibrary.get("dwarf");
            dwarf.hateRaces = List.Of<string>(new string[]
		    {
			goblin.id,SK.orc,SK.elf
		    });
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ActorAnimationLoader), "loadAnimationBoat")]
        public static bool loadAnimationBoat_Prefix(ref string pTexturePath, ActorAnimationLoader __instance)
        {
        if (pTexturePath.EndsWith("_"))
        {
         pTexturePath = pTexturePath + "human";
         return true;
        }
        foreach (string race in Main.instance.addRaces)
        {
        if (race == "goblin")
         {
          pTexturePath = pTexturePath.Replace(race, "goblin");
         }
        else if (race == "hive")
         {
          pTexturePath = pTexturePath.Replace(race, "hive");
         }
        else if (race == "lizard")
         {
          pTexturePath = pTexturePath.Replace(race, "lizard");
         }
        else if (race == "gnome")
         {
          pTexturePath = pTexturePath.Replace(race, "gnome");
         }
        else if (race == "angel")
         {
          pTexturePath = pTexturePath.Replace(race, "angel");
         }
        else if (race == "demonic")
         {
          pTexturePath = pTexturePath.Replace(race, "demonic");
         }
        else
         {
          pTexturePath = pTexturePath.Replace(race, "human");
         }
        }
        return true;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(ActorAnimationLoader), "generateFrameData")]
        
        public static void generateFrameData_post(ActorAnimationLoader __instance,string pFrameString, AnimationContainerUnit pAnimContainer, Dictionary<string, Sprite> pFrames, string pFramesIDs)
        {

        }

        public static Sprite[] loadAllSprite(string path, bool withFolders = false)
        {
            string p = $"{Main.mainPath}/EmbededResources/{path}";
            DirectoryInfo folder = new DirectoryInfo(p);
            List<Sprite> res = new List<Sprite>();
            foreach (FileInfo file in folder.GetFiles("*.png"))
            {
                Sprite sprite = Sprites.LoadSprite($"{file.FullName}");
                sprite.name = file.Name.Replace(".png", "");
                res.Add(sprite);
            }
            foreach (DirectoryInfo cFolder in folder.GetDirectories())
            {
                foreach (FileInfo file in cFolder.GetFiles("*.png"))
                {
                    Sprite sprite = Sprites.LoadSprite($"{file.FullName}");
                    sprite.name = file.Name.Replace(".png", "");
                    res.Add(sprite);
                }
            }
            return res.ToArray();
        }
    }
}