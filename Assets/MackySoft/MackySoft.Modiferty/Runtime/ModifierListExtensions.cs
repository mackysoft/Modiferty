using System;
using System.Linq;
using System.Collections.Generic;

namespace MackySoft.Modiferty {
	public static class ModifierListExtensions {

		public static bool HasModifier<TModifier> (this IEnumerable<IModifier> source) where TModifier : IModifier {
			foreach (IModifier modifier in source) {
				if (modifier is TModifier) {
					return true;
				}
			}
			return false;
		}

		public static TModifier GetModifier<TModifier> (this IEnumerable<IModifier> source) where TModifier : IModifier {
			foreach (IModifier modifier in source) {
				if (modifier is TModifier result) {
					return result;
				}
			}
			return default;
		}

		public static IEnumerable<TModifier> GetModifiers<TModifier> (this IEnumerable<IModifier> source) where TModifier : IModifier {
			foreach (IModifier modifier in source) {
				if (modifier is TModifier result) {
					yield return result;
				}
			}
		}

		public static bool TryGetModifier<TModifier> (this IEnumerable<IModifier> source,out TModifier result) where TModifier : IModifier {
			result = source.GetModifier<TModifier>();
			return result != null;
		}

		/// <summary>
		/// Remove all modifiers that match the specified type.
		/// </summary>
		/// <typeparam name="TModifier"> Type of Modifier to be removed. </typeparam>
		public static int RemoveAll<TModifier> (this ICollection<IModifier> source) where TModifier : IModifier {
			int removedModifiersCount = 0;
			foreach (IModifier modifier in source.ToArray()) {
				if (modifier is TModifier result) {
					source.Remove(result);
					removedModifiersCount++;
				}
			}
			return removedModifiersCount;
		}

		/// <summary>
		/// Remove all modifiers that match the condition.
		/// </summary>
		public static int RemoveAll (this ICollection<IModifier> source,Predicate<IModifier> match) {
			if (match == null) {
				throw new ArgumentNullException(nameof(match));
			}
			int removedModifiersCount = 0;
			foreach (IModifier modifier in source.ToArray()) {
				if (match.Invoke(modifier)) {
					source.Remove(modifier);
					removedModifiersCount++;
				}
			}
			return removedModifiersCount;
		}

	}

}