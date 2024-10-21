using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _playerRigidbody2D;
    private Animator _playerAnimator;
    [SerializeField] private float _playerSpeed;
    private Vector2 _playerDirection;
    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
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
    }

    void FixedUpdate()
    {
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
    }
}
