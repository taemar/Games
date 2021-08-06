using System.Collections;
using UnityEngine;

public class WallTrapActivate : MonoBehaviour
{
    [SerializeField] private Transform endPos;
    [SerializeField] private float timer;
    [SerializeField] private float lightOFFtime;
    [SerializeField] private GameObject plateLight;
    [SerializeField] private GameObject[] sceneLights;
    [SerializeField] private GameObject DarkAndSpikesTrap;

    public bool timeToMove = false;
    public bool nextText = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            transform.position = endPos.position;

            DarkAndSpikesTrap.SetActive(false);

            StartCoroutine(TimerAndRespawnObjects());
        }
    }

    private IEnumerator TimerAndRespawnObjects()
    {
        foreach (GameObject twinkle in sceneLights)
        {
            twinkle.SetActive(false);

            yield return new WaitForSeconds(lightOFFtime);
        }

        nextText = true;

        plateLight.SetActive(true);

        yield return new WaitForSeconds(timer);

        timeToMove = true; // по прошествии таймера активируем начало движения
    }
}
