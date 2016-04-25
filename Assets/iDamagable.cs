using UnityEngine;
using System.Collections;

public interface iDamagable
{
    void TakeHit(float damage, RaycastHit hit);
}
