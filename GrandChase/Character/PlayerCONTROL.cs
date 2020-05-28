using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

using UnityEngine.UI;

public class PlayerCONTROL : Character, IPunObservable
{
    
    //public float _moveSpeed;

    //private bool _isGround;
    public bool _isGround;


    public int _isComboCount;
    public bool _isDash;
    public bool _canDash;

    public int _dashCount;
    public int _dashLeftCount;
    public int _dashRightCount;
    public bool _rightDash;
    public bool _leftDash;

    public float _isMoveTime;

    public float _chargeTime;

    public float currentCharge;
    public float maxCharge = 150f;

    public float maxMp = 150.0f;
    public float currentMp = 0.0f;

    public GameObject chargeEffectPrefab;

    public bool flip;

    public float maxHp = 300.0f;
    public float currentHp = 300.0f;
    public float Atk = 25.0f;

    //public PhotonView PV;


    public bool _isSkillOne;
    public bool _isSkillTwo;
    public bool _isSkillThree;

    public float otherCurrentHp;
    public float otherHpBar;

    public Vector3 curPos;

    public bool isAttacking;
    public int hitCount;

    //photon TEST
    private bool isDie = false;
    public float respawnTime = 2.0f;

    public GameObject spellSpawnBox;
    public Image skillImage;
    public Image skillBackgroundImage;
    public float skillCastTime;
    public GameObject comboObject;

    public bool isComboUI;

    public bool isSkillThree;
    public bool isSkillOne;
    public AudioClip FireballSkillClip;

    public AudioSource playerAudio;


    //public bool _isCombo { get; set; }

    //public float _attackTime;
    override protected void UpdateProcess()
    {

        //if (GetComponent<PhotonView>().IsMine && !isDie)
        if (photonView.IsMine && !isDie)
        {
            UpdateInput();
        }
        //else if ((transform.position - curPos).sqrMagnitude >= 10) transform.position = curPos;
        //else transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 10);
        if(photonView.IsMine)
        {
            uiObject.transform.Find("hp").GetComponent<PlayerHpBar>().hpBar.fillAmount = currentHp / maxHp;
            //uiObject.transform.Find("Text").GetComponent<Text>().text = currentHp.ToString();

            uiObject.transform.Find("charge").GetComponent<PlayerChargeMpBar>().ChargeMpBar.fillAmount = currentCharge / maxCharge;
            if (isComboUI)
            {
                uiObject.transform.Find("Combo").gameObject.SetActive(true);
                //comboObject.SetActive(true);
                //comboObject.transform.Find("comboNum").GetComponent<Text>().text = hitCount.ToString();
                uiObject.transform.Find("Combo").Find("comboNum").GetComponent<Text>().text = hitCount.ToString();

                //uiObject.transform.Find("Combo").Find("totalText").GetComponent<Text>().text = "Total" + hitCount.ToString();
            }
        }
        //uiObject.transform.Find("hp").GetComponent<PlayerHpBar>().hp = currentHp;
        UpdateState();
        //if(isComboUI)
        //{
        //    uiObject.transform.Find("Combo").gameObject.SetActive(true);
        //    //comboObject.SetActive(true);
        //    //comboObject.transform.Find("comboNum").GetComponent<Text>().text = hitCount.ToString();
        //    uiObject.transform.Find("Combo").Find("comboNum").GetComponent<Text>().text = hitCount.ToString();
            
        //    //uiObject.transform.Find("Combo").Find("totalText").GetComponent<Text>().text = "Total" + hitCount.ToString();
        //}
        //uiObject.transform.Find("Combo").gameObject.SetActive(false);
        //else if (!isComboUI)
        //{
        //    uiObject.transform.Find("Combo").gameObject.SetActive(false);
        //    comboObject.SetActive(false);
        //}

        //if(!photonView.IsMine)
        //  otherHpBar = otherCurrentHp;

        //curPos = transform.position;
        //if(PV.IsMine)
        //if(GetComponent<PhotonView>().IsMine)
        //    UpdateInput();
        //UpdateState();

        //if (currentMp <= maxMp)
        //    currentMp += 0.1f;
        //Debug.Log(currentHp);
    }

    override protected void InitState()
    {
        base.InitState();

        


        State attackState = new PlayerAttackState();
        attackState.Init(this);
        _stateDic[eSTATE.ATTACK] = attackState;

        State moveState = new MoveState();
        moveState.Init(this);
        _stateDic[eSTATE.MOVE] = moveState;

        State hitState = new PlayerHitState();
        hitState.Init(this);
        _stateDic[eSTATE.HIT] = hitState;

        State skillOneState = new SkillOne();
        skillOneState.Init(this);
        _stateDic[eSTATE.HIT] = skillOneState;


        State skillTwoState = new SkillTwo();
        skillTwoState.Init(this);
        _stateDic[eSTATE.HIT] = skillTwoState;

        State skillThreeState = new SkillThree();
        skillThreeState.Init(this);
        _stateDic[eSTATE.HIT] = skillThreeState;

        State idleState = new PlayerIdleState();
        idleState.Init(this);
        _stateDic[eSTATE.IDLE] = idleState;
    }


