using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource playerSource;
    private Rigidbody rb;
    private AudioClip[] allMusicSphere;

    public float stopMusicSpeed;

    void Start()
    {
        playerSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        allMusicSphere = new AudioClip[] {
            Resources.Load<AudioClip>("Audio/movement_onEarth"), // 0
            Resources.Load<AudioClip>("Audio/movement_onLeaf"), // 1
            Resources.Load<AudioClip>("Audio/movement_onSand"), // 2
            Resources.Load<AudioClip>("Audio/movement_onRock"), // 3
            Resources.Load<AudioClip>("Audio/movement_onWood"), // 4

            Resources.Load<AudioClip>("Audio/jump_from_earth"), // 5 
            Resources.Load<AudioClip>("Audio/jump_from_leafs"), // 6
            Resources.Load<AudioClip>("Audio/jump_from_sand"), // 7

            Resources.Load<AudioClip>("Audio/fall_onEarth"), // 8
            Resources.Load<AudioClip>("Audio/fall_onLeaf"),  // 9
            Resources.Load<AudioClip>("Audio/fall_onSand"), // 10
            Resources.Load<AudioClip>("Audio/fall_onRock"), // 11
            Resources.Load<AudioClip>("Audio/fall_onWood"), // 12
        };
    }

    private void OnCollisionEnter(Collision obj)
    {
        SwitchWithTags(8, 9, 10, 11, 12, obj);
    }

    private void OnCollisionStay(Collision obj)
    {
        if(!playerSource.isPlaying)
            SwitchWithTags(0, 1, 2, 3, 4, obj);

        if (rb.velocity.magnitude < stopMusicSpeed)
            playerSource.Stop();

    }

    private void OnCollisionExit(Collision obj)
    {
        if (playerSource.isPlaying)
            playerSource.Stop();

        if(Input.GetKey(KeyCode.Space))
            SwitchWithTags(5, 6, 7, obj);
    }


    /// <summary>
    /// Сравнивает по тегам поверхности из массива.
    /// </summary>
    /// <param name="number">Параметр, отвечающий за разный вызов switch</param>
    /// <param name="i1">индекс массива allMusicSphere</param>
    /// <param name="i2">индекс массива allMusicSphere</param>
    /// <param name="i3">индекс массива allMusicSphere</param>
    /// <param name="i4">индекс массива allMusicSphere</param>
    /// <param name="i5">индекс массива allMusicSphere</param>
    /// <param name="obj">коллизия объекта под ногами</param>
    private void SwitchWithTags(int i1, int i2, int i3, int i4, int i5, Collision obj)
    {
        switch (obj.gameObject.tag)
        {
            case "Earth":
                playerSource.PlayOneShot(allMusicSphere[i1]);
                break;

            case "leaf":
                playerSource.PlayOneShot(allMusicSphere[i2]);
                break;

            case "Sand":
                playerSource.PlayOneShot(allMusicSphere[i3]);
                break;

            case "Rock":
                playerSource.PlayOneShot(allMusicSphere[i4]);
                break;

            case "Wood":
                playerSource.PlayOneShot(allMusicSphere[i5]);
                break;
        }
    }

    /// <summary>
    /// Сравнивает по тегам поверхности из массива c перегрузкой.
    /// </summary>
    /// <param name="i1">индекс массива allMusicSphere</param>
    /// <param name="i2">индекс массива allMusicSphere</param>
    /// <param name="i3">индекс массива allMusicSphere</param>
    /// <param name="i4">индекс массива allMusicSphere</param>
    /// <param name="obj">коллизия объекта под ногами</param>
    private void SwitchWithTags(int i1, int i2, int i3, Collision obj)
    {
        switch (obj.gameObject.tag)
        {
            case "leaf":
                playerSource.PlayOneShot(allMusicSphere[i2]);
                break;

            case "Sand":
                playerSource.PlayOneShot(allMusicSphere[i3]);
                break;

            default:
                playerSource.PlayOneShot(allMusicSphere[i1]);
                break;
        }
    }
}
