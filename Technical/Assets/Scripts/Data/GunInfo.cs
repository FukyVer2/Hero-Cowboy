using UnityEngine;
using System.Collections;

public class GunInfo {

	public int GunID;
	public string GunName;
	public int Level;
	public int Damage;
	public float FireRate;
	public int CountBullet;
	public int MaxBullet;
	public float Ratico;
	public int Crit;
	public float CountDown;
	public int GoldUprade;

	public GunInfo() 
	{

	}

	public GunInfo(GunDataConfig gunConfig, GunLevelConfig gunLevel) 
	{
		this.GunID = gunConfig.GunID;
		this.Level = gunLevel.Level;
		this.Damage = gunConfig.Damage * gunLevel.Damage;
		this.FireRate = gunConfig.FireRate * gunLevel.FireRate;
		this.CountBullet = gunConfig.CountBullet;
		this.MaxBullet = gunConfig.MaxBullet * gunLevel.MaxBullet;
		this.Ratico = gunConfig.Ratico * gunLevel.Ratico;
		this.Crit = gunConfig.Crit * gunLevel.Crit;
		this.CountDown = gunConfig.CountDown * gunLevel.CountDown;
		this.GoldUprade = gunConfig.GoldUpgrade * gunLevel.GoldUpgrade;
	}
}
