using UnityEngine;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;
 
public class MagicProjectileScript : MonoBehaviourPunCallbacks
{
    public PhotonView PV;

    public GameObject impactParticle;
    public GameObject projectileParticle;
    public GameObject muzzleParticle;
    public GameObject[] trailParticles;
    [HideInInspector]
    public Vector3 impactNormal; //Used to rotate impactparticle.
 
    private bool hasCollided = false;

    //photonTest
    public int actorNumber = -1;
 
    void Start()
    {
        projectileParticle = Instantiate(projectileParticle, transform.position, transform.rotation) as GameObject;
        projectileParticle.transform.parent = transform;
		if (muzzleParticle){
        muzzleParticle = Instantiate(muzzleParticle, transform.position, transform.rotation) as GameObject;
        //muzzleParticle = PhotonNetwork.Instantiate(muzzleParticle, transform.position, transform.rotation) as GameObject;
        //PV.RPC("DestroyTimeRPC", RpcTarget.All, muzzleParticle, 1.5f);
        Destroy(muzzleParticle, 1.5f); // Lifetime of muzzle effect.
        //PV.RPC("Destroy(muzzleParticle, 1.5f)", RpcTarget.AllBuffered); // Lifetime of muzzle effect.
        }
        //GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (!hasCollided)
        {
            hasCollided = true;
            //transform.DetachChildren();
            impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;
            //Debug.DrawRay(hit.contacts[0].point, hit.contacts[0].normal * 1, Color.yellow);

            if (other.tag == "Destructible") // Projectile will destroy objects tagged as Destructible
            {
                Destroy(other.gameObject);
            }
            if (other.CompareTag("Ground"))
            {
                //PhotonNetwork.Destroy(gameObject);// PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
                //PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
                //PV.RPC("DestroyRPC", RpcTarget.All,null);
                Destroy(projectileParticle, 3f);
                Destroy(impactParticle, 5f);
                Destroy(gameObject);
            }

            //if (!PV.IsMine && other.CompareTag("Player") && other.GetComponent<PhotonView>().IsMine)
            //{
            //    other.GetComponent<PlayerCONTROL>().Hit();
            //    PhotonNetwork.Destroy(gameObject);
            //    //PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
            //}

            //yield WaitForSeconds (0.05);
            foreach (GameObject trail in trailParticles)
            {
                GameObject curTrail = transform.Find(projectileParticle.name + "/" + trail.name).gameObject;
                curTrail.transform.parent = null;
                //PV.RPC("DestroyTimeRPC", RpcTarget.All, curTrail, 3f);
                Destroy(curTrail, 3f);
            }


            Destroy(projectileParticle, 3f);            
            Destroy(impactParticle, 5f);
            Destroy(gameObject);

            //PhotonNetwork.Destroy(gameObject);
            //PV.RPC("DestroyRPC", RpcTarget.AllBuffered);

            //PV.RPC("DestroyRPC", RpcTarget.All,null);

            //projectileParticle.Stop();

            ParticleSystem[] trails = GetComponentsInChildren<ParticleSystem>();
            //Component at [0] is that of the parent i.e. this object (if there is any)
            for (int i = 1; i < trails.Length; i++)
            {
                ParticleSystem trail = trails[i];
                if (!trail.gameObject.name.Contains("Trail"))
                    continue;

                trail.transform.SetParent(null);
                //PV.RPC("DestroyTimeRPC", RpcTarget.All, trail.gameObject, 2f);
                Destroy(trail.gameObject, 2);
            }

        }
        if(other.CompareTag("Player"))
        {
            Destroy(projectileParticle, 3f);
            Destroy(impactParticle, 5f);
            Destroy(gameObject);
        }

        //if (!PV.IsMine && other.CompareTag("Player") && other.GetComponent<PhotonView>().IsMine)
        //{
        //    //other.GetComponent<PlayerCONTROL>().Hit();
        //    //other.GetComponent<PlayerCONTROL>().GetComponent<PhotonView>().RPC("Hit", RpcTarget.All, null);
        //    other.GetComponent<PlayerCONTROL>().GetComponent<PhotonView>().RPC("Hit", RpcTarget.Others, null);                                                                                   
        //    //PhotonNetwork.Destroy(gameObject);
        //    //PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
        //    PV.RPC("DestroyRPC", RpcTarget.All,null);
        //}

        //if (!PV.IsMine && hit.collider.CompareTag("Player") && hit.collider.GetComponent<PhotonView>().IsMine)
        //{
        //    hit.collider.GetComponent<PlayerCONTROL>().Hit();

        //}
    }



    //void OnCollisionEnter(Collision hit)
    //{
    //    if (!hasCollided)
    //    {
    //        hasCollided = true;
    //        //transform.DetachChildren();
    //        impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;
    //        //Debug.DrawRay(hit.contacts[0].point, hit.contacts[0].normal * 1, Color.yellow);

    //        if (hit.gameObject.tag == "Destructible") // Projectile will destroy objects tagged as Destructible
    //        {
    //            Destroy(hit.gameObject);
    //        }
    //        if(hit.collider.CompareTag("Ground"))
    //        {
    //            PhotonNetwork.Destroy(gameObject);// PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
    //        }

    //        if (!PV.IsMine && hit.collider.gameObject.CompareTag("Player") && hit.collider.gameObject.GetComponent<PhotonView>().IsMine)
    //        {
    //            hit.collider.gameObject.GetComponent<PlayerCONTROL>().Hit();
    //            PhotonNetwork.Destroy(gameObject);
    //            //PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
    //        }

    //        //yield WaitForSeconds (0.05);
    //        foreach (GameObject trail in trailParticles)
    //        {
    //            GameObject curTrail = transform.Find(projectileParticle.name + "/" + trail.name).gameObject;
    //            curTrail.transform.parent = null;
    //            Destroy(curTrail, 3f);
    //        }
    //        Destroy(projectileParticle, 3f);
    //        Destroy(impactParticle, 5f);
    //        //Destroy(gameObject);

    //        PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
    //        //projectileParticle.Stop();

    //        ParticleSystem[] trails = GetComponentsInChildren<ParticleSystem>();
    //        //Component at [0] is that of the parent i.e. this object (if there is any)
    //        for (int i = 1; i < trails.Length; i++)
    //        {
    //            ParticleSystem trail = trails[i];
    //            if (!trail.gameObject.name.Contains("Trail"))
    //                continue;

    //            trail.transform.SetParent(null);
    //            Destroy(trail.gameObject, 2);
    //        }

    //    }
    //    //if (!PV.IsMine && hit.collider.CompareTag("Player") && hit.collider.GetComponent<PhotonView>().IsMine)
    //    //{
    //    //    hit.collider.GetComponent<PlayerCONTROL>().Hit();

    //    //}

    //}


    //[PunRPC]
    //void FireRPC() => GetComponent<Rigidbody>().AddForce(transform.forward * 1000);

    [PunRPC]
    void DestroyRPC() => PhotonNetwork.Destroy(gameObject);

    [PunRPC]
    void DestroyTimeRPC(GameObject gameobject, float time) => Destroy(gameobject, time);

}