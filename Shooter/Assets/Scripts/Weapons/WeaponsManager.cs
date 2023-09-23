using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public List<Weapon> AllWeapons;
    public Transform RightHandTarget;
    public Transform RightHandHint;
    public Transform LeftHandTarget;
    public Transform LeftHandHint;


    public Weapon CurrentWeapon;

    public static WeaponsManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void ChangeWeapon(string weaponName)
    {
        foreach (Weapon weapon in AllWeapons)
        {
            weapon.gameObject.SetActive(weapon.WeaponName == weaponName);
            if (weapon.WeaponName == weaponName)
            {
                RightHandTarget.localPosition = weapon.RightHandTarget;
                RightHandHint.localPosition = weapon.RightHandHint;
                LeftHandTarget.localPosition = weapon.LeftHandTarget;
                LeftHandHint.localPosition = weapon.LeftHandHint;
                RightHandTarget.localRotation = Quaternion.Euler(weapon.RightHandRoatate);

                CurrentWeapon = weapon;
            }
        }
    }


    private void Update()
    {

        if (Input.GetMouseButton(0) && CurrentWeapon)
        {
            CurrentWeapon.Attack();
        }
    }
}
