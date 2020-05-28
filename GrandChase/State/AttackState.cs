using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    bool _isAttack = false;
    Quaternion _characterRotation;

    // 고려해보아야함.
    // 콤보공격 넣어야함.
    //float _attackTime = 3.0f;
    //float _attackDuration = 0.0f;


    // Start is called before the first frame update
    override public void Start()
    {
        //_characterRotation = _character.CharacterModel.transform.localRotation;

        //_attackTime = Random.Range(18.0f, 20.0f);
        //_attackDuration = 0.0f;

        //_isAttack = false;
    }

    // Update is called once per frame
    override public void Update()
    {
        
    }
}
