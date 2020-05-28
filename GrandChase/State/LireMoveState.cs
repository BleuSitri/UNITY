using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LireMoveState : State
{
    bool _isFlip;

    Lire.eINPUTDIRECTION _preAniDirection;
    // Start is called before the first frame update
    override public void Start()
    {
        _preAniDirection = Lire.eINPUTDIRECTION.NONE;
        UpdateAnimation();
        _character.CharacterModel.GetComponent<Lire>()._canDash = true;
        _character.CharacterModel.GetComponent<Lire>()._dashCount += 1;
        //_character._canDash = true;
        //_character._dashCount += 1;

    }

    // Update is called once per frame
    //override public void Update()
    override public void Update()
    {
        if (Lire.eINPUTDIRECTION.NONE == _character.GetInputHorizontalDirection() &&
            Lire.eINPUTDIRECTION.NONE == _character.GetInputVerticalDirection())
        {
            _character.ChangeState(Lire.eSTATE.IDLE);
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

        //transform을 바꾸는 것이 아니라 addforce로 해보도록 생각해보자
        //이 코드는 오른쪽일때 moveSpeed*time.deltatime을 position에 더해준 값.

        switch (_character.GetInputVerticalDirection())
        {
            case Lire.eINPUTDIRECTION.UP:
                velocity.y = 6.0f;

                break;
        }

        switch (_character.GetInputHorizontalDirection())
        {
            case Lire.eINPUTDIRECTION.RIGHT:
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
                _isMoveTime += Time.deltaTime;
                if (_isMoveTime >= 0.4f)
                {
                    //_character._canDash = false;
                    //_isMoveTime = 0;


                    // _character._dashLeftCount = 0;
                    _character.CharacterModel.GetComponent<Lire>()._dashLeftCount = 0;
                    // _character._dashRightCount = 0;
                    _character.CharacterModel.GetComponent<Lire>()._dashRightCount = 0;
                    _isMoveTime = 0;
                }


                //if (!_character._rightDash)
                if (!_character.CharacterModel.GetComponent<Lire>()._rightDash)
                {
                    //_character._rightDash = true;
                    _character.CharacterModel.GetComponent<Lire>()._rightDash = true;
                    //_character._dashRightCount += 1;
                    _character.CharacterModel.GetComponent<Lire>()._dashRightCount += 1;
                    //_character._dashLeftCount = 0;
                    _character.CharacterModel.GetComponent<Lire>()._dashLeftCount = 0;
                }
                //if (_character._dashRightCount >= 2)
                if (_character.CharacterModel.GetComponent<Lire>()._dashRightCount >= 2)
                {
                    _character.CharacterModel.GetComponent<Animator>().SetTrigger("dash");
                    addPosition.z = MoveOffset(640.0f);
                    //_character._rightDash = true;
                    _character.CharacterModel.GetComponent<Lire>()._rightDash = true;
                    //_character._dashRightCount = 0;
                    _character.CharacterModel.GetComponent<Lire>()._dashRightCount = 0;
                }
                //else if(_dashCount < 2)
                // else if (_character._dashRightCount < 2)// && _dashLeftCount==0)
                else if (_character.CharacterModel.GetComponent<Lire>()._dashRightCount < 2)// && _dashLeftCount==0)
                    addPosition.z = MoveOffset(8.0f);

                break;
            case Lire.eINPUTDIRECTION.LEFT:
                //if (_isDash)
                //{
                //    addPosition.z = MoveOffset(-640.0f);
                //    _isDash = false;
                //}
                //addPosition.z = MoveOffset(-8.0f);

                _isMoveTime += Time.deltaTime;
                if (_isMoveTime >= 0.4f)
                {
                    //_character._canDash = false;
                    //_isMoveTime = 0;


                    _character.CharacterModel.GetComponent<Lire>()._dashLeftCount = 0;
                    //_character._dashLeftCount = 0;
                    _character.CharacterModel.GetComponent<Lire>()._dashRightCount = 0;
                    //_character._dashRightCount = 0;
                    _isMoveTime = 0;
                }

                // if (!_character._leftDash)
                if (!_character.CharacterModel.GetComponent<Lire>()._leftDash)
                {
                    _character.CharacterModel.GetComponent<Lire>()._leftDash = true;
                    //_character._leftDash = true;
                    _character.CharacterModel.GetComponent<Lire>()._dashLeftCount += 1;
                    //_character._dashLeftCount += 1;
                    _character.CharacterModel.GetComponent<Lire>()._dashRightCount = 0;
                    //_character._dashRightCount = 0;
                }
                //if (_character._dashLeftCount >= 2)
                if (_character.CharacterModel.GetComponent<Lire>()._dashLeftCount >= 2)
                {
                    //addPosition.z = MoveOffset(-640.0f);
                    addPosition.z = MoveOffset(640.0f);//Flip때문에
                    //_character._leftDash = true;
                    _character.CharacterModel.GetComponent<Lire>()._leftDash = true;
                    // _character._dashLeftCount = 0;
                    _character.CharacterModel.GetComponent<Lire>()._dashLeftCount = 0;
                }
                //else if(_dashCount < 2)
                //else if (_character._dashLeftCount < 2)// && _dashRightCount == 0)
                else if (_character.CharacterModel.GetComponent<Lire>()._dashLeftCount < 2)// && _dashRightCount == 0)
                                                                                             // addPosition.z = MoveOffset(-8.0f);
                    addPosition.z = MoveOffset(8.0f);//Flip때문에

                break;
        }
        _isComboCount = 0;
        _character.transform.position += (_character.transform.rotation * addPosition);
        _character.CharacterModel.GetComponent<Rigidbody>().velocity = velocity;

    }

    float MoveOffset(float moveSpeed)
    {
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
        switch (_character.GetAniDirection())
        {
            case Lire.eINPUTDIRECTION.UP:
                Debug.Log("UPSTATE");
                break;
            //case Player.eINPUTDIRECTION.
            case Lire.eINPUTDIRECTION.RIGHT:
                //_character.CharacterModel.GetComponent<Animator>().SetTrigger("moveright");
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("MOVETRIGGER");
                if (_isFlip)
                {
                    Flip();
                    _isFlip = false;
                }
                //Debug.Log("RIGHTSTATE");
                break;
            case Lire.eINPUTDIRECTION.LEFT:
                //_character.CharacterModel.GetComponent<Animator>().SetTrigger("moveleft");
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("MOVETRIGGER");
                if (!_isFlip)
                {
                    Flip();

                    _isFlip = true;
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
