using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes_Spawner : MonoBehaviour
{
    private float yPos = 7.83f;
    private float zPos = 33.36f;
    private float[] xPositions = {2.67f, 1.47f, 0.17f, -1.08f, -2.45f};

    private bool hasStarted;
    private Material[] colors;
    public Material yellow;
    public Material green;
    public Material blue;
    public Material orange;
    public Material red;

    [Range(1, 3)][SerializeField] int timeRangeRandomizer = 1;
    [Range(100, 200)][SerializeField] int movementSpeedRange = 150;
    public GameObject note;

    // Start is called before the first frame update
    void Start()
    {
        colors = new Material[5];
        colors[0] = red;
        colors[1] = orange;
        colors[2] = blue;
        colors[3] = green;
        colors[4] = yellow;
        //Debug.Log(colors);
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Game_Manager.game_Manager.startGame && !hasStarted) {
            hasStarted = true;
            this.StartCoroutine(spawnNotes());
        }
    }

    private IEnumerator spawnNotes(){
        while(true){
            float timeBetweenSpawns = Random.Range(1, timeRangeRandomizer);
            int whichNote = Random.Range(0, 5);
            //int movement_speed = Random.Range(100, movementSpeedRange+1);
            Vector3 pos = new Vector3(xPositions[whichNote], yPos, zPos);
            
            yield return new WaitForSeconds(timeBetweenSpawns);

            GameObject tmp = Instantiate(note, pos, Quaternion.identity) as GameObject;
            tmp.GetComponent<MeshRenderer>().material = colors[whichNote];
            tmp.GetComponent<Notes_Behaviour>().movement_speed = movementSpeedRange;
        }
    }

}
