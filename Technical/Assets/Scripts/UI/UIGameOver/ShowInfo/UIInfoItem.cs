using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIInfoItem : MonoBehaviour {

    public Text txtLevel;
    public Text txtDamge;
    public Text txtHp;
    public Text txtAmor;
    public Text txtGold;
    public Text txtBonus;

    public void Show(string _txtLevel = "", string _txtDamge = "", string _txtHp = "", string _txtAmor = "", string _txtGold = "", string _txtBonus = "")
    {
        if (txtLevel != null)
        {
            txtLevel.text = _txtLevel;
        }
        if (txtDamge != null)
        {
            txtDamge.text = _txtDamge;
        }
        if(txtHp != null)
        {
            txtHp.text = _txtHp;
        }
        if(txtAmor= null)
        {
            txtAmor.text = _txtAmor;
        }
        if(txtGold != null)
        {
            txtGold.text = _txtGold;
        }
        if(txtBonus != null)
        {
            txtBonus.text = _txtBonus;
        }
        else
        {
            Debug.Log("1 thong so chua co gia tri");
        }
    }
    [ContextMenu("Show")]
    void Test()
    {
        Show("Lv: 10","","900 Hp","","12.5K", "+250 Hp" );
    }
}
