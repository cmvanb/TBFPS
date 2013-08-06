/*
	Author	: Casper van Beuzekom
	Date	: 2013-08-05
	
	Copyright (c) Casper van Beuzekom
	All rights reserved.
	Do not distribute.
*/

using UnityEngine;
using System.Collections.Generic;

namespace Casper.TBFPS
{
	public class LevelData : ScriptableObject
	{
		// events
	
		// public vars
		[SerializeField]
		private string m_levelID;
		public string LevelID { get { return m_levelID; } }
		
		[SerializeField]
		private GameObject m_levelPrefab;
		public GameObject LevelPrefab { get { return m_levelPrefab; } }
		
		// private vars
				
		// constructor
		public LevelData(string levelID, GameObject levelPrefab)
		{
			m_levelID 		= levelID;
			m_levelPrefab 	= levelPrefab;
		}
		
		// public methods
		
		// private methods
	}
}