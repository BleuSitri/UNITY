using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerIdleState : State
{
    //State _state;
    // Start is called before the first frame update
    override public void Start()
    {
        //_character.CharacterModel.GetComponent<PlayerCONTROL>()._moveSpeed = 0f;
        _character.CharacterModel.GetComponent<PlayerCONTROL>().isAttacking = false;
        _character.WeaponObject.GetComponent<TrailRenderer>().enabled = false;
        //_character.CharacterModel.transform.Find("root").gameObject.transform.Find("weaponShield_l").gameObject.transform.Find("Sword4_L").GetComponent<TrailRenderer>().enabled = false;
        _character.CharacterModel.GetComponent<Animator>().SetTrigger("idle");
        Debug.Log("IDLESTATE");
        _isAttackTime = 0;
        _isMoveTime = 0;
        _isHitTime = 0;

        _character.CharacterModel.GetComponent<PlayerCONTROL>()._leftDash = false;
        //_character._leftDash = false;
        _character.CharacterModel.GetComponent<PlayerCONTROL>()._rightDash = false;
       // _character._rightDash = false;
        //_isComboCount = 0;
        //Debug.Log("IDLECOMBOCOUNT" + _isComboCount);
        //_isComboCount += 1;
        //_isCombo = false;
        //Debug.Log(_isCombo);
    }
    
    // Update is called once per frame
    override public void Update()
    {
        _isAttackTime += Time.deltaTime;
        //_isMoveTime += Time.deltaTime;
        _isMoveTime += Time.deltaTime;
        _isHitTime += Time.deltaTime;
        if (_isAttackTime >= 0.5f)
        {
            //_player._isComboCount = 0;
            //base.ZERO();
            //_character._isComboCount = 0;
            _character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount = 0;

            //Debug.Log("IDLECOMBOCOUNT" + _character._isComboCount);//_state._isComboCount);
            _isAttackTime = 0;
            //Debug.Log()
            _isCombo = false;
            //_character.CharacterModel.GetComponent<PlayerCONTROL>().isAttacking = false;
        }
       // if(_isMoveTime>=0.15f)
        if(_isMoveTime >=0.15f)
        {
            //_character._canDash = false;
            //_isMoveTime = 0;
            //_character._dashCount = 0;

            _isMoveTime = 0;


            _character.CharacterModel.GetComponent<PlayerCONTROL>()._leftDash = false;
            //_character._leftDash = false;
            _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashLeftCount = 0;
            //_character._dashLeftCount = 0;
            _character.CharacterModel.GetComponent<PlayerCONTROL>()._rightDash = false;
            //_character._rightDash = false;
            _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashRightCount = 0;
            //_character._dashRightCount = 0;
        }
        if (_isHitTime >= 1.5f)
        {
            //_player._isComboCount = 0;
            //base.ZERO();
            //_character._isComboCount = 0;
            _character.CharacterModel.GetComponent<PlayerCONTROL>().hitCount = 0;
            _character.CharacterModel.GetComponent<PlayerCONTROL>().isComboUI = false;
            //Debug.Log("IDLECOMBOCOUNT" + _character._isComboCount);//_state._isComboCount);
            _isHitTime = 0;
        }

        //Debug.Log(base._isAttackTime);
        Vector3 inputVertical = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
        Vector3 inputHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (0.0f != inputVertical.z || 0.0f != inputHorizontal.x)
        {
            //if(_character._canDash)
            //{
            //    _character._isDash = true;
            //    _character._canDash = false;

            //}
            _character.ChangeState(PlayerCONTROL.eSTATE.MOVE);
        }

    }
}
