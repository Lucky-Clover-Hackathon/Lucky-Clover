using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressStart : MonoBehaviour
{
    [SerializeField] private Text pressStart;

    // Start is called before the first frame update
    float lerpTime = 1f;
    float currentLerpTime;
    
    private Color startColor;
    private Color endColor;
    void Start()
    {
        startColor = pressStart.color;
        endColor = new Color(startColor.r, startColor.g, startColor.b, 0);
        
    }

    private void BlinkText()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Submit"))
        {
            LevelLoader.Load("Level1");
        }
    
        //increment timer once per frame
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = 0;
            var tempColor = startColor;
            startColor = endColor;
            endColor = tempColor;
        }
 
        //lerp!
        float perc = currentLerpTime / lerpTime;
        pressStart.color = Color.Lerp(startColor, endColor, perc);

    }
}
