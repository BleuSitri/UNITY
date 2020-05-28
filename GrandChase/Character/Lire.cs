using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lire : Character
{

    public bool _isGround;


    public int _isComboCount;
    public bool _isDash;
    public bool _canDash;

    public int _dashCount;
    public int _dashLeftCount;
    public int _dashRightCount;
    public bool _rightDash;
    public bool _leftDash;

    public float _isMoveTime;

    override protected void UpdateProcess()
    {
        UpdateInput();
        UpdateState();

    }

    override protected void InitState()
    {
        base.InitState();



        State idleState = new LireIdleState();
        idleState.Init(this);
        _stateDic[eSTATE.IDLE] = idleState;

        State attackState = new LireAttackState();
        attackState.Init(this);
        _stateDic[eSTATE.ATTACK] = attackState;
        
        State moveState = new LireMoveState();
        moveState.Init(this);
        _stateDic[eSTATE.MOVE] = moveState;
    }


    void UpdateInput()
    {
        _inputHorizontalDirection = eINPUTDIRECTION.NONE;
        _inputVerticalDirection = eINPUTDIRECTION.NONE;
        _inputAniDirection = eINPUTDIRECTION.NONE;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _inputHorizontalDirection = eINPUTDIRECTION.RIGHT;
            _inputAniDirection = eINPUTDIRECTION.RIGHT;
            _currentState.ChangeState(eSTATE.MOVE);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _inputHorizontalDirection = eINPUTDIRECTION.LEFT;
            _inputAniDirection = eINPUTDIRECTION.LEFT;
            _currentState.ChangeState(eSTATE.MOVE);
        }
        if (Input.GetKey(KeyCode.UpArrow) && _isGround)
        {
            _inputVerticalDirection = eINPUTDIRECTION.UP;
            _inputAniDirection = eINPUTDIRECTION.UP;
            GetComponent<BoxCollider>().isTrigger = true;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _currentState.ChangeState(eSTATE.ATTACK);

        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            _currentState.ChangeState(eSTATE.IDLE);
        }


        Vector3 origin = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        if (!_isGround)
        {
            RaycastHit hit;
            int layerMask = 1 << 8;

            Debug.DrawRay(origin, -transform.up * 0.5f, Color.red);

            if (Physics.Raycast(origin, -transform.up, out hit, 0.5f, layerMask))
            {
                Debug.Log(hit.collider.gameObject.tag);
                GetComponent<BoxCollider>().isTrigger = false;
            }
        }


    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isGround = true;
            //GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isGround = false;
        }
    }
}
