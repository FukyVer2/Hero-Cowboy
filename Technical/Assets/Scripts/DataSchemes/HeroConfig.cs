using System;
public class HeroConfig : ICloneable
{
	public HeroConfig(){}

	public object Clone(){return this.MemberwiseClone();}

	public HeroConfig Copy(){return this.Clone() as HeroConfig;}

	public int HeroID;
	public string HeroName;
	public int HP;
}