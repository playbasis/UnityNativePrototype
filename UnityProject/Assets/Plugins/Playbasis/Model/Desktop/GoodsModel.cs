using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.Desktop.Helper;

namespace Playbasis.Wrapper.Desktop.Model 
{
	#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || DEBUG_DESKTOP

	public class _goodsWr : Migrateable<goodsWr>
	{
		public string goods_id {get; set;}
		public uint quantity {get; set;}
		public string image {get; set;}
		public uint sort_order {get; set;}
		public string name {get; set;}
		public string description {get; set;}
		public _redeemWr redeem {get; set;}
		public string code {get; set;}
		public DateTime date_start {get; set;}
		public DateTime date_expire {get; set;}

		public goodsWr Migrate()
		{
			goodsWr newc = new goodsWr();
			newc.goodsId = goods_id;
			newc.quantity = quantity;
			newc.image = image;
			newc.sortOrder = sort_order;
			newc.name = name;
			newc.description_ = description;
			newc.redeem = redeem.Migrate();
			newc.code = code;
			newc.dateStart = DesktopHelper.GetTime(date_start);
			newc.dateExpire = DesktopHelper.GetTime(date_expire);
			return newc;
		}
	}

	public class _goodsInfoWr : _goodsWr, Migrateable<goodsInfoWr>
	{
		public uint amount {get; set;}
		public uint per_user {get; set;}
		public bool is_group {get; set;}

		public goodsInfoWr Migrate()
		{
			goodsInfoWr newc = new goodsInfoWr();
			newc.goods = base.Migrate();
			newc.amount = amount;
			newc.perUser = per_user;
			newc.isGroup = is_group;
			return newc;
		}
	}

	public class _redeemWr : Migrateable<redeemWr>
	{
		public _redeem_point_subWr point {get; set;}
		public List<_customWr> custom {get; set;}
		public List<_redeemBadgeWr> badge {get; set;}

		public redeemWr Migrate()
		{
			redeemWr newc = new redeemWr();
			newc.pointValue = point.point_value;
			newc.customArray = DesktopHelper.MigrateList<customWr, _customWr>(custom);
			newc.redeemBadgeArray = DesktopHelper.MigrateList<redeemBadgeWr, _redeemBadgeWr>(badge);
			return newc;
		}
	}

	public class _redeem_point_subWr
	{
		public uint point_value {get; set;}
	}

	public class _customWr : Migrateable<customWr>
	{
		public string custom_id {get; set;}
		public string custom_name {get; set;}
		public string custom_value {get; set;}

		public customWr Migrate()
		{
			customWr newc = new customWr();
			newc.customId = custom_id;
			newc.customName = custom_name;
			newc.customValue = custom_value;
			return newc;
		}
	}

	public class _redeemBadgeWr : Migrateable<redeemBadgeWr>
	{
		public string badge_id {get; set;}
		public uint badge_value {get; set;}

		public redeemBadgeWr Migrate()
		{
			redeemBadgeWr newc = new redeemBadgeWr();
			newc.badgeId = badge_id;
			newc.badgeValue = badge_value;
			return newc;
		}
	}

	public class _goodsInfoListWr : Migrateable<goodsInfoListWr>
	{
		public List<_goodsInfoWr> goods_list {get; set;}

		public goodsInfoListWr Migrate()
		{
			goodsInfoListWr newc = new goodsInfoListWr();
			newc.goodsInfoArray = DesktopHelper.MigrateList<goodsInfoWr, _goodsInfoWr>(goods_list);
			return newc;
		}
	}

	#endif
}