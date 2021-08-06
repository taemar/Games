using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTeleportScript : MonoBehaviour
{
    public Transform spawnObject; // точка спавна игрока из телепорта
    public byte numberOfSequence; // номер в последовательности (второй уровень)
    public GameObject lightTP; // фонарь, светящий на вывеску телепорта (второй уровень)

    private AudioSource source;
    private Light _light;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        _light = lightTP.GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform tfOther = other.GetComponent<Transform>();

        tfOther.position = spawnObject.position;

        if (other.CompareTag("Player"))
            source.Play();

        #region последовательная активация телепортов на втором уровне

        if (other.CompareTag("Player") && SceneManager.GetActiveScene().name == "2 level" && InfoClass.isNotBridge)
        {
            if (InfoClass.playerSequence[numberOfSequence - 1] == 0 && (numberOfSequence == 1 || numberOfSequence - InfoClass.playerSequence[numberOfSequence - 2] == 1))
            {
                InfoClass.playerSequence[numberOfSequence - 1] = numberOfSequence;

                if (numberOfSequence == InfoClass.playerSequence.Length)
                    InfoClass.bridgeActivate = 1;
            }
            else
            {
                for(int i = 0; i < InfoClass.playerSequence.Length; i++)
                    InfoClass.playerSequence[i] = 0;
            }
        }
        #endregion
    }

    #region метод апдейт для последовательной активации

    private void Update()
    {
        if (numberOfSequence > 0 && InfoClass.playerSequence[numberOfSequence - 1] == 0)
        {
            _light.enabled = false;
        }
        else  _light.enabled = true;
    }

    #endregion
}
