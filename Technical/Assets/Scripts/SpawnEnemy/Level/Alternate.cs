using UnityEngine;
using System.Collections;

//so Enemy trong 1 luot
[System.Serializable]
public class Alternate  {

    public string left = "";
    public string right = "";
	public int countEnemy;

    public Alternate()
    { }
    public Alternate(string _left, string _right)
    {
        this.left = _left;
        this.right = _right;
		string[] strLeft = left.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
		string[] strRight = right.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
		this.countEnemy = strLeft.Length + strRight.Length;
    }

	public void CalculateCountEnemy() 
	{
		string[] strLeft = left.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
		string[] strRight = right.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
		this.countEnemy = strLeft.Length + strRight.Length;
	}
}
