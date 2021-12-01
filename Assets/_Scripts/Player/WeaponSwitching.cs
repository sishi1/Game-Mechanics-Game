using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public GameObject selectorHotBar1;
    public GameObject selectorHotBar2;
    public int selectedWeapon;

    void Start()
    {
        selectWeapon();
        selectedWeapon = 0;
    }

    void Update()
    {
        // Scroll between weapons
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1) selectedWeapon = 0;
            else selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0) selectedWeapon = transform.childCount - 1;
            else selectedWeapon--;
        }

        // Press number keys to switch between weapons
        if (Input.GetKeyDown(KeyCode.Alpha1)) selectedWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2) selectedWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3) selectedWeapon = 2;

        if (previousSelectedWeapon != selectedWeapon) selectWeapon(); 

        // Selects which hotbar is active and inactive based on weapon
        if (selectedWeapon == 0)
        {
            selectorHotBar1.SetActive(true);
            selectorHotBar2.SetActive(false);
        } else
        {
            selectorHotBar1.SetActive(false);
            selectorHotBar2.SetActive(true);
        }
    }

    private void selectWeapon()
    {
        // Switch between weapons and set those that aren't equipped inactive
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon) weapon.gameObject.SetActive(true);
            else weapon.gameObject.SetActive(false);
            i++; 
        }
    }
}
