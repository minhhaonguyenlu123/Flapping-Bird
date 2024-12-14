using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject pipePrefab;
    private float countDown;
    public float timeDuration;

    public bool startPipe; // cho phep ong sinh ra

    private void Awake()
    {
        countDown = timeDuration;
        startPipe = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPipe == true)
        {   
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                Instantiate(pipePrefab, new Vector3(6, Random.Range(1.45f, -2f), 0), Quaternion.identity);
                countDown = timeDuration;
            }
        }
    }

}
