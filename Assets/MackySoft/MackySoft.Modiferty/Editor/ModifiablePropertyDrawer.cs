using UnityEngine;
using UnityEditor;
using MackySoft.Modiferty.Modifiers;

namespace MackySoft.Modiferty {

	[CustomPropertyDrawer(typeof(ModifieableProperty<>),true)]
	public class ModifiablePropertyDrawer : PropertyDrawer {
		public override void OnGUI (Rect position,SerializedProperty property,GUIContent label) {
			var baseValue = property.FindPropertyRelative("m_BaseValue");
			EditorGUI.PropertyField(position,baseValue,label);
		}
	}

	[CustomPropertyDrawer(typeof(OperatorModifierBase<,>),true)]
	public class RoundingModifierDrawer : PropertyDrawer {

		static readonly float k_PropertyHeight = EditorGUIUtility.singleLineHeight * 2f + EditorGUIUtility.standardVerticalSpacing;

		public override void OnGUI (Rect position,SerializedProperty property,GUIContent label) {
			EditorGUI.BeginProperty(position,label,property);

			var baseValue = property.FindPropertyRelative("m_BaseValue");
			var roundingMethod = property.FindPropertyRelative("m_RoundingMethod");
			float roundingMethodWidth = (roundingMethod != null) ? (position.width - EditorGUIUtility.labelWidth) * 0.5f : 0f;

			var baseValuePosition = new Rect(position.x,position.y,position.width - roundingMethodWidth,EditorGUIUtility.singleLineHeight);
			EditorGUI.PropertyField(baseValuePosition,baseValue,label);

			if (roundingMethod != null) {
				var roundingMethodPosition = new Rect(baseValuePosition.xMax,position.y,roundingMethodWidth,baseValuePosition.height);
				EditorGUI.PropertyField(roundingMethodPosition,roundingMethod,GUIContent.none);
			}

			var priority = property.FindPropertyRelative("m_Priority");
			EditorGUI.indentLevel++;
			var priorityPosition = EditorGUI.IndentedRect(position);
			priorityPosition.height = EditorGUIUtility.singleLineHeight;
			priorityPosition.y += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
			EditorGUI.indentLevel--;
			EditorGUI.PropertyField(priorityPosition,priority);

			EditorGUI.EndProperty();		
		}

		public override float GetPropertyHeight (SerializedProperty property,GUIContent label) {
			return k_PropertyHeight;
		}

	}

	[CustomPropertyDrawer(typeof(OperatorModifierInt))]
	public class OperatorModifierDrawer : PropertyDrawer {

		static readonly float k_PropertyHeight = EditorGUIUtility.singleLineHeight * 3f + EditorGUIUtility.standardVerticalSpacing;

		public override void OnGUI (Rect position,SerializedProperty property,GUIContent label) {
			EditorGUI.BeginProperty(position,label,property);

			position.height = EditorGUIUtility.singleLineHeight;

			var type = property.FindPropertyRelative("m_Type");
			EditorGUI.PropertyField(position,type,label);

			var baseValue = property.FindPropertyRelative("m_BaseValue");
			var roundingMethod = property.FindPropertyRelative("m_RoundingMethod");
			float roundingMethodWidth = (roundingMethod != null) ? (position.width - EditorGUIUtility.labelWidth) * 0.5f : 0f;

			EditorGUI.indentLevel++;
			var baseValuePosition = EditorGUI.IndentedRect(position);
			baseValuePosition.width = baseValuePosition.width - roundingMethodWidth;
			baseValuePosition.height = EditorGUIUtility.singleLineHeight;
			baseValuePosition.y += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
			EditorGUI.indentLevel--;

			EditorGUI.PropertyField(baseValuePosition,baseValue);

			if (roundingMethod != null) {
				var roundingMethodPosition = new Rect(baseValuePosition.xMax,baseValuePosition.y,roundingMethodWidth,baseValuePosition.height);
				EditorGUI.PropertyField(roundingMethodPosition,roundingMethod,GUIContent.none);
			}

			var priority = property.FindPropertyRelative("m_Priority");
			var priorityPosition = baseValuePosition;
			priorityPosition.width += roundingMethodWidth;
			priorityPosition.y += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
			EditorGUI.PropertyField(priorityPosition,priority);

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight (SerializedProperty property,GUIContent label) {
			return k_PropertyHeight;
		}

	}
}