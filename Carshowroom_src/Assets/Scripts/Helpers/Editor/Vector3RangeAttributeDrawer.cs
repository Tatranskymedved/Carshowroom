using UnityEngine;
using UnityEditor;

/* Copied from https://gist.github.com/DGoodayle/69c9c06eb0a277d833c5 , updated for Vector3

Vector Range Attribute by Just a Pixel (Danny Goodayle @DGoodayle) - http://www.justapixel.co.uk
Copyright (c) 2015
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
USAGE
[VectorRange(minX, maxX, minY, maxY, clamped)]
public Vector2 yourVector;
*/


[CustomPropertyDrawer(typeof(Vector3RangeAttribute))]
public class Vector3RangeAttributeDrawer : PropertyDrawer
{
    const int helpHeight = 30;
    const int textHeight = 16;
    Vector3RangeAttribute rangeAttribute { get { return (Vector3RangeAttribute)attribute; } }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Color previous = GUI.color;
        GUI.color = !IsValid(property) ? Color.red : Color.white;
        Rect textFieldPosition = position;
        textFieldPosition.width = position.width;
        textFieldPosition.height = position.height;
        EditorGUI.BeginChangeCheck();
        Vector3 val = EditorGUI.Vector3Field(textFieldPosition, label, property.vector3Value);
        if (EditorGUI.EndChangeCheck())
        {
            if (rangeAttribute.bClamp)
            {
                val.x = Mathf.Clamp(val.x, rangeAttribute.fMinX, rangeAttribute.fMaxX);
                val.y = Mathf.Clamp(val.y, rangeAttribute.fMinY, rangeAttribute.fMaxY);
                val.z = Mathf.Clamp(val.z, rangeAttribute.fMinZ, rangeAttribute.fMaxZ);
            }
            property.vector3Value = val;
        }
        Rect helpPosition = position;
        helpPosition.y += 16;
        helpPosition.height = 16;
        DrawHelpBox(helpPosition, property);
        GUI.color = previous;
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (!IsValid(property))
        {
            return 32;
        }
        return base.GetPropertyHeight(property, label);
    }
    void DrawHelpBox(Rect position, SerializedProperty prop)
    {
        // No need for a help box if the pattern is valid.
        if (IsValid(prop))
            return;

        EditorGUI.HelpBox(position, string.Format("Invalid Range X [{0}]-[{1}] Y [{2}]-[{3}] Z [{4}]-[{5}]",
            rangeAttribute.fMinX, rangeAttribute.fMaxX, rangeAttribute.fMinY, rangeAttribute.fMaxY, rangeAttribute.fMinZ, rangeAttribute.fMaxZ), MessageType.Error);
    }
    bool IsValid(SerializedProperty prop)
    {
        Vector3 vector = prop.vector3Value;
        return vector.x >= rangeAttribute.fMinX && vector.x <= rangeAttribute.fMaxX
            && vector.y >= rangeAttribute.fMinY && vector.y <= rangeAttribute.fMaxY
            && vector.z >= rangeAttribute.fMinZ && vector.z <= rangeAttribute.fMaxZ;
    }
}
