using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LireAttackState : State
{
    override public void Start()
    {
        _character.CharacterModel.GetComponent<Lire>()._isComboCount += 1;
        //_character._isComboCount += 1;
        _character.CharacterModel.GetComponent<Lire>()._dashRightCount = 0;
        //_character._dashRightCount = 0;
        _character.CharacterModel.GetComponent<Lire>()._dashLeftCount = 0;
        //_character._dashLeftCount = 0;
        Debug.Log("ATTACKSTATE" + _character.CharacterModel.GetComponent<Lire>()._isComboCount);//_state._isComboCount);
        //Debug.Log("ATTACKSTATE" + _character._isComboCount);//_state._isComboCount);


        _character.CharacterModel.GetComponent<Animator>().SetTrigger("ATTACKTRIGGER");

        ////if (_character._isComboCount == 1)
        //if (_character.CharacterModel.GetComponent<Lire>()._isComboCount == 1)
        //    _character.CharacterModel.GetComponent<Animator>().SetTrigger("attack01");
        ////else if (_character._isComboCount == 2)
        //else if (_character.CharacterModel.GetComponent<Lire>()._isComboCount == 2)
        //    _character.CharacterModel.GetComponent<Animator>().SetTrigger("attack02");
        ////else if (_character._isComboCount == 3)
        //else if (_character.CharacterModel.GetComponent<Lire>()._isComboCount == 3)
        //    _character.CharacterModel.GetComponent<Animator>().SetTrigger("attack03");
        ////else if (_character._isComboCount == 4)
        //else if (_character.CharacterModel.GetComponent<Lire>()._isComboCount == 4)
        //    _character.CharacterModel.GetComponent<Animator>().SetTrigger("attack04");
        ////else if (_character._isComboCount == 5)
        //else if (_character.CharacterModel.GetComponent<Lire>()._isComboCount == 5)
        //    _character.CharacterModel.GetComponent<Animator>().SetTrigger("attack05");

        //Debug.Log(_isCombo);
    }

    // Update is called once per frame
    override public void Update()
    {
    }
}
