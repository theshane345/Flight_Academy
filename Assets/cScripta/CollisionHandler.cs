using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject Explosion;

    void OnTriggerEnter(Collider other)
    {
        StartDeath();
    }

    void StartDeath()
    {
        SendMessage("OnPlayerDeath");
        Explosion.SetActive(true);
        Invoke("load", levelLoadDelay);
    }


    void load() {
        SceneManager.LoadScene(1);

    }
}
