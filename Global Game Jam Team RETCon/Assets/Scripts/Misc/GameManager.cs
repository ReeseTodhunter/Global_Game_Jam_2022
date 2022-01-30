using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public static float waveNum;    //Stores the number of wave you're on
    public static int currentCharacter; // 1 = Potato // 2 = Chilli
    public static bool gameIsPaused;

    void Awake()
    {

        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }

        //Setup Startup values
        gameIsPaused = false;
        waveNum = 0;
        currentCharacter = 1;
    }

    void Reset()
    {
        currentCharacter = 1;
        gameIsPaused = false;
        waveNum = 0;
    }
}
