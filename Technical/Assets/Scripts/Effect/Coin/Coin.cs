using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public float coin = 2.5f;
    public Vector2 force;
    public Rigidbody2D rigid;
    private Vector3 transfFinish = new Vector3(-2.49f, 4.69f, 0);
	// Use this for initialization
	void Start () {
        //rigid = GetComponent<Rigidbody2D>();        
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    void StartRender()
    { }
    
    [ContextMenu("Start")]
    void Test()
    {
        rigid.AddForce(force);
        Invoke("MoveCoin", 3.0f);
    }
    void MoveCoin()
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            //iT.MoveTo.delay, 2.0f,
            iT.MoveTo.speed, 7.5f,
            iT.MoveTo.position, transfFinish,
            iT.MoveTo.easetype, iTween.EaseType.linear,
            iT.MoveTo.oncomplete, "Finish"
            ));
    }
    public void AddForce(Vector2 _force)
    {
        rigid.AddForce(_force);
        float rand = Random.Range(2.5f, 3.5f);
        Invoke("MoveCoin", rand);
    }
    void Finish()
    {
        GameController.Instance.AddGold(coin);
        PoolObject.Instance.DespawnObject(transform, "Coin");
    }
    [ContextMenu("Test Scale")]
    void TestScale()
    {
        Scale scale =  gameObject.AddComponent<Scale>();
        scale.ZoomOutIn(gameObject, gameObject.transform.localScale, new Vector3(3, 3, 1), gameObject.transform.localScale, 5f, 5f, 3f, 3f);
        //scale.TestZoomOutIn(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    { }
}
