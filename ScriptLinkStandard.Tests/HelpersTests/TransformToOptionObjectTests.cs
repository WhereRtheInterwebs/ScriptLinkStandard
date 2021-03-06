﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptLinkStandard.Helpers;
using ScriptLinkStandard.Objects;
using System;

namespace ScriptLinkStandard.Tests.HelpersTests
{
    [TestClass]
    public class TransformToOptionObjectTests
    {
        private OptionObject newOptionObject;

        [TestInitialize]
        public void TestInitialize()
        {
            this.newOptionObject = new OptionObject();
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void NewOptionObjectEntityIDEqualsTransformReturnEntityID()
        {
            OptionObject transformedOptionObject = newOptionObject.ToReturnOptionObject();
            Assert.AreEqual(newOptionObject.EntityID, transformedOptionObject.EntityID);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void NewOptionObjectEpisodeNumberEqualsTransformEpisodeNumber()
        {
            OptionObject2 transformedOptionObject = newOptionObject.ToOptionObject2();
            Assert.AreEqual(newOptionObject.EpisodeNumber, transformedOptionObject.EpisodeNumber);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void NewOptionObjectErrorCodeEqualsTransformErrorCode()
        {
            OptionObject2 transformedOptionObject = newOptionObject.ToOptionObject2();
            Assert.AreEqual(newOptionObject.ErrorCode, (int)transformedOptionObject.ErrorCode);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifiedOptionObjectInvalidValueErrorCodeTransform()
        {
            OptionObject modifiedOptionObject = new OptionObject
            {
                ErrorCode = 7
            };
            OptionObject2 transformedOptionObject = modifiedOptionObject.ToOptionObject2();
            Assert.AreEqual(modifiedOptionObject.ErrorCode, transformedOptionObject.ErrorCode);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void NewOptionObjectErrorMessageEqualsTransformErrorMessage()
        {
            OptionObject2 transformedOptionObject = newOptionObject.ToOptionObject2();
            Assert.AreEqual(newOptionObject.ErrorMesg, transformedOptionObject.ErrorMesg);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void NewOptionObjectFacilityEqualsTransformFacility()
        {
            OptionObject2 transformedOptionObject = newOptionObject.ToOptionObject2();
            Assert.AreEqual(newOptionObject.Facility, transformedOptionObject.Facility);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void NewOptionObjectOptionIdEqualsTransformOptionId()
        {
            OptionObject2 transformedOptionObject = newOptionObject.ToOptionObject2();
            Assert.AreEqual(newOptionObject.OptionId, transformedOptionObject.OptionId);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void NewOptionObjectStaffIdEqualsTransformStaffId()
        {
            OptionObject2 transformedOptionObject = newOptionObject.ToOptionObject2();
            Assert.AreEqual(newOptionObject.OptionStaffId, transformedOptionObject.OptionStaffId);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void NewOptionObjectUserIdEqualsTransformUserId()
        {
            OptionObject2 transformedOptionObject = newOptionObject.ToOptionObject2();
            Assert.AreEqual(newOptionObject.OptionUserId, transformedOptionObject.OptionUserId);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void NewOptionObjectSystemCodeEqualsTransformSystemCode()
        {
            OptionObject2 transformedOptionObject = newOptionObject.ToOptionObject2();
            Assert.AreEqual(newOptionObject.SystemCode, transformedOptionObject.SystemCode);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void NewOptionObjectFormCountEqualsTransformFormCount()
        {
            OptionObject2 transformedOptionObject = newOptionObject.ToOptionObject2();
            Assert.AreEqual(newOptionObject.Forms.Count, transformedOptionObject.Forms.Count);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void ModifiedOptionObjectFormCountEqualsTransformFormCount()
        {
            OptionObject modifiedOptionObject = new OptionObject();
            FormObject addForm = new FormObject();
            modifiedOptionObject.Forms.Add(addForm);
            OptionObject2 transformedOptionObject = modifiedOptionObject.ToOptionObject2();
            Assert.AreEqual(modifiedOptionObject.Forms.Count, transformedOptionObject.Forms.Count);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObjectFromJsonSuccess()
        {
            string json = "{\"EntityID\":1,\"EpisodeNumber\":0.0,\"ErrorCode\":0.0,\"ErrorMesg\":null,\"Facility\":null,\"Forms\":[],\"NamespaceName\":null,\"OptionId\":null,\"OptionStaffId\":null,\"OptionUserId\":null,\"ParentNamespace\":null,\"ServerName\":null,\"SystemCode\":null,\"SessionToken\":null}";
            OptionObject expected = new OptionObject
            {
                EntityID = "1"
            };
            OptionObject actual = (OptionObject)ScriptLinkHelpers.TransformToOptionObject(json);
            Assert.IsNotNull(actual.EntityID);
            Assert.AreEqual(expected.EntityID, actual.EntityID);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObjectFromJsonFailure()
        {
            string json = "{\"EntityID\":2,\"EpisodeNumber\":0.0,\"ErrorCode\":0.0,\"ErrorMesg\":null,\"Facility\":null,\"Forms\":[],\"NamespaceName\":null,\"OptionId\":null,\"OptionStaffId\":null,\"OptionUserId\":null,\"ParentNamespace\":null,\"ServerName\":null,\"SystemCode\":null,\"SessionToken\":null}";
            OptionObject expected = new OptionObject
            {
                EntityID = "1"
            };
            OptionObject actual = (OptionObject)ScriptLinkHelpers.TransformToOptionObject(json);
            Assert.IsNotNull(actual.EntityID);
            Assert.AreNotEqual(expected.EntityID, actual.EntityID);
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObjectFromXmlSuccess()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" + Environment.NewLine
                            + "<OptionObject xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" + Environment.NewLine
                            + "  <EntityID>1</EntityID>" + Environment.NewLine
                            + "  <EpisodeNumber>0</EpisodeNumber>" + Environment.NewLine
                            + "  <ErrorCode>0</ErrorCode>" + Environment.NewLine
                            + "  <Forms />" + Environment.NewLine
                            + "</OptionObject>";
            OptionObject expected = new OptionObject
            {
                EntityID = "1"
            };
            OptionObject actual = (OptionObject)ScriptLinkHelpers.TransformToOptionObject(xml);
            Assert.IsNotNull(actual.EntityID);
            Assert.AreEqual(expected.EntityID, actual.EntityID);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("OptionObject")]
        public void OptionObjectFromXmlFailure()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" + Environment.NewLine
                            + "<OptionObject xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" + Environment.NewLine
                            + "  <EntityID>2</EntityID>" + Environment.NewLine
                            + "  <EpisodeNumber>0</EpisodeNumber>" + Environment.NewLine
                            + "  <ErrorCode>0</ErrorCode>" + Environment.NewLine
                            + "  <Forms />" + Environment.NewLine
                            + "</OptionObject>";
            OptionObject expected = new OptionObject
            {
                EntityID = "1"
            };
            OptionObject actual = (OptionObject)ScriptLinkHelpers.TransformToOptionObject(xml);
            Assert.IsNotNull(actual.EntityID);
            Assert.AreNotEqual(expected.EntityID, actual.EntityID);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
