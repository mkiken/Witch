using UnityEngine;
using System.Collections;

//http://docs.unity3d.com/ja/current/ScriptReference/RequireComponent.html
// The GameObject requires a Rigidbody component
[RequireComponent (typeof (Rigidbody))]
public class WallRigidBody : MonoBehaviour {

//	[SerializeField]
	private Rigidbody _rigidbody;
//	[SerializeField]
	private bool isKinematic = true;
//	[SerializeField]
	private bool useGravity = false;

//	[SerializeField]
	private RigidbodyConstraints constraints = RigidbodyConstraints.FreezeAll;
//	private RigidbodyConstraints constraints = RigidbodyConstraints.FreezeRotationX;


	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody>();
		_rigidbody.isKinematic = isKinematic;
		_rigidbody.useGravity = useGravity;
		_rigidbody.constraints = constraints;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
