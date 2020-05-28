using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject playerObject;
    Vector3 cameraPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        
        playerObject = GameObject.FindGameObjectWithTag("Player");
        cameraPosition = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z - 20);
    }
    void Start()
    {
        
        transform.position = cameraPosition;
        //transform.position = playerObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraPosition = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z - 20);
        transform.position = cameraPosition;
        //transform.position = Mathf(cameraPosition;
    }
}
