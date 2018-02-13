﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMinimap : MonoBehaviour {

	public Transform player;

	void LateUpdate ()
	{
		Vector3 newPosition = player.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;
	}
}
