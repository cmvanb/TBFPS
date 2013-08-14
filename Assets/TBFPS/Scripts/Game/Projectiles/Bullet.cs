/*
	Author	: Casper van Beuzekom
	Date	: 2013-08-11
	
	Copyright (c) Casper van Beuzekom
	All rights reserved.
	Do not distribute.
*/

using UnityEngine;
using System.Collections.Generic;

namespace Casper.TBFPS
{
	public class Bullet : MonoBehaviour
	{
		#region inspector vars
		[SerializeField]
		private GameObject m_hitSmokePrefab;
		
		[SerializeField]
		private float m_damage;
		#endregion
			
		#region unity callbacks
		void Start()
		{
			// hitscan
			RaycastHit hit = new RaycastHit();
			
			bool success = Physics.Raycast(transform.position, transform.forward, out hit, 1000f);
			
			if (success)
			{			
				GameObject hitSmoke = Object.Instantiate(m_hitSmokePrefab) as GameObject;
				hitSmoke.transform.position = hit.point;
				hitSmoke.transform.LookAt(hit.point + hit.normal);
				
				Health healthOfHitObject = hit.transform.GetComponent<Health>();
				
				if (healthOfHitObject != null)
				{
					healthOfHitObject.TakeDamage(m_damage);
				}
			}			
		}
		#endregion
	}
}