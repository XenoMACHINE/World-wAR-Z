using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleManager : MonoBehaviour
{

    [SerializeField] GameObject game;
    [SerializeField] Slider slider;

    float maxValue = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((float value) => {
            if (value <= 0.1) { return; }
            float newScale = maxValue * value;
            game.transform.localScale = new Vector3(newScale, newScale, newScale);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
