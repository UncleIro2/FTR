using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeSound : MonoBehaviour
{
    void Start()
    {
        SoundMananger.instance.PlaySound(SoundEnum.earthquake);
    }
}
