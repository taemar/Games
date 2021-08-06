using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// статический класс для хранения общих данных, которые передаются друг другу в игре
/// </summary>
public static class InfoClass
{
    public static Vector3 lastCheckPoint; // вектор для записи последнего пройденного чекпоинта. Используются в DeathZone.cs и Checkpoint.cs

    public static byte hpPlayer = 3; // жизни игрока. Используются в DeathZone.cs и Checkpoint.cs

    public static bool deadTest = false; // сообщает остальным скриптам, жив ли игрок. Используются в DissapearPlatformScript.sc, DestroyAfterTriggerPlatformScript.cs, DeathZone.cs...
    //... DeathCheck.cs

    public static byte gateSwitches = 0; // сообщает GatesUp, сколько переключателей преодолено. С каждой смертью игрока счетчик обнуляется.

    public static bool checkpointTest = false; // сообщает DeathZone.cs, проходил ли игрок чекпоинт

    public static bool sound_after3Death = false; // сообщает из DeathZone.cs о том, что игрок возрождается после трех жизней. 

    public static bool sound_afterDeath = false; // сообщает в Checkpoint.cs о том, что надо играть музыку.

    #region статика для последовательных телепортов на втором уровне

    public static byte[] playerSequence = new byte[4]; // массив последовательности активаций телепортов

    public static bool isNotBridge = true; // сообщает EnterTeleportScript.cs и BridgeMaker.cs есть ли мост?

    public static byte bridgeActivate = 0; // из EnterTeleportScript.cs сообщает BridgeMaker.cs что пора создавать мост.

    #endregion
}
