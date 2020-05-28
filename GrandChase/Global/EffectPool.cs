using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPool : MonoBehaviour
{
    private GameObject effectPoolObject;
    private static EffectPool m_instance;
    public static EffectPool instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<EffectPool>();
            }
            return m_instance;
        }
    }

    public GameObject[] effectPrefab;
    //public int maxPool = 10;

    public List<GameObject> effectPool = new List<GameObject>();

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
        effectPoolObject = GameObject.FindGameObjectWithTag("EFFECTPOOL");
        CreateEffectPool();
    }

    public GameObject GetEffect()
    {
        for (int i = 0; i < effectPool.Count; i++)
        {
            if (effectPool[i].activeSelf == false)
            {
                return effectPool[i];
            }
        }
        return null;
    }
    public void CreateEffectPool()
    {
        for (int i = 0; i < effectPrefab.Length; i++)
        {
            GameObject selectedItem = effectPrefab[i];
            var obj = Instantiate<GameObject>(selectedItem, effectPoolObject.transform);
            obj.name = selectedItem.name;
            obj.SetActive(false);
            effectPool.Add(obj);
        }
    }
}
