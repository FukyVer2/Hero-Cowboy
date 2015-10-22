using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour {

    private GameObject obj;
    private float time;
    private float frequency;
    private float t = 0;
    private bool isFlicker = false;
    private SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
        sprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isFlicker)
            UpdateFlicker();
	}
    public void FlickerTo(GameObject _obj, float _time, float _frequency)
    {
        this.obj = _obj;
        this.time = _time;
        this.frequency = _frequency;
        isFlicker = true;
        Invoke("FinishFlicker", _time);
    }
    void Reset()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
    }
    void FinishFlicker()
    {
        isFlicker = false;
        Reset();
        Flicker flicker = obj.GetComponent<Flicker>();
        if(flicker != null)
        {
            Destroy(flicker);
        }
    }
    public bool isFlickerTo()
    {
        return isFlicker;
    }
    void UpdateFlicker()
    {
        if(t >= frequency)
        {
            if(sprite.color.a > 0.5f)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
            }
            else
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
            }
            t = 0;
        }
        t += Time.deltaTime;
    }
}
