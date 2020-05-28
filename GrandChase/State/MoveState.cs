using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    bool _isFlip;
    bool _isDash;

    public float _moveSpeed;

    PlayerCONTROL.eINPUTDIRECTION _preAniDirection;
    // Start is called before the first frame update
    override public void Start()
    {
        _isHitTime = 0;
        _preAniDirection = PlayerCONTROL.eINPUTDIRECTION.NONE;
        UpdateAnimation();
        _character.CharacterModel.GetComponent<PlayerCONTROL>()._canDash = true;
        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashCount += 1;
        _character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount = 0;
        //_character._canDash = true;
        //_character._dashCount += 1;

    }

    // Update is called once per frame
    //override public void Update()
    override public void Update()
    {
        _isHitTime += Time.deltaTime;
        if (_isHitTime >= 1.5f)
        {
            //_player._isComboCount = 0;
            //base.ZERO();
            //_character._isComboCount = 0;
            _character.CharacterModel.GetComponent<PlayerCONTROL>().hitCount = 0;

            //Debug.Log("IDLECOMBOCOUNT" + _character._isComboCount);//_state._isComboCount);
            _isHitTime = 0;
            _character.CharacterModel.GetComponent<PlayerCONTROL>().isComboUI = false;
        }
        _character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount = 0;
        if (PlayerCONTROL.eINPUTDIRECTION.NONE == _character.GetInputHorizontalDirection()&&
            PlayerCONTROL.eINPUTDIRECTION.NONE == _character.GetInputVerticalDirection())
        {
            _character.ChangeState(PlayerCONTROL.eSTATE.IDLE);
            return;
        }
        UpdateAnimation();
        //_character.UpdateMove();
        UpdateMove();
        
    }


    public void UpdateMove()
    { 
        Vector3 addPosition = Vector3.zero;
        Vector3 velocity = _character.CharacterModel.GetComponent<Rigidbody>().velocity;


        _character.WeaponObject.GetComponent<TrailRenderer>().enabled = false;
        //transform을 바꾸는 것이 아니라 addforce로 해보도록 생각해보자
        //이 코드는 오른쪽일때 moveSpeed*time.deltatime을 position에 더해준 값.

        switch (_character.GetInputVerticalDirection())
        {
            case PlayerCONTROL.eINPUTDIRECTION.UP:
                velocity.y = 6.0f;

                break;
        }

        switch (_character.GetInputHorizontalDirection())
        {
            case PlayerCONTROL.eINPUTDIRECTION.RIGHT:
                //if (_isDash)
                //{
                //    addPosition.z = MoveOffset(16.0f);
                //    _isDash = false;
                //}

                //if (_dashCount >= 2)
                //{
                //    addPosition.z = MoveOffset(640.0f);
                //    _dashCount = 0;
                //}
                if(_character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount <=0)
                {
                    _isMoveTime += Time.deltaTime;
                    if (_isMoveTime >= 0.4f)
                    {
                        //_character._canDash = false;
                        //_isMoveTime = 0;


                        // _character._dashLeftCount = 0;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashLeftCount = 0;
                        // _character._dashRightCount = 0;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashRightCount = 0;
                        _isMoveTime = 0;
                    }


                    //if (!_character._rightDash)
                    if (!_character.CharacterModel.GetComponent<PlayerCONTROL>()._rightDash)
                    {
                        //_character._rightDash = true;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._rightDash = true;
                        //_character._dashRightCount += 1;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashRightCount += 1;
                        //_character._dashLeftCount = 0;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashLeftCount = 0;
                    }
                    //if (_character._dashRightCount >= 2)
                    if (_character.CharacterModel.GetComponent<PlayerCONTROL>()._dashRightCount >= 2)
                    {
                        _character.CharacterModel.GetComponent<Animator>().SetTrigger("dash");
                        //addPosition.z = MoveOffset(80.0f);
                        //_character._rightDash = true;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._rightDash = true;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._isDash = true;
                        //_character._dashRightCount = 0;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashRightCount = 0;
                    }
                    //else if(_dashCount < 2)
                    // else if (_character._dashRightCount < 2)// && _dashLeftCount==0)

                    //else if (_character.CharacterModel.GetComponent<Player>()._dashRightCount < 2)// && _dashLeftCount==0)
                    //    addPosition.z = MoveOffset(4.0f);

                    else if (!_character.CharacterModel.GetComponent<PlayerCONTROL>()._isDash)// && _dashLeftCount==0)
                        addPosition.z = MoveOffset(4.0f);
                    else if(_character.CharacterModel.GetComponent<PlayerCONTROL>()._rightDash && _character.CharacterModel.GetComponent<PlayerCONTROL>()._isDash)
                        addPosition.z = MoveOffset(16.0f);
                }


                break;
            case PlayerCONTROL.eINPUTDIRECTION.LEFT:
                //if (_isDash)
                //{
                //    addPosition.z = MoveOffset(-640.0f);
                //    _isDash = false;
                //}
                //addPosition.z = MoveOffset(-8.0f);
                if (_character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount <= 0)
                {
                    _isMoveTime += Time.deltaTime;
                    if (_isMoveTime >= 0.4f)
                    {
                        //_character._canDash = false;
                        //_isMoveTime = 0;


                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashLeftCount = 0;
                        //_character._dashLeftCount = 0;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashRightCount = 0;
                        //_character._dashRightCount = 0;
                        _isMoveTime = 0;
                    }

                    // if (!_character._leftDash)
                    if (!_character.CharacterModel.GetComponent<PlayerCONTROL>()._leftDash)
                    {
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._leftDash = true;
                        //_character._leftDash = true;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashLeftCount += 1;
                        //_character._dashLeftCount += 1;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashRightCount = 0;
                        //_character._dashRightCount = 0;
                    }
                    //if (_character._dashLeftCount >= 2)
                    if (_character.CharacterModel.GetComponent<PlayerCONTROL>()._dashLeftCount >= 2)
                    {
                        //addPosition.z = MoveOffset(-640.0f);
                        //addPosition.z = MoveOffset(80.0f);//Flip때문에
                                                          //_character._leftDash = true;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._leftDash = true;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._isDash = true;
                        // _character._dashLeftCount = 0;
                        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashLeftCount = 0;
                    }
                    //else if(_dashCount < 2)
                    //else if (_character._dashLeftCount < 2)// && _dashRightCount == 0)

                    //else if (_character.CharacterModel.GetComponent<Player>()._dashLeftCount < 2)// && _dashRightCount == 0)
                    //                                                                             // addPosition.z = MoveOffset(-8.0f);
                    //    addPosition.z = MoveOffset(4.0f);//Flip때문에

                    else if (!_character.CharacterModel.GetComponent<PlayerCONTROL>()._isDash)// && _dashRightCount == 0)
                                                                                                 // addPosition.z = MoveOffset(-8.0f);
                        addPosition.z = MoveOffset(4.0f);//Flip때문에
                    else if(_character.CharacterModel.GetComponent<PlayerCONTROL>()._leftDash && _character.CharacterModel.GetComponent<PlayerCONTROL>()._isDash)
                        addPosition.z = MoveOffset(16.0f);

                }
                break;
        }
        _isComboCount = 0;
        _character.transform.position += (_character.transform.rotation * addPosition);
        _character.CharacterModel.GetComponent<Rigidbody>().velocity = velocity;

    }

    float MoveOffset(float moveSpeed)
    {
        //_character.CharacterModel.GetComponent<PlayerCONTROL>()._moveSpeed = moveSpeed;

        return (moveSpeed * Time.deltaTime);
    }

    //public override void FixedUpdate()
    //{
    //    //if(Player.eINPUTDIRECTION.NONE == _character.GetInputVerticalDirection())
    //    if (Player.eINPUTDIRECTION.NONE == _character.GetInputHorizontalDirection() &&
    //        Player.eINPUTDIRECTION.NONE == _character.GetInputVerticalDirection())
    //    {
    //        _character.ChangeState(Player.eSTATE.IDLE);
    //        return;
    //    }
    //    _character.UpdateJump();
    //}

    void UpdateAnimation()
    {


        if (_preAniDirection == _character.GetAniDirection())
            return;
        _preAniDirection = _character.GetAniDirection();

        //_character.CharacterModel.GetComponent<Animator>().SetFloat("Speed", _character.CharacterModel.GetComponent<PlayerCONTROL>()._moveSpeed);

        switch (_character.GetAniDirection())
        {
            case PlayerCONTROL.eINPUTDIRECTION.UP:
                Debug.Log("UPSTATE");
                break;
            //case Player.eINPUTDIRECTION.
            case PlayerCONTROL.eINPUTDIRECTION.RIGHT:
                //_character.CharacterModel.GetComponent<Animator>().SetTrigger("moveright");
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("move");
                //if (_isFlip)
                if (_character.CharacterModel.GetComponent<PlayerCONTROL>().flip)
                {
                    Flip();
                    //_isFlip = false;
                    _character.CharacterModel.GetComponent<PlayerCONTROL>().flip = false;
                }
                //Debug.Log("RIGHTSTATE");
                break;
            case PlayerCONTROL.eINPUTDIRECTION.LEFT:
                //_character.CharacterModel.GetComponent<Animator>().SetTrigger("moveleft");
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("move");
                //if(!_isFlip)
                if (!_character.CharacterModel.GetComponent<PlayerCONTROL>().flip)
                {
                    Flip();

                    //_isFlip = true;
                    _character.CharacterModel.GetComponent<PlayerCONTROL>().flip = true;
                }

                //Debug.Log("LEFTSTATE");
                break;
        }
    }

    void Flip()
    {
        // Vector3 theScale = _character.CharacterModel.transform.localScale;

        // theScale.z *= -1;
        // _character.CharacterModel.transform.localScale = theScale;

        _character.CharacterModel.GetComponent<Animator>().transform.Rotate(0, 180, 0);
    }
}
