using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///класс, возвращающий игрока на последний чекпоинт или, если тот потратил все жизни, возвращает в стартовую позицию 
/// </summary>
public class DeathZone : MonoBehaviour
{
    public Transform startPositionPlayerSphere;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform tfPlayer = other.GetComponent<Transform>();

            InfoClass.deadTest = false; // игрок прошел Purgatory и жив-здоров.

            if (InfoClass.hpPlayer == 0)
            {
                InfoClass.hpPlayer = 3; // при смерти игрока обновляем его жизни...

                InfoClass.gateSwitches = 0; //... и обнуляем счетчик, который обновляет GateSwitch.cs.

                InfoClass.sound_after3Death = true; // сообщаем SoundAfter3Death.cs о том, что игрок вскоре переродится и пора запускать соотв. музяку.

                InfoClass.sound_afterDeath = false;

                if (SceneManager.GetActiveScene().name == "1 level")
                {
                    SceneManager.LoadScene("1 level");
                }
                else if(SceneManager.GetActiveScene().name == "2 level")
                {
                    for (int i = 0; i < InfoClass.playerSequence.Length; i++)
                        InfoClass.playerSequence[i] = 0;

                    InfoClass.isNotBridge = true;

                    SceneManager.LoadScene("2 level");
                }
                else SceneManager.LoadScene("3 level");
            }
            else
            {
                InfoClass.hpPlayer--;

                if (InfoClass.checkpointTest)
                {
                    tfPlayer.position = InfoClass.lastCheckPoint;

                    InfoClass.sound_afterDeath = true; // даем команду Checkpoint.cs на воспроизведение звука.
                }
                else tfPlayer.position = startPositionPlayerSphere.position;
            }
        }

    }

}
