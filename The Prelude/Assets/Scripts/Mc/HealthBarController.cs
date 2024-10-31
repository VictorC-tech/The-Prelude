using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerController health;
    List<HealthBar> hearts = new List<HealthBar>();

    private void Start()
    {
        DrawHearts();
    }

    public void DrawHearts()
    {
        ClearHearts();
        for (int i = 0; i < health.maxHealth; i++)
        {
            createEmptyHeart();
        }
        for (int i = 0; i< hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(health.health - i, 0, 1);
            hearts[i].setHeartImg((HeartStatus)health.maxHealth);
        }
    }

    public void createEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);
        HealthBar heartComponent = newHeart.GetComponent<HealthBar>();
        heartComponent.setHeartImg(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }
    
    public void ClearHearts()
    {
        foreach(Transform t in  transform)
        {
            Destroy(t.gameObject);
        }
        hearts=new List<HealthBar>();
    }
    
    
    
}
