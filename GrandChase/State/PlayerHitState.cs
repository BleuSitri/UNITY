using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerHitState : State
{
    // Start is called before the first frame update
    override public void Start()
    {
        Debug.Log("PLAYER HITSTATE");
        _character.CharacterModel.GetComponent<Animator>().SetTrigger("hit");
        //photonView.RPC("ComboCount", RpcTarget.Others);
        //_character.CharacterModel.GetComponent<PlayerCONTROL>().hitCount += 1;
    }

    // Update is called once per frame
    override public void Update()
    {
        
    }


    [PunRPC]
    public void ComboCount()
    {
        _character.CharacterModel.GetComponent<PlayerCONTROL>().hitCount += 1;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    {

    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{

    //}
}
