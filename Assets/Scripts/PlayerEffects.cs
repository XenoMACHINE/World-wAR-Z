using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerEffects : MonoBehaviour
{
    public Image damageImage;
    public GameObject sliderPrefab;
    public List<ItemEffects> itemEffects = new List<ItemEffects>();

    PlayerMovement playerMovement;
    PlayerHealth playerHealth;
    PlayerAttack playerAttack;
    GameObject hud;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD");
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < itemEffects.Count; i++)
        {
            itemEffects[i].timer -= Time.deltaTime;

            itemEffects[i].itemSlider.transform.position = new Vector3(
                itemEffects[i].itemSlider.transform.position.x,
                itemEffects[0].itemSlider.transform.position.y - 50 * i,
                itemEffects[i].itemSlider.transform.position.z
            );

            itemEffects[i].slider.value = itemEffects[i].timer / itemEffects[i].itemDuration;

            if (itemEffects[i].timer <= 0)
            {
                StopEffect(itemEffects[i]);
                i--;
            }
        }
    }

    public void StartEffect(ItemEffects itemEffect)
    {
        if (itemEffect.healthRegeneration > 0 && playerHealth.currentHealth >= playerHealth.startingHealth) { return; }

        foreach(ItemEffects item in itemEffects){
            if (itemEffect.flashColor == item.flashColor){

                item.timer = itemEffect.itemDuration;
                damageImage.color = itemEffect.flashColor;
                Destroy(itemEffect.gameObject);
                return;
            }
        }


        itemEffect.itemSlider = Instantiate(sliderPrefab, hud.transform);
        itemEffect.slider = itemEffect.itemSlider.gameObject.GetComponent<Slider>();

        (itemEffect.slider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>().FirstOrDefault(t => t.name == "Fill").color = itemEffect.flashColor;

        damageImage.color = itemEffect.flashColor;

        Destroy(itemEffect.gameObject);

        itemEffects.Add(itemEffect);
        itemEffect.timer = itemEffect.itemDuration;

        playerMovement.speed += itemEffect.speedBonus;
        playerHealth.currentHealth = System.Math.Min(1000, playerHealth.currentHealth + itemEffect.healthRegeneration);
        playerAttack.damagePerShot += itemEffect.attackBonus;
        playerAttack.timeBetweenBullets -= itemEffect.attackSpeedBonus;
    }

    public void StopEffect(ItemEffects itemEffect) {
        Destroy(itemEffect.itemSlider);
        itemEffects.Remove(itemEffect);
        itemEffect.timer = itemEffect.itemDuration;

        playerMovement.speed -= itemEffect.speedBonus;
        playerAttack.damagePerShot -= itemEffect.attackBonus;
        playerAttack.timeBetweenBullets += itemEffect.attackSpeedBonus;
    }
}
