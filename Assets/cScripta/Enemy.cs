using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject ExplosionM;
    [SerializeField] Transform parent;
    [SerializeField] int hits = 10;
    [SerializeField] int scorePerHit = 12;
    

    ScoreBosrd scoreBosrd;
   
    void Start()
    {
        AddCollider();
        scoreBosrd = FindObjectOfType<ScoreBosrd>();
    }

    private void AddCollider()
    {
        Collider enemy = gameObject.AddComponent<BoxCollider>();
        enemy.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits <= 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        //iveaddedcode//
        scoreBosrd.Hit(scorePerHit);
        hits--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(ExplosionM, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
