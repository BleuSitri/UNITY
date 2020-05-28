using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ItemSpawn : MonoBehaviourPunCallbacks, IPunObservable
{
    public float itemSpawnTime;
    public int itemCount;
    public float spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //itemSpawnTime += Time.deltaTime;
        itemCount += 1;



        //if(itemSpawnTime>= 1.0f)
        if(itemCount >= 1)
        {
            //if(itemSpawnTime%5 ==0)
            if (itemCount % 700 ==0)
            { 
                spawnPoint = Random.Range(0.5f, 25f);
                itemCount = 0;
                var _item = ItemPool.instance.GetItem();
                if(_item != null)
                {
                    _item.transform.position = new Vector3(spawnPoint, 0.5f, -3f);
                    _item.SetActive(true);
                }
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(spawnPoint);
        }
        else
        {
            spawnPoint = (float)stream.ReceiveNext();
        }
    }
}
