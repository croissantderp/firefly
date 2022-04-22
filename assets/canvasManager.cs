using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasManager : MonoBehaviour
{
    public RectTransform rect;

    public Button Exitbutton;

    bool retracted = false;

    float lastTouch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touches.Length != 0)
        {
            StartCoroutine(delayRetract());
        }

        if (!retracted)
        {
            if (lastTouch < 5f)
            {
                lastTouch += Time.deltaTime;
            }
            else
            {
                rect.position = Vector2.Lerp(rect.position, rect.position + new Vector3(0, 1000), 1); ;
                retracted = true;
            }
        }
    }

    IEnumerator delayRetract()
    {
        yield return new WaitForSeconds(0.25f);

        if (retracted)
        {
            rect.position = Vector2.Lerp(rect.position, rect.position + new Vector3(0, -1000), 1); ;
            retracted = false;
        }
        else
        {
            rect.position = Vector2.Lerp(rect.position, rect.position + new Vector3(0, 1000), 1); ;
            retracted = true;
        }

        lastTouch = 0;
    }

}
