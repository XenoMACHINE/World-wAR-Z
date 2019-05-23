using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomGameManager : MonoBehaviour
{

    [SerializeField] GameObject game = null;
    [SerializeField] Toggle toggle = null;

    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        game.SetActive(false);
        toggle.onValueChanged.AddListener((bool value) => {
            if (value == true){
                game.SetActive(false);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
