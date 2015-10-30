using UnityEngine;
using System.Collections;

public enum LevelType
{
    NONE =0,
    PLAYER = 1,
    ENEMY = 2,
    GUN =3,
}
[System.Serializable]
public class LevelIndex : MonoBehaviour
{
    public PlayerIndex playerIndex;
    public EnemyIndex enemyIndex;
    public GunIndex gunIndex;
    public LevelIndex()
    { 
    }
    public LevelIndex(PlayerIndex _player, EnemyIndex _enemy, GunIndex _gun)
    {
        this.playerIndex = _player;
        this.enemyIndex = _enemy;
        this.gunIndex = _gun;
    }
    public LevelIndex(string[] data)
    {
        playerIndex = new PlayerIndex(data);
    }
    public LevelIndex(string[] data, LevelType _type)
    {
        switch(_type)
        {
            case LevelType.NONE:
                break;
            case LevelType.PLAYER:
                playerIndex = new PlayerIndex(data);
                break;
            case LevelType.ENEMY:
                enemyIndex = new EnemyIndex(data);
                break;
            case LevelType.GUN:
                gunIndex = new GunIndex(data);
                break;
        }
        
    }
    public LevelIndex(string[] dataPlay, string[] dataEnemy, string[] dataGun)
    {
        playerIndex = new PlayerIndex(dataPlay);
        enemyIndex = new EnemyIndex(dataEnemy);
        gunIndex = new GunIndex(dataGun);
    }
}
[System.Serializable]
public class PlayerIndex : MonoBehaviour
{
    public int id;
    public string type;
    public TypePlayer typePlay;
    public int level;
    public float hp;
    public float damge;

    public PlayerIndex()
    {
    }
    public PlayerIndex(int _id, string _type, int _level, int _hp, int _damge)
    {
        this.id = _id;
        this.type = _type;
        this.level = _level;
        this.hp = _hp;
        this.damge = _damge;
    }
    public PlayerIndex(string[] data)
    {
        this.id = int.Parse(data[0]);
        this.type = data[1];
        this.typePlay = GetPlayerTypeByString(type);
        this.level = int.Parse(data[2]);
        this.hp = float.Parse(data[3]);
        this.damge = float.Parse(data[4]);
    }
    TypePlayer GetPlayerTypeByString(string _type)
    {
        //MapObjectType _mapType;
        if (_type.Contains(TypePlayer.PLAYER.value))
        {
            return TypePlayer.PLAYER;
        }
        else
        {
            return TypePlayer.GetTypeByString(type);
        }
    }

    //public string MapObjectToString()
    //{
    //    return System.String.Format("{0};{1};{2};{3};{4}", this.iD, this.type, this.level, this.position.x, this.position.y);
    //}
}
[System.Serializable]
public class EnemyIndex : MonoBehaviour
{
    public int id;
    public string type;
    public TypeEnemy typeEnemy;
    public int level;
    public float speed;
    public float hp;
    public float damge;

    public EnemyIndex()
    {
    }
    public EnemyIndex(int _id, string _type,float _speed,int _level, float _hp, float _damge)
    {
        this.id = _id;
        this.type = _type;
        this.speed  = _speed; 
        this.level = _level;
        this.hp = _hp;
        this.damge = _damge;
    }
    public EnemyIndex(string[] data)
    {
        this.id = int.Parse(data[0]);
        this.type = data[1];
        this.typeEnemy = GetPlayerTypeByString(type);
        this.level = int.Parse(data[2]);
        this.hp = float.Parse(data[3]);
        this.damge = float.Parse(data[4]);
    }
    TypeEnemy GetPlayerTypeByString(string _type)
    {
        //MapObjectType _mapType;
        if (_type.Contains(TypeEnemy.RUN.value))
        {
            return TypeEnemy.RUN;
        }
        else
        {
            return TypeEnemy.GetTypeByString(type);
        }
    }

    //public string MapObjectToString()
    //{
    //    return System.String.Format("{0};{1};{2};{3};{4}", this.iD, this.type, this.level, this.position.x, this.position.y);
    //}
}
[System.Serializable]
public class GunIndex : MonoBehaviour
{
    public int id;
    public string type;
    public TypeGun typeGun;
    public int level;
    public int numberBulletMax;
    public int numberBulletsOfCartridge;
    public float damge;
    public float ratioCrit;
    public float valueCrit;

