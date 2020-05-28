using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Character : MonoBehaviourPunCallbacks//, IPunObservable
{
    public GameObject CharacterModel;

    //혹시나 다른 캐릭터의 공격과 겹쳐서 comboCount가 다르게 올라갈 경우
    //player단으로 내리거나 다른 방식 사용해보자!
    //public int _isComboCount;
    //public bool _isDash;
    //public bool _canDash;

    //public int _dashCount;
    //public int _dashLeftCount;
    //public int _dashRightCount;
    //public bool _rightDash;
    //public bool _leftDash;

    //public float _isMoveTime;
    public GameObject WeaponObject;

    public PhotonView PV;
    //public float otherCurrentHp;
    
    //
    public int actorNumber = -1;

    public GameObject uiObject;



    void Start()
    {
        Init();
    }
    void Update()
    {
        UpdateProcess();
    }

    public void Init()
    {
        WeaponObject = GameObject.FindGameObjectWithTag("WEAPON");
        //uiObject = GameObject.FindGameObjectWithTag("GAMEUI");
        uiObject = GameObject.FindGameObjectWithTag("CANVAS").transform.Find("GameUI").gameObject;
        InitState();
        ChangeState(eSTATE.IDLE);
    }

    virtual protected void UpdateProcess()
    {
        UpdateState();
    }

    public enum eSTATE
    {
        IDLE,
        MOVE,
        ATTACK,
        HIT,
        DIE,
        SKILLONE,
        SKILLTWO,
        SKILLTHREE,
    }

    protected Dictionary<eSTATE, State> _stateDic = new Dictionary<eSTATE, State>();
    protected State _currentState;
    
    virtual protected void InitState()
    {

        State moveState = new MoveState();
        State attackState = new AttackState();
        State hitState = new HitState();


        State skillOneState = new SkillOne();
        State skillTwoState = new SkillTwo();
        State skillThreeState = new SkillThree();
        State idleState = new IdleState();



        moveState.Init(this);
        attackState.Init(this);
        hitState.Init(this);
        skillOneState.Init(this);
        skillTwoState.Init(this);
        skillThreeState.Init(this);
        idleState.Init(this);


        _stateDic.Add(eSTATE.MOVE, moveState);
        _stateDic.Add(eSTATE.ATTACK, attackState);
        _stateDic.Add(eSTATE.HIT, hitState);
        _stateDic.Add(eSTATE.SKILLONE, skillOneState);
        _stateDic.Add(eSTATE.SKILLTWO, skillTwoState);
        _stateDic.Add(eSTATE.SKILLTHREE, skillThreeState);
        _stateDic.Add(eSTATE.IDLE, idleState);
    }
    public void ChangeState(eSTATE nextState)
    {
        if(null != _currentState)
        {
            _currentState.Stop();
        }
        _currentState = _stateDic[nextState];
        _currentState.Start();
    }

    protected void UpdateState()
    {
        _currentState.Update();
        //_currentState.FixedUpdate();
    }

    //Input
    public enum eINPUTDIRECTION
    {
        NONE,
        RIGHT,
        LEFT,
        UP,
    }

    protected eINPUTDIRECTION _inputVerticalDirection = eINPUTDIRECTION.NONE;
    protected eINPUTDIRECTION _inputHorizontalDirection = eINPUTDIRECTION.NONE;
    protected eINPUTDIRECTION _inputAniDirection = eINPUTDIRECTION.NONE;

    public eINPUTDIRECTION GetInputHorizontalDirection()
    {
        return _inputHorizontalDirection;
    }
    public eINPUTDIRECTION GetInputVerticalDirection()
    {
        return _inputVerticalDirection;
    }
    public eINPUTDIRECTION GetAniDirection()
    {
        return _inputAniDirection;
    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if(stream.IsWriting)
    //    {
    //        stream.SendNext(CharacterModel.GetComponent<PlayerCONTROL>().currentHp);
    //    }
    //    else
    //    {
    //        otherCurrentHp = (float)stream.ReceiveNext();
    //    }

    //}

    //move
    //public void UpdateMove()
    //{
    //    Vector3 addPosition = Vector3.zero;
    //    Vector3 velocity = CharacterModel.GetComponent<Rigidbody>().velocity;

    //    //transform을 바꾸는 것이 아니라 addforce로 해보도록 생각해보자
    //    //이 코드는 오른쪽일때 moveSpeed*time.deltatime을 position에 더해준 값.

    //    switch (_inputVerticalDirection)
    //    {
    //        case eINPUTDIRECTION.UP:
    //            velocity.y = 6.0f;

    //            break;
    //    }

    //    switch (_inputHorizontalDirection)
    //    {
    //        case eINPUTDIRECTION.RIGHT:
    //            //if (_isDash)
    //            //{
    //            //    addPosition.z = MoveOffset(16.0f);
    //            //    _isDash = false;
    //            //}

    //            //if (_dashCount >= 2)
    //            //{
    //            //    addPosition.z = MoveOffset(640.0f);
    //            //    _dashCount = 0;
    //            //}
    //            _isMoveTime += Time.deltaTime;
    //            if (_isMoveTime >= 0.4f)
    //            {
    //                //_character._canDash = false;
    //                //_isMoveTime = 0;


    //                _dashLeftCount = 0;
    //                _dashRightCount = 0;
    //                _isMoveTime = 0;
    //            }


    //            if (!_rightDash)
    //            {
    //                _rightDash = true;
    //                _dashRightCount += 1;
    //                _dashLeftCount = 0;
    //            }
    //            if(_dashRightCount >= 2)
    //            {
    //                CharacterModel.GetComponent<Animator>().SetTrigger("dash");
    //                addPosition.z = MoveOffset(640.0f);
    //                _rightDash = true;
    //                _dashRightCount = 0;
    //            }
    //            //else if(_dashCount < 2)
    //            else if(_dashRightCount < 2)// && _dashLeftCount==0)
    //                addPosition.z = MoveOffset(8.0f);

    //            break;
    //        case eINPUTDIRECTION.LEFT:
    //            //if (_isDash)
    //            //{
    //            //    addPosition.z = MoveOffset(-640.0f);
    //            //    _isDash = false;
    //            //}
    //            //addPosition.z = MoveOffset(-8.0f);

    //            _isMoveTime += Time.deltaTime;
    //            if (_isMoveTime >= 0.4f)
    //            {
    //                //_character._canDash = false;
    //                //_isMoveTime = 0;


    //                _dashLeftCount = 0;
    //                _dashRightCount = 0;
    //                _isMoveTime = 0;
    //            }

    //            if (!_leftDash)
    //            {
    //                _leftDash = true;
    //                _dashLeftCount += 1;
    //                _dashRightCount = 0;
    //            }
    //            if (_dashLeftCount >= 2)
    //            {
    //                //addPosition.z = MoveOffset(-640.0f);
    //                addPosition.z = MoveOffset(640.0f);//Flip때문에
    //                _leftDash = true;
    //                _dashLeftCount = 0;
    //            }
    //            //else if(_dashCount < 2)
    //            else if (_dashLeftCount < 2)// && _dashRightCount == 0)
    //               // addPosition.z = MoveOffset(-8.0f);
    //                addPosition.z = MoveOffset(8.0f);//Flip때문에

    //            break;
    //    }
    //    _isComboCount = 0;
    //    transform.position += (transform.rotation * addPosition);
    //    CharacterModel.GetComponent<Rigidbody>().velocity = velocity;

    //}

    //float MoveOffset(float moveSpeed)
    //{
    //    return (moveSpeed * Time.deltaTime);
    //}

    //Attack


    //Animation

}
