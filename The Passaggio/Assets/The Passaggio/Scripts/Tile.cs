using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{

    abstract public void Fall(float fallingImpulseForce,float faliingTorqueFactor);
    abstract public void GetHit(float force, float faliingTorqueFactor);

}
