using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public GameObject spawnerArrow;
    public GameObject spawnerEnemy;
    // Start is called before the first frame update
    void Start()
    {
        spawnerArrow = GameObject.FindGameObjectWithTag("ArrowSpawnZone");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
