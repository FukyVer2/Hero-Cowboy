using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerCoin : MonoBehaviour {

    public GameObject coinPrefabs;
    public List<Coin> listCoin;
    public int countCoin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [ContextMenu("Render")]
    void RenderCoin()
    {

        for (int i = 0; i < countCoin; i++)
        {
            GameObject coinObject = Instantiate(coinPrefabs, Vector3.zero, Quaternion.identity) as GameObject;
            Coin coin = coinObject.GetComponent<Coin>();
            if (coin != null)
            {
                Vector2 force = new Vector2(Random.Range(-200, 200), Random.Range(200, 350));
                coin.AddForce(force);
                listCoin.Add(coin);
            }
        }
    }
    void RenderCoin(int _countCoin, Vector3 _force)
    {
        for (int i = 0; i < _countCoin; i++)
        {
            GameObject coinObject = Instantiate(coinPrefabs, Vector3.zero, Quaternion.identity) as GameObject;
            Coin coin = coinObject.GetComponent<Coin>();
            if (coin != null)
            {
                //Vector2 force = new Vector2(Random.Range(-200, 200), Random.Range(200, 350));
                coin.AddForce(_force);
                //listCoin.Add(coin);
            }
        }
    }
}
