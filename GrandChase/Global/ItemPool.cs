using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ItemPool : MonoBehaviourPunCallbacks, IPunObservable
{
    int randomNumber;
    // Start is called before the first frame update
    private GameObject itemPoolObject;
    private static ItemPool m_instance;
    public static ItemPool instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<ItemPool>();
            }
            return m_instance;
        }
    }

    public GameObject[] itemPrefab;
    public int maxPool = 10;

    public List<GameObject> itemPool = new List<GameObject>();

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
        itemPoolObject = GameObject.FindGameObjectWithTag("ITEMPOOL");
        CreatePool();
    }

    public GameObject GetItem()
    {
        for (int i = 0; i < itemPool.Count; i++)
        {
            if (itemPool[i].activeSelf == false)
            {
                return itemPool[i];
            }
        }
        return null;
    }
    public void CreatePool()
    {
        for(int i =0;i<maxPool;i++)
        {
            randomNumber = Random.Range(0, itemPrefab.Length);
            GameObject selectedItem = itemPrefab[Random.Range(0, itemPrefab.Length)];
            var obj = Instantiate<GameObject>(selectedItem, itemPoolObject.transform);
            obj.name = selectedItem.name + i.ToString("00");
            obj.SetActive(false);
            itemPool.Add(obj);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(randomNumber);
        }
        else
        {
            randomNumber = (int)stream.ReceiveNext();
        }
    }
}
