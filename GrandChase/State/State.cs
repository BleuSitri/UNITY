using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class State : MonoBehaviourPunCallbacks
{
    public bool _isCombo { get; set; }

    public float _isAttackTime { get; set; }

    public int _isComboCount { get; set; }
    //public int _isComboCount;

    public float _isMoveTime { get; set; }
    //public bool _canDash;

    public float _isHitTime { get; set; }

    protected Character _character;
    //protected PlayerAttackState _player;
    
    public void Init(Character character)
    {
        _character = character;
    }

    virtual public void Start()
    {

    }
    virtual public void Stop()
    {

    }
    //virtual public void Update()
    //{

    //}

    virtual public void Update()
    {
        //if (!_isCombo)
        //{
        //    _isAttackTime += Time.deltaTime;
        //}
        //else if (_isCombo)
        //{
        //    _isAttackTime = 0;
        //    _isComboCount += 1;
        //}
    }

    virtual public void ChangeState(Character.eSTATE nextState)
    {
        _character.ChangeState(nextState);
    }

    public void ZERO()
    {
        _isComboCount = 0;
    }
    public void PLUS()
    {
        _isComboCount += 1;
    }
}
