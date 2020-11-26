using UnityEngine;

namespace MackySoft.Modiferty {

	public enum RoundingMethod {
		Round = 0,
		Floor = 1,
		Ceil = 2
	}

	public static class RoundUtility {

		public static float Round (this float f,RoundingMethod method) {
			if (method == RoundingMethod.Round) {
				return Mathf.Round(f);
			} else if (method == RoundingMethod.Floor) {
				return Mathf.Floor(f);
			} else {
				return Mathf.Ceil(f);
			}
		}

		public static int RoundToInt (this float f,RoundingMethod method) {
			return (int)Round(f,method);
		}

	}

}