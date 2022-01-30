using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    public int[,] WaveNums = new int [5,2];

    [SerializeField]
    List<GameObject> EnemyList = new List<GameObject>();

    [SerializeField]
    List<Vector3> EnemySpawns = new List<Vector3>();
    private int WaveSpawnNum = 0;

    //Dictionary<int, GameObject> EnemyList = new Dictionary<int, GameObject>();

    /*EnemyList.Add(1, EnemyBasic);
    EnemyList.Add(2, EnemyChili);
    EnemyList.Add(3, EnemyPotato);
    EnemyList.Add(4, EnemyChilSp);
    EnemyList.Add(5, EnemyPotSp);*/

    //public int[,] RoundAmountEnemy = new int []


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWave()
    {
        for(int i = 0; i < EnemyList.Count; i++)
        {
            Instantiate(EnemyList[i], EnemySpawns[i],Quaternion.identity);
            //spawn code here
        }
    }
}
