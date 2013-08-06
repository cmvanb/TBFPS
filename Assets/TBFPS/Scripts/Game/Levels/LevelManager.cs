/*
	Author	: Casper van Beuzekom
	Date	: 2013-08-05
	
	Copyright (c) Casper van Beuzekom
	All rights reserved.
	Do not distribute.
*/

using UnityEngine;
using System.Collections.Generic;
using Casper.Framework;

namespace Casper.TBFPS
{
	public sealed class LevelManager : Singleton<LevelManager>
	{
		// events
	
		// public vars
		private LevelData m_currentLevelData;
		public LevelData CurrentLevelData { get { return m_currentLevelData; } set { m_currentLevelData = value; } }
		
		// private vars
		private List<LevelData> m_levelData;
		
		// singleton callbacks
		public override void Init() 
		{
			base.Init();
			
			this.MakePersistent();
			
			m_levelData = new List<LevelData>();
		}
		
		// unity callbacks
		
		// public methods
		public void LoadAllLevelData()
		{
			Object[] allLevelData = Resources.LoadAll("Data/Levels");
			
			DebugUtil.Log("Loaded data for " + allLevelData.Length + " levels");
			
			for (int i = 0; i < allLevelData.Length; ++i)
			{
				if (allLevelData[i] is LevelData)
				{
					m_levelData.Add((LevelData)allLevelData[i]);
				}
				else
				{
					DebugUtil.LogError(allLevelData[i] + " is not LevelData");
				}
			}
		}
		
		public LevelData GetLevelData(string levelID)
		{
			foreach (LevelData levelData in m_levelData)
			{
				if (levelData.LevelID == levelID)
				{
					return levelData;
				}
			}
			
			DebugUtil.LogError("Could not find level data with id " + levelID);
			return null;
		}
		
		public void InstantiateLevelFromData(LevelData levelData)
		{
			GameObject level = Object.Instantiate(levelData.LevelPrefab) as GameObject;
			
			if (level != null)
			{
				DebugUtil.Log("Instantiated level with id " + levelData.LevelID);
			}
			else
			{
				DebugUtil.LogError("Could not instantiate level with id " + levelData.LevelID);
			}
		}
		
		// private methods
	}
}