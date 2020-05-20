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

	}

}