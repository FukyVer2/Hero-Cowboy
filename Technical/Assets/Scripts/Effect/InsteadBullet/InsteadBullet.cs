using UnityEngine;
using System.Collections;

public class InsteadBullet : MonoBehaviour {

    public float timeLoading = 2;
    public float scale;
    public float maxScale;
    private float s = 0;
	// Use this for initialization
	void Start () {
        scale = 1.0f / timeLoading;
	}
	
	// Update is called once per frame
	void Update () {
        if (s < maxScale)
        {
            s += scale * Time.deltaTime;
            gameObject.transform.localScale = new Vector3(s, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
	}
    [ContextMenu("Reset")]
    public void Reset()
    {
        s = 0;
    }
}
