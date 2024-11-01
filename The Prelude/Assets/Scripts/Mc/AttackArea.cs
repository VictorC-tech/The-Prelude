using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int _damage = 1;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<SlimeController>()!= null)
        {
            SlimeController healthComponent = collider.GetComponent<SlimeController>();
            healthComponent.TakeDamage(_damage);
        }
    }
}
