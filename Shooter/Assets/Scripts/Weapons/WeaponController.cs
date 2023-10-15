using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private WeaponsManager CurrentWeapon;

    void Start()
    {
        CurrentWeapon = WeaponsManager.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentWeapon.ChangeWeapon("Gun");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentWeapon.ChangeWeapon("Machete");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentWeapon.ChangeWeapon("Pistol");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CurrentWeapon.ChangeWeapon("Flashbang");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CurrentWeapon.ChangeWeapon("Grenade");
        }
    }
}
