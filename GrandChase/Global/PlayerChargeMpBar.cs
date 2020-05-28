using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChargeMpBar : MonoBehaviour
{
    public GameObject playerObject;
    public Image ChargeMpBar;
    public GameObject ChargeEffectPrefab;
    Vector3 ChargeEffectPosition;
    Vector3 ChargeMpBarImage;
    /*public*/


    // Start is called before the first frame update
    void Start()
    {
       // playerObject = GameObject.FindGameObjectWithTag("Player");
        //ChargeEffectPrefab = Camera.main.WorldToScreenPoint()
        ChargeMpBarImage = Camera.main.ScreenToWorldPoint(ChargeMpBar.transform.position);
    }

    // Update is called once per frame
    void Update()
    {


        if(playerObject != null)
        {
            //ChargeEffectPosition = Camera.main.WorldToScreenPoint()
            ChargeEffectPrefab.SetActive(true);
            //ChargeMpBar.fillAmount = playerObject.GetComponent<PlayerCONTROL>().currentCharge / playerObject.GetComponent<PlayerCONTROL>().maxCharge;

            ChargeEffectPosition = new Vector3(ChargeMpBarImage.x, ChargeMpBarImage.y, (ChargeMpBarImage.x - 176.62f) + 353.24f * ChargeMpBar.fillAmount);


            //ChargeEffectPrefab.transform.position = ChargeMpBar.transform.position + playerObject.GetComponent<Player>().maxCharge * ChargeMpBar.fillAmount;
            //ChargeEffectPrefab.transform.position = new Vector3((ChargeMpBar.transform.position.x-190) + 380 * ChargeMpBar.fillAmount/*playerObject.GetComponent<Player>().maxCharge * ChargeMpBar.fillAmount*/, ChargeMpBar.transform.position.y, ChargeMpBar.transform.position.z-20);
            //ChargeEffectPrefab.transform.position = new Vector3((ChargeMpBarImage.x - 190) + 380 * ChargeMpBar.fillAmount/*playerObject.GetComponent<Player>().maxCharge * ChargeMpBar.fillAmount*/, ChargeMpBarImage.y, ChargeMpBarImage.z - 20);
            //ChargeEffectPosition = new Vector3((ChargeMpBar.transform.position.x - 190) + 380 * ChargeMpBar.fillAmount/*playerObject.GetComponent<Player>().maxCharge * ChargeMpBar.fillAmount*/, ChargeMpBar.transform.position.y, ChargeMpBar.transform.position.z - 20);
            //ChargeEffectPrefab.transform.position = Camera.main.ScreenToWorldPoint(ChargeEffectPosition);


            if (playerObject.GetComponent<PlayerCONTROL>().currentCharge == 0)
            {
                ChargeEffectPrefab.SetActive(false);
            }
        }


    }
}