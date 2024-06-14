using ContactManager;
using System;
using Xunit;


namespace ContactManagerTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddContact()
        {
            // Arrange
            ContactManager.Program.AddContact("John");

            // Act
            var result = ContactManager.Program.AddContact("Jane");

            // Assert
            Assert.Contains("Jane", result);
        }

        [Fact]
        public void TestAddDuplicateContact()
        {
            // Arrange
            ContactManager.Program.AddContact("John");

            // Act
            var result = ContactManager.Program.AddContact("John");

            // Assert
            Assert.Equal(4, result.Count);
        }

        [Fact]
        public void TestAddEmptyContact()
        {
            // Act
            var result = ContactManager.Program.AddContact("");

            // Assert
            Assert.DoesNotContain("", result);
        }

        [Fact]
        public void TestRemoveExistingContact()
        {
            // Arrange
            ContactManager.Program.AddContact("John");

            // Act
            var result = ContactManager.Program.RemoveContact("John");

            // Assert
            Assert.DoesNotContain("John", result);
        }

        [Fact]
        public void TestRemoveNonExistingContact()
        {
            // Arrange
            ContactManager.Program.AddContact("John");

            // Act
            var result = ContactManager.Program.RemoveContact("Jane");

            // Assert
            Assert.Contains("John", result);
        }

        [Fact]
        public void TestViewAllContacts()
        {
            // Arrange
            ContactManager.Program.AddContact("John Doe");
            ContactManager.Program.AddContact("Jane Doe");

            // Act
            var result = ContactManager.Program.ViewAllContacts();

            // Assert
            Assert.Contains("John Doe", result);
            Assert.Contains("Jane Doe", result);
        }
    }
}