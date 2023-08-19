using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{

    void Start()
    {
        
    }

  

    public int SelectedWeapon=0;
     void Update()
    {
        SelectWeapon();
    }
    public void Weapon_One()
    {
        
        SelectedWeapon = 0;
    }  
    public void Weapon_Two()
    {
        if (transform.childCount >= 2)
        {
            SelectedWeapon = 1;
        }
          
    }
    public void Weapon_Three()
    {
        if (transform.childCount >= 3)
        {
            SelectedWeapon = 2;
        }
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == SelectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }

    }
}
