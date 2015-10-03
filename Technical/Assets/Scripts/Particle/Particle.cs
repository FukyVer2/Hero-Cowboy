using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

    public float timeRemove;
    ParticleSystem p;
    
	// Use this for initialization
	void Start () {
        p = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Init()
    {
        p = GetComponent<ParticleSystem>();
        p.Play();
        PoolObject.Instance.DespawnObjectTime(transform, "Particle", timeRemove);
    }
    public void ResetParticle()
    {
        
    }
    [ContextMenu("Play")]
    void Test()
    {
        p.Play();
    }
}
