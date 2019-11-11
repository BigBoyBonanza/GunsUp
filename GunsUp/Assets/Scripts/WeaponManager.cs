using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform WeaponPos;
    public Transform NormPos;
    public Transform ADSPos;
    public Transform ReloadPos;

    public Camera aiming;
    public AmmoManager ammoCylinder;


    //disables aim during some actions
    public bool canFire = true;
    private bool isAiming = false;
    private bool isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        WeaponPos.position = NormPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canFire)
        {
            shoot();
        }
        if (Input.GetButtonDown("Fire2") && canFire)
        {
            isAiming = true;
        }
        if (Input.GetButtonUp("Fire2") && canFire)
        {
            isAiming = false;
        }
        if (Input.GetButtonDown("Reload") && canFire)
        {
            //WeaponPos.position = RelodPos.position;
            //WeaponPos.rotation = RelodPos.rotation;
            isReloading = true;
            reloading();
        }
        if (Input.GetButtonUp("Reload") && canFire)
        {
            //WeaponPos.position = NormPos.position;
            //WeaponPos.rotation = NormPos.rotation;
            isReloading = false;
        }
    }

    private void LateUpdate()
    {
        updateGun();
        //updateWeaponBob();
        //updateWeaponRecoil();
        //weapon position will be combination of aim position, recoil, and weapon bob
        //WeaponPos.position = WeaponPos.position;        
    }

    private void updateGun()
    {
        if (isAiming && canFire)
        {
            //WeaponPos.position = ADSPos.position;
            WeaponPos.position = Vector3.Lerp(WeaponPos.position, ADSPos.position, 20f * Time.deltaTime);
            //aiming.fieldOfView = 25;
            updateFOV(Mathf.Lerp(aiming.fieldOfView, 25f, 10f * Time.deltaTime));
        }
        else if (isReloading && canFire)
        {

            //WeaponPos.position = ReloadPos.position;
            //WeaponPos.rotation = ReloadPos.rotation;
            WeaponPos.position = Vector3.Lerp(WeaponPos.position, ReloadPos.position, 20f * Time.deltaTime);
            WeaponPos.rotation = Quaternion.Lerp(WeaponPos.rotation, ReloadPos.rotation, 20f * Time.deltaTime);
        }
        else
        {
            //WeaponPos.position = NormPos.position;
            WeaponPos.position = Vector3.Lerp(WeaponPos.position, NormPos.position, 20f * Time.deltaTime);
            //aiming.fieldOfView = 60;
            updateFOV(Mathf.Lerp(aiming.fieldOfView, 60f, 10f * Time.deltaTime));
            //WeaponPos.rotation = NormPos.rotation;
            WeaponPos.rotation = Quaternion.Lerp(WeaponPos.rotation, NormPos.rotation, 20f * Time.deltaTime);
        }
    }

    public void updateFOV(float fov)
    {
        aiming.fieldOfView = fov;
    }
    private void reloading()
    {
        ammoCylinder.reload();

    }
    private void shoot()
    {
        ammoCylinder.shoot();
        //will check if there are bullets from the ammo manager
        //if there are will rotate cylinder
        //shoots and removes bullet from view
        //
    }
}
