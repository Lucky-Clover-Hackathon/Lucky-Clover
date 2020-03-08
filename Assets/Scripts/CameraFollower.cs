using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private float smoothingAmt = 0.95f;
    private GameObject player ;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = gameObject.transform.position;
        gameObject.transform.position.Set(camPos.x, camPos.y, -10f);
        Vector3 playerPos = player.gameObject.transform.position;
        gameObject.transform.position = Vector3.Lerp( new Vector3(camPos.x,camPos.y, -10f ), playerPos + new Vector3(0f,2.3f,0f), smoothingAmt*Time.deltaTime);
        camPos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(camPos.x, camPos.y, -10f);
    }
}
