using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;
    public GameObject bullet6;
    public GameObject cylinder;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot()
    {
        //bullet1.GetComponent<Renderer>().enabled = false;
        MeshRenderer variable = bullet1.GetComponent<MeshRenderer>();
        variable.enabled = false;
    }

    public void reload()
    {
        MeshRenderer variable = bullet1.GetComponent<MeshRenderer>();
        variable.enabled = true;
    }

    //when trigger is pulled "FIRE1"
    //rotates next round in
    //fires
    //makes that bullet "gone"
    //only does per trigger pull

    //when reloading
    //gun "aims" at bullet in view
    //rotates nearest available spot in cylinder to being the next round to shoot
    //pulls in bullet to spot and fills
    //repeats if possible till all bullets are back in gun

 /*
    ///       _ready to shoot
    ///      /    0    \
    ///     /0 <- next 0\
    ///    |            |
    ///     \0        0/
    ///      \____0___/
    ///      rotates clockwise only
*/
}
