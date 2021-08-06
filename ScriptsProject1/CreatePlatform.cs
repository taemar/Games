using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// класс, отвечающий за спавн разрушенных платформ
/// </summary>
public class CreatePlatform : MonoBehaviour
{
    public GameObject prefab;            // префаб платформы
    public GameObject initialPlatform;   // начальная платформа

    private bool isNotCreate = true;     // переменная, ограничивающая число спавнов платформ.
    private GameObject platformClone;    // клон платформы

    void LateUpdate()
    {
        if (InfoClass.deadTest)  // спрашивает, мертв ли игрок? Если да, то...
        {
            if (initialPlatform == null && isNotCreate)
            {
                if(platformClone == null && isNotCreate)  //... спрашивает, есть ли платформа или клон платформы и если нет, создавались ли они?
                {
                    platformClone = Instantiate(prefab, transform.position, Quaternion.identity);

                    isNotCreate = false;
                }
            }
        }
        else isNotCreate = true;
    }
}
