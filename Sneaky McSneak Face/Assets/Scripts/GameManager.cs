using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Image healthUI;
    public float currentHealth;
    public float maxHealth;
    public float damage;
    public float ammo;
    public float maxAmmo;
    public TextMeshProUGUI ammoUI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthUI.fillAmount = currentHealth / maxHealth;
        ammo = maxAmmo;
        ammoUI.text = "Ammo: " + ammo.ToString() + "/" + maxAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
            {
                healthUI.fillAmount -= damage / maxHealth;
            }
    }
}
