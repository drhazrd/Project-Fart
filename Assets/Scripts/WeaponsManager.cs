using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsManager : MonoBehaviour
{
    [System.Serializable]
    public sealed class WeaponSlot
    {
        public bool available = false;
        public EWeaponType type = EWeaponType.Standard;
        public Gun weapon, subWeapon;
        public Rigidbody dropout = null;
    }

    public int selectedWeapon = 0;
    public int selectedWeaponCrosshair = 0;
    [SerializeField]
    private WeaponSlot[] weapons = null;

    public Image crossHairHUD;
    public Sprite[] crossHair;
    private static Gun1 m_Firearm = null;

    private static bool isMelee { get { return (m_Firearm == null); } }
    private static int weaponIndex = -1, weaponsCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectedWeapon();
    }

    // Update is called once per frame
    void Update(){

        int previousSelectWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }
        if (previousSelectWeapon != selectedWeapon)
        {
            SelectedWeapon();
        }
        crossHairHUD.sprite = crossHair[selectedWeapon];
    }
    void SelectedWeapon() {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon&& weapon.gameObject.GetComponent<Gun1>().isAvailable)
            {
                weapon.gameObject.SetActive(true);
            }
            else if (i == selectedWeapon && weapon.gameObject.GetComponent<Gun1>().isAvailable)
            {
                i++;
            }else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }

    }
}
