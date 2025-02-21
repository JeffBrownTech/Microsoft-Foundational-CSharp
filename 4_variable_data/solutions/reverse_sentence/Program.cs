string pangram = "The quick brown fox jumps over the lazy dog";

string[] words = pangram.Split(' ');
string[] reversedWords = new string[words.Length];

for (int i = 0; i < words.Length; i++)
{
    char[] wordArray = words[i].ToCharArray();
    Array.Reverse(wordArray);
    string reversedWord = new string(wordArray);
    reversedWords[i] = reversedWord;
}

string reversePangram = String.Join(" ", reversedWords);
Console.WriteLine(reversePangram);