using System;
using System.Xml.Linq;
using Ave.Extensions.Assertions.Xml;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.Extensions.Assertions.Xml
{
    public class XmlAssertionsTests
    {
        #region XDocumentAssertions

        #region Be / NotBe

        [Fact(DisplayName = "XML-001: XDocument.Be succeeds when documents are equal")]
        public void XML001()
        {
            // Arrange
            var doc1 = new XDocument(new XElement("root"));
            var doc2 = doc1;

            // Act
            Result<XDocument?, Error> result = doc1.Should().Be(doc2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-002: XDocument.Be fails when documents are not equal")]
        public void XML002()
        {
            // Arrange
            var doc1 = new XDocument(new XElement("root"));
            var doc2 = new XDocument(new XElement("other"));

            // Act
            Result<XDocument?, Error> result = doc1.Should().Be(doc2);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "XML-003: XDocument.NotBe succeeds when documents are not equal")]
        public void XML003()
        {
            // Arrange
            var doc1 = new XDocument(new XElement("root"));
            var doc2 = new XDocument(new XElement("other"));

            // Act
            Result<XDocument?, Error> result = doc1.Should().NotBe(doc2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-004: XDocument.NotBe fails when documents are equal")]
        public void XML004()
        {
            // Arrange
            var doc = new XDocument(new XElement("root"));

            // Act
            Result<XDocument?, Error> result = doc.Should().NotBe(doc);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.NotBe, result.Error.Code);
        }

        #endregion

        #region BeEquivalentTo / NotBeEquivalentTo

        [Fact(DisplayName = "XML-005: XDocument.BeEquivalentTo succeeds when documents are equivalent")]
        public void XML005()
        {
            // Arrange
            var doc1 = XDocument.Parse("<root><child /></root>");
            var doc2 = XDocument.Parse("<root><child /></root>");

            // Act
            Result<XDocument?, Error> result = doc1.Should().BeEquivalentTo(doc2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-006: XDocument.BeEquivalentTo fails when documents are not equivalent")]
        public void XML006()
        {
            // Arrange
            var doc1 = XDocument.Parse("<root><child /></root>");
            var doc2 = XDocument.Parse("<root><other /></root>");

            // Act
            Result<XDocument?, Error> result = doc1.Should().BeEquivalentTo(doc2);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.BeEquivalentTo, result.Error.Code);
        }

        [Fact(DisplayName = "XML-007: XDocument.NotBeEquivalentTo succeeds when documents are not equivalent")]
        public void XML007()
        {
            // Arrange
            var doc1 = XDocument.Parse("<root><child /></root>");
            var doc2 = XDocument.Parse("<root><other /></root>");

            // Act
            Result<XDocument?, Error> result = doc1.Should().NotBeEquivalentTo(doc2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region HaveRoot

        [Fact(DisplayName = "XML-008: XDocument.HaveRoot succeeds when root name matches")]
        public void XML008()
        {
            // Arrange
            var doc = XDocument.Parse("<root />");

            // Act
            Result<XDocument?, Error> result = doc.Should().HaveRoot("root");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-009: XDocument.HaveRoot fails when root name does not match")]
        public void XML009()
        {
            // Arrange
            var doc = XDocument.Parse("<root />");

            // Act
            Result<XDocument?, Error> result = doc.Should().HaveRoot("other");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.HaveRoot, result.Error.Code);
        }

        [Fact(DisplayName = "XML-010: XDocument.HaveRoot with XName succeeds")]
        public void XML010()
        {
            // Arrange
            var doc = XDocument.Parse("<root xmlns='http://example.com' />");

            // Act
            Result<XDocument?, Error> result = doc.Should().HaveRoot(XName.Get("root", "http://example.com"));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-011: XDocument.HaveRoot throws when expected is null")]
        public void XML011()
        {
            // Arrange
            var doc = XDocument.Parse("<root />");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => doc.Should().HaveRoot((string)null!));
        }

        #endregion

        #region HaveElement

        [Fact(DisplayName = "XML-012: XDocument.HaveElement succeeds when element exists")]
        public void XML012()
        {
            // Arrange
            var doc = XDocument.Parse("<root><child /></root>");

            // Act
            Result<XDocument?, Error> result = doc.Should().HaveElement("child");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-013: XDocument.HaveElement fails when element does not exist")]
        public void XML013()
        {
            // Arrange
            var doc = XDocument.Parse("<root><child /></root>");

            // Act
            Result<XDocument?, Error> result = doc.Should().HaveElement("other");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.HaveElement, result.Error.Code);
        }

        #endregion

        #endregion

        #region XElementAssertions

        #region Be / NotBe

        [Fact(DisplayName = "XML-014: XElement.Be succeeds when elements are equal")]
        public void XML014()
        {
            // Arrange
            var elem1 = XElement.Parse("<item>value</item>");
            var elem2 = XElement.Parse("<item>value</item>");

            // Act
            Result<XElement?, Error> result = elem1.Should().Be(elem2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-015: XElement.Be fails when elements are not equal")]
        public void XML015()
        {
            // Arrange
            var elem1 = XElement.Parse("<item>value1</item>");
            var elem2 = XElement.Parse("<item>value2</item>");

            // Act
            Result<XElement?, Error> result = elem1.Should().Be(elem2);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "XML-016: XElement.NotBe succeeds when elements are not equal")]
        public void XML016()
        {
            // Arrange
            var elem1 = XElement.Parse("<item>value1</item>");
            var elem2 = XElement.Parse("<item>value2</item>");

            // Act
            Result<XElement?, Error> result = elem1.Should().NotBe(elem2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region BeEquivalentTo / NotBeEquivalentTo

        [Fact(DisplayName = "XML-017: XElement.BeEquivalentTo succeeds when elements are equivalent")]
        public void XML017()
        {
            // Arrange
            var elem1 = XElement.Parse("<item attr='val'>content</item>");
            var elem2 = XElement.Parse("<item attr='val'>content</item>");

            // Act
            Result<XElement?, Error> result = elem1.Should().BeEquivalentTo(elem2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-018: XElement.NotBeEquivalentTo succeeds when elements are not equivalent")]
        public void XML018()
        {
            // Arrange
            var elem1 = XElement.Parse("<item attr='val1'>content</item>");
            var elem2 = XElement.Parse("<item attr='val2'>content</item>");

            // Act
            Result<XElement?, Error> result = elem1.Should().NotBeEquivalentTo(elem2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region HaveValue

        [Fact(DisplayName = "XML-019: XElement.HaveValue succeeds when value matches")]
        public void XML019()
        {
            // Arrange
            var elem = XElement.Parse("<item>expected value</item>");

            // Act
            Result<XElement?, Error> result = elem.Should().HaveValue("expected value");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-020: XElement.HaveValue fails when value does not match")]
        public void XML020()
        {
            // Arrange
            var elem = XElement.Parse("<item>actual value</item>");

            // Act
            Result<XElement?, Error> result = elem.Should().HaveValue("expected value");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.HaveValue, result.Error.Code);
        }

        #endregion

        #region HaveAttribute

        [Fact(DisplayName = "XML-021: XElement.HaveAttribute succeeds when attribute exists with value")]
        public void XML021()
        {
            // Arrange
            var elem = XElement.Parse("<item name='test' />");

            // Act
            Result<XElement?, Error> result = elem.Should().HaveAttribute("name", "test");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-022: XElement.HaveAttribute fails when attribute does not exist")]
        public void XML022()
        {
            // Arrange
            var elem = XElement.Parse("<item />");

            // Act
            Result<XElement?, Error> result = elem.Should().HaveAttribute("name", "test");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.HaveAttribute, result.Error.Code);
        }

        [Fact(DisplayName = "XML-023: XElement.HaveAttribute fails when attribute value does not match")]
        public void XML023()
        {
            // Arrange
            var elem = XElement.Parse("<item name='other' />");

            // Act
            Result<XElement?, Error> result = elem.Should().HaveAttribute("name", "test");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.HaveAttribute, result.Error.Code);
        }

        #endregion

        #region HaveElement

        [Fact(DisplayName = "XML-024: XElement.HaveElement succeeds when child element exists")]
        public void XML024()
        {
            // Arrange
            var elem = XElement.Parse("<parent><child /></parent>");

            // Act
            Result<XElement?, Error> result = elem.Should().HaveElement("child");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-025: XElement.HaveElement fails when child element does not exist")]
        public void XML025()
        {
            // Arrange
            var elem = XElement.Parse("<parent />");

            // Act
            Result<XElement?, Error> result = elem.Should().HaveElement("child");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.HaveElement, result.Error.Code);
        }

        #endregion

        #endregion

        #region XAttributeAssertions

        #region Be / NotBe

        [Fact(DisplayName = "XML-026: XAttribute.Be succeeds when attributes are equal")]
        public void XML026()
        {
            // Arrange
            var attr1 = new XAttribute("name", "value");
            var attr2 = new XAttribute("name", "value");

            // Act
            Result<XAttribute?, Error> result = attr1.Should().Be(attr2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-027: XAttribute.Be fails when attributes have different names")]
        public void XML027()
        {
            // Arrange
            var attr1 = new XAttribute("name1", "value");
            var attr2 = new XAttribute("name2", "value");

            // Act
            Result<XAttribute?, Error> result = attr1.Should().Be(attr2);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "XML-028: XAttribute.Be fails when attributes have different values")]
        public void XML028()
        {
            // Arrange
            var attr1 = new XAttribute("name", "value1");
            var attr2 = new XAttribute("name", "value2");

            // Act
            Result<XAttribute?, Error> result = attr1.Should().Be(attr2);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "XML-029: XAttribute.NotBe succeeds when attributes are not equal")]
        public void XML029()
        {
            // Arrange
            var attr1 = new XAttribute("name", "value1");
            var attr2 = new XAttribute("name", "value2");

            // Act
            Result<XAttribute?, Error> result = attr1.Should().NotBe(attr2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region HaveValue

        [Fact(DisplayName = "XML-030: XAttribute.HaveValue succeeds when value matches")]
        public void XML030()
        {
            // Arrange
            var attr = new XAttribute("name", "expected");

            // Act
            Result<XAttribute?, Error> result = attr.Should().HaveValue("expected");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-031: XAttribute.HaveValue fails when value does not match")]
        public void XML031()
        {
            // Arrange
            var attr = new XAttribute("name", "actual");

            // Act
            Result<XAttribute?, Error> result = attr.Should().HaveValue("expected");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.HaveValue, result.Error.Code);
        }

        #endregion

        #endregion

        #region Chaining

        [Fact(DisplayName = "XML-032: Chaining XElement assertions works")]
        public void XML032()
        {
            // Arrange
            var elem = XElement.Parse("<item name='test'>value</item>");

            // Act
            Result<XElement?, Error> result = elem.Should()
                .HaveAttribute("name", "test")
                .And.HaveValue("value");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "XML-033: Chaining XDocument assertions works")]
        public void XML033()
        {
            // Arrange
            var doc = XDocument.Parse("<root><child /></root>");

            // Act
            Result<XDocument?, Error> result = doc.Should()
                .HaveRoot("root")
                .And.HaveElement("child");

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region Null Handling

        [Fact(DisplayName = "XML-034: XDocument null subject handles gracefully")]
        public void XML034()
        {
            // Arrange
            XDocument? doc = null;

            // Act
            Result<XDocument?, Error> result = doc.Should().HaveRoot("root");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.HaveRoot, result.Error.Code);
        }

        [Fact(DisplayName = "XML-035: XElement null subject handles gracefully")]
        public void XML035()
        {
            // Arrange
            XElement? elem = null;

            // Act
            Result<XElement?, Error> result = elem.Should().HaveValue("value");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.HaveValue, result.Error.Code);
        }

        [Fact(DisplayName = "XML-036: XAttribute null subject handles gracefully")]
        public void XML036()
        {
            // Arrange
            XAttribute? attr = null;

            // Act
            Result<XAttribute?, Error> result = attr.Should().HaveValue("value");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(XmlAssertionCodes.HaveValue, result.Error.Code);
        }

        #endregion
    }
}
