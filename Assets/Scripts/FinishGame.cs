using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FinishGame : MonoBehaviour
{
    public GameObject ui;
    public bool uioff;
    // Start is called before the first frame update
    void Start()
    {
        uioff = true;
        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uioff = false;
            ui.SetActive(true);

        }
    }
}
