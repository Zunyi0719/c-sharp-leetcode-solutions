// bot-up
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

// top-down
public class Solution {
    int row = 0;
    int col = 0;
    int max = 0;
    int[,] dp;
    
    public string LongestPalindrome(string s) {
        if(s.Length==0) return "";
        int n = s.Length;
        dp = new int[n, n];
        
        TopDownDP(n-1,n-1,s);
        return s.Substring(row,col-row+1);
    }
    
    public void TopDownDP(int i,int j,string s)
    {
        if(i<0 || j<0) return;
        if(dp[i,j]!=0) return;
        
        char a = s[i];
        char b = s[j];
        
        if(j-i+1<=1)
        {
            if(a==b) update(i,j);
            else dp[i,j] = -1;
        }
        else
        {
            if(dp[i+1,j-1]==0) TopDownDP(i+1,j-1,s);
            if(a==b && dp[i+1,j-1]==1) update(i,j);
            else dp[i,j] = -1;
        }
        TopDownDP(i-1,j,s);
        TopDownDP(i-1,j-1,s);
    }
    
    public void update(int i,int j)
    {
        dp[i,j] = 1;
        if(j-i+1>=max)
        {
            max = j-i+1;
            row = i;
            col = j;
        }
    }
}
