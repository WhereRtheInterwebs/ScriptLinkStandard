﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptLinkStandard.Objects;
using System.Collections.Generic;

namespace ScriptLinkStandard.Test.EntitiesTests
{
    [TestClass]
    public class OptionObjectTests
    {
        private OptionObject configuredOptionObject;

        [TestInitialize]
        public void TestInitialize()
        {
            this.configuredOptionObject = new OptionObject();

            FieldObject addField = new FieldObject
            {
                FieldNumber = "123",
                FieldValue = "Value",
                Enabled = "1",
                Lock = "1",
                Required = "1"
            };
            RowObject addRow = new RowObject
            {
                RowId = "1||1"
            };
            addRow.Fields.Add(addField);
            FormObject addForm = new FormObject
            {
                FormId = "1",
                CurrentRow = addRow
            };
            configuredOptionObject.Forms.Add(addForm);

            FieldObject addMiField01 = new FieldObject
            {
                FieldNumber = "234",
                FieldValue = "MI Value"
            };
            FieldObject addMiField02 = new FieldObject
            {
                FieldNumber = "234",
                FieldValue = "MI Value 2"
            };
            RowObject addMiRow01 = new RowObject
            {
                RowId = "2||1"
            };
            addMiRow01.Fields.Add(addMiField01);
            RowObject addMiRow02 = new RowObject
            {
                RowId = "2||2"
            };
            addMiRow02.Fields.Add(addMiField01);
            FormObject addMiForm = new FormObject
            {
                FormId = "2",
                CurrentRow = addMiRow01,
                MultipleIteration = true
            };
            addMiForm.OtherRows.Add(addMiRow02);
            configuredOptionObject.Forms.Add(addMiForm);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_HasFormObject()
        {
            OptionObject optionObject = new OptionObject();
            Assert.IsNotNull(optionObject.Forms);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_Forms_IsNotEmpty()
        {
            OptionObject optionObject = new OptionObject();
            var expected = new List<FormObject>();
            var actual = optionObject.Forms;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_CanGetHtmlString_WithoutHtmlHeaders()
        {
            OptionObject optionObject = new OptionObject();
            var actual = optionObject.ToHtmlString(false);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_CanGetHtmlString_WithHtmlHeaders()
        {
            OptionObject optionObject = new OptionObject();
            var actual = optionObject.ToHtmlString(false);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_AddFormObject_FormObject()
        {
            FormObject formObject1 = new FormObject
            {
                FormId = "1",
                MultipleIteration = false
            };
            FormObject formObject2 = new FormObject
            {
                FormId = "2",
                MultipleIteration = true
            };
            OptionObject optionObject = new OptionObject();
            optionObject.AddFormObject(formObject1);
            Assert.AreEqual(1, optionObject.Forms.Count);
            optionObject.AddFormObject(formObject2);
            Assert.AreEqual(2, optionObject.Forms.Count);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        [ExpectedException(typeof(System.ArgumentException))]
        public void OptionObject_AddFormObject_FormObject_Exception()
        {
            FormObject formObject1 = new FormObject
            {
                FormId = "1",
                MultipleIteration = false
            };
            FormObject formObject2 = new FormObject
            {
                FormId = "2",
                MultipleIteration = true
            };
            OptionObject optionObject = new OptionObject();
            optionObject.AddFormObject(formObject1);
            Assert.AreEqual(1, optionObject.Forms.Count);
            optionObject.AddFormObject(formObject1);
            Assert.AreEqual(1, optionObject.Forms.Count);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_AddFormObject_Properties()
        {
            OptionObject optionObject = new OptionObject();
            optionObject.AddFormObject("1", false);
            Assert.AreEqual(1, optionObject.Forms.Count);
            optionObject.AddFormObject("2", true);
            Assert.AreEqual(2, optionObject.Forms.Count);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        [ExpectedException(typeof(System.ArgumentException))]
        public void OptionObject_AddFormObject_Properties_Exception()
        {
            OptionObject optionObject = new OptionObject();
            optionObject.AddFormObject("1", false);
            Assert.AreEqual(1, optionObject.Forms.Count);
            optionObject.AddFormObject("1", false);
            Assert.AreEqual(1, optionObject.Forms.Count);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetCurrentRowId_Null()
        {
            OptionObject optionObject = new OptionObject();
            var actual = optionObject.GetCurrentRowId("1");
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetCurrentRowId_AreEqual()
        {
            RowObject rowObject = new RowObject
            {
                RowId = "1||1"
            };
            FormObject formObject = new FormObject
            {
                FormId = "1",
                CurrentRow = rowObject
            };
            OptionObject optionObject = new OptionObject();
            optionObject.Forms.Add(formObject);
            var actual = optionObject.GetCurrentRowId("1");
            Assert.AreEqual("1||1", actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetFieldValue_AreEqual()
        {
            var expected = "Value";
            var actual = configuredOptionObject.GetFieldValue("123");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetFieldValue_AreNotEqual()
        {
            OptionObject optionObject = new OptionObject();
            var expected = "Value";
            var actual = optionObject.GetFieldValue("123");
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetFieldValue_MI_AreEqual()
        {
            var expected = "MI Value";
            var actual = configuredOptionObject.GetFieldValue("234");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetFieldValue_MI_AreNotEqual()
        {
            var expected = "Value";
            var actual = configuredOptionObject.GetFieldValue("456");
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetFieldValues_AreEqual()
        {
            var expected = "Value";
            var values = configuredOptionObject.GetFieldValues("123");
            var actual = values.Count > 0 ? values[0] : null;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetFieldValues_MI_AreEqual()
        {
            var expected = "MI Value";
            var values = configuredOptionObject.GetFieldValues("234");
            var actual = values.Count > 0 ? values[0] : null;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetFieldValues_AreNotEqual()
        {
            var expected = "Value";
            var values = configuredOptionObject.GetFieldValues("456");
            var actual = values.Count > 0 ? values[0] : null;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetMultipleIterationStatus_IsFalse()
        {
            OptionObject optionObject = new OptionObject();
            var actual = optionObject.GetMultipleIterationStatus("1");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetMultipleIterationStatus_IsTrue()
        {
            var actual = configuredOptionObject.GetMultipleIterationStatus("2");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetParentRowId_Null()
        {
            OptionObject optionObject = new OptionObject();
            var actual = optionObject.GetParentRowId("1");
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_GetParentRowId_AreEqual()
        {
            RowObject rowObject = new RowObject
            {
                ParentRowId = "1||1"
            };
            FormObject formObject = new FormObject
            {
                FormId = "1",
                CurrentRow = rowObject
            };
            OptionObject optionObject = new OptionObject();
            optionObject.Forms.Add(formObject);
            var actual = optionObject.GetParentRowId("1");
            Assert.AreEqual(rowObject.ParentRowId, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_IsFieldPresent_IsTrue()
        {
            var actual = configuredOptionObject.IsFieldPresent("123");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_IsFieldPresent_IsFalse()
        {
            var actual = configuredOptionObject.IsFieldPresent("456");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_IsFieldEnabled_IsTrue()
        {
            var actual = configuredOptionObject.IsFieldEnabled("123");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_IsFieldEnabled_IsFalse()
        {
            var actual = configuredOptionObject.IsFieldEnabled("456");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_SetDisabledFields_IsTrue()
        {
            List<string> requiredFields = new List<string> { "123" };
            configuredOptionObject.SetDisabledFields(requiredFields);
            var actual = configuredOptionObject.IsFieldEnabled("123");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_IsFieldLocked_IsTrue()
        {
            var actual = configuredOptionObject.IsFieldLocked("123");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_IsFieldLocked_IsFalse()
        {
            var actual = configuredOptionObject.IsFieldLocked("456");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_SetUnlockedFields_IsTrue()
        {
            List<string> requiredFields = new List<string> { "123" };
            configuredOptionObject.SetUnlockedFields(requiredFields);
            Assert.IsTrue(!configuredOptionObject.IsFieldLocked("123"));
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_SetLockedFields_IsTrue()
        {
            List<string> lockedFields = new List<string> { "123" };
            configuredOptionObject.SetLockedFields(lockedFields);
            Assert.IsTrue(configuredOptionObject.IsFieldLocked("123"));
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_IsFieldRequired_IsTrue()
        {
            var actual = configuredOptionObject.IsFieldRequired("123");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_IsFieldRequired_AreNotEqual()
        {
            var actual = configuredOptionObject.IsFieldRequired("456");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_SetOptionalFields_IsTrue()
        {
            List<string> optionalFields = new List<string> { "123" };
            configuredOptionObject.SetOptionalFields(optionalFields);
            Assert.IsTrue(configuredOptionObject.IsFieldEnabled("123"));
            Assert.IsFalse(configuredOptionObject.IsFieldRequired("123"));
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObject_SetRequiredFields_AreEqual()
        {
            List<string> requiredFields = new List<string> { "123" };
            configuredOptionObject.SetRequiredFields(requiredFields);
            Assert.IsTrue(configuredOptionObject.IsFieldEnabled("123"));
            Assert.IsTrue(configuredOptionObject.IsFieldRequired("123"));
        }
    }
}
