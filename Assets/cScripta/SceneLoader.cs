using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("LevelLoad", 2f);
    }

    void LevelLoad()
    {
        SceneManager.LoadScene(1);
    }


}
