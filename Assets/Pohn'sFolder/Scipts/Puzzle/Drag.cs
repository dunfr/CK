using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving;
    private bool finsh;
    private float startPosX;
    private float startPosY;
    private Vector3 restPostion;
    // Start is called before the first frame update
    void Start()
    {
        restPostion = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finsh)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.transform.localPosition.z);
            }
        }

    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            moving = true;
        }
    }
    private void OnMouseUp()
    {
        moving = false;
        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 0.5f)
        {
            this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
            finsh = true;
            PuzzleUIManager.Instance.AddPoints();
        }
        else
        {
            this.transform.localPosition = new Vector3(restPostion.x, restPostion.y, restPostion.z);
        }
    }
}
