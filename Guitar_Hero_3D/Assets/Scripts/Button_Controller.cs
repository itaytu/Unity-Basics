using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer meshRenderer;
    public Material defaultColor;
    public Material pressedColor;
    
    public KeyCode keyToPress;

    public bool isColliding;
    void Start()
    {
        isColliding = false;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            meshRenderer.material = pressedColor;
            if(!isColliding && Game_Manager.game_Manager.startGame){
                score.instance.missClicked();
            }
        }

        if(Input.GetKeyUp(keyToPress)){
            meshRenderer.material = defaultColor;
        }
    }

    /*private void OnTriggerStay(Collider other) {
        //Debug.Log("Entered");
        if(Input.GetKeyDown(keyToPress)) {
            Debug.Log("NICEEE");
            Destroy(other.gameObject);
        }
    }*/
}
