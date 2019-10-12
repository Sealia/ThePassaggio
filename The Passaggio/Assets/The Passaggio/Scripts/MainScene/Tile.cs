using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    bool wasHit = false;
    bool wasSwallowed = false;

   public void GetHit()
    {
        if(!wasHit)
        {
            Crush();
        }
        wasHit = true;
    }

    public void GetSwallowed(float fallingImpulseForce, float faliingTorqueFactor)
    {
        if(!wasSwallowed)
        {
            Disassemble(fallingImpulseForce, faliingTorqueFactor);
        }
        wasSwallowed = true;
        wasHit = true;
    }

    public abstract void Crush();
    public abstract void Disassemble(float fallingImpulseForce, float faliingTorqueFactor);

    public void Fall()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        
    }

}
