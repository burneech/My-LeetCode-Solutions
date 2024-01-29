namespace LeetCode
{
    /*
        3. Longest Substring Without Repeating Characters - https://leetcode.com/problems/longest-substring-without-repeating-characters/description/

        Given a string s, find the length of the longest substring without repeating characters.

        Example 1:

        Input: s = "abcabcbb"
        Output: 3
        Explanation: The answer is "abc", with the length of 3.

        Example 2:

        Input: s = "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.

        Example 3:

        Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
    */
    internal class _3_Longest_Substring_Without_Repeating_Characters
    {
        static int FirstSolution(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            List<char> substringLetters = new List<char>{s[0]}; // Here we will temprorary store our characters that form each substring.
            List<int> substringLengths = new List<int>();       // Here we will memorize the length of each substring that we encounter.

            for (int i = 1; i < s.Length; i++)
            {
                if (substringLetters.Contains(s[i])) // If we encounter a repetition in our temporary list of characters...
                {
                    substringLengths.Add(substringLetters.Count); // ... we calculate the length of the current substring, store that length, ...
                    substringLetters.Clear();   // ... clear the temporary list so it can be ready for the next substring, ...
                    substringLetters.Add(s[i]); // ... add the current letter to the list (that was a repetition for the previous substring but its now new for the next one), ...
                    continue; // ... and continue our loop in case there are more letters / substrings to check.
                }
                else
                {
                    substringLetters.Add(s[i]); // Add the current letter to the list of substring letters.
                }
            }
            return substringLengths.Max(); // After we have looped through all the letters, we simply return the longest memorized length of a substring.
        }

        static int SecondSolution(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var lastSeenIndexOfLetters = new Dictionary<char, int>();   // Here we will memorize the last seen index (value) for each of our letters (key).
            var indexOfLastRepetition = 0;                              // When did we last encounter the repetition of a letter (our substring cut-off).
            var maxLength = 0;                                          // The length of the longest substring will end up here.

            for (int i = 0; i < s.Length; i++)
            {
                if (lastSeenIndexOfLetters.TryGetValue(s[i], out int prevIndexOfCurrentLetter)) // If we have already encountered this letter, let us take the index of its previous appereance...
                    indexOfLastRepetition = Math.Max(indexOfLastRepetition, prevIndexOfCurrentLetter); // ... and check if this is the new latest index of repetition and the point at which we...
                        // ... should cut-off the beggining of our current substring.

                maxLength = Math.Max(maxLength, i - indexOfLastRepetition); // Determine the length of the current substring, and if it is the longest yet - store it.

                lastSeenIndexOfLetters[s[i]] = i; // Store the current index for the current letter, for when we possibly encounter it again later.
            }

            return maxLength; // Passing through the for loop, the maxLength variable should by now hold the answer, i.e. the length of the longest substring without repeating characters.
        }

        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("3 - Longest Substring Without Repeating Characters\n");

            Console.WriteLine("Test 1 -> Input = \"abcabcbb\", expected result: 3 (\"abc\")");
            Console.WriteLine($"First solution: {FirstSolution("abcabcbb")}");
            Console.WriteLine($"Second solution: {SecondSolution("abcabcabb")}");

            Console.WriteLine("Test 2 -> Input = \"bbbbb\", expected result: 1 (\"b\")");
            Console.WriteLine($"First solution: {FirstSolution("bbbbb")}");
            Console.WriteLine($"Second solution: {SecondSolution("bbbbb")}");

            Console.WriteLine("Test 3 -> Input = \"pwwkew\", expected result: 3 (\"wke\")");
            Console.WriteLine($"First solution: {FirstSolution("pwwkew")}");
            Console.WriteLine($"Second solution: {SecondSolution("pwwkew")}");
        }
    }
}
