using UnityEngine;
using UnityEngine.UI;

public class WeaopnSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    public int selectedWeaponCrosshair = 0;

    public Image crossHairHUD;
    public Sprite[] crossHair;
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
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }

    }
}
