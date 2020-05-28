using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMpBar : MonoBehaviour
{
    public GameObject playerObject;
    public Image mpBar;
    //public float maxMp = 120f;
    ///*public*/ float currentMp = 0.0f;
    public GameObject MpLineFolder;
    float unitMp = 40;
    // Start is called before the first frame update
    void Start()
    {
        //playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject != null && !GameManager.instance.startBool)
        {
            if (playerObject.GetComponent<PlayerCONTROL>().currentMp <= playerObject.GetComponent<PlayerCONTROL>().maxMp)
                playerObject.GetComponent<PlayerCONTROL>().currentMp += 0.1f;
            mpBar.fillAmount = playerObject.GetComponent<PlayerCONTROL>().currentMp / playerObject.GetComponent<PlayerCONTROL>().maxMp;
        }
    }
    public void GetMpBoost()
    {

        float scaleX = (150f / unitMp) / (playerObject.GetComponent<PlayerCONTROL>().maxMp / unitMp);

        MpLineFolder.GetComponent<HorizontalLayoutGroup>().gameObject.SetActive(false);
        foreach(Transform child in MpLineFolder.transform)
        {
            child.gameObject.transform.localScale = new Vector3(scaleX, 1, 1);
        }
        MpLineFolder.GetComponent<HorizontalLayoutGroup>().gameObject.SetActive(true);
    }
}
