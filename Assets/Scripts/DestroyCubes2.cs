using UnityEngine;
using System.Collections;

public class DestroyCubes2 : MonoBehaviour
{
    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.name == "prop_powerCube")
        {
            Destroy(col.gameObject);
        }
    }
}