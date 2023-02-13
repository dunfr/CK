using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Warmini : MonoBehaviour
{
    public int Index = 0;
    public int key = 9;
    private KeyCode[] keycodes;
    private KeyCode[] Randomkey =
    {
        KeyCode.DownArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.RightArrow
    };

    private int cycle = 0;

    private void keycodesinit()
    {
        keycodes = new KeyCode[key];
        for (int i = 0; i < keycodes.Length; i++)
        {
            keycodes[i] = Randomkey[Random.Range(0, 4)];
        }
    }

    void Start()
    {
        keycodesinit();
        for (int i = 0; i < keycodes.Length; i++)
        {
            Debug.Log(keycodes[i]);
        }
    }

    void Update()
    {
        if (Index == key)
        {
            Index = 0;
            cycle++;
            keycodesinit();
            for (int i = 0; i < keycodes.Length; i++)
            {
                Debug.Log(keycodes[i]);
            }
        }

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(keycodes[Index]))
            {
                Index++;
                Debug.Log("correct");
            }
            else
            {
                Index = 0;
                Debug.Log("Wrong");
            }
        }

        if (cycle == 6)
        {
            Debug.Log("Game Clear");
            return;
        }
    }
}
