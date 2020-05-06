using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public Text scoreText;

    public Text comboText;

    public Text pointsAddedText;
    private int combo;

    private GameObject[] combo_effects;
    public static score instance;
    public int currentScore = 0;
    public int scorePerNote = 20;
    public int scorePerClick = 2;
    public int ScorePerMiss = 5;
    // Start is called before the first frame update
    void Start() {
        combo = 0;
        comboText.enabled = false;
        pointsAddedText.enabled = false;
        instance = this;
        scoreText = this.GetComponent<Text>();
        combo_effects = GameObject.FindGameObjectsWithTag("Combo Effects");
        foreach(GameObject game in combo_effects) {
            game.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {
        if(Game_Manager.game_Manager.startGame) {
            scoreText.fontSize = 90;
            scoreText.text = currentScore.ToString();
        }    
    }

    public void noteHit() {
        pointsAddedText.enabled = true;
        pointsAddedText.color = Color.green;
        combo++;

        if(combo < 10){
            currentScore += scorePerNote;
            pointsAddedText.text = scorePerNote.ToString();
        }
        
        if(10 <= combo) {
            foreach(GameObject game in combo_effects) {
                game.SetActive(true);
            }
            currentScore += combo*5;
            comboText.enabled = true;
            comboText.text = "X" + combo.ToString() + " Combo Streak!!!";
            pointsAddedText.text = (combo*5).ToString();
        }

        Invoke("disableText", Time.deltaTime*20);
    }

    public void noteMiss() {
        foreach(GameObject game in combo_effects) {
            game.SetActive(false);
        }
        currentScore -= ScorePerMiss;
        pointsAddedText.enabled = true;
        pointsAddedText.color = Color.red;
        pointsAddedText.text = "-" + ScorePerMiss.ToString();
        combo = 0;
        comboText.enabled = false;
        Invoke("disableText", Time.deltaTime*20);
    }

    public void missClicked() {
        foreach(GameObject game in combo_effects) {
            game.SetActive(false);
        }
        currentScore -= scorePerClick;
        pointsAddedText.enabled = true;
        pointsAddedText.color = Color.red;
        pointsAddedText.text = "-" + scorePerClick.ToString();
        combo = 0;
        comboText.enabled = false;
        Invoke("disableText", Time.deltaTime*20);
    }

    void disableText(){
        pointsAddedText.enabled = false;
    }
}
