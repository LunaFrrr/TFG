using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeOut(Animator animatorFade)
    {
        animatorFade.Play("FadeOut");
    }

    public void FadeIn(Animator animatorFade)
    {

        animatorFade.Play("FadeIn");
    }
}

