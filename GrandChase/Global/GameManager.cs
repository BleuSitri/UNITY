using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject arenaObject;
    public GameObject comboObject;
    public GameObject loadObject;
    public GameObject networkObject;
    public GameObject gameUI;

    public float arenaDrawTime;
    public bool startBool;

    //싱글톤 접근용 프로퍼티
    public static GameManager instance
    {
        get
        {
            if (m_instance == null) //싱글톤 변수에 오브젝트가 할당되지 않았다면
            {
                //씬에서 게임매니저 오브젝트를 찾아서 할당
                m_instance = FindObjectOfType<GameManager>();
            }
            //내뱉기
            return m_instance;
        }
    }

    private static GameManager m_instance;

    private void Awake()
    {
        if (instance != this)
        {
            //씬에 싱글톤 오브젝트 된 다른 게임매니저 오브젝트가 있다면
            Destroy(gameObject); //나 자신을 파괴
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startBool)
            ConnectionCheck();
        //if (networkObject.GetComponent<ChatNetworkManager>().Count >= 2 && startBool)
        //if (networkObject.GetComponent<ChatNetworkManager>().Count >= 1 && loadObject.activeSelf&& startBool)
        //{
        //    loadObject.SetActive(false);
        //    //networkObject.SetActive(false);
        //    //gameUI.SetActive(true);
        //    arenaObject.SetActive(true);
        //    arenaDrawTime += Time.deltaTime;
        //    if(arenaDrawTime>=1.0f)
        //    {
        //        arenaObject.SetActive(false);
        //        startBool = false;
        //    }
        //}
        //else if(networkObject.GetComponent<ChatNetworkManager>().Count == 0)
          //  loadObject.SetActive(true);
    }

    void ConnectionCheck()
    {
        if(PhotonNetwork.CountOfPlayers == 2)
        {
            arenaDrawTime += Time.deltaTime;

            if(arenaDrawTime >=1.0f)
            {
                arenaObject.SetActive(false);
                startBool = false;
            }
            else if(arenaDrawTime <1.0f)
            {
                arenaObject.SetActive(true);
            }
        }

        //if (PhotonNetwork.CountOfPlayers == 2 && !startBool)
        //{
        //    arenaObject.SetActive(true);
        //    startBool = true;
        //}
        //if(startBool)
        //{
        //    arenaObject.SetActive(false);
        //}    
    }

    void ComboCount()
    {

    }
}
