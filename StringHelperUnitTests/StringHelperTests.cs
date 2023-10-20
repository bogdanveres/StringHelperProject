using StringHelperDLL;

namespace StringHelperUnitTests
{
    [TestClass]
    public class StringHelperTests
    {
        [TestMethod]
        public void ToUpperCaseFirstLetter_ReturnsStringWithUppercaseFirstLetter()
        {
            // Arrange
            string input = "this is a test";

            // Act
            string result = StringHelper.ToUpperCaseFirstLetter(input);

            // Assert
            Assert.AreEqual("This Is A Test", result);
        }

        [TestMethod]
        public void TruncateString_ReturnsOriginalString_WhenInputIs10CharsLong()
        {
            // Arrange
            string input = "Short text";

            // Act
            string result = StringHelper.TruncateString(input);

            // Assert
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void TruncateString_ReturnsOriginalString_WhenInputIsShorterThan10Chars()
        {
            // Arrange
            string input = "Small";

            // Act
            string result = StringHelper.TruncateString(input);

            // Assert
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void RemoveHtmlTags_RemovesTags_WhenInputContainsTags()
        {
            // Arrange
            string input = "<p>This is some <b>bold</b> text.</p>";

            // Act
            string result = StringHelper.RemoveHtmlTags(input);

            // Assert
            Assert.AreEqual("This is some bold text.", result);
        }

        [TestMethod]
        public void RemoveHtmlTags_ReturnsOriginalString_WhenInputDoesNotContainTags()
        {
            // Arrange
            string input = "This is some plain text.";

            // Act
            string result = StringHelper.RemoveHtmlTags(input);

            // Assert
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void RemoveHtmlTags_ReturnsEmptyString_WhenInputIsEmpty()
        {
            // Arrange
            string input = "";

            // Act
            string result = StringHelper.RemoveHtmlTags(input);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void RemoveDiacritics_RemovesDiacritics_WhenInputContainsDiacritics()
        {
            // Arrange
            string input = "Café au lait";

            // Act
            string result = StringHelper.RemoveDiacritics(input);

            // Assert
            Assert.AreEqual("Cafe au lait", result);
        }

        [TestMethod]
        public void RemoveDiacritics_ReturnsOriginalString_WhenInputDoesNotContainDiacritics()
        {
            // Arrange
            string input = "This is some plain text.";

            // Act
            string result = StringHelper.RemoveDiacritics(input);

            // Assert
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void RemoveDiacritics_ReturnsEmptyString_WhenInputIsEmpty()
        {
            // Arrange
            string input = "";

            // Act
            string result = StringHelper.RemoveDiacritics(input);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void IsUrl_ValidUrl_ReturnsTrue()
        {
            // Arrange
            string url = "https://www.example.com";

            // Act
            bool result = StringHelper.IsUrl(url);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsUrl_InvalidUrl_ReturnsFalse()
        {
            // Arrange
            string url = "not a valid url";

            // Act
            bool result = StringHelper.IsUrl(url);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsEmail_ValidEmail_ReturnsTrue()
        {
            // Arrange
            string email = "test@example.com";

            // Act
            bool result = StringHelper.IsEmail(email);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmail_InvalidEmail_ReturnsFalse()
        {
            // Arrange
            string email = "not a valid email";

            // Act
            bool result = StringHelper.IsEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsAlphaNumeric_ValidString_ReturnsTrue()
        {
            // Arrange
            string str = "abc123";

            // Act
            bool result = StringHelper.IsAlphaNumeric(str);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsAlphaNumeric_InvalidString_ReturnsFalse()
        {
            // Arrange
            string str = "abc!@#";

            // Act
            bool result = StringHelper.IsAlphaNumeric(str);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SubstringBetween_ValidInput_ReturnsSubstring()
        {
            // Arrange
            string str = "Hello [world]!";
            string start = "[";
            string end = "]";

            // Act
            string result = StringHelper.SubstringBetween(str, start, end);

            // Assert
            Assert.AreEqual(result, "world");
        }

        [TestMethod]
        public void Base64Encode_ValidInput_ReturnsEncodedString()
        {
            // Arrange
            string str = "Hello world!";

            // Act
            string result = StringHelper.Base64Encode(str);

            // Assert
            Assert.AreEqual(result, "SGVsbG8gd29ybGQh");
        }

        [TestMethod]
        public void Base64Encode_EmptyInput_ReturnsEmptyString()
        {
            // Arrange
            string str = string.Empty;

            // Act
            string result = StringHelper.Base64Encode(str);

            // Assert
            Assert.AreEqual(result, string.Empty);
        }

        [TestMethod]
        public void Base64Decode_ValidInput_ReturnsDecodedString()
        {
            // Arrange
            string str = "SGVsbG8gd29ybGQh";

            // Act
            string result = StringHelper.Base64Decode(str);

            // Assert
            Assert.AreEqual(result, "Hello world!");
        }

        [TestMethod]
        public void Base64Decode_EmptyInput_ReturnsEmptyString()
        {
            // Arrange
            string str = string.Empty;

            // Act
            string result = StringHelper.Base64Decode(str);

            // Assert
            Assert.AreEqual(result, string.Empty);
        }

        [TestMethod]
        public void GetRandomString_ValidLength_ReturnsStringOfGivenLength()
        {
            // Arrange
            int length = 10;

            // Act
            string result = StringHelper.GetRandomString(length);

            // Assert
            Assert.AreEqual(result.Length, length);
        }

        [TestMethod]
        public void GetRandomString_ZeroLength_ReturnsEmptyString()
        {
            // Arrange
            int length = 0;

            // Act
            string result = StringHelper.GetRandomString(length);

            // Assert
            Assert.AreEqual(result, string.Empty);
        }

        [TestMethod]
        public void GetRandomString_ValidLengthAndChars_ReturnsStringOfGivenLength()
        {
            // Arrange
            int length = 10;
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            // Act
            string result = StringHelper.GetRandomString(length, chars);

            // Assert
            Assert.AreEqual(result.Length, length);
        }

        [TestMethod]
        public void GetCharOccurencesInString_ValidInput_ReturnsCharOccurences()
        {
            // Arrange
            string str = "Hello world!";

            // Act
            string result = StringHelper.GetCharOccurencesInString(str);

            // Assert
            Assert.AreEqual(result, "H - 1\n" +
                                    "e - 1\n" +
                                    "l - 3\n" +
                                    "o - 2\n" +
                                    "  - 1\n" +
                                    "w - 1\n" +
                                    "r - 1\n" +
                                    "d - 1\n" +
                                    "! - 1\n");
        }

        [TestMethod]
        public void CountWords_ValidInput_ReturnsNumberOfWords()
        {
            // Arrange
            string str = "Hello world!";

            // Act
            int result = StringHelper.CountWords(str);

            // Assert
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void ReverseString_ValidInput_ReturnsReversedString()
        {
            // Arrange
            string str = "Hello world!";

            // Act
            string result = StringHelper.ReverseString(str);

            // Assert
            Assert.AreEqual(result, "!dlrow olleH");
        }

        [TestMethod]
        public void RemoveWhiteSpaces_ValidInput_ReturnsStringWithoutSpaces()
        {
            // Arrange
            string str = "Hello world!";

            // Act
            string result = StringHelper.RemoveWhiteSpaces(str);

            // Assert
            Assert.AreEqual(result, "Helloworld!");
        }

        [TestMethod]
        public void ToCamelCase_ValidInput_ReturnsCamelCaseString()
        {
            // Arrange
            string str = "hello world!";

            // Act
            string result = StringHelper.ToCamelCase(str);

            // Assert
            Assert.AreEqual(result, "Hello World!");
        }

        [TestMethod]
        public void ToSnakeCase_ValidInput_ReturnsSnakeCaseString()
        {
            // Arrange
            string str = "Hello World!";

            // Act
            string result = StringHelper.ToSnakeCase(str);

            // Assert
            Assert.AreEqual(result, "hello world!");
        }

        [TestMethod]
        public void ToKebabCase_ValidInput_ReturnsKebabCaseString()
        {
            // Arrange
            string str = "Hello World!";

            // Act
            string result = StringHelper.ToKebabCase(str);

            // Assert
            Assert.AreEqual(result, "hello-world!");
        }

        [TestMethod]
        public void ToUpperCaseFirstLetter_ValidInput_ReturnsStringWithUpperCaseFirstLetter()
        {
            // Arrange
            string str = "hello world!";

            // Act
            string result = StringHelper.ToUpperCaseFirstLetter(str);

            // Assert
            Assert.AreEqual(result, "Hello World!");
        }

        [TestMethod]
        public void CheckPalindrome_ValidPalindrome_ReturnsTrue()
        {
            // Arrange
            string str = "racecar";

            // Act
            bool result = StringHelper.CheckPalindrome(str);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckPalindrome_InvalidPalindrome_ReturnsFalse()
        {
            // Arrange
            string str = "hello world";

            // Act
            bool result = StringHelper.CheckPalindrome(str);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveDuplicateChars_ValidInput_ReturnsStringWithoutDuplicateChars()
        {
            // Arrange
            string str = "Hello world!";

            // Act
            string result = StringHelper.RemoveDuplicateChars(str);

            // Assert
            Assert.AreEqual(result, "Helo wrd!");
        }

        [TestMethod]
        public void GenerateEmailAddress_ValidInput_ReturnsEmailAddress()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";
            string domain = "example.com";

            // Act
            string result = StringHelper.GenerateEmailAddress(firstName, lastName, domain);

            // Assert
            Assert.AreEqual(result, "john.doe@example.com");
        }

        [TestMethod]
        public void GetRandomFirstName_ReturnsRandomFirstName()
        {
            // Act
            string result = StringHelper.GetRandomFirstName();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetRandomLastName_ReturnsRandomLastName()
        {
            // Act
            string result = StringHelper.GetRandomLastName();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}