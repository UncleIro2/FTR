using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    void Start()
    {
        SoundMananger.instance.PlaySound(SoundEnum.Background);
    }
}
