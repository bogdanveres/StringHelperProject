using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace StringHelperDLL
{
    public class StringHelper
    {
        /// <summary>
    /// Truncate  string 
    /// </summary>
    /// <param name="str">String to be truncated.</param>
    /// <returns>Truncated string.</returns>
    public static string TruncateString(string str)
    {
        var result = string.Empty;
        if (str.Length > 10)
        {
            //result is first 10 chars of str
            result = $"{str.Substring(0, 10)}...";
        }
        else
        {
            result = str;
        }

        return result;
    }

    /// <summary>
    /// Remove HTML tags from string.
    /// </summary>
    /// <param name="str">String with HTML tags.</param>
    /// <returns>String without HTML tags.</returns>
    public static string RemoveHtmlTags(string str)
    {
        var result = string.Empty;
        result = Regex.Replace(str, "<.*?>", string.Empty);
        return result;
    }

    /// <summary>
    /// Remove diacritics from string.
    /// </summary>
    /// <param name="str">String with diacritics.</param>
    /// <returns>String without diacritics.</returns>
    public static string RemoveDiacritics(string str)
    {
        var result = string.Empty;
        var normalizedString = str.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        result = stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        return result;
    }

    /// <summary>
    /// Check if string is URL.
    /// </summary>
    /// <param name="str">String to be checked.</param>
    /// <returns>True or False.</returns>
    public static bool IsUrl(string str)
    {
        var result = false;
        var regex = new Regex(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$");
        if (regex.IsMatch(str))
        {
            result = true;
        }

        return result;
    }

    /// <summary>
    /// Check if string is valid email address.
    /// </summary>
    /// <param name="str">Email address.</param>
    /// <returns>True or False.</returns>
    public static bool IsEmail(string str)
    {
        var result = false;
        var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        if (regex.IsMatch(str))
        {
            result = true;
        }

        return result;
    }

    /// <summary>
    /// Check if string is alpha numeric.
    /// </summary>
    /// <param name="str">String to be checked.</param>
    /// <returns>True or False.</returns>
    public static bool IsAlphaNumeric(string str)
    {
        var result = false;
        var regex = new Regex("^[a-zA-Z0-9]*$");
        if (regex.IsMatch(str))
        {
            result = true;
        }

        return result;
    }

    /// <summary>
    /// Extract string between two strings.
    /// </summary>
    /// <param name="str">Full string.</param>
    /// <param name="start">Start position.</param>
    /// <param name="end">End position.</param>
    /// <returns>Extracted string.</returns>
    public static string SubstringBetween(string str, string start, string end)
    {
        var result = string.Empty;
        var startIndex = str.IndexOf(start);
        var endIndex = str.IndexOf(end);

        if (startIndex == -1)
        {
            throw new ArgumentException("Start substring not found in input string.");
        }

        startIndex += start.Length;

        if (endIndex == -1)
        {
            throw new ArgumentException("End substring not found in input string.");
        }

        result = str.Substring(startIndex, endIndex - startIndex);
        return result;
    }

    /// <summary>
    /// Encode string to BASE 64.
    /// </summary>
    /// <param name="str">String to be encoded.</param>
    /// <returns>Encoded string.</returns>
    public static string Base64Encode(string str)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(str);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    /// <summary>
    /// Decode string from BASE 64.
    /// </summary>
    /// <param name="str">Encoded string.</param>
    /// <returns>Decoded string.</returns>
    public static string Base64Decode(string str)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(str);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }

    /// <summary>
    /// Get random string.
    /// </summary>
    /// <param name="length">Length of string to be generated.</param>
    /// <returns>Random string.</returns>
    public static string GetRandomString(int length)
    {
        var random = new Random();
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var result = new string(
            Enumerable.Repeat(chars, length)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
        return result;
    }

    /// <summary>
    /// Get random string.
    /// </summary>
    /// <param name="length">Length of string to be generated.</param>
    /// <param name="chars">Chars to use to generate random string.</param>
    /// <returns>Random string.</returns>
    public static string GetRandomString(int length, string chars)
    {
        var random = new Random();
        var result = new string(
            Enumerable.Repeat(chars, length)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
        return result;
    }

    /// <summary>
    /// Get occurences of char in string.
    /// </summary>
    /// <param name="str">String to be checked.</param>
    /// <returns>Occurences of chars.</returns>
    public static string GetCharOccurencesInString(string str)
    {
        var result = string.Empty;
        var charOccurences = new Dictionary<char, int>();
        foreach (var c in str)
        {
            if (charOccurences.ContainsKey(c))
            {
                charOccurences[c]++;
            }
            else
            {
                charOccurences.Add(c, 1);
            }
        }

        foreach (var c in charOccurences)
        {
            result += $"{c.Key} - {c.Value}\n";
        }

        return result;
    }

    /// <summary>
    /// Count words in string.
    /// </summary>
    /// <param name="str">string to be counted.</param>
    /// <returns>Number of words.</returns>
    public static int CountWords(string str)
    {
        var result = 0;
        var words = str.Split(' ');
        result = words.Length;
        return result;
    }

    /// <summary>
    /// Reverse string.
    /// </summary>
    /// <param name="str">String to be reversed.</param>
    /// <returns>Reversed string.</returns>
    public static string ReverseString(string str)
    {
        var result = string.Empty;
        for (int i = str.Length - 1; i >= 0; i--)
        {
            result += str[i];
        }

        return result;
    }

    /// <summary>
    /// Remove white spaces from string.
    /// </summary>
    /// <param name="str">String to be checked.</param>
    /// <returns>Clean string.</returns>
    public static string RemoveWhiteSpaces(string str)
    {
        var result = string.Empty;
        result = Regex.Replace(str, @"\s+", "");
        return result;
    }

    /// <summary>
    /// Converts string to camel case.
    /// </summary>
    /// <param name="str">String to be converted.</param>
    /// <returns>Converted string.</returns>
    public static string ToCamelCase(string str)
    {
        var result = string.Empty;
        var words = str.Split(' ');
        foreach (var word in words)
        {
            result += $"{word[0].ToString().ToUpper()}{word.Substring(1).ToLower()} ";
        }

        return result.Trim();
    }

    /// <summary>
    /// Converts string to snake case.
    /// </summary>
    /// <param name="str">String to be converted.</param>
    /// <returns>Converted string.</returns>
    public static string ToSnakeCase(string str)
    {
        var result = string.Empty;
        var words = str.Split(' ');
        foreach (var word in words)
        {
            result += $"{word.ToLower()} ";
        }

        return result.Trim();
    }

    /// <summary>
    /// Converts string to kebab case.
    /// </summary>
    /// <param name="str">String to be converted.</param>
    /// <returns>Converted string.</returns>
    public static string ToKebabCase(string str)
    {
        var result = string.Empty;
        var words = str.Split(' ');
        foreach (var word in words)
        {
            result += $"{word.ToLower()}-";
        }

        return result.TrimEnd('-');
    }

    /// <summary>
    /// Upper case first letter of each word in string.
    /// </summary>
    /// <param name="str">String to upper case.</param>
    /// <returns>Converted string.</returns>
    public static string ToUpperCaseFirstLetter(string str)
    {
        var result = string.Empty;
        var words = str.Split(' ');
        foreach (var word in words)
        {
            result += $"{word[0].ToString().ToUpper()}{word.Substring(1).ToLower()} ";
        }

        return result.Trim();
    }

    /// <summary>
    /// Check if string is palindrome.
    /// </summary>
    /// <param name="str">String to be checked.</param>
    /// <returns>True or False.</returns>
    public static bool CheckPalindrome(string str)
    {
        var result = true;
        for (int i = 0; i < str.Length / 2; i++)
        {
            if (str[i] != str[str.Length - 1 - i])
            {
                result = false;
                break;
            }
        }

        return result;
    }

    /// <summary>
    /// Remove duplicate chars from string.
    /// </summary>
    /// <param name="str">String to be checked.</param>
    /// <returns>String without diplicated chars.</returns>
    public static string RemoveDuplicateChars(string str)
    {
        var result = string.Empty;
        var chars = new HashSet<char>();
        foreach (var c in str)
        {
            if (!chars.Contains(c))
            {
                result += c;
                chars.Add(c);
            }
        }

        return result;
    }

    /// <summary>
    /// Generate email address.
    /// </summary>
    /// <param name="firstName">First name.</param>
    /// <param name="lastName">Last Name.</param>
    /// <param name="domain">Mail domain.</param>
    /// <returns>Email address.</returns>
    public static string GenerateEmailAddress(string firstName, string lastName, string domain)
    {
        var result = string.Empty;
        result = $"{firstName.ToLower()}.{lastName.ToLower()}@{domain.ToLower()}";
        return result;
    }

    /// <summary>
    /// Get Random First Name.
    /// </summary>
    /// <returns>First name.</returns>
    public static string GetRandomFirstName()
    {
        List<string> firstNames = new List<string>
        {
            "Liam", "Olivia", "Noah", "Emma", "Oliver", "Ava", "Elijah", "Charlotte", "Isabella", "Mia",
            "Lucas", "Amelia", "Mason", "Harper", "Ethan", "Evelyn", "Henry", "Abigail", "James", "Emily",
            "Alexander", "Elizabeth", "Benjamin", "Sofia", "Sebastian", "Avery", "Jack", "Lily", "William", "Scarlett",
            "Michael", "Grace", "Ezra", "Chloe", "David", "Victoria", "Joseph", "Riley", "Samuel", "Aria",
            "Daniel", "Sophia", "Matthew", "Nora", "Aiden", "Ella", "Luke", "Aubrey", "Jackson", "Camila",
            "Owen", "Layla", "John", "Zoey", "Wyatt", "Penelope", "Carter", "Lillian", "Leo", "Addison",
            "Isaac", "Luna", "Jayden", "Stella", "Gabriel", "Natalie", "Caleb", "Hannah", "Isaiah", "Zoe",
            "Grayson", "Leah", "Muhammad", "Violet", "Anthony", "Savannah", "Dylan", "Alice", "Isabel", "Eliana",
            "Emily", "Aaliyah", "William", "Lily", "Samantha", "Audrey", "Andrew", "Hazel", "David", "Sophie"
        };

        return GetRandomStringFromList(firstNames);
    }
    
    /// <summary>
    /// Get Random Last Name.
    /// </summary>
    /// <returns>Last Name.</returns>
    public static string GetRandomLastName()
    {
        List<string> lastNames = new List<string>
        {
            "Smith", "Johnson", "Brown", "Taylor", "Williams", "Jones", "Davis", "Miller", "Wilson", "Moore",
            "Anderson", "Jackson", "Harris", "Martin", "Thompson", "White", "Lewis", "Walker", "Hall", "Young",
            "Allen", "King", "Wright", "Lee", "Scott", "Green", "Evans", "Turner", "Carter", "Baker",
            "Hill", "Roberts", "Edwards", "Stewart", "Phillips", "Murphy", "Cook", "Rogers", "Cooper", "Peterson",
            "Reed", "Bailey", "Bell", "Gonzalez", "Perez", "Gray", "Hayes", "Watson", "Russell", "Diaz",
            "Simmons", "Foster", "Bryant", "Alexander", "Powell", "Long", "Patterson", "Hughes", "Flores", "Washington",
            "Butler", "Sanders", "Price", "Kelly", "Cox", "Bennett", "Wood", "Barnes", "Rogers", "Ross",
            "Coleman", "Griffin", "Dixon", "Hamilton", "Morgan", "Duncan", "Hayes", "Snyder", "Shaw", "Gibson",
            "Reynolds", "Hunt", "Ramirez", "Wells", "Franklin", "Knight", "Robertson", "Sanders", "Dean", "Carroll",
            "Warren", "Gibson", "Spencer", "Pierce", "Dawson", "Fletcher", "Carroll", "Warren", "Gibson", "Spencer"
        };

        return GetRandomStringFromList(lastNames);
    }

    /// <summary>
    /// Get random string from list.
    /// </summary>
    /// <param name="stringList">List of names.</param>
    /// <returns>Random name from list.</returns>
    private static string GetRandomStringFromList(List<string> stringList)
    {
        var random = new Random();
        var result = stringList[random.Next(0, stringList.Count - 1)];
        return result;
    }
    }
}