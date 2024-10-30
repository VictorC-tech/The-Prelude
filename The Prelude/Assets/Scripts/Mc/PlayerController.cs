using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _playerRigidbody2D;
    private Animator _playerAnimator;
    [SerializeField]
    private float _playerSpeed;
    private float _playerInitialSpeed;
    [SerializeField]
    private float _playerRunSpeed;
    private Vector2 _playerDirection;
    private bool _isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _playerInitialSpeed = _playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRun();
        onAttack();
    }

    void FixedUpdate()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _playerDirection.Normalize();

        if (_playerDirection.sqrMagnitude > 0.1 )
        {
            MovePlayer();
            _playerAnimator.SetFloat("AxisX", _playerDirection.x);
            _playerAnimator.SetFloat("AxisY", _playerDirection.y);
            _playerAnimator.SetInteger("Movimento", 1);
        }
        else
        {
            _playerAnimator.SetInteger("Movimento", 0);
        }
        
        if(_isAttacking)
        {
            
            _playerAnimator.SetInteger("Movimento", 2);
        }
    }

    void MovePlayer()
    {
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
    }
    
    void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _playerSpeed = _playerRunSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _playerSpeed = _playerInitialSpeed;
        }
    }

    void onAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _isAttacking = true;
            _playerSpeed = 0;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            _isAttacking = false;
            _playerSpeed = _playerInitialSpeed;
        }
    }
}