    void UpdateInput()
    {
        _inputHorizontalDirection = eINPUTDIRECTION.NONE;
        _inputVerticalDirection = eINPUTDIRECTION.NONE;
        _inputAniDirection = eINPUTDIRECTION.NONE;

        if(Input.GetKey(KeyCode.RightArrow))// && _currentState != _stateDic[eSTATE.ATTACK])
        {
            _inputHorizontalDirection = eINPUTDIRECTION.RIGHT;
            _inputAniDirection = eINPUTDIRECTION.RIGHT;
            _currentState.ChangeState(eSTATE.MOVE);
        }
        if(Input.GetKey(KeyCode.LeftArrow))// && _currentState != _stateDic[eSTATE.ATTACK])
        {
            _inputHorizontalDirection = eINPUTDIRECTION.LEFT;
            _inputAniDirection = eINPUTDIRECTION.LEFT;
            _currentState.ChangeState(eSTATE.MOVE);
        }
        if(Input.GetKey(KeyCode.UpArrow) && _isGround)
        {
            _inputVerticalDirection = eINPUTDIRECTION.UP;
            _inputAniDirection = eINPUTDIRECTION.UP;
            GetComponent<BoxCollider>().isTrigger = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //_moveSpeed = 0f;
            _isDash = false;
            //_currentState.ChangeState(eSTATE.IDLE);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //_moveSpeed = 0f;
            _isDash = false;
            //_currentState.ChangeState(eSTATE.IDLE);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _currentState.ChangeState(eSTATE.ATTACK);
            //_attackTime += Time.deltaTime;
            //StartCoroutine("startComboTime");
        }
        if(Input.GetKey(KeyCode.Z))
        {
           _chargeTime += Time.deltaTime;
            if (_chargeTime >= 0.5f)
            {
                _isComboCount = 0;
                if(_currentState.Equals(eSTATE.MOVE))
                {
                    GetComponent<Animator>().SetTrigger("move");
                }
                else if(_currentState.Equals(eSTATE.IDLE))
                {
                    GetComponent<Animator>().SetTrigger("idle");
                }
                if (flip)
                    chargeEffectPrefab.transform.position = new Vector3(transform.position.x, transform.position.y+0.55f,transform.position.z-2);
                else if(!flip)
                {
                    chargeEffectPrefab.transform.position = new Vector3(transform.position.x, transform.position.y+0.55f,transform.position.z-2);
                }
                chargeEffectPrefab.SetActive(true);
                if (currentCharge <= currentMp)
                {
                    currentCharge += 0.5f;
                }
            }
        }
        //_currentState.ChangeState(eSTATE.IDLE);
        if (Input.GetKeyUp(KeyCode.Z))
        {
            chargeEffectPrefab.SetActive(false);
            if(currentCharge>=40 && currentCharge<80)
            {
                //transform.Find("SpellSpawnBox").GetComponent<SkillSpawn>();
                //PhotonView pv = GameObject.Find("SpellSpawnBox").GetComponent<PhotonView>();
                //pv.RPC("Fire", RpcTarget.Others, null);

                //PhotonView pv = gameObject.GetComponent<PhotonView>();
                //pv.RPC("Fire", RpcTarget.Others, null);
                //PhotonNetwork.Instantiate("FireMegaObj", spellSpawnBox.transform.position, transform.rotation).GetComponent<PhotonView>().RPC("FireRPC", RpcTarget.All, null);
                //PhotonNetwork.Instantiate("FireMegaObj", spellSpawnBox.transform.position, transform.rotation).GetComponent<PhotonView>().RPC("FireRPC", RpcTarget.All, null);


                //skillImage.enabled = true;
                //skillBackgroundImage.enabled = true;



                //uiObject.transform.Find("SkillImage").gameObject.SetActive(true);
                //uiObject.transform.Find("SkillBackGroundImage").gameObject.SetActive(true);
                //skillCastTime += Time.deltaTime;
                //if(skillCastTime>=1.0f)
                //{
                //    skillCastTime = 0;
                //    uiObject.transform.Find("SkillImage").gameObject.SetActive(false);
                //    //uiObject.transform.Find("SkillImage").GetComponent<Image>().enabled = false;
                //    uiObject.transform.Find("SkillBackGroundImage").gameObject.SetActive(false);
                //    //uiObject.transform.Find("SkillBackGroundImage").GetComponent<Image>().enabled = false;
                //    //skillImage.enabled = false;
                //    //skillBackgroundImage.enabled = false;
                //    photonView.RPC("Fire", RpcTarget.All);
                //}


                currentMp -= 40;
                //_isSkillOne = true;
                _currentState.ChangeState(eSTATE.SKILLONE);
                //currentCharge = 0f;
                //_chargeTime = 0f;
                //skillCastTime = 0;
            }
            else if (currentCharge >= 80 && currentCharge < 120)
            {
                currentMp -= 80;
                _currentState.ChangeState(eSTATE.SKILLTWO);
                //currentCharge = 0f;
                //_chargeTime = 0f;
                //skillCastTime = 0;
            }
            else if (currentCharge >= 120)
            {
                currentMp -= 120;
                //_isSkillThree = true;
                _currentState.ChangeState(eSTATE.SKILLTHREE);
                //currentCharge = 0f;
                //_chargeTime = 0f;
                //skillCastTime = 0;
            }
            currentCharge = 0f;
            _chargeTime = 0f;
            skillCastTime = 0;
            //_currentState.ChangeState(eSTATE.IDLE);
        }



        //RaycastHit hit;
        //int layerMask = 1 << 8;

        //Debug.DrawRay(transform.position, -transform.up * 0.5f, Color.red);

        //if (Physics.Raycast(transform.position, -transform.up, out hit, 0.5f, layerMask))
        //{
        //    Debug.Log(hit.collider.gameObject.tag);
        //    GetComponent<BoxCollider>().isTrigger = false;
        //}

        Vector3 origin = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);

