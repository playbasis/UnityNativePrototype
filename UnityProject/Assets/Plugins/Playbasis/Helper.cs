using UnityEngine;
using System;
using System.Collections.Generic;
using Playbasis.Wrapper;
using System.Runtime.InteropServices;
using AOT;
using Playbasis.Wrapper.Model;
using Playbasis.Wrapper.InternalModel;

namespace Playbasis.Wrapper.Helper {

	/// <summary>String representation of object builder</summary>
	public class ToStringBuilder
	{
		/// <summary>Build string representation of object</summary>
		/// <param name="obj">Object to get string representation</param>
		/// <returns>string</returns>
		public static string build(ToStringable obj)
		{
			string s = "{";

			if (obj != null)
			{
				s += obj.toString();
			}

			s += "}";
			return s;
		}

		/*
			Build string representation of all elements of List<E> with prefix name at the beginning.
		*/
		public static string buildList<E>(List<E> list, string prefix=null)
		{
			string s = "";
			if (prefix != null)
				s = prefix + "{";

			for (int i=0; list!=null && i<list.Count; i++)
			{
				E element = list[i];
				s += getString<E>(ref element);

				if (i < list.Count - 1)
				{
					s += ", ";
				}
			}

			if (prefix != null)
				s += "}";
			return s;
		}

		/*
			Get string representation from individual element.
			If type E is unknown then return null, otherwise return element's string representation.
		*/
		private static string getString<E>(ref E element)
		{
			ToStringable tos = element as ToStringable;
			// non-fatal error, as element that is array, we need to avoid endless loop in calling
			if (tos == null)
				return null;

			return tos.toString();
		}
	}
}