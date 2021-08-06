using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameContoller : MonoBehaviour
{
    public UnityEngine.UI.Text hpText;
    public GameObject pauseMenu;

    public GameObject playerSphere;
    public GameObject OtherSounds;
    public GameObject BackgroundMusic;
    public GameObject pausePanel;

    private int hp;
    private AudioSource _playerSphere;
    private AudioSource _OtherSounds;
    private AudioSource _BackgroundMusic;
    private AudioSource _pausePanel;

    void Start()
    {
        hp = InfoClass.hpPlayer;

        _playerSphere = playerSphere.GetComponent<AudioSource>();
        _OtherSounds = OtherSounds.GetComponent<AudioSource>();
        _BackgroundMusic = BackgroundMusic.GetComponent<AudioSource>();
        _pausePanel = pausePanel.GetComponent<AudioSource>();
    }


    void Update()
    {
        if(InfoClass.hpPlayer != hp && InfoClass.hpPlayer != 0)
        {
            hp = InfoClass.hpPlayer;

            hpText.text = "HEALTH: " + hp;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);

            Time.timeScale = 0;
                
            _BackgroundMusic.mute = true;   
            _OtherSounds.mute = true;                
            _playerSphere.mute = true;
                
            _pausePanel.Play();

        }
    }

    public void PressResume()
    {
        pauseMenu.SetActive(false);

        _BackgroundMusic.mute = false;
        _OtherSounds.mute = false;
        _playerSphere.mute = false;

        Time.timeScale = 1;
    }

    public void PressMainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Menu");
    }

}
