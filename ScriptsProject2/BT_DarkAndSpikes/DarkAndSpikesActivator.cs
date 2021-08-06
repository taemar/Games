using System.Collections;
using UnityEngine;

public class DarkAndSpikesActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] behindWallObjects;
    [SerializeField] private GameObject[] sceneLights;
    [SerializeField] private GameObject allSpikes;
    [SerializeField] private GameObject blockedWall;
    [SerializeField] private DarkAndSpikesTrigger DAS_trigger;
    [SerializeField] private float lightOFFtime;

    private void Update()
    {
        if (DAS_trigger.triggerPassed && !allSpikes.activeSelf)
        {
            allSpikes.SetActive(true);

            blockedWall.SetActive(true);

            StartCoroutine(lightOFF());
        }
    }

    private IEnumerator lightOFF()
    {
        foreach (GameObject obj in behindWallObjects)
        {
            Destroy(obj);
        }

        foreach(GameObject twinkle in sceneLights)
        {
            yield return new WaitForSeconds(lightOFFtime);

            twinkle.SetActive(false);
        }
    }
}
