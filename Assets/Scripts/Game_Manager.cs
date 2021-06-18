using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private static Game_Manager instance;
    private static Game_Manager Instance { get { return instance; } }

    public int deathCounter = 0;
    public int currentWeaponIndex = 0;
    public int weaponAvailability = 1;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey("CurrentWeapon"))
        {
            deathCounter = PlayerPrefs.GetInt("DeathCounte");
            currentWeaponIndex = PlayerPrefs.GetInt("CurrentWeapon");
            weaponAvailability = PlayerPrefs.GetInt("weaponAvailability");
        }
        else
        {
            PlayerPrefs.SetInt("CurrentWeapon", currentWeaponIndex);
            PlayerPrefs.SetInt("DeathCounter", deathCounter);
            PlayerPrefs.SetInt("weaponAvailability", weaponAvailability);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
