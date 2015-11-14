using System;
public class EnemyConfig : ICloneable
{
	public EnemyConfig(){}

	public object Clone(){return this.MemberwiseClone();}

	public EnemyConfig Copy(){return this.Clone() as EnemyConfig;}

	public int EmemyID;
	public string Name;
	public int HP;
	public int Damage;
	public float FireRate;
	public float Vellocity;
}