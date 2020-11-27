using System;
using MackySoft.Modiferty.Modifiers;

namespace MackySoft.Modiferty {

	[Serializable]
	public class ReactiveModifiableFloat : ReactiveModifiableProperty<float> {
		public ReactiveModifiableFloat () : this(default) {
		}

		public ReactiveModifiableFloat (float initialValue) : base(initialValue) {
		}
	}

	#region Operator Modifiers

	[Serializable]
	public class ReactiveAdditiveModifierFloat : ReactiveOperatorModifierBase<float> {

		public ReactiveAdditiveModifierFloat () : this(default) {
		}
		public ReactiveAdditiveModifierFloat (float baseValue) : base(baseValue) {
		}

		public override float Evaluate (float value) {
			return value + Evaluate();
		}

	}

	[Serializable]
	public class ReactiveSubtractiveModifierFloat : ReactiveOperatorModifierBase<float> {

		public ReactiveSubtractiveModifierFloat () : this(default) {
		}
		public ReactiveSubtractiveModifierFloat (float baseValue) : base(baseValue) {
		}

		public override float Evaluate (float value) {
			return value - Evaluate();
		}

	}

	[Serializable]
	public class ReactiveMultiplyModifierFloat : ReactiveOperatorModifierBase<float> {

		public ReactiveMultiplyModifierFloat () : this(1f) {
		}
		public ReactiveMultiplyModifierFloat (float baseValue) : base(baseValue) {
		}

		public override float Evaluate (float value) {
			return value * Evaluate();
		}

	}

	[Serializable]
	public class ReactiveDivisionModifierFloat : ReactiveOperatorModifierBase<float> {

		public ReactiveDivisionModifierFloat () : this(1f) {
		}
		public ReactiveDivisionModifierFloat (float baseValue) : base(baseValue) {
		}

		public override float Evaluate (float value) {
			return value / Evaluate();
		}

	}

	#endregion

	[Serializable]
	public class ReactiveSetModifierFloat : ReactiveSetModifier<float> {
		public ReactiveSetModifierFloat () : this(default) {
		}

		public ReactiveSetModifierFloat (float baseValue) : base(baseValue) {
		}
	}

}