using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void PlayPressed()
    {
        InfoClass.hpPlayer = 3;             // при загрузке новой игры обновляем жизни игрока ...
        InfoClass.gateSwitches = 0;         // ... обнуляем счетчик, который обновляет GateSwitch.cs ...
        InfoClass.checkpointTest = false;   // ... обнуляем все прошедшие чекпоинты ...
        InfoClass.sound_after3Death = false;// ... обнуляем все глобальные переменные звуков смерти
        InfoClass.sound_afterDeath = false;

        SceneManager.LoadScene("1 level");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
