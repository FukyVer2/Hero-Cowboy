using System;
public class GunLevelConfig : ICloneable
{
	public GunLevelConfig(){}

	public object Clone(){return this.MemberwiseClone();}

	public GunLevelConfig Copy(){return this.Clone() as GunLevelConfig;}

	public int Level;
	public int Damage;
	public float FireRate;
	public float CountDown;
	public int MaxBullet;
	public int Ratico;
	public int Crit;
	public int GoldUpgrade;
}