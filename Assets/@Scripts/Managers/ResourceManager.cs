using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    Func<ResourceManager> a => () =>
    {
        Debug.Log("체크");
        return FindObjectOfType<ResourceManager>();
    };

    // Start is called before the first frame update
    void Start()
    {
    }

    [Tooltip("test")]
    public void Test()
    {
        Debug.Log(a());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
