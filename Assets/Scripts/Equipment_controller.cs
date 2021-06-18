using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment_controller : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
    public GameObject player;
    public GameObject npc;
    public GameObject weapon;
    public GameObject text;
    public GameObject dialog;
    public bool weapon2Available = true;
    public bool weapon3Available = true;
    public bool weapon4Available = false;
    bool textAppears = true;

    // Start is called before the first frame update
    void Start()
    {
        weapon2.SetActive(false);
        weapon3.SetActive(false);
        weapon4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
            weapon3.SetActive(false);
            weapon4.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            weapon2.SetActive(true);
            weapon1.SetActive(false);
            weapon3.SetActive(false);
            weapon4.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            weapon3.SetActive(true);
            weapon2.SetActive(false);
            weapon1.SetActive(false);
            weapon4.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) && weapon4Available)
        {
            weapon4.SetActive(true);
            weapon2.SetActive(false);
            weapon3.SetActive(false);
            weapon1.SetActive(false);
        }

        float distanceToNPC = Vector3.Distance(player.transform.position, npc.transform.position);
        float distanceToWeapom = WeaponDistanceCounter();

        if ((distanceToNPC < 5 || distanceToWeapom < 5)&& textAppears)
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }

        

        if (Input.GetKeyDown(KeyCode.E) && distanceToNPC < 5)
        {
            dialog.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && distanceToWeapom < 5)
        {
            weapon4Available = true;
            Destroy(weapon);
        }
    }

    public void DeactivaeDialog()
    {
        dialog.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public float WeaponDistanceCounter()
    {
        if (weapon != null)
        {
            return Vector3.Distance(player.transform.position, weapon.transform.position);
        }
        else
        {
            return 99;
        }
    }
}
