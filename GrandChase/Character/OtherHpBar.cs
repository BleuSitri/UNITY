using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherHpBar : MonoBehaviour
{
    public GameObject playerObject;
    public Image hpBar;
    public GameObject hpObject;

    public GameObject networkObject;

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
            //hpBar.fillAmount = playerObject.GetComponent<PlayerCONTROL>().currentHp / playerObject.GetComponent<PlayerCONTROL>().maxHp;
            //playerObject.GetComponent<PhotonView>().Owner.UserId.

            //hpBar.fillAmount = playerObject.GetComponent<PlayerCONTROL>().otherHpBar / playerObject.GetComponent<PlayerCONTROL>().maxHp;

            //hpBar.fillAmount = playerObject.GetComponent<PlayerCONTROL>().otherHpBar / playerObject.GetComponent<PlayerCONTROL>().maxHp;
            //hpBar.fillAmount = ObjectInit.instance.playerObjectList[1].GetComponent<PlayerCONTROL>().currentHp / playerObject.GetComponent<PlayerCONTROL>().maxHp;
            //hpBar.fillAmount = networkObject.GetComponent<NetworkManager>().playerArray[1].GetComponent<PlayerCONTROL>().currentHp / playerObject.GetComponent<PlayerCONTROL>().maxHp;

            hpBar.fillAmount = playerObject.GetComponent<PlayerCONTROL>().currentHp / playerObject.GetComponent<PlayerCONTROL>().maxHp;

            //hpBar.fillAmount = playerObject.GetComponent<PlayerCONTROL>().otherCurrentHp / playerObject.GetComponent<PlayerCONTROL>().maxHp;

            //hpObject = GameObject.FindGameObjectWithTag("HPUI");
            //hpObject.GetComponent<PhotonView>().RPC("showHpBar",)

        }
    }
}
