using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Camera cam;
    float rotSpeed = 20;
    public float shootSpeed;
    public GameObject firstBall;
    public GameObject ballPrefab;
    public GameObject firePoint;
    Quaternion currentPos;
    public GameObject gameMainCam;
    public GameObject prefabCam;
    public GameObject panelDragText;

    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        currentPos = firePoint.transform.rotation;
    }

    void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        //float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);
        //transform.RotateAround(Vector3.right, -rotY);
    }
    
    private void OnMouseUp()
    {
        shoot();
    }

    public void shoot()
    {
        Instantiate(ballPrefab, new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, firePoint.transform.position.z), currentPos);
        //ballPrefab.transform.position = this.transform.position;
        firstBall.SetActive(false);
        prefabCam.SetActive(true);
        panelDragText.SetActive(false);


        Debug.Log("BALL");
    }

}
