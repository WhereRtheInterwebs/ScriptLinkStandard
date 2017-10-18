﻿using ScriptLinkStandard.Interfaces;

namespace ScriptLinkStandard.Helpers
{
    public partial class ScriptLinkHelpers
    {
        public static bool GetMultipleIterationStatus(IOptionObject optionObject, string formId)
        {
            if (optionObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "optionObject");
            return GetMultipleIterationStatus(optionObject.ToOptionObject2015(), formId);
        }
        public static bool GetMultipleIterationStatus(IOptionObject2 optionObject, string formId)
        {
            if (optionObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "optionObject");
            return GetMultipleIterationStatus(optionObject.ToOptionObject2015(), formId);
        }
        public static bool GetMultipleIterationStatus(IOptionObject2015 optionObject, string formId)
        {
            if (optionObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "optionObject");
            if (formId == null || formId == "")
                throw new System.ArgumentException("Parameter cannot be null or blank.", "formId");
            if (optionObject.Forms == null)
                throw new System.ArgumentException("The OptionObject does not contain any Forms.");
            foreach (var formObject in optionObject.Forms)
            {
                if (formObject.FormId == formId)
                {
                    return GetMultipleIterationStatus(formObject);
                }
            }
            throw new System.ArgumentException("The FormObject with FormId " + formId + " does not exist in this OptionObject.");
        }
        public static bool GetMultipleIterationStatus(IFormObject formObject)
        {
            if (formObject == null)
                throw new System.ArgumentException("Parameter cannot be null.", "rowObject");
            return formObject.MultipleIteration;
        }
    }
}
