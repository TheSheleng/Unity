using System;
using UnityEngine;

public class Door1Script : MonoBehaviour
{
    private void OnCollisionEnter(Collision Other)
    {
        if (Other.gameObject.name == "Character")
        {
            ToastScript.ShowToast("To open the door you need to find the key #1");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
