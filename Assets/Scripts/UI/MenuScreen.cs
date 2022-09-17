using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuScreen : Panel
{
    [SerializeField] private AudioSource _menuSound;
    [SerializeField] private AudioSource _gameSound;

    private SpawnEnemyes _spawn;
    private Player _player;

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
    }

    public override void Close(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        _menuSound.Stop();
        _gameSound.Play();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
