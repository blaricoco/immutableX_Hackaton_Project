using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Outline;

public class MushiPickUp : MonoBehaviour
{
    public float distanceThreshold = 4f; // distance at which the pop-up should appear
    public GameObject player; // reference to the player GameObject
    // public GameObject popupUI; // reference to the pop-up UI object
    private bool isActive = true;


    // private Outline outline;


    private int lives = 5;


    void Start(){
        player =  GameObject.FindGameObjectsWithTag("Player")[0];
        // // outline  = GetComponent<outline>();
        // popupUI =  GameObject.FindGameObjectsWithTag("Player");

    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        // Debug.Log(distanceToPlayer);
        if (distanceToPlayer < distanceThreshold)
        {
            // Debug.Log("Should pop up");
            // popupUI.SetActive(true);
            isActive = true;
            // outline.enabled = true;
            if (Input.GetMouseButtonDown(0)){
                print("Bonk");
                getDamage();
            }
        }
        else if( distanceToPlayer >= distanceThreshold && isActive)
        {
            // popupUI.SetActive(false);
            isActive = false;
            // outline.enabled = false;

        }
    }

    void getDamage() {
        if(lives > 0) lives--;
        else{ 
            // Mint or something
            Destroy(gameObject);
            isActive = false;
            // outline.enabled = false;

            // popupUI.SetActive(false);
        }
    }
}