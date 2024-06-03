using System;
using System.Collections.Generic;

class Scriptures
{
    public string reference;
    public string scripture;
    public string[] words;
    public Scriptures(string _reference, string _scripture)
    {
        reference = _reference;
        scripture = _scripture;
        words = scripture.Split(' ');
    }
    public void script_replace()
    {
        var no_underscore_words = words.Where(word => !word.Contains('_')).ToArray();
        Random random = new Random();
        int random_index = random.Next(no_underscore_words.Length);
        string selected_word = no_underscore_words[random_index]; 
        string replace_under = new string('_', selected_word.Length);
        words[Array.IndexOf(words, selected_word)] = replace_under;
        string updated_scripture = String.Join(" ", words);
        scripture = updated_scripture;
    }
    public bool is_script_is_done()
    {
        var hasnounder = words.Any(words => !words.Contains('_'));
        return hasnounder;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Scriptures scriptures01 = new Scriptures("1 nephi 17:50", "And I said unto them: If God had commanded me to do all things I could do them. If he should command me that I should say unto this water, be thou earth, it should be earth; and if I should say it, it would be done.");
        bool game_active = true;
        while (game_active == true)
        {
            Console.Clear();
            Console.WriteLine(scriptures01.reference + " " + scriptures01.scripture +"\n");
            Console.WriteLine("Please enter to continue or type 'quit' to finsh:");
            string user_input = Console.ReadLine();
            if (user_input.ToLower() != "quit" && scriptures01.is_script_is_done() == true)
            {scriptures01.script_replace();}else{break;}
        }
    }
    
}
