using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject gameManagerObject;
    public GameObject[] playerArray;
    private void Awake()
    {
        
        Screen.SetResolution(1920, 1080, false);
        PhotonNetwork.ConnectUsingSettings();
        gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
    }

    public override void OnConnectedToMaster() => PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, null);

    public override void OnJoinedRoom()
    {

        //PhotonNetwork.Instantiate("Player", new Vector3(-3.979701f, -1.75f, 41.7f), Quaternion.Euler(new Vector3(0,90f,0)));//Quaternion.identity);

        PhotonNetwork.Instantiate("Player", new Vector3(0.5f, 0.5f, -0.5f), Quaternion.Euler(new Vector3(0, 90f, 0)));//Quaternion.identity);
        //if (PhotonNetwork.IsMasterClient)
        //{

            //*playerArray[0] = *
        //}
        //else
        //{
        //    playerArray[1] = PhotonNetwork.Instantiate("Player", new Vector3(0.5f, 0.5f, -3.5f), Quaternion.Euler(new Vector3(0, 90f, 0)));//Quaternion.identity);
        //}
        gameManagerObject.GetComponent<ObjectInit>().GameInit();
    }

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