        if (!_isGround)
        {
            RaycastHit hit;
            int layerMask = 1 << 9;

            Debug.DrawRay(origin, -transform.up * 0.5f, Color.red);

            if (Physics.Raycast(origin, -transform.up, out hit, 0.5f, layerMask))
            {
                Debug.Log(hit.collider.gameObject.tag);
                GetComponent<BoxCollider>().isTrigger = false;
                //GetComponent<Rigidbody>().useGravity = false;
                //if(_inputVerticalDirection != eINPUTDIRECTION.UP)
                    //GetComponent<Rigidbody>().velocity = Vector3.up * 0;
            }
        }

        {
            Vector3 slopRightCheckOrigin = new Vector3(transform.position.x, transform.position.y/* + 0.000001f*/, transform.position.z);
            RaycastHit rightHit;
            int layerMask = 1 << 10;
            Debug.DrawRay(slopRightCheckOrigin, transform.forward * 0.1f, Color.red);
            if (Physics.Raycast(slopRightCheckOrigin, transform.forward, out rightHit, 0.1f, layerMask))
            {

                GetComponent<BoxCollider>().isTrigger = false;
                if (rightHit.collider.transform.position.y >= transform.position.y)
                {
                    transform.position = new Vector3(transform.position.x, rightHit.collider.transform.position.y, transform.position.z);
                }


            }

            //Vector3 slopLeftCheckOrigin = new Vector3(transform.position.x, transform.position.y/* + 0.000001f*/, transform.position.z);
            //RaycastHit LeftHit;
            //Debug.DrawRay(slopLeftCheckOrigin, -transform.forward * 0.5f, Color.green);
            //if (Physics.Raycast(slopLeftCheckOrigin, -transform.forward, out LeftHit, 0.1f, layerMask))
            //{

            //    GetComponent<BoxCollider>().isTrigger = false;
            //    if (LeftHit.collider.transform.position.y <= transform.position.y)
            //    {
            //        transform.position = new Vector3(transform.position.x, LeftHit.collider.transform.position.y, transform.position.z);
            //    }

            //}
        }


    }

    //IEnumerator startComboTime()
    //{
    //    _attackTime += Time.deltaTime;
    //    yield return new WaitForSeconds(0.2f);
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("HPITEM"))
        {
            if (currentHp >= 0 && currentHp + 30 < maxHp)
                currentHp += 30;
            else if(currentHp+30>=maxHp)
            {
                currentHp = maxHp;
            }
        }
        if (collision.collider.CompareTag("MPITEM"))
        {
            if(currentMp+40<maxMp)
            {
                currentMp += 40;
            }
            else if(currentMp+40>=maxMp)
            {
                currentMp = maxMp;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isGround = true;

            //GetComponent<Rigidbody>().useGravity = true;
            //GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            _isGround = false;

            //GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("SKILL") && !skillImage.enabled)// && !isDie))
        if (other.CompareTag("SKILL") && !uiObject.transform.Find("SkillImage").gameObject.activeSelf)// && !isDie))
        {
            currentHp -= 20.0f;
            _currentState.ChangeState(eSTATE.HIT);
        }

        if(other.CompareTag("WEAPON") && !uiObject.transform.Find("SkillImage").gameObject.activeSelf && isAttacking)
        {
            currentHp -= 5.0f;
            _currentState.ChangeState(eSTATE.HIT);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("SKILL") && !isDie)// && !photonView.IsMine)
    //    {
    //        int actorNumber = other.gameObject.GetComponent<MagicProjectileScript>().actorNumber;
    //        //string hitter = GetNickNameByActorNumber(actorNumber);

    //        currentHp -= 20.0f;

    //        if (photonView.IsMine && currentHp <= 0.0f)
    //        {
    //            isDie = true;
    //            //StartCoroutine(RespawnPlayer(actorNumber));
    //        }

    //        _currentState.ChangeState(eSTATE.HIT);
    //    }
    //}

    ////private void OnTriggerEnter(Collider other)
    ////{
    ////    if (other.CompareTag("Player"))
    ////    {
    ////        _currentState.ChangeState(eSTATE.HIT);
    ////    }
    ////}

    ////private void OnTriggerExit(Collider other)
    ////{
    ////    if (other.CompareTag("Player"))
    ////    {
    ////        _currentState.ChangeState(eSTATE.HIT);
    ////    }
    ////}

    //IEnumerator RespawnPlayer(int actorNumber)
    //{
    //    //Transform followTr = null;

    //    //foreach (GameObject tank in GameObject.FindGameObjectsWithTag("TANK"))
    //    //{
    //    //    if (tank.GetComponent<PhotonView>().OwnerActorNr == actorNumber)
    //    //    {
    //    //        followTr = tank.transform.Find("CamPivot").transform;
    //    //        break;
    //    //    }
    //    //}
    //    yield return new WaitForSeconds(respawnTime);
    //    currentHp = 300.0f;
    //    isDie = false;
    //}



    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        //photonView.
    //        stream.SendNext(currentHp);
    //        stream.SendNext(otherCurrentHp);
    //    }
    //    else
    //    {
    //        currentHp = (float)stream.ReceiveNext();
    //        otherCurrentHp = (float)stream.ReceiveNext();
    //        //currentHp = (float)stream.ReceiveNext();
    //        //otherHpBar = (float)stream.ReceiveNext();
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    //if (other.CompareTag("Ground"))
    //    //{
    //    //    //_isGround = true;
    //    //    GetComponent<BoxCollider>().isTrigger = false;
    //    //}

    //    RaycastHit hit;
    //    int layerMask = 1 << 8;

    //    Debug.DrawRay(transform.position, -transform.up * 0.5f, Color.red);

    //    if (Physics.Raycast(transform.position, -transform.up, out hit, 0.5f, layerMask))
    //    {
    //        Debug.Log(hit.collider.gameObject.tag);
    //        GetComponent<BoxCollider>().isTrigger = false;
    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Ground"))
    //    {                                                                 
    //        _isGround = false;
    //    }
    //}

    // Update is called once per frame
    //[PunRPC]
    //void Fire()
    //{
    //    GameObject projectile = Instantiate(Resources.Load("FireMegaObj"), transform.position, transform.rotation) as GameObject;
    //    projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 1000);
    //}

    [PunRPC]
    public void FireOne()
    {
        //PhotonNetwork.Instantiate("FireMegaObj", spellSpawnBox.transform.position, transform.rotation).GetComponent<PhotonView>().RPC("FireRPC", RpcTarget.All, null);
        //GameObject projectile = Instantiate(Resources.Load("FireMegaObj"), transform.position, transform.rotation) as GameObject;

        GameObject projectile = Instantiate(Resources.Load("FireMegaObj"), spellSpawnBox.transform.position, transform.rotation) as GameObject;
        playerAudio.clip = FireballSkillClip;
        playerAudio.Play();
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 1000);
    }

    [PunRPC]
    public void FireThree()
    {
        Instantiate(Resources.Load("MeteorSwarm"));
    }

    [PunRPC]
    public void Hit()
    {
        currentHp -= 40;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(currentHp);
            //photonView.
            //stream.SendNext(transform.position);
            //stream.SendNext(otherCurrentHp);
        }
        else
        {
            
            currentHp = (float)stream.ReceiveNext();
            //curPos = (Vector3)stream.ReceiveNext();
            //otherCurrentHp = (float)stream.ReceiveNext();
            //currentHp = (float)stream.ReceiveNext();
            //otherHpBar = (float)stream.ReceiveNext();
        }
    }
    
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 