public class Solution {
    int row = 0;
    int col = 0;
    int max = 0;
    bool[,] dp;
    
    public string LongestPalindrome(string s) {
        if(s.Length==0) return "";
        int n = s.Length;
        dp = new bool[n, n];
        
        for(int j=0;j<n;j++)
        {
            for(int i=j;i>=0;i--)
            {
                char a = s[i];
                char b = s[j];
                if(j-i<=1)
                {
                    if(a==b) change(i,j);
                    else dp[i,j] = false;
                }
                else
                {
                    if(a==b && dp[i+1,j-1]) change(i,j);
                    else dp[i,j] = false;
                }
            }
        }
        return s.Substring(row,col-row+1);
    }
    
    public void change(int i, int j){
        dp[i,j] = true;
        if(j-i+1>max)
        {
            max = j-i+1;
            row = i;
            col = j;
        }
    }
}
