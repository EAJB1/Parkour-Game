using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public WeaponSwitching weaponSwitchingScript;
    public MeleeWeapon meleeWeaponScript;

    public Rigidbody rb;
    //public BoxCollider coll;
    public MeshCollider coll;
    public Transform player, weaponHolder, fpsCam, weapons;

    public float pickUpRange = 4f;
    public float dropForwardForce = 2.5f;
    public float dropUpwardForce = 2f;

    private int previousSelectedWeapon;

    public bool equipped;
    public bool isEquippable;
    public static bool slotFull;


    // Start is called before the first frame update
    void Start()
    {
        if (!equipped)
        {
            meleeWeaponScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if (equipped)
        {
            meleeWeaponScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is in range and if "F" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;

        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.F) && !slotFull && isEquippable)
        {
            PickUp();
        }
        else if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.F) && slotFull && isEquippable)
        {
            previousSelectedWeapon = weaponSwitchingScript.selectedWeapon;
            weaponSwitchingScript.selectedWeapon++;
            PickUpDeactivate();

            if (previousSelectedWeapon != weaponSwitchingScript.selectedWeapon)
            {
                weaponSwitchingScript.selectedWeapon = previousSelectedWeapon;
            }
        }

        // Drop if equipped and if "G" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.G))
        {
            previousSelectedWeapon = weaponSwitchingScript.selectedWeapon - 1;
            Drop();

            // Find remaining weapons and activate the one before the dropped weapon
            if (weaponHolder.transform.childCount > 0 && previousSelectedWeapon != weaponSwitchingScript.selectedWeapon)
            {
                weaponSwitchingScript.selectedWeapon = previousSelectedWeapon;
                //NOT IN USE: switchingScript.selectedWeapon = weaponHolder.transform.childCount - 1;
                Activate();
            }
        }

        if (weaponSwitchingScript.selectedWeapon < 0)
        {
            weaponSwitchingScript.selectedWeapon = 0;
        }

        if (weaponHolder.transform.childCount >= 1)
        {
            Activate();
        }
    }

    void OnMouseOver()
    {
        isEquippable = true;
    }

    void OnMouseExit()
    {
        isEquippable = false;
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        // Change layer to '8: Weapon equipped'
        gameObject.layer = 8;

        // Check if object has child, if so, change all children to the same layer
        if (transform.childCount >= 0)
        {
            //gameObject.layer = LayerMask.NameToLayer("Crowbar_Cloth");
            //obj = gameObject;
            foreach (Transform child in gameObject.GetComponentsInChildren<Transform>(true))
            {
                //child.gameObject.layer = LayerMask.NameToLayer("Weapon equipped");
                child.gameObject.layer = 8;
            }
        }

        // Make weapon a child of the camera and move it to default position
        transform.SetParent(weaponHolder);

        // Set the position, rotation and scale of the weapon depending on the type of weapon (object tag)
        if (gameObject.tag == "Ninja Sword")
        {
            transform.localPosition = new Vector3(1.03f, -0.5536351f, 0.8454437f);
            transform.localRotation = Quaternion.Euler(new Vector3(66.732f, 5.613f, 80.929f));
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
        else if (gameObject.tag == "Axe")
        {
            transform.localPosition = new Vector3(0.8260558f, -0.423959f, 0.7299191f);
            transform.localRotation = Quaternion.Euler(new Vector3(26.859f, -12.592f, -12.211f));
            transform.localScale = new Vector3(0.0009f, 0.0009f, 0.0009f);
        }
        else if (gameObject.tag == "Crowbar")
        {
            transform.localPosition = new Vector3(0.6968062f, -0.237864f, 0.859993f);
            transform.localRotation = Quaternion.Euler(new Vector3(0f, 75f, 9.452f));
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }

        // Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        // Enable script
        meleeWeaponScript.enabled = true;
    }

    private void PickUpDeactivate()
    {
        equipped = true;
        slotFull = true;

        // Change layer to '8: Weapon equipped'
        gameObject.layer = 8;

        // Make weapon a child of the camera and move it to default position
        transform.SetParent(weaponHolder);

        // Set the position, rotation and scale of the weapon depending on the type of weapon (object tag)
        if (gameObject.tag == "Ninja Sword")
        {
            transform.localPosition = new Vector3(1.03f, -0.5536351f, 0.8454437f);
            transform.localRotation = Quaternion.Euler(new Vector3(66.732f, 5.613f, 80.929f));
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
        else if (gameObject.tag == "Axe")
        {
            transform.localPosition = new Vector3(0.8260558f, -0.423959f, 0.7403412f);
            transform.localRotation = Quaternion.Euler(new Vector3(26.859f, -12.592f, -12.211f));
            transform.localScale = new Vector3(0.0009f, 0.0009f, 0.0009f);
        }
        else if (gameObject.tag == "Crowbar")
        {
            transform.localPosition = new Vector3(0.6968062f, -0.237864f, 0.859993f);
            transform.localRotation = Quaternion.Euler(new Vector3(0f, 75f, 9.452f));
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }

        // Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        // Enable script
        meleeWeaponScript.enabled = true;

        // Deactivate gameObject
        gameObject.SetActive(false);
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        // Change layer to '9: Weapon not equipped'
        gameObject.layer = 9;

        // Set parent to the 'Weapons' empty game object
        transform.SetParent(weapons);

        // Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        // Set scale depending on type of weapon (object tag)
        if (gameObject.tag == "Ninja Sword")
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
        else if (gameObject.tag == "Axe")
        {
            transform.localScale = new Vector3(0.0009f, 0.0009f, 0.0009f);
        }
        else if (gameObject.tag == "Crowbar")
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }

        // Gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        // Add force (change this so the faster player is going, the less force applied)
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);

        // Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        // Disable script
        meleeWeaponScript.enabled = false;
    }

    private void Activate()
    {
        int i = 0;

        foreach (Transform weapon in weaponHolder.transform)
        {
            if (i == weaponSwitchingScript.selectedWeapon)
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
