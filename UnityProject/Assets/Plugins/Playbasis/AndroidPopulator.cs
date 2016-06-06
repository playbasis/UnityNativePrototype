using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper;
using Playbasis.Wrapper.Log;
using Playbasis.Wrapper.Model;

namespace Playbasis.Wrapper.Android
{
	public class AndroidPopulator {

		#if UNITY_ANDROID

		/*
			Populate playerPublic from AndroidJavaObject.
		*/
		public static void PopulatePlayerPublic(ref playerPublicWr p, AndroidJavaObject result)
		{
			p.basic.image = result.Call<string>("getImage");
			p.basic.userName = result.Call<string>("getUsername");

			{
				AndroidJavaObject obj = result.Call<AndroidJavaObject>("getExp");
				if (obj != null)
				{
					p.basic.exp = (uint)obj.Call<int>("intValue");
				}
			}

			{
				AndroidJavaObject obj = result.Call<AndroidJavaObject>("getLevel");
				if (obj != null)
				{
					p.basic.level = (uint)obj.Call<int>("intValue");
				}
			}

			p.basic.firstName = result.Call<string>("getFirstName");
			p.basic.lastName = result.Call<string>("getLastName");

			// don't know why this has problem and not working
			// uncomment will lead to crash
			/*{
				AndroidJavaObject obj = result.Call<AndroidJavaObject>("getGender");
				if (obj != null)
				{
					p.basic.gender = (uint)obj.Call<int>("getGender");
					Debug.Log("5");
				}
			}*/

			p.basic.clPlayerId = result.Call<string>("getClPlayerId");

			{
				AndroidJavaObject obj = result.Call<AndroidJavaObject>("getDateRegistered");
				if (obj != null)
				{
					p.registered = obj.Call<long>("getTime");
				}
			}

			{
				AndroidJavaObject obj = result.Call<AndroidJavaObject>("getDateLastLogin");
				if (obj != null)
				{
					p.lastLogin = obj.Call<long>("getTime");
				}
			}

			{
				AndroidJavaObject obj = result.Call<AndroidJavaObject>("getDateLastLogout");
				if (obj != null)
				{
					p.lastLogout = obj.Call<long>("getTime");
				}
			}
		}

		/*
			Populate detailed player info.
		*/
		public static void PopulatePlayer(ref playerWr data, AndroidJavaObject result)
		{
			PopulatePlayerPublic(ref data.playerPublic, result);

			data.email = result.Call<string>("getEmail");
			data.phoneNumber = result.Call<string>("getPhoneNumber");
		}

		/*
			Populate specified point name of player.
		*/
		public static void PopulatePointOfPlayer(ref pointRWr data, AndroidJavaObject result)
		{
			int size = result.Call<int>("size");
			if (size > 0)
			{
				List<pointWr> pointList = new List<pointWr>();

				for (int i=0; i<size; i++)
				{
					pointWr p = new pointWr();
					AndroidJavaObject pJavaObj = result.Call<AndroidJavaObject>("get", i);

					p.rewardId = pJavaObj.Call<string>("getRewardId");
					p.rewardName = pJavaObj.Call<string>("getRewardName");

					{
						AndroidJavaObject obj = pJavaObj.Call<AndroidJavaObject>("getValue");
						if (obj != null)
						{
							p.value = (uint)obj.Call<int>("intValue");
						}
					}

					pointList.Add(p);
				}

				data.pointArray.setFinalList(pointList);
			}
			else
			{
				data.pointArray.setFinalList(new List<pointWr>());
			}
		}

		#endif

	}
}