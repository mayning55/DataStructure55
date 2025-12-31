using System.Runtime.InteropServices;
using System.Text;

namespace StringAlgor;

class Program
{
    static void Main(string[] args)
    {
        //BruteForce bf = new BruteForce();
        //int index = bf.StringBruteForce("sutsad", "sad");
        // KMP kmp = new KMP();
        // int index = kmp.KMPAlgor("sutsad", "sad");
        // BoyerMoore bm = new BoyerMoore();
        // int index = bm.BoyerMooreAlgor("abbcfdddbddcaddebc", "abbc");
        // Horspool hs = new Horspool();
        // int index = hs.HorspoolAlgor("caddebc", "debc");
        // Sunday sd =new Sunday();
        // int index = sd.SundayAlgor("sutsad","sad");

        // Console.WriteLine(index);

        // Trie trie = new Trie();

        // trie.InsertNode("abad");
        // trie.InsertNode("dsd");
        // trie.InsertNode("mad");
        // System.Console.WriteLine(trie.SearchString("mad"));
        // System.Console.WriteLine(trie.SearchString("pad"));
        // System.Console.WriteLine(trie.SearchString("..."));
        // System.Console.WriteLine(trie.SearchString("...."));
        // System.Console.WriteLine(trie.SearchString("....."));
        // System.Console.WriteLine(trie.SearchString(".."));
        // System.Console.WriteLine(trie.SearchString(".ad"));
        // System.Console.WriteLine(trie.SearchString("m.d"));
        // System.Console.WriteLine(trie.SearchString("m..d"));
        // System.Console.WriteLine(trie.SearchString("b.."));
        // System.Console.WriteLine(trie.SearchString("a.."));
        // System.Console.WriteLine(trie.SearchString("a..."));

        // AhoCorasick.Trie ac = new AhoCorasick.Trie();
        // string[] ss = new string[] { "say", "she", "shr", "he", "her" };
        // foreach (var s in ss)
        // {
        //     ac.Add(s);
        // }
        // ac.Build();
        // var x = ac.Find("yasherhs");
        // System.Console.WriteLine(string.Join(",", x));

        // AC_Automaton tn = new AC_Automaton();
        // foreach (var s in ss)
        // {
        //     tn.AddWord(s);
        // }
        // tn.BuildFailPointers();
        // var y = tn.Search("yasherhs");
        // System.Console.WriteLine(string.Join(' ',y));
        /*
        字符串
        */
        // AhoCorasickAutomaton<char, string> acstring = new AhoCorasickAutomaton<char, string>();
        // string[] strings = new string[] { "he", "her", "his", "she", "hers", "him" };
        // foreach (var s in strings)
        // {
        //     acstring.InsertNode(s);
        // }
        // acstring.BuildFailPointers();
        // var result = acstring.Search("she is Anna,her brother is tall. his is five years old.");
        // //she =>she,he; her=>he,her; brother=>he,her; his=>his;
        // System.Console.WriteLine(string.Join(" ", result));
        // /*
        // 数组
        // */
        // AhoCorasickAutomaton<int, int[]> acIntArray = new AhoCorasickAutomaton<int, int[]>();
        // int[][] ints = new int[][] { [2, 3], [4, 5], [3, 4], [6, 6], [1, 4] };
        // foreach (var i in ints)
        // {
        //     acIntArray.InsertNode(i);
        // }
        // acIntArray.BuildFailPointers();
        // int[] serachArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        // var acresult = acIntArray.Search(serachArray);
        // foreach (var x in acresult)
        // {
        //     System.Console.WriteLine(string.Join(" ", x));
        // }
        /*
        过滤字符
        */
        FilterStringAC fac = new FilterStringAC();
        string[] strings = new string[] { "一只", "二", "三只", "一根" };
        HashSet<string> words = new HashSet<string>(strings);
        fac.AddWord(words);
        Console.WriteLine(fac.FilterSearch("有一只猫戴着一根丝带，二条鱼在水里游，还有三只狗屋里"));
        //有**猫戴着**丝带，*条鱼在水里游，还有**狗屋里
    }
}
