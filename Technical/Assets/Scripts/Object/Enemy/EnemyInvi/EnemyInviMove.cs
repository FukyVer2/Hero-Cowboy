using UnityEngine;
using System.Collections;

public class EnemyInviMove : MonoBehaviour {

    public EnemyInvi enemyInvi;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Invi()
    {
        enemyInvi.gameObject.SetActive(false);
    }
}
