using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SkillThree : State
{

    public float skillCastTime;

    public bool isSkillThree;
    // Start is called before the first frame update
    override public void Start()
    {
        ////skillCastTime = 0f;
        //_character.CharacterModel.GetComponent<PlayerCONTROL>().skillCastTime = 0f;
        //isSkillThree = true;
        ////skillPoolObject = GameObject.FindGameObjectWithTag("SKILLPOOL");
        ////meteorPrefab = skillPoolObject.transform.Find("MeteorSwarm").gameObject;
    }

    // Update is called once per frame
    override public void Update()
    {
       // _character.CharacterModel.GetComponent<PlayerCONTROL>().uiObject.transform.Find("SkillImage").gameObject.SetActive(true);
       // _character.CharacterModel.GetComponent<PlayerCONTROL>().uiObject.transform.Find("SkillBackGroundImage").gameObject.SetActive(true);
       // //skillCastTime += Time.deltaTime;
       // _character.CharacterModel.GetComponent<PlayerCONTROL>().skillCastTime += Time.deltaTime;
       // //Debug.Log(skillCastTime);
       // //if (skillCastTime >= 1.0f)
       // if (_character.CharacterModel.GetComponent<PlayerCONTROL>().skillCastTime >= 1.5f && isSkillThree)
       //// if (_character.CharacterModel.GetComponent<PlayerCONTROL>().skillCastTime >= 1.5f &&
       // //    _character.CharacterModel.GetComponent<PlayerCONTROL>()._isSkillThree)
       // {
       //    // _character.CharacterModel.GetComponent<PlayerCONTROL>()._isSkillThree = false;
       //     isSkillThree = false;
       //     //isSkillOne = true;
       //     _character.CharacterModel.GetComponent<PlayerCONTROL>().uiObject.transform.Find("SkillImage").gameObject.SetActive(false);
       //     _character.CharacterModel.GetComponent<PlayerCONTROL>().uiObject.transform.Find("SkillBackGroundImage").gameObject.SetActive(false);
       //     //skillCastTime = 0f;
       //     _character.CharacterModel.GetComponent<PlayerCONTROL>().skillCastTime = 0f;

       //     //isSkillOne = false;
       //     _character.CharacterModel.GetComponent<PhotonView>().RPC("FireThree", RpcTarget.All);
       //     _character.ChangeState(PlayerCONTROL.eSTATE.IDLE);
       // }
    }
}
