using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private static int _level;        // The player's score.
    Text text;                      // Reference to the Text component.

    public int Level { set { _level = value; RefreshDisplay(); } get { return _level; } }

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
        _level = 1;
    }

    void Update()
    {
    }

    void RefreshDisplay(){
        text.text = "Niveau: " + _level;
    }
}