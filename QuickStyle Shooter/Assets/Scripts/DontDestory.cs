using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1) Destroy(gameObject);

        else DontDestroyOnLoad(gameObject);
    }
}
