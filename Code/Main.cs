using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using ReflectionUtility;
using HarmonyLib;
using System.Reflection;

namespace DiversityCrate{
    [ModEntry]
    class Main : MonoBehaviour{
        #region
        public static Main instance;
        public DiversityCrateRaceLibrary DiversityCrateRaceLibrary = new DiversityCrateRaceLibrary();
        #endregion
        internal const string id = "agriche.mods.worldbox.DiversityCrate";
        internal static Harmony harmony;
        internal static Dictionary<string, UnityEngine.Object> modsResources;
        public List<string> addRaces = new List<string>(){"goblin", "hive", "lizard"};
        public DiversityCrateBuilds DiversityCrateBuilds = new DiversityCrateBuilds();
        public BuildingLibrary buildingLibrary = new BuildingLibrary();
        public const string mainPath = "Mods/DiversityCrate";

        void Awake(){
            modsResources = Reflection.GetField(typeof(ResourcesPatch), null, "modsResources") as Dictionary<string, UnityEngine.Object>;
            harmony = new Harmony(id);
            DiversityCrateKingdoms.init();
            DiversityCrateBuilds.init();
            buildingLibrary.init();
            DiversityCrateRaces.init();
            DiversityCrateRaceLibrary.init();            
            DiversityCrateTab.init();
            DiversityCrateButtons.init();
            var dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, "dictItems") as Dictionary<string, Sprite>;
            ActorAnimationLoader.loadAnimationBoat($"boat_fishing");
            var fairy = AssetManager.actor_library.get("fairy");
            fairy.traits.Remove("energized");
            var bandit = AssetManager.actor_library.get("bandit");
            bandit.traits.Remove("energized");
            //Reflection.CallStaticMethod(typeof(BannerGenerator), "loadTexturesFromResources", "goblin");
            instance = this;
        }
        void Start()
        {
        Harmony.CreateAndPatchAll(typeof(DiversityCrateRaceLibrary));
        }
    }
}