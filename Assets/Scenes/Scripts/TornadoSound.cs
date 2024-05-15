using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSound : MonoBehaviour
{
    void Start()
    {
        SoundMananger.instance.PlaySound(SoundEnum.storm);
    }
}
