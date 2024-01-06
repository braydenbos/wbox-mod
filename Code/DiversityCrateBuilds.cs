using System;
using System.Linq;
using System.Collections.Generic;
using NCMS.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using ReflectionUtility;
using DG.Tweening;
using DiversityCrate;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using HarmonyLib;

namespace DiversityCrate
{
    class DiversityCrateBuilds
    {
     private List<BuildingAsset> humanBuildings = new List<BuildingAsset>();
     public void init()
     {               
     foreach (BuildingAsset humanBuilding in AssetManager.buildings.list)
     {
      if (humanBuilding.race == "human")
        {
         humanBuildings.Add(humanBuilding);
        }
     }
     foreach(var race in DiversityCrateRaceLibrary.additionalRaces){
     if(race == "goblin")
     {
     initgoblin();
     }
     if(race == "hive")
     {
     inithive();
     }
     if(race == "lizard")
     {
     initlizard();
     }
     }
    }
         
        private static void initgoblin()
        {
            RaceBuildOrderAsset pAsset = new RaceBuildOrderAsset();
            pAsset.id = "goblin";
            AssetManager.race_build_orders.add(pAsset);
            pAsset.addBuilding("bonfire", 1);
            pAsset.addBuilding("tent_goblin", pHouseLimit: true);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire");
            pAsset.addUpgrade("tent_goblin");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("tent_goblin");
            addVariantsUpgrade(pAsset, "house_goblin", List.Of<string>("hall_goblin"));
            addVariantsUpgrade(pAsset, "1house_goblin", List.Of<string>("1hall_goblin"));
            addVariantsUpgrade(pAsset, "2house_goblin", List.Of<string>("1hall_goblin"));
            addVariantsUpgrade(pAsset, "3house_goblin", List.Of<string>("2hall_goblin"));
            addVariantsUpgrade(pAsset, "4house_goblin", List.Of<string>("2hall_goblin"));
            pAsset.addUpgrade("hall_goblin", pPop: 30, pBuildings: 8);
            pAsset.addUpgrade("1hall_goblin", pPop: 100, pBuildings: 20);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("statue", "mine", "barracks_goblin");
            pAsset.addUpgrade("fishing_docks_goblin");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("fishing_docks_goblin");
            pAsset.addBuilding("windmill_goblin", 1, pPop: 6, pBuildings: 5);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire");
            pAsset.addUpgrade("windmill_goblin", pPop: 40, pBuildings: 10);
            pAsset.addBuilding("fishing_docks_goblin", 5, pBuildings: 2);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire");
            pAsset.addBuilding("well", 1, pPop: 20, pBuildings: 10);
            BuildOrderLibrary.b.requirements_types = List.Of<string>("hall");
            pAsset.addBuilding("hall_goblin", 1, pPop: 10, pBuildings: 6);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("house");
            pAsset.addBuilding("mine", 1, pPop: 20, pBuildings: 10);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire", "hall_goblin");
            pAsset.addBuilding("barracks_goblin", 1, pPop: 50, pBuildings: 16, pMinZones: 20);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("1hall_goblin");
            pAsset.addBuilding("watch_tower_goblin", 1, pPop: 30, pBuildings: 10);
            pAsset.addUpgrade("watch_tower_goblin" , 0, 0, 3, 3, false, false, 0);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire", "hall_goblin");
            pAsset.addBuilding("temple_goblin", 1, pPop: 90, pBuildings: 20, pMinZones: 20);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire", "1hall_goblin", "statue");
            pAsset.addBuilding("statue", 1, pPop: 70, pBuildings: 15);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("1hall_goblin");
        }

        private static void inithive()
        {
            RaceBuildOrderAsset pAsset = new RaceBuildOrderAsset();
            pAsset.id = "hive";
            AssetManager.race_build_orders.add(pAsset);
            pAsset.addBuilding("bonfire", 1);
            pAsset.addBuilding("tent_hive", pHouseLimit: true);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire");
            pAsset.addUpgrade("tent_hive");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("tent_hive");
            addVariantsUpgrade(pAsset, "house_hive", List.Of<string>("hall_hive"));
            addVariantsUpgrade(pAsset, "1house_hive", List.Of<string>("1hall_hive"));
            addVariantsUpgrade(pAsset, "2house_hive", List.Of<string>("1hall_hive"));
            addVariantsUpgrade(pAsset, "3house_hive", List.Of<string>("2hall_hive"));
            addVariantsUpgrade(pAsset, "4house_hive", List.Of<string>("2hall_hive"));
            pAsset.addUpgrade("hall_hive", pPop: 30, pBuildings: 8);
            pAsset.addUpgrade("1hall_hive", pPop: 100, pBuildings: 20);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("statue", "mine", "barracks_hive");
            pAsset.addUpgrade("fishing_docks_hive");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("fishing_docks_hive");
            pAsset.addBuilding("windmill_hive", 1, pPop: 6, pBuildings: 5);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire");
            pAsset.addUpgrade("windmill_hive", pPop: 40, pBuildings: 10);
            pAsset.addBuilding("fishing_docks_hive", 5, pBuildings: 2);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire");
            pAsset.addBuilding("well", 1, pPop: 20, pBuildings: 10);
            BuildOrderLibrary.b.requirements_types = List.Of<string>("hall");
            pAsset.addBuilding("hall_hive", 1, pPop: 10, pBuildings: 6);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("house");
            pAsset.addBuilding("mine", 1, pPop: 20, pBuildings: 10);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire", "hall_hive");
            pAsset.addBuilding("barracks_hive", 1, pPop: 50, pBuildings: 16, pMinZones: 20);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("1hall_hive");
            pAsset.addBuilding("watch_tower_hive", 1, pPop: 30, pBuildings: 10);
            pAsset.addUpgrade("watch_tower_hive" , 0, 0, 3, 3, false, false, 0);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire", "hall_hive");
            pAsset.addBuilding("temple_hive", 1, pPop: 90, pBuildings: 20, pMinZones: 20);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire", "1hall_hive", "statue");
            pAsset.addBuilding("statue", 1, pPop: 70, pBuildings: 15);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("1hall_hive");
        }

