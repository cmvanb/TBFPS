/*
	Author	: Casper van Beuzekom
	Date	: 2013-08-10
	
	Copyright (c) Casper van Beuzekom
	All rights reserved.
	Do not distribute.
*/

using UnityEngine;
using System.Collections.Generic;

namespace Casper.TBFPS
{
	public class MouseLook : MonoBehaviour
	{
		// events
		
		// inspector vars
		[SerializeField]
		private Transform m_playerBody;
		
		[SerializeField]
		private Transform m_camera;
	
		[SerializeField]
		private Vector2 m_mouseSensitivity 		= new Vector2(5f, 5f);
		
		[SerializeField]
		private Vector2 m_rotationPitchLimit 	= new Vector2(90f, -90f);
		
		[SerializeField]
		private Vector2 m_rotationYawLimit 		= new Vector2(-360f, 360f);
		
		// public vars
		
		// private vars
		private Vector2 m_mouseMovement;
		
		private float m_pitch;
		
		private float m_yaw;
		
		private Vector2 m_initialYawPitch;
		
		// unity callbacks
		void Awake()
		{
			m_initialYawPitch = new Vector2(m_camera.eulerAngles.y, m_camera.eulerAngles.x);
		}
		
		void Update()
		{
			if (Screen.lockCursor)
			{
				UpdateMouseLook();
			}
			
			Rotate();
		}
		
		// public methods
		
		// private methods
		private void UpdateMouseLook()
		{
			m_mouseMovement.x = Input.GetAxisRaw("Mouse X") * Time.timeScale;
			m_mouseMovement.y = Input.GetAxisRaw("Mouse Y") * Time.timeScale;
			
			// modify pitch and yaw with input, sensitivity
			m_pitch -= m_mouseMovement.y * (m_mouseSensitivity.y);
			m_yaw 	+= m_mouseMovement.x * (m_mouseSensitivity.x);
	
			// clamp angles
			m_pitch = m_pitch < -360f ? m_pitch += 360f : m_pitch;
			m_pitch = m_pitch > 360f ? m_pitch -= 360f : m_pitch;
			m_pitch = Mathf.Clamp(m_pitch, -m_rotationPitchLimit.x, -m_rotationPitchLimit.y);
			
			m_yaw 	= m_yaw < -360f ? m_yaw += 360f : m_yaw;
			m_yaw 	= m_yaw > 360f ? m_yaw -= 360f : m_yaw;
			m_yaw 	= Mathf.Clamp(m_yaw, m_rotationYawLimit.x, m_rotationYawLimit.y);
		}
				
		private void Rotate()
		{
			// rotate the player body (yaw only)
			Quaternion xQuaternion 	= Quaternion.AngleAxis(m_yaw + m_initialYawPitch.x, Vector3.up);
			
			m_playerBody.rotation 	= xQuaternion;
	
			// rotate the camera (pitch only)
			Quaternion yQuaternion 	= Quaternion.AngleAxis((-m_pitch) - m_initialYawPitch.y, Vector3.left);
			
			m_camera.localRotation 	=  yQuaternion;
		}
	}
}