using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TapBehaviour : MonoBehaviour {

    public virtual void TapDown(ref RaycastHit hit) { }

	public virtual void TapUp(ref RaycastHit hit) { }
}
