using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCount : MonoBehaviour
{
    public GameObject playerObject;
    public List<GameObject> effectList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerObject.GetComponent<PlayerCONTROL>().isAttacking)
        {
            for(int i =0;i<effectList.Count;i++)
            {
                Destroy(effectList[i]);
            }
                effectList.Clear();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerObject.GetComponent<PlayerCONTROL>().isAttacking)
            {
                playerObject.GetComponent<PlayerCONTROL>().hitCount += 1;
                playerObject.GetComponent<PlayerCONTROL>().isComboUI = true;
                switch (playerObject.GetComponent<PlayerCONTROL>()._isComboCount)
                {
                    case 1:
                        GameObject effectOneHit = Instantiate(Resources.Load("hitEffect"),other.transform) as GameObject;
                        effectOneHit.GetComponent<ParticleSystem>().Play();
                        effectList.Add(effectOneHit);
                        break;
                    case 2:
                        GameObject effectTwoHit = Instantiate(Resources.Load("hitEffect1"), other.transform) as GameObject;
                        effectTwoHit.GetComponent<ParticleSystem>().Play();
                        effectList.Add(effectTwoHit);
                        break;
                    case 3:
                        GameObject effectThreeHit = Instantiate(Resources.Load("hitEffect2"), other.transform) as GameObject;
                        effectThreeHit.GetComponent<ParticleSystem>().Play();
                        effectList.Add(effectThreeHit);
                        break;
                    case 4:
                        GameObject effectFourHit = Instantiate(Resources.Load("hitEffect3"), other.transform) as GameObject;
                        effectFourHit.GetComponent<ParticleSystem>().Play();
                        effectList.Add(effectFourHit);
                        break;
                    case 5:
                        GameObject effectFiveHit = Instantiate(Resources.Load("hitEffect4"), other.transform) as GameObject;
                        effectFiveHit.GetComponent<ParticleSystem>().Play();
                        effectList.Add(effectFiveHit);
                        break;
                }
            }
        }
    }
}
