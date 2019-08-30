using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{

    abstract public void Fall(float fallingImpulseForce);
    abstract public void GetHit(float force);

}
