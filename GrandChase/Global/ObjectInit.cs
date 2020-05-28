using Cinemachine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInit : MonoBehaviour
{

    public static ObjectInit instance
    {
        get
        {
            if (m_instance == null) //싱글톤 변수에 오브젝트가 할당되지 않았다면
            {
                //씬에서 게임매니저 오브젝트를 찾아서 할당
                m_instance = FindObjectOfType<ObjectInit>();
            }
            //내뱉기
            return m_instance;
        }
    }

    private static ObjectInit m_instance;

    private void Awake()
    {
        if (instance != this)
        {
            //씬에 싱글톤 오브젝트 된 다른 게임매니저 오브젝트가 있다면
            Destroy(gameObject); //나 자신을 파괴
        }
    }


    public GameObject playerObject;
    public GameObject cameraObject;

    public GameObject mpUIObject;
    public GameObject chargeUIObject;
    //public GameObject hpUIObject;
    public GameObject[] hpUIObjects;
    public List<GameObject> playerObjectList;
    //public GameObject gameUI;
    //public Character characterScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameInit()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        //playerObject.GetComponent<PlayerCONTROL>().PV = playerObject.GetComponent<PhotonView>();
        playerObject.GetComponent<PlayerCONTROL>().CharacterModel = playerObject;
        playerObject.GetComponent<PlayerCONTROL>().chargeEffectPrefab = playerObject.transform.Find("IdentifyChannel").gameObject;
        playerObject.GetComponent<PlayerCONTROL>().otherCurrentHp = 0.0f;
        playerObject.GetComponent<PlayerCONTROL>().playerAudio = playerObject.GetComponent<AudioSource>();

        //playerObject.GetComponent<PlayerCONTROL>().comboObject = GameObject.FindGameObjectWithTag("CANVAS").transform.Find("GameUI").Find("Combo").gameObject;


        //characterScript = FindObjectOfType<Character>();
        //characterScript.uiObject = GameObject.FindGameObjectWithTag("GAMEUI");



        cameraObject = GameObject.FindGameObjectWithTag("CCamera");
        cameraObject.GetComponent<CinemachineVirtualCamera>().Follow = playerObject.transform;
        cameraObject.GetComponent<CinemachineVirtualCamera>().LookAt = playerObject.transform;

        mpUIObject = GameObject.FindGameObjectWithTag("MPUI");
        mpUIObject.GetComponent<PlayerMpBar>().playerObject = playerObject;

        chargeUIObject = GameObject.FindGameObjectWithTag("CHARGEUI");
        chargeUIObject.GetComponent<PlayerChargeMpBar>().playerObject = playerObject;

        hpUIObjects = GameObject.FindGameObjectsWithTag("HPUI");
        hpUIObjects[0].GetComponent<PlayerHpBar>().playerObject = playerObject;
        hpUIObjects[1].GetComponent<OtherHpBar>().playerObject = playerObject;
        //for(int i =0;i<hpUIObjects.Length;i++)
        //{
        //    hpUIObjects[i].GetComponent<PlayerHpBar>().playerObject = playerObject;
        //}
        //hpUIObject = GameObject.FindGameObjectWithTag("HPUI");
        //hpUIObject.GetComponent<PlayerHpBar>().playerObject = playerObject;


    }
}
