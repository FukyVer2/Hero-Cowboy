using UnityEngine;
using System.Collections;

public class UpGrade : MonoBehaviour {

    public Transform transfPlayer;
    public Transform transfCoinPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void EffectCoin()
    {
        ManagerObject.Instance.RenderCoinUpGrade(ObjectType.COIN, transfCoinPlayer.position, 4);
    }
    [ContextMenu("Up Grade")]
    public void UpGradePlayer()
    {
        ManagerObject.Instance.RenderLevelUp(ObjectType.LEVELUP, transfPlayer.position);
        Particle.Instance.PlayerLevelUp(transfPlayer.position);
        EffectCoin();
    }
}
