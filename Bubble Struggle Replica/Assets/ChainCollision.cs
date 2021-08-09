using UnityEngine;

public class ChainCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col)
	{
		Chain.IsFired = false;

		if (col.tag == "Ball")
		{
			CameraShake.shakeNow = true;
			col.GetComponent<Ball>().Split();
		}
	}

}
