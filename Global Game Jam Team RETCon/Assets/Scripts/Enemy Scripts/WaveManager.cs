using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    public int[,] WaveNums = new int[70, 3];

    public GameObject[,] WaveEnemies = new GameObject[70, 2];
    public float[] Counter = new float[70];

    [SerializeField]
    List<GameObject> EnemyList = new List<GameObject>();

    [SerializeField]
    List<Vector3> EnemySpawns = new List<Vector3>();

    [SerializeField]
    private GameObject[] SpawnPoints = new GameObject[9];

    private int WaveSpawnNum = 0;

    private float SpawnCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnCounter = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpawnCounter -= Time.fixedDeltaTime;
        if (SpawnCounter <= 0)
        {
            Instantiate(EnemyList[WaveSpawnNum], new Vector3(EnemySpawns[WaveSpawnNum].x, EnemySpawns[WaveSpawnNum].y, 0.0f), Quaternion.identity);
            SpawnCounter = EnemySpawns[WaveSpawnNum].z;
            WaveSpawnNum += 1;
        }
    }
}
