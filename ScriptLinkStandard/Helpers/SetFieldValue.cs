﻿using ScriptLinkStandard.Interfaces;
using ScriptLinkStandard.Objects;

namespace ScriptLinkStandard.Helpers
{
    public partial class ScriptLinkHelpers
    {
        public static OptionObject SetFieldValue(IOptionObject optionObject, string fieldNumber, string fieldValue)
        {
            if (optionObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "optionObject");
            if (fieldNumber == null || fieldNumber == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "fieldNumber");
            return SetFieldValue(optionObject.ToOptionObject2015(), fieldNumber, fieldValue).ToOptionObject(); ;
        }

        public static OptionObject SetFieldValue(IOptionObject optionObject, string formId, string rowId, string fieldNumber, string fieldValue)
        {
            if (optionObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "optionObject");
            if (formId == null || formId == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "formId");
            if (rowId == null || rowId == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "rowId");
            if (fieldNumber == null || fieldNumber == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "fieldNumber");
            return SetFieldValue(optionObject.ToOptionObject2015(), formId, rowId, fieldNumber, fieldValue).ToOptionObject();
        }
        public static OptionObject2 SetFieldValue(IOptionObject2 optionObject, string fieldNumber, string fieldValue)
        {
            if (optionObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "optionObject");
            if (fieldNumber == null || fieldNumber == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "fieldNumber");
            return SetFieldValue(optionObject.ToOptionObject2015(), fieldNumber, fieldValue).ToOptionObject2(); ;
        }

        public static OptionObject2 SetFieldValue(IOptionObject2 optionObject, string formId, string rowId, string fieldNumber, string fieldValue)
        {
            if (optionObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "optionObject");
            if (formId == null || formId == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "formId");
            if (rowId == null || rowId == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "rowId");
            if (fieldNumber == null || fieldNumber == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "fieldNumber");
            return SetFieldValue(optionObject.ToOptionObject2015(), formId, rowId, fieldNumber, fieldValue).ToOptionObject2();
        }

        public static OptionObject2015 SetFieldValue(IOptionObject2015 optionObject, string fieldNumber, string fieldValue)
        {
            if (optionObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "optionObject");
            if (optionObject.Forms == null)
                throw new System.ArgumentException("There are no FormObjects in the OptionObject.", "optionObject");
            if (fieldNumber == null || fieldNumber == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "fieldNumber");
            foreach (FormObject formObject in optionObject.Forms)
            {
                if (formObject.IsFieldPresent(fieldNumber))
                {
                    if (formObject.MultipleIteration && formObject.OtherRows.Count > 0)
                        throw new System.ArgumentException("Unable to determine which FieldObject to update. Please specify the FormId and RowId associated with the intended FieldObject.", "optionObject");

                    string formId = formObject.FormId;
                    string rowId = formObject.GetCurrentRowId();
                    return SetFieldValue(optionObject, formId, rowId, fieldNumber, fieldValue);
                }
            }
            throw new System.ArgumentException("The specified FieldObject was not found in this OptionObject.", "optionObject");
        }

        public static OptionObject2015 SetFieldValue(IOptionObject2015 optionObject, string formId, string rowId, string fieldNumber, string fieldValue)
        {
            if (optionObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "optionObject");
            if (formId == null || formId == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "formId");
            if (rowId == null || rowId == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "rowId");
            if (fieldNumber == null || fieldNumber == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "fieldNumber");
            if (optionObject.Forms == null)
                throw new System.ArgumentException("There are no FormObjects in the provided OptionObject.", "optionObject");
            for (int i = 0; i < optionObject.Forms.Count; i++)
            {
                if (optionObject.Forms[i].FormId == formId)
                    optionObject.Forms[i] = SetFieldValue(optionObject.Forms[i], rowId, fieldNumber, fieldValue);
            }
            return (OptionObject2015)optionObject;
        }

        public static FormObject SetFieldValue(IFormObject formObject, string fieldNumber, string fieldValue)
        {
            if (formObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "formObject");
            if (formObject.CurrentRow == null)
                throw new System.ArgumentException("The FormObject has no CurrentRow.", "formObject");
            if (fieldNumber == null || fieldNumber == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "fieldNumber");
            if (formObject.MultipleIteration && formObject.OtherRows.Count > 0)
                throw new System.ArgumentException("Unable to determine which FieldObject to update. Please specify the FormId and RowId associated with the intended FieldObject.", "optionObject");
            return SetFieldValue(formObject, formObject.CurrentRow.RowId, fieldNumber, fieldValue);
        }

        public static FormObject SetFieldValue(IFormObject formObject, string rowId, string fieldNumber, string fieldValue)
        {
            if (formObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "formObject");
            if (formObject.CurrentRow == null)
                throw new System.ArgumentException("The FormObject does not have a CurrentRow.", "formObject");
            if (rowId == null || rowId == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "rowId");
            if (fieldNumber == null || fieldNumber == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "fieldNumber");
            if (formObject.CurrentRow.RowId == rowId)
            {
                formObject.CurrentRow = SetFieldValue(formObject.CurrentRow, fieldNumber, fieldValue);
                return (FormObject)formObject;
            }
            if (formObject.MultipleIteration)
            {
                for (int i = 0; i < formObject.OtherRows.Count; i++)
                {
                    if (formObject.OtherRows[i].RowId == rowId)
                    {
                        formObject.OtherRows[i] = SetFieldValue(formObject.OtherRows[i], fieldNumber, fieldValue);
                        return (FormObject)formObject;
                    }
                }
            }
            throw new System.ArgumentException("The specified FieldObject was not found in this FormObject.", "formObject");
        }

        public static RowObject SetFieldValue(IRowObject rowObject, string fieldNumber, string fieldValue)
        {
            if (rowObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "rowObject");
            if (fieldNumber == null || fieldNumber == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "fieldNumber");
            for (int i = 0; i < rowObject.Fields.Count; i++)
            {
                if (rowObject.Fields[i].FieldNumber == fieldNumber)
                {
                    rowObject.Fields[i] = SetFieldValue(rowObject.Fields[i], fieldValue);
                    rowObject.RowAction = "EDIT";
                    break;
                }
            }
            return (RowObject)rowObject;
        }

        public static FieldObject SetFieldValue(IFieldObject fieldObject, string fieldValue)
        {
            if (fieldObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "fieldObject");
            fieldObject.FieldValue = fieldValue;
            fieldObject.SetAsModified();
            return (FieldObject)fieldObject;
        }
    }
}
