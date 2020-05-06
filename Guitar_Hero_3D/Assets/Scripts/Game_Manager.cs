using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public AudioSource theSong;

    public static Game_Manager game_Manager;

    public bool startGame;

    // Start is called before sthe first frame update
    void Start()
    {
        game_Manager = this;
        startGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startGame) {
            if(Input.GetKeyDown(KeyCode.Space)){
                score.instance.comboText.enabled = false;
                startGame = true;
                theSong.Play();
                Time.timeScale = 1;
            }
        }
        if(theSong.time <= 184f && theSong.time >= 180f){
                theSong.Stop();
                startGame = false;
                score.instance.comboText.enabled = true;
                score.instance.comboText.text = "Well Done! Game Ended";
                Time.timeScale = 0;
        }
        if(startGame) {
            if(Input.GetKeyDown(KeyCode.Q)){
                theSong.Pause();
                startGame = false;
                score.instance.comboText.enabled = true;
                score.instance.comboText.text = "Game Paused";
                Time.timeScale = 0;
            }
        }

    }

}

