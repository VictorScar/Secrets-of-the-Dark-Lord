using SODL.Utils;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(OneLineAttribute))]
public class OneLineDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (Event.current.type == EventType.Layout) return;

        EditorGUI.BeginProperty(position, label, property);

        // init
        List<SerializedProperty> props = new List<SerializedProperty>();
        var e = property.GetEnumerator();

        while (e.MoveNext())
        {
            var p = e.Current as SerializedProperty;
            props.Add(p.Copy());
        }

        // set sizes
        Rect indentedRect = EditorGUI.IndentedRect(position);
        var i = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        if (props.Count > 0)
            indentedRect.width /= props.Count;

        // create fields
        foreach (var prop in props)
        {
            EditorGUI.PropertyField(indentedRect, prop, GUIContent.none);
            indentedRect.x += indentedRect.width;
        }

        EditorGUI.indentLevel = i;
        EditorGUI.EndProperty();
    }

    int GetChildsCount(SerializedProperty property)
    {
        var e = property.GetEnumerator();
        int count = 0;
        while (e.MoveNext())
        {
            count++;
        }
        return count;
    }
}
