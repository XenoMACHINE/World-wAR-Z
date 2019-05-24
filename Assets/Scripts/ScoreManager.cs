using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private static int _level;        // The player's score.
    private static int _xpToNextLevel;        // The player's score.
    Text text;                      // Reference to the Text component.
    public Text pexText;
    public Slider xpSlider;

    public int Level { set { _level = value; RefreshDisplay(); } get { return _level; } }
    public int XPToNextLevel { set { _xpToNextLevel = value; RefreshDisplay(); } get { return _xpToNextLevel; } }

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
        pexText.text = _xpToNextLevel + " / 500 XP";
        xpSlider.value = _xpToNextLevel;
    }

}