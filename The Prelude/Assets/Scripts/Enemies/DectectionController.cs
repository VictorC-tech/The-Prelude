using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectionController : MonoBehaviour
{
    public string _TagTargetDetection = "Player";
    public List<Collider2D> detectedTargets = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == _TagTargetDetection)
        {
            detectedTargets.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _TagTargetDetection)
        {
            detectedTargets.Remove(collision);
        }
    }
}
