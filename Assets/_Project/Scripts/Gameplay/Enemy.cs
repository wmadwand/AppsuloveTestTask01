using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Score; /*{ get; private set; }*/
    public bool IsCollisionEnter = false;

    public void Remove()
    {
        Destroy(gameObject);
    }
}