    public GunIndex()
    {
    }
    public GunIndex(int _id, string _type, int _level, int _numberBulletMax, int _numberBulletsOfCartridge, float _damge, float _ratioCrit, float _valueCrit)
    {
        this.id = _id;
        this.type = _type;
        this.level = _level;
        this.numberBulletMax = _numberBulletMax;
        this.numberBulletsOfCartridge = _numberBulletsOfCartridge;
        this.damge = _damge;
        this.ratioCrit = _ratioCrit;
        this.valueCrit = _valueCrit;

    }
    public GunIndex(string[] data)
    {
        this.id = int.Parse(data[0]);
        this.type = data[1];
        this.typeGun = GetPlayerTypeByString(type);
        this.level = int.Parse(data[2]);
        this.numberBulletMax = int.Parse(data[3]);
        this.numberBulletsOfCartridge = int.Parse(data[4]);
        this.damge = float.Parse(data[5]);
        this.ratioCrit = float.Parse(data[6]);
        this.valueCrit = float.Parse(data[7]);        
    }
    TypeGun GetPlayerTypeByString(string _type)
    {
        //MapObjectType _mapType;
        if (_type.Contains(TypeGun.SHOTGUN.value))
        {
            return TypeGun.SHOTGUN;
        }
        else
        {
            return TypeGun.GetTypeByString(type);
        }
    }

    //public string MapObjectToString()
    //{
    //    return System.String.Format("{0};{1};{2};{3};{4}", this.iD, this.type, this.level, this.position.x, this.position.y);
    //}
}
public class TypeEnemy
{
    private TypeEnemy(string _value) { value = _value; }
	public string value{ get; set;}
    public static TypeEnemy RUN { get { return new TypeEnemy("RUN"); } }
    public static TypeEnemy TANK { get { return new TypeEnemy("TANK"); } }
    public static TypeEnemy FLY { get { return new TypeEnemy("FLY"); } }
    public static TypeEnemy TELE { get { return new TypeEnemy("TELE"); } }
    public static TypeEnemy GetTypeByString(string str)
    {
        switch (str)
        {
            case "RUN":
                return TypeEnemy.RUN;
                break;
            case "TANK":
                return TypeEnemy.TANK;
                break;
            case "TELE":
                return TypeEnemy.TELE;
                break;
            case "FLY":
                return TypeEnemy.FLY;
                break;
            default:
                return null;
                break;
        }
    }
}
public class TypePlayer
{
    private TypePlayer(string _value) { value = _value; }
    public string value { get; set; }
    public static TypePlayer PLAYER { get { return new TypePlayer("PLAYER"); } }
    public static TypePlayer TOWER { get { return new TypePlayer("TOWER"); } }
    public static TypePlayer SUPPORT { get { return new TypePlayer("SUPPORT"); } }
    public static TypePlayer GetTypeByString(string str)
    {
        switch (str)
        {
            case "PLAYER":
                return TypePlayer.PLAYER;
                break;
            case "TOWER":
                return TypePlayer.TOWER;
                break;
            case "SUPPORT":
                return TypePlayer.SUPPORT;
                break;
            default:
                return null;
                break;
        }
    }
}
public class TypeGun
{
    private TypeGun(string _value) { value = _value; }
	public string value{ get; set;}

    public static TypeGun SHOTGUN { get { return new TypeGun("SHOTGUN"); } }
    public static TypeGun BIGGUN { get { return new TypeGun("BIGGUN"); } }
    public static TypeGun GRENDAGUN { get { return new TypeGun("GRENDAGUN"); } }
    public static TypeGun MACHINEGUN { get { return new TypeGun("MACHINEGUN"); } }

    public static TypeGun GetTypeByString(string str)
    {
        switch (str)
        {
            case "SHOTGUN":
                return TypeGun.SHOTGUN;
                break;
            case "BIGGUN":
                return TypeGun.BIGGUN;
                break;
            case "GRENDAGUN":
                return TypeGun.GRENDAGUN;
                break;
            case "MACHINEGUN":
                return TypeGun.MACHINEGUN;
                break;            
            default:
                return null;
                break;
        }
    }

}