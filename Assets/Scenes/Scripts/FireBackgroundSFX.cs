using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBackgroundSFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundMananger.instance.PlaySound(SoundEnum.fire);
    }

}
