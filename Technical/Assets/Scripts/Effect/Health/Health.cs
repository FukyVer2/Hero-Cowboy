using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float hpDefault;
    public float hp;
    private float scaleXDefault = 0.75f;
	// Use this for initialization
	void Start () {
        scaleXDefault = gameObject.transform.localScale.x;
	}
    public void Reset()
    {
        gameObject.transform.localScale = new Vector3(scaleXDefault, gameObject.transform.localScale.y, 1);
    }
	// Update is called once per frame
	void Update () {
	
	}
    public void SetHpDefault(float _hpDefault)
    {
        hpDefault = _hpDefault;
    }
    [ContextMenu("HP")]
    void test()
    {
        HP(100);
    }
    public void HP(float _hp)
    {
        float scale = _hp * scaleXDefault / hpDefault;
        gameObject.transform.localScale = new Vector3(scale, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
    
}
