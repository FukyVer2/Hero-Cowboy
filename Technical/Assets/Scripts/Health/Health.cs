using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float hpDefault;
    public float hp;
    private float scaleXDefault;
	// Use this for initialization
	void Start () {
        scaleXDefault = gameObject.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetHpDefault(float _hpDefault)
    {
        hpDefault = _hpDefault;
    }
    [ContextMenu("HP")]
    public void HP(float _hp)
    {
        float scale = _hp * scaleXDefault / hpDefault;
        gameObject.transform.localScale = new Vector3(scale, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
}
