using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject ExplosionM;
    [SerializeField] Transform parent;

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
        scoreBosrd.Hit(scorePerHit);
        GameObject fx = Instantiate(ExplosionM, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
