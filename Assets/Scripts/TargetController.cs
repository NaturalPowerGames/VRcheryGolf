using UnityEngine;

public class TargetController : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.gameObject.name);
	}
}
