using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        foreach (var o in objects)
        {
            GameObject.DontDestroyOnLoad(o);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
