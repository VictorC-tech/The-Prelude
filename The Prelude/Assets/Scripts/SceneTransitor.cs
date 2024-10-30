using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitor : MonoBehaviour
{
    [SerializeField]
    private string nomeProximaFase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IrProximaFase();
    }
    private void IrProximaFase()
    {
        SceneManager.LoadScene(this.nomeProximaFase);   
    }
}