using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;


public class GameData : Singleton<GameData> {

	public List<GunDataConfig> mGunDataConfig = new List<GunDataConfig>();
	public List<GunLevelConfig> mGunLevelConfig = new List<GunLevelConfig> ();
	public List<EnemyConfig> mEnemyConfig = new List<EnemyConfig>();
	public List<HeroConfig> mHeroConfig = new List<HeroConfig> ();
	public List<HeroLevelConfig> mHeroLevelConfig = new List<HeroLevelConfig> ();
    //public MapInfo mapInfo;

	[ContextMenu("LoadGameData")]
	public void LoadGameData() {
		LoadData<GunDataConfig> (mGunDataConfig, "GameData/GunDataConfig");
		LoadData<GunLevelConfig> (mGunLevelConfig, "GameData/GunLevelConfig");
		LoadData<EnemyConfig> (mEnemyConfig, "GameData/EnemyConfig");
		LoadData<HeroConfig> (mHeroConfig, "GameData/HeroConfig");
		LoadData<HeroLevelConfig> (mHeroLevelConfig, "GameData/HeroLevelConfig");
        this.LoadMaps();
	}

	public EnemyConfig GetEnemyConfig(EnemyTypeConfig enemyType) {
		int enemyID = (int)enemyType;
		EnemyConfig enemyConfig = mEnemyConfig.Find(x => x.EmemyID == enemyID);
		return enemyConfig;
	}

	public HeroInfo GetHeroInfoByLevel(int level) 
	{
		HeroConfig heroConfig = mHeroConfig.Find(x => x.HeroID == 1);
        Debug.Log("hero Name = " + heroConfig.HeroName);
        HeroLevelConfig heroLevel = mHeroLevelConfig.Find(x => x.HeroLevel == level);
        Debug.Log("hero level = " + heroLevel.HeroLevel);

		HeroInfo heroInfo = new HeroInfo (heroConfig, heroLevel);
		return heroInfo;
	}

	public GunInfo GetGunInfoByLevel(GunType gunType, int level) 
	{
		int gunID = (int)gunType;
		GunDataConfig gunConfig = mGunDataConfig.Find (x => x.GunID == gunID);
		GunLevelConfig gunLevel = mGunLevelConfig.Find (x => x.Level == level);

		GunInfo gunInfo = new GunInfo (gunConfig, gunLevel);

		return gunInfo;
	}

	
	void LoadMaps() {
        //string filePathMapdemo = "Maps/lvl_003_3000_3000_15_2015_8_8_10342";
        //MapInfo mapInfo = new MapInfo (filePathMapdemo);
        //mListMaps.Add (mapInfo);

//        this.LoadWorldMapLevel(mListWorldMapLevel, "GameData/WorldMapLevel");
//        this.LoadMapInfo(mListMaps, mListWorldMapLevel);
	}


    void LoadData<T>(List<T> listName, string assetPath)
    {
		if (listName != null) {
			listName.Clear();
		}

		TextAsset textAsset = Resources.Load<TextAsset> (assetPath);

		if (textAsset) {
			System.Type typeOfT = typeof(T);

			//cat dong
			string[] temp = textAsset.text.Split(new char[]{'\n'}, StringSplitOptions.RemoveEmptyEntries);

			//lay danh sach field cua lop
			Assembly a = Assembly.GetAssembly(typeOfT);
			FieldInfo[] fieldInfo = typeOfT.GetFields(BindingFlags.Public | BindingFlags.Instance);

			//bo dong dau tien, key
			for(int i = 1; i < temp.Length; i++) {
				T newObject = (T)a.CreateInstance(typeOfT.FullName);

				Debug.Log("Line " + i + " = " + temp[i]);
				string[] context = temp[i].Split(new char[]{';'});
				for(int j = 0; j < fieldInfo.Length; j++) {
//					try {
//
//					}catch(Exception ex) {
//
//					}
					string collumnValue = context[j];
					if(fieldInfo[j].FieldType == typeof(String)) {
						fieldInfo[j].SetValue(newObject, collumnValue.Substring(1, context[j].Length - 2));
					}else if (fieldInfo[j].FieldType == typeof(Int32)){
						int value = 0;
						if(collumnValue.Length > 0) {
							value = Int32.Parse(collumnValue);
						}
						fieldInfo[j].SetValue(newObject, value);
					}else if (fieldInfo[j].FieldType == typeof(float)) {
						float value = 0.0f;
						if(collumnValue.Length > 0) {
							value = float.Parse(collumnValue);
						}
						fieldInfo[j].SetValue(newObject, value);
					}
				}
				listName.Add(newObject);
			}

		}
	}
}
