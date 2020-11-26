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

		public static IDisposable AddModifierAsDisposable<T> (this ICollection<IModifier<T>> source,IModifier<T> modifier) {
			if (source == null) {
				throw new ArgumentNullException(nameof(source));
			}
			if (modifier == null) {
				throw new ArgumentNullException(nameof(modifier));
			}

			source.Add(modifier);
			return new ModifierDisposable<T>(source,modifier);
		}

		/// <summary>
		/// Remove all modifiers that match the specified type.
		/// </summary>
		/// <typeparam name="TModifier"> Type of Modifier to be removed. </typeparam>
		public static int RemoveModifiersAll<TModifier> (this ICollection<IModifier> source) where TModifier : IModifier {
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
		public static int RemoveModifiersAll<T> (this ICollection<IModifier<T>> source,Predicate<IModifier<T>> match) {
			if (match == null) {
				throw new ArgumentNullException(nameof(match));
			}
			int removedModifiersCount = 0;
			foreach (IModifier<T> modifier in source.ToArray()) {
				if (match.Invoke(modifier)) {
					source.Remove(modifier);
					removedModifiersCount++;
				}
			}
			return removedModifiersCount;
		}

		class ModifierDisposable<T> : IDisposable {

			bool m_IsDisposed;
			IModifier<T> m_Modifier;
			ICollection<IModifier<T>> m_Collection;

			public ModifierDisposable (ICollection<IModifier<T>> collection,IModifier<T> modifier) {
				m_Modifier = modifier;
				m_Collection = collection;
			}

			public void Dispose () {
				if (!m_IsDisposed) {
					m_IsDisposed = true;
					m_Collection.Remove(m_Modifier);

					m_Collection = null;
					m_Modifier = null;
				}
			}
		}

	}

}