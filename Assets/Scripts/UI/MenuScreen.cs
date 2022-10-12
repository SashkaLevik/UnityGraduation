using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuScreen : Panel
{
    [SerializeField] private AudioSource _menuSound;
    [SerializeField] private AudioSource _gameSound;
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _topSpawner;
    [SerializeField] private Spawner _middleSpawner;
    [SerializeField] private Spawner _bottomSpawner;


    private int _sceneNumber = 0;

    private event UnityAction PlayButtonClick;

    private void Start()
    {
        Time.timeScale = 0;
    }        
    
    protected override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }

    public override void Open(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        _gameSound.Stop();
        _menuSound.Play();
        SceneManager.LoadScene(_sceneNumber);
    }

    public override void Close(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        _menuSound.Stop();
        _gameSound.Play();
        _player.ResetPlayer();
        _topSpawner.StartSpawn();
        _middleSpawner.StartSpawn();
        _bottomSpawner.StartSpawn();
    }    
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
