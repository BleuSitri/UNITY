using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    float _waitTime = 1.0f;
    float _waitDuration = 0.0f;


    // Start is called before the first frame update
    override public void Start()
    {
        //Debug.Log("IDLESTATE");
        _character.CharacterModel.GetComponent<Animator>().SetTrigger("idle");

        _waitTime = Random.Range(1.0f, 2.0f);
        _waitDuration = 0.0f;


        _isComboCount += 1;
    }

    // Update is called once per frame
    override public void Update()
    {
        if(_waitTime<=_waitDuration)
        {
            //Debug.Log("IDLESTATE");
            //_character.ChangeState(Player.eSTATE.FIND_TARGET);
        }
        _waitDuration += Time.deltaTime;
    }
}
