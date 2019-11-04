﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        int numMusicPLayer = FindObjectsOfType<MusicPlayer>().Length;

        if (numMusicPLayer > 1)
        {
            Destroy(gameObject);
        }
        else 
        { 
            DontDestroyOnLoad(gameObject); 
        }

    }
    
}
