using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHandler : MonoBehaviour
{
    public int health;

    public Slider healthBar;

    void Update() {
        healthBar.value = health;
    }
}
