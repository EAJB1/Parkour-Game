using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    //public MeleeWeapon meleeWeaponScirpt;

    public int selectedWeapon = 0;
    public bool animationAllowed = true;
    public bool multipleWeapons;

    private int previousSelectedWeapon;
    private bool newSlotFull = PickUpController.slotFull;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
                animationAllowed = true;
            }
            else
            {
                selectedWeapon++;
                animationAllowed = true;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
                animationAllowed = true;
            }
            else
            {
                selectedWeapon--;
                animationAllowed = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
            animationAllowed = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
            animationAllowed = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
            animationAllowed = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
            animationAllowed = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
        {
            selectedWeapon = 4;
            animationAllowed = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) && transform.childCount >= 6)
        {
            selectedWeapon = 5;
            animationAllowed = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha7) && transform.childCount >= 7)
        {
            selectedWeapon = 6;
            animationAllowed = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha8) && transform.childCount >= 8)
        {
            selectedWeapon = 7;
            animationAllowed = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9) && transform.childCount >= 9)
        {
            selectedWeapon = 8;
            animationAllowed = true;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

        // If selectedWeapon has more than one weapon then bool is true
        if (selectedWeapon >= 1)
        {
            multipleWeapons = true;
        }
        else if (selectedWeapon < 1)
        {
            multipleWeapons = false;
        }
    }
    
    void SelectWeapon()
    {
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
