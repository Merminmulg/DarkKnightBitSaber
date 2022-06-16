using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    private static bool _gameIsPaused = false;
    [SerializeField] private GameObject _pauseMenuUI;
    private bool _heroDead;
    [SerializeField] private AudioSource _gameMelody;

    [SerializeField] private Sprite _firstForm;
    [SerializeField] private Sprite _secondForm;
    [SerializeField] private Image _image;
    [SerializeField] private AudioClip _gameMelodyClip;

    private float _gameSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _pauseMenuUI.SetActive(false);
        _gameMelody.PlayOneShot(_gameMelodyClip);
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
    public void BackToMenu()
    {
        _pauseMenuUI.SetActive(false);
        _gameIsPaused = !_gameIsPaused;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main-menu");
    }
    public void Resume()
    {
        _image.sprite = _firstForm;
        _pauseMenuUI.SetActive(false);
        _gameIsPaused = !_gameIsPaused;
        _gameMelody.UnPause();
        if (!_heroDead)
        {
            Time.timeScale = _gameSpeed;
        }
    }
    public void Pause()
    {
        _image.sprite = _secondForm;
        if (Time.timeScale == 0) 
        {
            _heroDead = true;
        }
        _gameMelody.Pause();
        _pauseMenuUI.SetActive(true);
        _gameIsPaused = !_gameIsPaused;
        _gameSpeed = Time.timeScale;
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
