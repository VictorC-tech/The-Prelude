using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _playerRigidbody2D;
    private Animator _playerAnimator;
<<<<<<< HEAD
    [SerializeField]
    private float _playerSpeed;
    private float _playerInitialSpeed;
    public float _playerRunSpeed;
=======
    [SerializeField] private float _playerSpeed;
>>>>>>> ab36ac31b5c74359cc70f45508500d1ac0e3c639
    private Vector2 _playerDirection;
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
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _playerDirection.Normalize();

        if (_playerDirection.sqrMagnitude > 0 )
        {
            _playerAnimator.SetInteger("Movimento", 1);
        }
        else
        {
            _playerAnimator.SetInteger("Movimento", 0);
        }
        Flip();

    }

    void FixedUpdate()
    {
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        if (_playerDirection.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (_playerDirection.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }
    
    void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _player
        }
    }
}
