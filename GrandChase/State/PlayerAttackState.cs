using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerAttackState : State
{
    //public int _count;

    //State _state;
    public int _count;
    //public State _characterState;
    public float _attackTime;

    


    // Start is called before the first frame update
    override public void Start()
    {
        //_characterState.
        //_isCombo = true;
        //_count += 1;
        //Debug.Log("ATTACKSTATE" + _count);
        //_isCombo = true;
        //_count = _isComboCount;
        //_isComboCount += 1;
        //_count += 1;
        //base.PLUS();
        //_isComboCount += 1;
        //_isComboCount += 1;

        //_character.CharacterModel.GetComponent<Animator>().SetBool("IsAttack", true);
        _character.CharacterModel.GetComponent<PlayerCONTROL>().isAttacking = true;
        _character.WeaponObject.GetComponent<TrailRenderer>().enabled = true;
        //_character.CharacterModel.transform.Find("root").gameObject.transform.Find("weaponShield_l").gameObject.transform.Find("Sword4_L").GetComponent<TrailRenderer>().enabled = true;
        _character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount += 1;
        //_character._isComboCount += 1;
        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashRightCount = 0;
        //_character._dashRightCount = 0;
        _character.CharacterModel.GetComponent<PlayerCONTROL>()._dashLeftCount = 0;
        //_character._dashLeftCount = 0;
        Debug.Log("ATTACKSTATE" + _character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount);//_state._isComboCount);
        //Debug.Log("ATTACKSTATE" + _character._isComboCount);//_state._isComboCount);

        //if (_character._isComboCount == 1)
        if (_character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount == 1)
        {
            
            _character.CharacterModel.GetComponent<Animator>().SetTrigger("attack01");
        }
        //else if (_character._isComboCount == 2)
        else if (_character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount == 2)
            _character.CharacterModel.GetComponent<Animator>().SetTrigger("attack02");
        //else if (_character._isComboCount == 3)
        else if (_character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount == 3)
            _character.CharacterModel.GetComponent<Animator>().SetTrigger("attack03");
        //else if (_character._isComboCount == 4)
        else if (_character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount == 4)
            _character.CharacterModel.GetComponent<Animator>().SetTrigger("attack04");
        //else if (_character._isComboCount == 5)
        else if (_character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount == 5)
        {
            _character.CharacterModel.GetComponent<Animator>().SetTrigger("attack05");
            _character.CharacterModel.GetComponent<PlayerCONTROL>()._isComboCount = 0;

        }

        //Debug.Log(_isCombo);
    }

    // Update is called once per frame
    override public void Update()
    {
        //_attackTime += Time.deltaTime;
        //if (_attackTime >= 0.3f)
        //{
        //    _character.CharacterModel.GetComponent<Player>()._isComboCount = 0;
        //    //_character.ChangeState(Character.eSTATE.IDLE);
        //}
        //_character.CharacterModel.GetComponent<Player>()._chargeTime += Time.time;
        //if (_character.CharacterModel.GetComponent<Player>()._chargeTime>=0.2f)
        //{
        //    _character.CharacterModel.GetComponent<Player>()._isComboCount = 0;
        //    _character.CharacterModel.GetComponent<Player>().chargeEffectPrefab.SetActive(true);
        //    //if (_character.CharacterModel.GetComponent<Player>().currentCharge <= _character.CharacterModel.GetComponent<Player>().currentMp)
        //    //{
        //    //    //_character.CharacterModel.GetComponent<Player>().currentCharge += 0.5f;

        //    //}
        //}

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

        //Debug.Log("ATTACKSTATE" + _isComboCount);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        if(_character.CharacterModel.GetComponent<PlayerCONTROL>().isAttacking)
    //        {
    //            _character.CharacterModel.GetComponent<PlayerCONTROL>().hitCount += 1;
    //        }
    //    }
    //}
}
