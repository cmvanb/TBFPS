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
	public class PlayerMovement : MonoBehaviour
	{
		// events
	
		// inspector vars
		[SerializeField]
		private Transform m_playerBody;
		
		[SerializeField]
		private CharacterController m_characterController;
		
		[SerializeField]
		private float m_maxSpeed;
		
		[SerializeField]
		private float m_acceleration;
		
		[SerializeField]
		private float m_deceleration;
		
		// public vars
		
		// private vars
		private Vector3 m_inputVector;
		
		private Vector3 m_lastInputVector;
		
		private Vector3 m_movementVector;
		
		private float m_speed;
		
		// unity callbacks
		void Update()
		{
			UpdateInput();
			
			UpdateSpeed();
			
			UpdateMovement();
			
			Move();
		}
		
		// public methods
		
		// private methods
		private void UpdateInput()
		{
			float inputX = Input.GetAxisRaw("Horizontal") * Time.timeScale;
			float inputZ = Input.GetAxisRaw("Vertical") * Time.timeScale;
			
			m_inputVector = new Vector3(inputX, 0f, inputZ);
			m_inputVector.Normalize();
			
			if (m_inputVector.sqrMagnitude > 0f)
			{
				m_lastInputVector = m_inputVector;
			}
		}
		
		private void UpdateSpeed()
		{
			// if input vector is bigger than 0f we are receiving movement input
			if (m_inputVector.sqrMagnitude > 0f)
			{
				m_speed = Mathf.MoveTowards(m_speed, m_maxSpeed, m_acceleration);			
			}
			else
			{
				m_speed = Mathf.MoveTowards(m_speed, 0f, m_deceleration);
			}
		}		
		
		private void UpdateMovement()
		{
			m_movementVector = m_playerBody.TransformDirection(m_lastInputVector) * m_speed * Time.deltaTime;
		}
		
		private void Move()
		{
			m_characterController.Move(m_movementVector);
		}
	}
}