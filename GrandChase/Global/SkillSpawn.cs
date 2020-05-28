using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SkillSpawn : MonoBehaviourPunCallbacks
{
    public GameObject playerObject;
    //public PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        //playerObject = GameObject.FindGameObjectWithTag("Player");
        //pv = GetComponent<PhotonView>();
        //PhotonView pv = gameObject.GetComponent<PhotonView>();
        //pv.RPC("Fire", RpcTarget.Others, null);
        //photonView.RPC("Fire", RpcTarget.Others, null);
    }

    public void skillCast()
    {
        //pv.RPC("Fire", RpcTarget.Others, null);
    }

    // Update is called once per frame
    //[PunRPC]
    //void Fire()
    //{
    //    GameObject projectile = Instantiate(Resources.Load("FireMegaObj"), transform.position, playerObject.transform.rotation) as GameObject;
    //    projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 1000);
    //}
}
