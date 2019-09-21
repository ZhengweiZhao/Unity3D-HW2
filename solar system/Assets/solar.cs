using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solar : MonoBehaviour
{
	// Start is called before the first frame update
	public Transform sun;
	public Transform mars;
	public Transform jupiter;
	public Transform saturn;
	public Transform uranus;
	public Transform neptune;
	public Transform mercury;
	public Transform venus;
	public Transform earth;

	void Start()
	{
		//init
		sun.position = Vector3.zero;
		mercury.position = new Vector3(1, 0, 0);
		venus.position = new Vector3(-2, 0, 0);
		earth.position = new Vector3(3, 0, 0);
		mars.position = new Vector3(-6, 0, 0);
		jupiter.position = new Vector3(-7, 0, 0);
		saturn.position = new Vector3(9, 0, 0);
		uranus.position = new Vector3(12, 0, 0);
		neptune.position = new Vector3(-14, 0, 0);
	}

	// Update is called once per frame
	void Update()
	{
		mars.RotateAround(sun.position, new Vector3(0, 13, 5), 10 * Time.deltaTime);
		mars.Rotate(new Vector3(0, 12, 5) * 40 * Time.deltaTime);

		jupiter.RotateAround(sun.position, new Vector3(0, 8, 3), 8 * Time.deltaTime);
		jupiter.Rotate(new Vector3(0, 10, 3) * 30 * Time.deltaTime);

		saturn.RotateAround(sun.position, new Vector3(0, 2, 1), 6 * Time.deltaTime);
		saturn.Rotate(new Vector3(0, 3, 1) * 20 * Time.deltaTime);

		uranus.RotateAround(sun.position, new Vector3(0, 9, 1), 6 * Time.deltaTime);
		uranus.Rotate(new Vector3(0, 10, 1) * 20 * Time.deltaTime);

		neptune.RotateAround(sun.position, new Vector3(0, 7, 1), 5 * Time.deltaTime);
		neptune.Rotate(new Vector3(0, 8, 1) * 30 * Time.deltaTime);

		mercury.RotateAround(sun.position, new Vector3(0, 3, 1), 20 * Time.deltaTime);
		mercury.Rotate(new Vector3(0, 5, 1) * 5 * Time.deltaTime);

		venus.RotateAround(sun.position, new Vector3(0, 2, 1), 15 * Time.deltaTime);
		venus.Rotate(new Vector3(0, 2, 1) * Time.deltaTime);

		earth.RotateAround(sun.position, Vector3.up, 10 * Time.deltaTime);
		earth.Rotate(Vector3.up * 30 * Time.deltaTime);

	}
}


