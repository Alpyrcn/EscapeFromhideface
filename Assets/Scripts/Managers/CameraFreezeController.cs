using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraFreezeController : MonoBehaviour
{
    public Cinemachine.CinemachineBrain cinemachineBrain;

    private void Start()
    {
    
        cinemachineBrain = GetComponent<Cinemachine.CinemachineBrain>();
    }

    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                
                Time.timeScale = 0f;
                cinemachineBrain.enabled = true;
            }
            else
            {
                
                Time.timeScale = 1f;
                cinemachineBrain.enabled = false; 
            }
        }
    }
}

