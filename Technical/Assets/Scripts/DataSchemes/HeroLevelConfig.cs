using System;
public class HeroLevelConfig : ICloneable
{
	public HeroLevelConfig(){}

	public object Clone(){return this.MemberwiseClone();}

	public HeroLevelConfig Copy(){return this.Clone() as HeroLevelConfig;}

	public int HeroLevel;
	public int HP;
}