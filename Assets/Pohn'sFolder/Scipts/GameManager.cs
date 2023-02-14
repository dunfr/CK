using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int ResolutionX;
    public int ResolutionY;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(ResolutionX, ResolutionY, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("PuzzleStage1");
        }
    }
}
