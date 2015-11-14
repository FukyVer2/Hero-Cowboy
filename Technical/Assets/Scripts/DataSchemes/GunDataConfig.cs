using System;
public class GunDataConfig : ICloneable
{
	public GunDataConfig(){}

	public object Clone(){return this.MemberwiseClone();}

	public GunDataConfig Copy(){return this.Clone() as GunDataConfig;}

	public int GunID;
	public string GunName;
	public int Damage;
	public float FireRate;
	public int CountBullet;
	public int MaxBullet;
	public float Ratico;
	public int Crit;
	public float CountDown;
	public int GoldUpgrade;
}