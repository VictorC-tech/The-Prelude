using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float _movespeedEnemy = 3.5f;
    private Vector2 _enemyDirection;
    private Rigidbody2D _enemyRigidbody2D;
    public DectectionController _detectionArea;
    private Animator _enemyAnimator;


    // Start is called before the first frame update
    void Start()
    {
        _enemyRigidbody2D = GetComponent<Rigidbody2D>();
        _enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _enemyDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        if(_detectionArea.detectedTargets.Count > 0)
        {
            _enemyDirection = (_detectionArea.detectedTargets[0].transform.position - transform.position).normalized;
            _enemyRigidbody2D.MovePosition(_enemyRigidbody2D.position + _enemyDirection * _movespeedEnemy * Time.fixedDeltaTime);
            if (_enemyDirection.sqrMagnitude > 0.1 )
            {
                _enemyAnimator.SetFloat("AxisX", _enemyDirection.x);
                _enemyAnimator.SetFloat("AxisY", _enemyDirection.y);
                _enemyAnimator.SetInteger("Movimento", 1);
            }
            
        }
        else
        {
            _enemyAnimator.SetInteger("Movimento", 0);
        }
    }
}