        private static void initlizard()
        {
            RaceBuildOrderAsset pAsset = new RaceBuildOrderAsset();
            pAsset.id = "lizard";
            AssetManager.race_build_orders.add(pAsset);
            pAsset.addBuilding("bonfire", 1);
            pAsset.addBuilding("tent_lizard", pHouseLimit: true);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire");
            pAsset.addUpgrade("tent_lizard");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("tent_lizard");
            addVariantsUpgrade(pAsset, "house_lizard", List.Of<string>("hall_lizard"));
            addVariantsUpgrade(pAsset, "1house_lizard", List.Of<string>("1hall_lizard"));
            addVariantsUpgrade(pAsset, "2house_lizard", List.Of<string>("1hall_lizard"));
            addVariantsUpgrade(pAsset, "3house_lizard", List.Of<string>("2hall_lizard"));
            addVariantsUpgrade(pAsset, "4house_lizard", List.Of<string>("2hall_lizard"));
            pAsset.addUpgrade("hall_lizard", pPop: 30, pBuildings: 8);
            pAsset.addUpgrade("1hall_lizard", pPop: 100, pBuildings: 20);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("statue", "mine", "barracks_lizard");
            pAsset.addUpgrade("fishing_docks_lizard");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("fishing_docks_lizard");
            pAsset.addBuilding("windmill_lizard", 1, pPop: 6, pBuildings: 5);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire");
            pAsset.addUpgrade("windmill_lizard", pPop: 40, pBuildings: 10);
            pAsset.addBuilding("fishing_docks_lizard", 5, pBuildings: 2);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire");
            pAsset.addBuilding("well", 1, pPop: 20, pBuildings: 10);
            BuildOrderLibrary.b.requirements_types = List.Of<string>("hall");
            pAsset.addBuilding("hall_lizard", 1, pPop: 10, pBuildings: 6);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("house");
            pAsset.addBuilding("mine", 1, pPop: 20, pBuildings: 10);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire", "hall_lizard");
            pAsset.addBuilding("barracks_lizard", 1, pPop: 50, pBuildings: 16, pMinZones: 20);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("1hall_lizard");
            pAsset.addBuilding("watch_tower_lizard", 1, pPop: 30, pBuildings: 10);
            pAsset.addUpgrade("watch_tower_lizard" , 0, 0, 3, 3, false, false, 0);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire", "hall_lizard");
            pAsset.addBuilding("temple_lizard", 1, pPop: 90, pBuildings: 20, pMinZones: 20);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("bonfire", "1hall_lizard", "statue");
            pAsset.addBuilding("statue", 1, pPop: 70, pBuildings: 15);
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("1hall_lizard");
        }
       
        private void loadSprites(BuildingAsset pTemplate)
        {
            string folder = pTemplate.race;
            if (folder == string.Empty)
            {
                folder = "Others";
            }
            folder = folder + "/" + pTemplate.id;
            Sprite[] array = Utils.ResourcesHelper.loadAllSprite("buildings/" + folder, 0.5f, 0.0f);

            pTemplate.sprites = new BuildingSprites();
            foreach (Sprite sprite in array)
            {
                string[] array2 = sprite.name.Split(new char[] { '_' });
                string text = array2[0];
                int num = int.Parse(array2[1]);

                if (array2.Length == 3)
                {
                    int.Parse(array2[2]);
                }
                while (pTemplate.sprites.animationData.Count < num + 1)
                {
                    pTemplate.sprites.animationData.Add(null);
                }
                if (pTemplate.sprites.animationData[num] == null)
                {
                    pTemplate.sprites.animationData[num] = new BuildingAnimationDataNew();
                }
                BuildingAnimationDataNew buildingAnimationDataNew = pTemplate.sprites.animationData[num];
                if (text.Equals("main"))
                {
                    buildingAnimationDataNew.list_main.Add(sprite);
                    if (buildingAnimationDataNew.list_main.Count > 1)
                    {
                        buildingAnimationDataNew.animated = true;
                    }
                }
                else if (text.Equals("ruin"))
                {
                    buildingAnimationDataNew.list_ruins.Add(sprite);
                }
                else if (text.Equals("special"))
                {
                    buildingAnimationDataNew.list_special.Add(sprite);
                }
                else if (text.Equals("mini"))
                {
                    pTemplate.sprites.mapIcon = new BuildingMapIcon(sprite);
                }
            }
            foreach (BuildingAnimationDataNew buildingAnimationDataNew2 in pTemplate.sprites.animationData)
            {
                buildingAnimationDataNew2.main = buildingAnimationDataNew2.list_main.ToArray();
                buildingAnimationDataNew2.ruins = buildingAnimationDataNew2.list_ruins.ToArray();
                buildingAnimationDataNew2.special = buildingAnimationDataNew2.list_special.ToArray();
            }
           
        }
        private static void addVariantsUpgrade(RaceBuildOrderAsset pAsset, string name, List<string> requirementsBuildings){
            foreach(var race in DiversityCrateRaceLibrary.defaultRaces){
                pAsset.addUpgrade($"{name}_{race}");
                BuildOrderLibrary.b.requirements_orders = requirementsBuildings;
            }
        }
    }
}