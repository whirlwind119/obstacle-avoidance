﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameManager class for storing global functions
public class GM : MonoBehaviour {
	private GM m_Instance;
	public GM Instance { get { return m_Instance; } }

	void Awake() {
		m_Instance = this;
	}

	void OnDestroy() {
		m_Instance = null;
	}

	/**
	 *	rotate to face towards the desired point
	 *	@param go: the game object to rotate
	 *	@param loc: the location in space towards which we should face
	 */
	public static void lookAt2d(GameObject go, Vector3 loc) {
		Vector3 diff = loc - go.transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		go.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}

	/**
	 * Overloads lookAt2d to support a Vector2d location
	 */
	public static void lookAt2d(Vector2 loc) {
		lookAt2d(new Vector3(loc.x, loc.y, 0));
	}
}