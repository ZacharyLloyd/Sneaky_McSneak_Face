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
    public float ammoValue;
    public static float ammo;
    public float maxAmmo;
    public TextMeshProUGUI ammoUI;

    //Singleton
    public static GameManager instance;

    public PlayerMovement player;

    //Awake runs before all Starts
    private void Awake()
    {
        //Setup the Singleton
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthUI.fillAmount = currentHealth / maxHealth;
        ammo = ammoValue;
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
        if (ammo != 0)
            if (Input.GetKeyDown(KeyCode.Space)) UseAmmo();
    }
    //Using ammo UI
    public void UseAmmo()
    {
        --ammo;
        ammoUI.text = "Ammo: " + ammo.ToString() + "/" + maxAmmo.ToString();
    }
}
