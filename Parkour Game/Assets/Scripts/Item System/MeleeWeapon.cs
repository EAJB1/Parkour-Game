using System.Collections;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public WeaponSwitching weaponSwitchingScript;

    public float damage = 10f;
    public float range = 3f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 1;
    private int currentAmmo;
    public float reloadTime = 0.45f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem weaponTrail;
    public Animator animator;

    void Start()
    {
        if (currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }
    }
    
    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("LightAttack", false);
        
        if (gameObject.tag == "Ninja Sword" || gameObject.tag == "Ninja Sword"  && weaponSwitchingScript.animationAllowed)
        {
            if (weaponSwitchingScript.multipleWeapons)
            {
                
            }
            animator.SetBool("Sword", true);
        }
        else 
        { 
            animator.SetBool("Sword", false); 
        }

        if (gameObject.tag == "Axe" || gameObject.tag == "Axe" && weaponSwitchingScript.animationAllowed)
        {
            animator.SetBool("Axe", true);
        }
        else
        {
            animator.SetBool("Axe", false);
        }

        if (gameObject.tag == "Crowbar" || gameObject.tag == "Crowbar" && weaponSwitchingScript.animationAllowed)
        {
            animator.SetBool("Crowbar", true);
        }
        else
        {
            animator.SetBool("Crowbar", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(ReloadWeapon());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Swing());
        }
    }

    IEnumerator ReloadWeapon()
    {
        //Debug.Log("Reloading...");
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    IEnumerator Swing()
    {
        weaponTrail.Play();
        animator.SetBool("LightAttack", true);
        currentAmmo--;
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }

        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("LightAttack", false);
    }
}
