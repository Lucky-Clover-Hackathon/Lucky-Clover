using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadLuck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LuckTicker());
    }

    private IEnumerator LuckTicker()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(30,60));
            Debug.Log("BadLuck");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
