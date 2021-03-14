using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private GameObject prefabCam;

    // Start is called before the first frame update
    public void Start()
    {
        Controller cs = new Controller();

        prefabCam = GameObject.FindGameObjectWithTag("PrefabsCamera");
        
        
        GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
        //.velocity = new Vector3(0, 0, 25);
    }

    // Update is called once per frame
    void Update()
    {
        prefabCam.transform.position = new Vector3(transform.position.x, 2, transform.position.z - 5);
    }
}
