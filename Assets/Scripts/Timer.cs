using UnityEngine;
using System;

namespace InGame.Manager
{
	[Serializable]
	public class Timer
	{
		float m_fAccumulateTime = 0f;
		bool m_bIsIncreaseTime = true;

		float Accumulation
		{
			get
			{
				return m_fAccumulateTime += (m_bIsIncreaseTime) ? Time.deltaTime : -(Time.deltaTime);
			}
		}

		float m_fTime = 0f;
		public Timer() { m_fAccumulateTime = 0f; m_fTime = 0f; }

		public Timer(float Time) => m_fTime = Time;

		public Timer(float Time, bool m_bIsIncreaseTime)
		{
			m_fTime = Time;
			if (!m_bIsIncreaseTime)
				m_fAccumulateTime = m_fTime;
			this.m_bIsIncreaseTime = m_bIsIncreaseTime;
		}
		public float GetTime() => m_fAccumulateTime;
		public float Operate() => Accumulation;

		public void Init() => m_fAccumulateTime = m_fTime;
		public bool LimitOperate() => (m_bIsIncreaseTime) ? Accumulation >= m_fTime : Accumulation <= 0f;
		public override string ToString()
		{
			return Accumulation.ToString();
		}
	}
}