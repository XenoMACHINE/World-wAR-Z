using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private static int _score;        // The player's score.
    Text text;                      // Reference to the Text component.

    public int Score { set { _score = value; RefreshDisplay(); } get { return _score; }}

    public static ScoreManager Instance = null;

    void Awake()
    {
        if (Instance == null){
            Instance = this;
        }else{
            Destroy(this);
        }
        // Set up the reference.
        text = GetComponent<Text>();

        // Reset the score.
        _score = 0;
    }

    void Update()
    {
    }

    void RefreshDisplay(){
        text.text = "Score: " + _score;
    }
}