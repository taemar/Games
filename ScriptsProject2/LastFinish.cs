using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastFinish : MonoBehaviour
{
    [SerializeField] private GameObject effects;
    [SerializeField] private GameObject finishText;

    [SerializeField] private float finishTime;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(FinishTime());
        }
    }

    private IEnumerator FinishTime()
    {
        effects.SetActive(true);

        finishText.SetActive(true);

        yield return new WaitForSeconds(finishTime);

        SceneManager.LoadScene(0);
    }
}
