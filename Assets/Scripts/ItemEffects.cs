using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEffects : MonoBehaviour
{
    public int speedBonus = 0;
    public int healthRegeneration = 0;
    public int attackBonus = 0;
    public float attackSpeedBonus = 0f;
    public float itemDuration = 0f;
    public float timer = 0f;
    public Color flashColor = Color.white;
    public Image fill;
    public float itemMaxValue = 100f;
    public PlayerEffects playerEffects;

    GameObject player;
    public GameObject itemSlider;
    public Slider slider;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerEffects = player.GetComponent<PlayerEffects>();
    }

    void Update()
    {
        if (slider != null)
        {
            print(timer / itemDuration);
            slider.value = timer / itemDuration;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerEffects.StartEffect(this);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Nothing
    }
}
