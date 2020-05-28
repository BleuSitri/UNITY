using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LireIdleState : State
{
    override public void Start()
    {

        _character.CharacterModel.GetComponent<Animator>().SetTrigger("IDLETRIGGER");
        Debug.Log("IDLESTATE");
        _isAttackTime = 0;
        _isMoveTime = 0;

        _character.CharacterModel.GetComponent<Lire>()._leftDash = false;
        //_character._leftDash = false;
        _character.CharacterModel.GetComponent<Lire>()._rightDash = false;
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
        if (_isAttackTime >= 0.5f)
        {
            //_player._isComboCount = 0;
            //base.ZERO();
            //_character._isComboCount = 0;
            _character.CharacterModel.GetComponent<Lire>()._isComboCount = 0;

            //Debug.Log("IDLECOMBOCOUNT" + _character._isComboCount);//_state._isComboCount);
            _isAttackTime = 0;
            //Debug.Log()
            _isCombo = false;
        }
        // if(_isMoveTime>=0.15f)
        if (_isMoveTime >= 0.15f)
        {
            //_character._canDash = false;
            //_isMoveTime = 0;
            //_character._dashCount = 0;

            _isMoveTime = 0;


            _character.CharacterModel.GetComponent<Lire>()._leftDash = false;
            //_character._leftDash = false;
            _character.CharacterModel.GetComponent<Lire>()._dashLeftCount = 0;
            //_character._dashLeftCount = 0;
            _character.CharacterModel.GetComponent<Lire>()._rightDash = false;
            //_character._rightDash = false;
            _character.CharacterModel.GetComponent<Lire>()._dashRightCount = 0;
            //_character._dashRightCount = 0;
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
            _character.ChangeState(Lire.eSTATE.MOVE);
        }

    }
}
