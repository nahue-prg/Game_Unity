using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcess : MonoBehaviour
{
    public PostProcessVolume volum;
    private Bloom blom;
    private Vignette vignette;


    // Start is called before the first frame update
    void Start()
    {
        volum.profile.TryGetSettings(out blom);
        volum.profile.TryGetSettings(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) )
            {
            blom.intensity.value = 0;
            vignette.intensity.value = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            blom.intensity.value = 1;
            vignette.intensity.value = 1;
        }
    }
}
