﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    public RawImage gravityKey;

    private Color keyColor;

    private void Start()
    {
        keyColor = gravityKey.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "GravityRoom")
        {
            keyColor.a = 1f;

            gravityKey.color = keyColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GravityRoom")
        {
            keyColor.a = 0.3f;

            gravityKey.color = keyColor;
        }

        if(other.gameObject.tag == "Detection")
        {
            Detected();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BodyPart")
        {
            if(collision.gameObject.name.Equals("Eyes(Clone)"))
            {
                Debug.Log("You got eyes");
            }

            if(collision.gameObject.name == "Brain")
            {
                Debug.Log("You got brain");
            }

            Destroy(collision.gameObject);
        }
    }

    public void Detected()
    {
        gameObject.GetComponentInChildren<Movement>().enabled = false;
        gameObject.GetComponentInChildren<CameraMovement>().enabled = false;
    }
}
