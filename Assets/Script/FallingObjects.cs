using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject,5f);
    }
}
