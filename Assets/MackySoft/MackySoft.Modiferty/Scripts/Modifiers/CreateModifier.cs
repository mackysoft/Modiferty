using System;

namespace MackySoft.Modiferty {
	public class CreateModifier<T> : IModifier<T> {

		public Func<T,T> ModifyMethod { get; set; }
		public int Priority { get; set; }

		public CreateModifier (Func<T,T> modifyMethod) {
			ModifyMethod = modifyMethod;
		}

		public T Evaluate (T value) {
			return ModifyMethod.Invoke(value);
		}

	}

}