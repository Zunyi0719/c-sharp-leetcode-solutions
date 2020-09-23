public class Solution 
{
    public int LengthOfLongestSubstring(string s) 
    {
        Hashtable ht = new Hashtable();
        int i = 0;
        int max = 0;
        
        for(int j=0;j<s.Length;j++)
        {
            if(!ht.Contains(s[j]))
            {
                ht.Add(s[j],j);
            }
            else
            {
                int index = (int)ht[s[j]];
                ht[s[j]] = j;
                if(i<=index) i = index+1;
            }
            max = Math.Max(j-i+1,max);
        }
        return max;
    }
}
