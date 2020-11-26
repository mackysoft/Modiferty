using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MackySoft.Modiferty {

	[CustomPropertyDrawer(typeof(ModifieableProperty<>),true)]
	[CustomPropertyDrawer(typeof(ModifiableInt))]
	public class ModifiablePropertyDrawer : PropertyDrawer {
		public override void OnGUI (Rect position,SerializedProperty property,GUIContent label) {
			var baseValue = property.FindPropertyRelative("m_BaseValue");
			EditorGUI.PropertyField(position,baseValue,label);
		}
	}
}