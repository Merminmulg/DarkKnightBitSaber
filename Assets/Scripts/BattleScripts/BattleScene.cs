using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleScene : MonoBehaviour
{
    private float _gameSpeed = 1;

    private List<GameObject> _enemies;
    [SerializeField] private List<GameObject> _enemiesWavePrefabs;
    [SerializeField] private GameObject _enemySpawnZone;
    [SerializeField] private List<float> _spawnDelay;
    [SerializeField] private bool _auto;
    [SerializeField] private List<GameObject> _enemiesTypesPrefabs;
    [SerializeField] private PointView _pointsView;
    [SerializeField] private float _autoSpawnDelay = 15f;

    [SerializeField] private Hero _hero;
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private GameObject _GameOverTitle;
    // Start is called before the first frame update
    void Start()
    {
        _enemies = new List<GameObject>(_enemiesWavePrefabs.Count);
        _hero.OnHeroDeath += EndGame;
        Debug.Log("ButtleSceneSuccess");
        if (!_auto)
        {
            StartCoroutine(SpawnEnemies());
        }
        else
        {
            StartCoroutine(InfinitySpawnRandomEnemies());
        }
        _GameOverTitle.SetActive(false);
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
    private void EndGame()
    {
        _playButton.gameObject.SetActive(true);
        _GameOverTitle.SetActive(true);
        Time.timeScale = 0f;
    }
    public IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < _enemiesWavePrefabs.Count; i++)
        {
            yield return new WaitForSeconds(_spawnDelay[i]);
            _enemies.Add(Instantiate(_enemiesWavePrefabs[i], _enemySpawnZone.transform));
            _enemies[i].GetComponent<Enemy>().GetDamage += _hero.ApplyDamage;
            _enemies[i].GetComponent<Enemy>().HeroAction += _hero.Action;
        }
        Debug.Log("All enemies spawned");
    }
    public IEnumerator InfinitySpawnRandomEnemies()
    {
        while(!_hero.isAlive)
        {
            _gameSpeed += _gameSpeed * 0.1f;
            Time.timeScale = _gameSpeed;
            _enemies.Add(Instantiate(_enemiesTypesPrefabs[Random.Range(0,_enemiesTypesPrefabs.Count)], _enemySpawnZone.transform));
            _enemies.Last().GetComponent<Enemy>().GetDamage += _hero.ApplyDamage;
            _enemies.Last().GetComponent<Enemy>().HeroAction += _hero.Action;
            _enemies.Last().GetComponent<Enemy>().SetAnimation += _hero.SetAnimationSpeed;
            _enemies.Last().GetComponent<Enemy>().OnArrowDestroied += _pointsView.EnemyKilled;
            yield return new WaitForSeconds(_autoSpawnDelay);
        }
    }
}
