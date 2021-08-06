using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchNewScene : MonoBehaviour
{
    private bool startTimer = false;
    private bool next_level = false;
    private bool playOneMore = true;

    public float timer;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            InfoClass.hpPlayer = 3;             // при загрузке след. уровня обновляем жизни игрока ...
            InfoClass.gateSwitches = 0;         // ... обнуляем счетчик, который обновляет GateSwitch.cs ...
            InfoClass.checkpointTest = false;   // ... обнуляем все прошедшие чекпоинты ...
            InfoClass.sound_after3Death = false;// ... обнуляем все глобальные переменные звуков смерти
            InfoClass.sound_afterDeath = false;

            startTimer = true; // запускаем таймер

            if (playOneMore) // проигрываем звук один раз
            {
                source.Play();
                playOneMore = false;
            }
        }
    }


    private void Update()
    {

        if (startTimer) // при триггере вкл. таймер, дающий проиграться музыке перед загрузкой следующей сцены.
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                next_level = true;
                startTimer = false;
            }

        }

        if (next_level) // по окончанию таймера запускаем новый уровень
        {
            next_level = false;
            Nextlevel();
        }
    }

    /// <summary>
    /// метод переключения на следующий уровень
    /// </summary>
    private void Nextlevel()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "1 level":
                SceneManager.LoadScene("2 level");
                break;

            case "2 level":
                SceneManager.LoadScene("3 level");
                break;

            default:
                SceneManager.LoadScene("1 level");
                break;
        }
    }

}
