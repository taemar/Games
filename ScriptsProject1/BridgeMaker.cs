using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMaker : MonoBehaviour
{
    public GameObject prefab;
    public byte sequence;

    private bool oneTime = true;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (InfoClass.bridgeActivate == sequence && oneTime)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);

            InfoClass.bridgeActivate = 0;
            InfoClass.isNotBridge = false;

            source.PlayOneShot(source.clip);
            oneTime = false;
        }
    }
}
