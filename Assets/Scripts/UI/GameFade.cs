﻿using UnityEngine;
using System.Collections;

public class GameFade : MonoBehaviour {
    [SerializeField]
    private float waitTime, aStart, aEnd, lerpValue, timer, duration;
    [SerializeField]
    private bool fadein = false;
    [SerializeField]
    private int levelLoad;

    private CanvasGroup g;
    void Start()
    {
        g = this.GetComponent<CanvasGroup>();
       // StartCoroutine(Starter());
    }

    public void Update()
    {

        if (fadein)
        {
            g.alpha = Mathf.Lerp(aStart, aEnd, lerpValue);

            timer += Time.deltaTime;
            lerpValue = (timer / duration);
        }
        else if (!fadein)
        {
            g.alpha = Mathf.Lerp(aEnd, aStart, lerpValue);

            timer += Time.deltaTime;
            lerpValue = (timer / duration);
        }
        if(lerpValue >= 1)
        {
            lerpValue = 1;
        }

    }

    public void Complete()
    {
        fadein = false;
    }


    public IEnumerator Starter()
    {
        yield return new WaitForSeconds(waitTime);

        fadein = true;

    }
}
