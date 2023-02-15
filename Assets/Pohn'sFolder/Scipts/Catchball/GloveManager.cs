using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveManager : MonoBehaviour
{
    public BoxCollider2D grandfaGlove;
    public BoxCollider2D grandmaGlove;
    private bool isGrandfaGrab;
    private bool isGrandmaGrab;

    // Start is called before the first frame update
    void Start()
    {
        grandfaGlove.enabled = false;
        grandmaGlove.enabled = false;
        isGrandfaGrab = true;
        isGrandmaGrab = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && isGrandfaGrab)
        {
            grandfaGlove.enabled = true;
            isGrandfaGrab = false;
            StartCoroutine("GloveTime");
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrandmaGrab)
        {
            grandmaGlove.enabled = true;
            isGrandmaGrab = false;
            StartCoroutine("GloveTime");
        }
    }
    private IEnumerator GloveTime()
    {   
        yield return new WaitForSeconds(.3f);
        grandfaGlove.enabled = false;
        grandmaGlove.enabled = false;
        isGrandfaGrab = true;
        isGrandmaGrab = true;
        StopCoroutine("GloveTime");
    }

}
