using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerHpBar : MonoBehaviourPunCallbacks
{

    public GameObject playerObject;
    public Image hpBar;
    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        //playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject != null)
        {
            
            //PhotonNetwork.
            //hpBar.fillAmount = playerObject.GetComponent<PlayerCONTROL>().currentHp / playerObject.GetComponent<PlayerCONTROL>().maxHp;
            //hpBar.fillAmount = hp / playerObject.GetComponent<PlayerCONTROL>().maxHp;
            //showHpBar();
        }
    }

    //[PunRPC]
    //public void showHpBar()
    //{
    //    hpBar.fillAmount = playerObject.GetComponent<PlayerCONTROL>().currentHp / playerObject.GetComponent<PlayerCONTROL>().maxHp;
    //}

}
