using UnityEngine;

namespace MackySoft.Modiferty.Modifiers {

	public abstract class ReactiveOperatorModifierBase<TRHS,TResult> : ReactiveModifiableProperty<TRHS>, IModifier<TResult> {

		[SerializeField]
		int m_Priority;

		public int Priority {
			get => m_Priority;
			set => m_Priority = value;
		}

		protected ReactiveOperatorModifierBase () : this(default) {
		}
		protected ReactiveOperatorModifierBase (TRHS baseValue) : base(baseValue) {
		}

		public abstract TResult Evaluate (TResult value);
	}

	public abstract class ReactiveOperatorModifierBase<T> : ReactiveOperatorModifierBase<T,T> {
		protected ReactiveOperatorModifierBase () : this(default) {
		}
		protected ReactiveOperatorModifierBase (T baseValue) : base(baseValue) {
		}
	}

}