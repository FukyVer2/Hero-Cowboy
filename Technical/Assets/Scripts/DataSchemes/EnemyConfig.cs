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

public enum EnemyTypeConfig
{
	NONE = 0, 
	ENEMY_RUN_1 = 11,
	ENEMY_RUN_2 = 12,
	ENEMY_RUN_3 = 13,
	ENEMY_TANK_1 = 21,
	ENEMY_TANK_2 = 22,
	ENEMY_TANK_3 = 23,
	ENEMY_TELE_1 = 31,
	ENEMY_TELE_2 = 32,
	ENEMY_TELE_3 = 33,
	ENEMY_FLY_1 = 41,
	ENEMY_FLY_2 = 42,
	ENEMY_FLY_3 = 43
}