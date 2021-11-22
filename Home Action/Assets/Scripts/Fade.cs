using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (Bed.fadeNow)
        {
            fadeOut();
            Invoke("fadeIn", 1f);
            Bed.fadeNow = false;
        }
    }

    private void fadeOut()
    {
        anim.SetTrigger("FadeOut");
    }

    private void fadeIn()
    {
        anim.SetTrigger("FadeIn");
    }
}
