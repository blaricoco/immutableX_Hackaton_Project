using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{

    public GameObject Bonk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // if (Input.GetMouseButtonDown(0)){
        //         // print("BONK!");
        //         // Bonk.GetComponent<Animator>().Play("bonk");
        //     }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.tag == "portal"){
            SceneManager.LoadScene("Land");
        }
    }
}
