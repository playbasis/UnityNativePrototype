using System;
using UnityEngine;

namespace Playbasis.Wrapper.Desktop.Model
{
	public interface Migrateable<T> { T Migrate(); }
}