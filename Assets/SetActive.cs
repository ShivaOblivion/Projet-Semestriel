using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject cube;
    public void Active()
    {
        cube.SetActive(true);
    }

    public void desactive()
    {
        cube.SetActive(false);
    }
}

