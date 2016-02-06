using UnityEngine;
using System.Collections;

public class CBubbleEnemy : CBall {

	// Use this for initialization
	public override void Start () {
		base.Start ();
		base.setKinematic ();
	}
	
}
