using UnityEngine;
using System.Collections;

//so Enemy trong 1 luot
[System.Serializable]
public class Alternate  {

    public string left = "";
    public string right = "";

    public Alternate()
    { }
    public Alternate(string _left, string _right)
    {
        this.left = _left;
        this.right = _right;
    }

}
