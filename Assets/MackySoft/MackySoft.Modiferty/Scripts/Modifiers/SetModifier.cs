using System;
using UnityEngine;

namespace MackySoft.Modiferty {

	/// <summary>
	/// The given value ignored and the returns specified value returned.
	/// </summary>
	[Serializable]
	public class SetModifier<T> : IModifier<T> {

		[SerializeField]
		T m_Value;

		[SerializeField]
		int m_Priority;

		public T Value { get => m_Value; set => m_Value = value; }

		public int Priority { get => m_Priority; set => m_Priority = value; }

		public SetModifier (T value,int priority = 0) {
			m_Value = value;
			Priority = priority;
		}

		/// <summary>
		/// The given value ignored and the <see cref="Value"/> returned.
		/// </summary>
		public T Evaluate (T value) {
			return m_Value;
		}

	}

}