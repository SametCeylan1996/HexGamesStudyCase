using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject finish_1;
    public GameObject finish_2;
    public GameObject panelStart;
    public GameObject panelDragText;
    public GameObject particleSystem;
    float timer = 3f;
    int deg = 0;

    private void Update()
    {
        if (deg == 1)
        {
            timer -= Time.deltaTime;

            if ((int)timer == 0)
            {
                finish_1.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            deg = 1;
            finish_2.SetActive(true);
            particleSystem.SetActive(true);
            panelDragText.SetActive(false);
        }
    }

    public void nextStart()
    {
        panelStart.SetActive(false);
        panelDragText.SetActive(true);
    }

}
