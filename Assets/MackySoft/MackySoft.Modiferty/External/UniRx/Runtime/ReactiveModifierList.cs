using System;
using System.Linq;
using System.Collections.Generic;
using UniRx;

namespace MackySoft.Modiferty {

	public interface IReadOnlyReactiveModifierList<T> : IReadOnlyModifierList<T>, IReadOnlyReactiveCollection<IModifier<T>> {
		
	}

	public interface IReactiveModifierList<T> : IReadOnlyReactiveModifierList<T>, IModifierList<T>, IReactiveCollection<IModifier<T>> {

	}

	[Serializable]
	public class ReactiveModifierList<T> : ReactiveCollection<IModifier<T>>, IReactiveModifierList<T> {

		public ReactiveModifierList () {
		}

		public ReactiveModifierList (IEnumerable<IModifier<T>> collection) : base(collection) {
		}

		public ReactiveModifierList (List<IModifier<T>> list) : base(list) {
		}

		public T Evaluate (T value) {
			if (Count > 0) {
				foreach (var modifier in Items.OrderByDescending(m => m.Priority)) {
					value = modifier.Evaluate(value);
				}
			}
			return value;
		}

	}

	public static class ReactiveModifierListExtensions {

		/// <summary>
		/// Notify ModifierList change.
		/// </summary>
		public static IObservable<IReadOnlyReactiveModifierList<T>> ObserveChanged<T> (this IReadOnlyReactiveModifierList<T> source) {
			if (source == null) {
				throw new ArgumentNullException(nameof(source));
			}
			return Observable.Merge(
				source.ObserveCountChanged().AsUnitObservable(),
				source.ObserveReplace().AsUnitObservable(),
				source.ObserveMove().AsUnitObservable()
			).Select(_ => source);
		}

	}

}