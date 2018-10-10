using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject _Player;
    public int _Hp = 200;
    public bool _IsLife;
    public float _MouseSensitivity;
    public float _MoveSpeed;
    
    private Vector3 _Move;
    private int _Animation_Parameter;
    private Animator _Animator;
    private string _ParameterStr;
    private float _PrevMousePosition;
	// Use this for initialization
	void Start ()
    {
        _Hp = 200;
        _IsLife = true;
        _MouseSensitivity = 1f;
        _MoveSpeed = 1f;

        _Animator = _Player.GetComponent<Animator>();
        _Animator.SetBool("isLife", _IsLife);

        _ParameterStr = "state";

        _Animation_Parameter = 0;
        _PrevMousePosition = Input.mousePosition.x;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!_IsLife) { IsDead(); return; }

        InputKey();

        AniUpdate();
        DiedUpdate();
	}

    float mousePosition;
    float z;
    void InputKey()
    {
        mousePosition = Input.mousePosition.x;
        z = 0;

        _Animation_Parameter = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _Animation_Parameter = 1;
            z = 5;
        }

        _Player.transform.Translate(0, 0, z * _MoveSpeed * Time.deltaTime);
        _Player.transform.Rotate(0, (mousePosition - _PrevMousePosition) * (_MouseSensitivity * .1f), 0);

        _PrevMousePosition = mousePosition;
    }

    void AniUpdate()
    {
        _Animator.SetInteger(_ParameterStr, _Animation_Parameter);
    }

    void DiedUpdate()
    {
        if(0 > _Hp) { _IsLife = false; }
    }
    void IsDead()
    {
        _Animator.SetBool("isLife", _IsLife);
    }
}
