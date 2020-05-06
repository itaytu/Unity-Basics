using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes_Behaviour : MonoBehaviour
{
    private Rigidbody rb;
    public float movement_speed = 5f;
    private Vector3 screenBounds; 

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < screenBounds.z * 2){
            Destroy(this.gameObject);
            score.instance.noteMiss();
        }
    }

    void FixedUpdate() {
        //rb.AddForce(0, 0, -movement_speed * Time.deltaTime, ForceMode.Acceleration);
        rb.AddForce(0, 0, -movement_speed * (147f/60f) * Time.deltaTime );
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "GameController") {
            other.GetComponent<Button_Controller>().isColliding = true;
            KeyCode key = other.GetComponent<Button_Controller>().keyToPress;
            if(Input.GetKeyDown(key)){
                score.instance.noteHit();
                Destroy(this.gameObject);
            }
        }    
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "GameController") {
            other.GetComponent<Button_Controller>().isColliding = true;
            KeyCode key = other.GetComponent<Button_Controller>().keyToPress;
            if(Input.GetKeyDown(key)){
                score.instance.noteHit();
                Destroy(this.gameObject);
            }
        }    
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "GameController") {
            other.GetComponent<Button_Controller>().isColliding = false;
            score.instance.noteMiss();
            Destroy(this.gameObject);
        }
    }
}
