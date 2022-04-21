using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    private List<GameObject> _enemies;
    [SerializeField] private List<GameObject> _enemiesWavePrefabs;
    [SerializeField] private GameObject _enemySpawnZone;
    [SerializeField] private List<float> _spawnDelay;
    [SerializeField] private Hero _hero;
    // Start is called before the first frame update
    void Start()
    {
        _enemies = new List<GameObject>(_enemiesWavePrefabs.Count);
        Debug.Log("ButtleSceneSuccess");
        StartCoroutine(SpawnEnemies());  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        
    }
    public IEnumerator SpawnEnemies()
    {
        for (int i = 0; i<_enemiesWavePrefabs.Count; i++)
        {
            yield return new WaitForSeconds(_spawnDelay[i]);
            _enemies.Add(Instantiate(_enemiesWavePrefabs[i], _enemySpawnZone.transform));
            _enemies[i].GetComponent<Enemy>().GetDamage += _hero.ApplyDamage;
        }
        Debug.Log("All enemies spawned");
    }
}
