using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _Animator;
    private GameObject _attackArea = default;
    private bool _isAttacking = false;
    private float _timerAttack = 0.25f;
    private float _timer = 0f;
    private Vector2 _playerDirection;
    
    void Start()
    {
        _attackArea = transform.GetChild(0).gameObject;
        _Animator = GetComponent<Animator>();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if(_isAttacking)
        {
             
            _Animator.SetInteger("Movimento", 2);
            _timer += Time.deltaTime;
            if(_timer >= _timerAttack)
            {
                _timer = 0;
                _isAttacking = false;
                _attackArea.SetActive(_isAttacking);
            }
        }

        
    }

    private void Attack()
    {
        Vector2 lookDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        // Ajusta a posição do collider de ataque
        _attackArea.transform.position = (Vector2)transform.position + lookDirection;
        _attackArea.transform.right = lookDirection; 
        _isAttacking = true;
        _attackArea.SetActive(_isAttacking);
    }
}
