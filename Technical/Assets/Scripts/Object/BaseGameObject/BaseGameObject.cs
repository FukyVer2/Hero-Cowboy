﻿using UnityEngine;
using System.Collections;

public class BaseGameObject : MonoBehaviour {

    public int id;
    public int status = -1;//trang thai cua Enemy: -1 die, 0 move, 1 attack
    public float hp = 300;
    public float damge = 0;

    public bool pause = false;

    public Animator animator;
    public Health health;
    public Transform posNumberHit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   
    public virtual void Die()
    {
    }
    public virtual void Hit(float _damge, bool isCrit)
    {
    }
}
