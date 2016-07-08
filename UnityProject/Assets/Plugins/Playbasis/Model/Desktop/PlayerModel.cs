using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Desktop.Helper;

namespace Playbasis.Wrapper.Desktop.Model 
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	public class _playerBasicWr : Migrateable<playerBasicWr>
	{
		public string image {get; set;}
		public string username {get; set;}
		public uint exp {get; set;}
		public uint level {get; set;}
		public string first_name {get; set;}
		public string last_name {get; set;}
		public uint gender {get; set;}
		public string cl_player_id {get; set;}

		public playerBasicWr Migrate()
		{
			playerBasicWr newc = new playerBasicWr();
			newc.image = image;
			newc.userName = username;
			newc.exp = exp;
			newc.level = level;
			newc.firstName = first_name;
			newc.lastName = last_name;
			newc.gender = gender;
			newc.clPlayerId = cl_player_id;
			return newc;
		}
	}

	public class _playerPublicWr : _playerBasicWr, Migrateable<playerPublicWr>
	{
		public DateTime registered {get; set;}
		public DateTime last_login {get; set;}
		public DateTime last_logout {get; set;}

		public playerPublicWr Migrate()
		{
			playerPublicWr newc = new playerPublicWr();
			newc.basic = base.Migrate();
			newc.registered = DesktopHelper.GetTime(registered);
			newc.lastLogin = DesktopHelper.GetTime(last_login);
			newc.lastLogout = DesktopHelper.GetTime(last_logout);
			return newc;
		}
	}

	public class _playerWr : _playerPublicWr, Migrateable<playerWr>
	{
		public string email {get; set;}
		public string phone_number {get; set;}

		public playerWr Migrate()
		{
			playerWr newc = new playerWr();
			newc.playerPublic = base.Migrate();
			newc.email = email;
			newc.phoneNumber = phone_number;
			return newc;
		}
	}

	public class _pointWr : Migrateable<pointWr>
	{
		public string reward_id {get; set;}
		public uint value {get; set;}
		public string reward_name {get; set;}

		public pointWr Migrate()
		{
			pointWr newc = new pointWr();
			newc.rewardId = reward_id;
			newc.value = value;
			newc.rewardName = reward_name;
			return newc;
		}
	}

	public class _pointRWr : Migrateable<pointRWr>
	{
		public List<_pointWr> point {get; set;}

		public pointRWr Migrate()
		{
			pointRWr newc = new pointRWr();
			newc.pointArray = DesktopHelper.MigrateList<pointWr, _pointWr>(point);
			return newc;
		}
	}

	#endif
}