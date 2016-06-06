using System;
using UnityEngine;
using Playbasis.Wrapper;
using Playbasis.Wrapper.Model;

namespace Playbasis.Wrapper.Log
{
	public class Printer {

		public static void print<T>(ref T data)
		{
			if (typeof(T) == typeof(playerBasicWr))
			{
				playerBasicWr c = (playerBasicWr)(object)data;
				Debug.Log(c.toString());
			}
			else if (typeof(T) == typeof(playerPublicWr))
			{
				playerPublicWr c = (playerPublicWr)(object)data;
				Debug.Log(c.toString());
			}
			else if (typeof(T) == typeof(playerWr))
			{
				playerWr c = (playerWr)(object)data;
				Debug.Log(c.toString());
			}
			else if (typeof(T) == typeof(pointWr))
			{
				pointWr c = (pointWr)(object)data;
				Debug.Log(c.toString());
			}
			else if (typeof(T) == typeof(pointRWr))
			{
				pointRWr c = (pointRWr)(object)data;
				Debug.Log(c.toString());
			}
			else if (typeof(T) == typeof(quizBasicWr))
			{
				quizBasicWr c = (quizBasicWr)(object)data;
				Debug.Log(c.toString());
			}
			else if (typeof(T) == typeof(quizListWr))
			{
				quizListWr c = (quizListWr)(object)data;
				Debug.Log(c.toString());
			}
			else if (typeof(T) == typeof(gradeRewardCustomWr))
			{
				gradeRewardCustomWr c = (gradeRewardCustomWr)(object)data;
				Debug.Log(c.toString());
			}
		}
	}
}