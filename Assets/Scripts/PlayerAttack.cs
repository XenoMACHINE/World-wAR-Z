using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour
{
    public float initialDamagePerShot = 20;
    public float initialTimeBetweenBullets = 0.5f;
    public float initialRange = 10f;
    public float damagePerShot = 20;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.5f;        // The time between each shot.
    public float range = 10f;                      // The distance the gun can fire.
}
