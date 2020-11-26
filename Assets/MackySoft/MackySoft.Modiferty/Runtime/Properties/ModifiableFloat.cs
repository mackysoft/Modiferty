using System;
using MackySoft.Modiferty.Modifiers;

namespace MackySoft.Modiferty {

	[Serializable]
	public class ModifiableFloat : ModifieableProperty<float> {
		public ModifiableFloat () : this(default) {
		}
		public ModifiableFloat (float baseValue) : base(baseValue) {
		}
	}

	#region Operator Modifiers

	[Serializable]
	public class AdditiveModifierFloat : OperatorModifierBase<float> {

		public AdditiveModifierFloat () : this(default) {
		}
		public AdditiveModifierFloat (float baseValue) : base(baseValue) {
		}

		public override float Evaluate (float value) {
			return value + Evaluate();
		}

	}

	[Serializable]
	public class SubtractiveModifierFloat : OperatorModifierBase<float> {

		public SubtractiveModifierFloat () : this(default) {
		}
		public SubtractiveModifierFloat (float baseValue) : base(baseValue) {
		}

		public override float Evaluate (float value) {
			return value - Evaluate();
		}

	}

	[Serializable]
	public class MultiplyModifierFloat : OperatorModifierBase<float> {

		public MultiplyModifierFloat () : this(1f) {
		}
		public MultiplyModifierFloat (float baseValue) : base(baseValue) {
		}

		public override float Evaluate (float value) {
			return value * Evaluate();
		}

	}

	[Serializable]
	public class DivisionModifierFloat : OperatorModifierBase<float> {

		public DivisionModifierFloat () : this(1f) {
		}
		public DivisionModifierFloat (float baseValue) : base(baseValue) {
		}

		public override float Evaluate (float value) {
			return value / Evaluate();
		}

	}

	#endregion

	/// <summary>
	/// The given value ignored and the returns specified value returned.
	/// </summary>
	[Serializable]
	public class SetModifierFloat : SetModifier<float> {
		public SetModifierFloat (float value,int priority = 0) : base(value,priority) {
		}
	}

}