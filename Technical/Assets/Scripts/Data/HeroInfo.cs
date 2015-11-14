using UnityEngine;
using System.Collections;

public class HeroInfo {

	public int HeroID;
	public int Level;
	public string PlayerName;
	public int HP;

	public HeroInfo() {

	}

	public HeroInfo(HeroConfig heroConfig, HeroLevelConfig heroLevel) 
	{
		this.HeroID = heroConfig.HeroID;
		this.Level = heroLevel.HeroLevel;
		this.HP = heroLevel.HP * heroConfig.HP;
	}
}
