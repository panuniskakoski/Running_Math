using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_master : MonoBehaviour
{
    private static Game_master instance;
    public Vector2 lastChechkPointPos;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
    }
}
