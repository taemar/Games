using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// класс, включающий таймер исчезновения при соприкосновении с игроком, и отключающий таймер исчезновения после соприкосновения.
/// </summary>
public class AuthorDisappearScript : MonoBehaviour
{
    public float disappearDelay;
    public float musicTime;

    private AudioSource source;
    private MeshRenderer rend;
    private BoxCollider col;

    private float delayHelper;  // вспомогательная переменная, помнящая начальный дилей
    private bool switcher = false; // переключатель, включающий и отключающий таймер
    private bool _switcher = false; // переключатель, включающий и выключающий компоненты платформы
    private bool oneTime = true;

    private void Start()
    {
        delayHelper = disappearDelay;
        
        source = GetComponent<AudioSource>();
        rend = GetComponent<MeshRenderer>();
        col = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (switcher)
        {
            if (disappearDelay > 0)
                disappearDelay -= Time.deltaTime;

            if (disappearDelay < musicTime && oneTime)
            {
                source.Play();
                oneTime = false;
            }

            if (disappearDelay < 0)
            {
                _switcher = true;
                switcher = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        switcher = true;

        if (_switcher)
        {
            rend.enabled = false;
            col.enabled = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        switcher = false;
        oneTime = true;

        source.Stop();
    }

    /// <summary>
    /// метод проверки игрока на жизнь/смерть
    /// </summary>
    void LateUpdate()
    {
        if (InfoClass.deadTest) // мертв ли игрок? если да, то включаем и перестаем отключать рендер с коллайдером. А также обновляем таймер дилэя.
        {
            rend.enabled = true;
            col.enabled = true;
            
            _switcher = false;
            oneTime = true;
            disappearDelay = delayHelper;    
        }
    }
}
