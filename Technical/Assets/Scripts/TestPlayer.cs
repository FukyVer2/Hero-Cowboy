﻿using UnityEngine;
using System.Collections;

public class TestPlayer : MonoSingleton<TestPlayer> {

    public float Hp = 100;
    public GameObject prefabsNumber;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Hit(float damge)
    {
        Hp -= damge;
    }
    [ContextMenu("RenderNumber")]
    public void RenderNumber(float damge)
    {
        GameObject numberObj = PoolObject.Instance.SpawnObject(prefabsNumber, "Number");
        numberObj.transform.position = Vector3.zero;
        Number number = numberObj.GetComponent<Number>();
        number.Init();
        number.Calculogic(damge);
    }
}