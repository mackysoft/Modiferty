using System;
using UnityEngine;

namespace MackySoft.Modiferty {

	[Serializable]
	public class ReactiveSetModifier<T> : ReactiveModifiableProperty<T>, IModifier<T> {

		[SerializeField]
		int m_Priority;

		public int Priority {
			get => m_Priority;
			set => m_Priority = value;
		}

		public ReactiveSetModifier () : this(default) {
		}

		public ReactiveSetModifier (T baseValue) : base(baseValue) {
		}

		public T Evaluate (T value) {
			return Evaluate();
		}

	}
}