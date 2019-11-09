using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform WeaponPos;
    public Transform NormPos;
    public Transform ADSPos;
    public Transform RelodPos;

    public Camera aiming;

    public bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        WeaponPos.position = NormPos.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && canFire)
        {
            WeaponPos.position = ADSPos.position;
            aiming.fieldOfView = 25;
        }
        if (Input.GetButtonUp("Fire2") && canFire)
        {
            WeaponPos.position = NormPos.position;
            aiming.fieldOfView = 60;

        }
        if (Input.GetButtonDown("Reload") && canFire)
        {
            WeaponPos.position = RelodPos.position;
            WeaponPos.rotation = RelodPos.rotation;
        }
        if (Input.GetButtonUp("Reload") && canFire)
        {
            WeaponPos.position = NormPos.position;
            WeaponPos.rotation = NormPos.rotation;
        }
    }
}
