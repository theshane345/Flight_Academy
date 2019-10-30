using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LevelLoad", 2f);
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void LevelLoad()
    {
        SceneManager.LoadScene(1);
    }

}
