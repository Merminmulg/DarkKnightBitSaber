using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private static bool _gameIsPaused = false;
    [SerializeField] private GameObject _pauseMenuUI;
    private bool _heroDead;
    // Start is called before the first frame update
    void Start()
    {
        _pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        _gameIsPaused = !_gameIsPaused;
        if (!_heroDead)
        {
            Time.timeScale = 1.0f;
        }
    }
    public void Pause()
    {
        if (Time.timeScale == 0) 
        {
            _heroDead = true;
        }
            _pauseMenuUI.SetActive(true);
            _gameIsPaused = !_gameIsPaused;
            Time.timeScale = 0f;
    }
    public void Restart()
    {   
        _pauseMenuUI.SetActive(false);
        _gameIsPaused = !_gameIsPaused;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
