using DigitalRuby.PyroParticles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SkillOne : State
{
    public GameObject skillPoolObject;
    public GameObject spellSpawnBox;

    public GameObject playerObject;
    public float skillCastTime;
    public bool isSkillOne;
    // Start is called before the first frame update
    override public void Start()
    {
        //skillCastTime = 0f;
        _character.CharacterModel.GetComponent<PlayerCONTROL>().skillCastTime = 0f;
        //skillPoolObject = GameObject.FindGameObjectWithTag("SKILLPOOL");
        //meteorPrefab = skillPoolObject.transform.Find("MeteorSwarm").gameObject;
        spellSpawnBox = _character.CharacterModel.gameObject.transform.Find("SpellSpawnBox").gameObject;
        Debug.Log("SkillOneSTate");
        isSkillOne = true;
        //_character.CharacterModel.GetComponent<PlayerCONTROL>().uiObject.transform.Find("SkillImage").gameObject.SetActive(true);
        //_character.CharacterModel.GetComponent<PlayerCONTROL>().uiObject.transform.Find("SkillBackGroundImage").gameObject.SetActive(true);
        //_character.CharacterModel.GetComponent<PhotonView>().RPC("Fire", RpcTarget.All);

        //Instantiate(Resources.Load("Fireball"), new Vector3(10f, -1.75f, 48.73f), Quaternion.Euler(new Vector3(0,_character.CharacterModel.transform.rotation.y,0)));
        //Instantiate(Resources.Load("Fireball"), new Vector3(10f, -1.75f, 48.73f), _character.CharacterModel.transform.rotation);
        //Instantiate(Resources.Load("Fireball"), _character.CharacterModel.transform.position + new UnityEngine.Vector3(2.5f, 0, 0), _character.CharacterModel.transform.rotation);//_character.CharacterModel.transform.rotation);
        // skillPoolObject.Instantiate("MeteorSwarm");
        //skillPoolObject = Instantiate(Resources.Load("PyroParticles/Prefab/Prefab/MeteorSwarm")) as GameObject;
        //PhotonNetwork.Instantiate("MeteorSwarm", new Vector3(-3.979701f, -1.75f, 41.7f), Quaternion.identity);

        //GameObject projectile = Instantiate(Resources.Load("FireMegaObj"), spawnPosition.position, Quaternion.identity) as GameObject;
        // GameObject projectile = Instantiate(Resources.Load("FireMegaObj"), _character.CharacterModel.gameObject.transform.position, Quaternion.identity) as GameObject;

        //if (!photonView.IsMine) return;
        //photonView.RPC("Fire", RpcTarget.Others);
        //Fire();

        //playerObject = GameObject.FindGameObjectWithTag("Player");
        //playerObject.GetComponent<PhotonView>().RPC("Fire", RpcTarget.Others, null);

        //GameObject projectile = Instantiate(Resources.Load("FireMegaObj"), spellSpawnBox.transform.position, _character.CharacterModel.transform.rotation) as GameObject;
        //projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 1000);



        //projectile.transform.LookAt(hit.point);


        //projectile.GetComponent<MagicProjectileScript>().impactNormal = hit.normal;

        //Instantiate(meteorPrefab, new Vector3(-3.979701f, -1.75f, 41.7f), Quaternion.identity,);

    }

    //[PunRPC]
    //void Fire()
    //{
    //    GameObject projectile = Instantiate(Resources.Load("FireMegaObj"), spellSpawnBox.transform.position, _character.CharacterModel.transform.rotation) as GameObject;
    //    projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 1000);
    //}

    //[PunRPC]
    //void Fire()
    //{
    //    GameObject projectile = Instantiate(Resources.Load("FireMegaObj"), spellSpawnBox.transform.position, _character.CharacterModel.transform.rotation) as GameObject;
    //    projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 1000);
    //}

    // Update is called once per frame
    override public void Update()
    {
        _character.CharacterModel.GetComponent<PlayerCONTROL>().uiObject.transform.Find("SkillImage").gameObject.SetActive(true);
        _character.CharacterModel.GetComponent<PlayerCONTROL>().uiObject.transform.Find("SkillBackGroundImage").gameObject.SetActive(true);
        //skillCastTime += Time.deltaTime;
        _character.CharacterModel.GetComponent<PlayerCONTROL>().skillCastTime += Time.deltaTime;
        Debug.Log(skillCastTime);
        //if(skillCastTime>=1.0f)
         if (_character.CharacterModel.GetComponent<PlayerCONTROL>().skillCastTime >=1.0f && isSkillOne)
        //if (_character.CharacterModel.GetComponent<PlayerCONTROL>().skillCastTime >= 1.5f &&
        //    _character.CharacterModel.GetComponent<PlayerCONTROL>()._isSkillOne)
        {
            //_character.CharacterModel.GetComponent<PlayerCONTROL>()._isSkillOne = false;
            isSkillOne = false;
            _character.CharacterModel.GetComponent<PlayerCONTROL>().uiObject.transform.Find("SkillImage").gameObject.SetActive(false);
            _character.CharacterModel.GetComponent<PlayerCONTROL>().uiObject.transform.Find("SkillBackGroundImage").gameObject.SetActive(false);
            // skillCastTime = 0f;
            _character.CharacterModel.GetComponent<PlayerCONTROL>().skillCastTime = 0f;
           
            //isSkillOne = false;
            _character.CharacterModel.GetComponent<PhotonView>().RPC("FireOne", RpcTarget.All);
            _character.ChangeState(PlayerCONTROL.eSTATE.IDLE);
        }
        //if(isSkillOne)
        //{
        //    _character.CharacterModel.GetComponent<PlayerCONTROL>().uiObject.transform.Find("SkillImage").gameObject.SetActive(false);
        //    _character.CharacterModel.GetComponent<PlayerCONTROL>().uiObject.transform.Find("SkillBackGroundImage").gameObject.SetActive(false);
        //    skillCastTime = 0f;
            
        //    //isSkillOne = false;
        //    _character.CharacterModel.GetComponent<PhotonView>().RPC("Fire", RpcTarget.All);
        //    _character.ChangeState(PlayerCONTROL.eSTATE.IDLE);
        //}
    }
}
