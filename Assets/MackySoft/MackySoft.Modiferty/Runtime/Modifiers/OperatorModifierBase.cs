using UnityEngine;

namespace MackySoft.Modiferty.Modifiers {

	public abstract class OperatorModifierBase<TRHS,TResult> : ModifieableProperty<TRHS>, IModifier<TResult> {

		[SerializeField]
		int m_Priority;

		public int Priority {
			get => m_Priority;
			set => m_Priority = value;
		}

		protected OperatorModifierBase () : this(default) {
		}

		protected OperatorModifierBase (TRHS baseValue) : base(baseValue) {
		}

		public abstract TResult Evaluate (TResult value);

	}

	public abstract class OperatorModifierBase<T> : OperatorModifierBase<T,T> {
		protected OperatorModifierBase () : this(default) {
		}

		protected OperatorModifierBase (T baseValue) : base(baseValue) {
		}
	}

}