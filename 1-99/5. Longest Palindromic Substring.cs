// bot-up O(n^2)
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

// top-down O(n^2)
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

// iteration plus recur, but avoid duplicate visit O(n^2)
public class Solution {
    int row = 0;
    int col = 0;
    int max = 0;
    int[,] dp;
    
    public string LongestPalindrome(string s) {
        if(s.Length==0) return "";
        int n = s.Length;
        dp = new int[n, n];
        
        for(int i=0;i<n;i++)
        {
            for(int j=0;j<n;j++)
            {
                if(i>j || dp[i,j]!=0) continue;
                
                char a = s[i];
                char b = s[j];
                if(j-i<=1)
                {
                    if(a==b) update(i,j);
                    else dp[i,j] = -1;
                }
                else
                {
                    recur(i+1,j-1,s);
                    if(a==b && dp[i+1,j-1]==1) update(i,j);
                    else dp[i,j] = -1;
                }
            }
        }
        return s.Substring(row,col-row+1);
    }
    
    public void recur(int i,int j,string s)
    {
        if(dp[i,j]!=0) return;
        
        char a = s[i];
        char b = s[j];
        if(j-i<=1)
        {
            if(a==b) update(i,j);
            else dp[i,j] = -1;
        }
        else
        {
            recur(i+1,j-1,s);
            if(a==b && dp[i+1,j-1]==1) update(i,j);
            else dp[i,j] = -1;
        }
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

// 中心点双指针扩散 O(n^2)
public class Solution {
    public string LongestPalindrome(string s) 
    {
        if(s.Length==0) return "";
        StringBuilder sb = new StringBuilder();
        for(int i=0;i<s.Length;i++) sb.Append("*"+s[i]);
        sb.Append("*");
        
        String ss = sb.ToString();
        int st = 0;
        int max = 0;
        
        for(int i=0;i<ss.Length;i++)
        { 
            int l = i-1;
            int r = i+1;
            
            while(l>=0 && r<ss.Length && ss[l]==ss[r])
            {
                l--;
                r++;
            }
            l++;
            r--;
            
            if(max < r-l+1)
            {
                st = l;
                max = r-l+1;
            }
        }
        
        return s.Substring(st/2,max/2);
    }
}

// 马拉车算法 O(n)
public class Solution {
    public string LongestPalindrome(string s) 
    {
        if(s.Length==0) return "";
        StringBuilder sb = new StringBuilder();
        for(int i=0;i<s.Length;i++) sb.Append("*"+s[i]);
        sb.Append("*");
        
        String ss = sb.ToString();
        int []dp = new int[ss.Length]; 
        int maxR = 0;
        for(int i=1;i<ss.Length;i++)
        {
            if(i>dp[maxR]+maxR)
            {
                int l = i-1;
                int r = i+1;
                while(l>=0 && r<ss.Length && ss[l]==ss[r])
                {
                    l--;
                    r++;
                }
                l++;
                r--;
                maxR = i;
                dp[i] = r-i;
            }
            else
            {
                if(i+dp[2*maxR-i] >= dp[maxR]+maxR)
                {
                    dp[i] = dp[maxR]+maxR-i;
                    int l = i-dp[i]-1;
                    int r = i+dp[i]+1;
                    while(l>=0 && r<ss.Length && ss[l]==ss[r])
                    {
                        l--;
                        r++;
                    }
                    l++;
                    r--;
                    maxR = i;
                    dp[i] = r-i;
                }
                else
                {
                    dp[i] = dp[2*maxR-i];
                }
            }
        }
        int max = 0;
        for(int i=1;i<dp.Length;i++)
        {
            max = dp[i]>dp[max]? i:max;
        }
        
        return s.Substring((max-dp[max]+1)/2,dp[max]);
    }
}

// 马拉车优化，在最前面再加一个特殊字符 如'~',避免了对称时index跑到-1的情况，减少代码冗余
public class Solution {
    public string LongestPalindrome(string s) 
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("~*");
        
        for(int i=0;i<s.Length;i++) sb.Append(s[i]+"*");
        string ss = sb.ToString();
        
        int []dp = new int[ss.Length];
        
        int n = 1;
        for(int i=1;i<ss.Length;i++)
        {
            dp[i] = dp[2*n-i];
            
            if(i+dp[i]>=dp[n]+n)
            {
                dp[i] = dp[n]+n>i? dp[n]+n-i:0;
                int l = i-dp[i]-1;
                int r = i+dp[i]+1;
                
                while(l>=0 && r<ss.Length && ss[l]==ss[r])
                {
                    l--;
                    r++;
                }
                
                l++;
                r--;    
                dp[i] = r-i;
                n = i;
            }
        }
        
        int max = 0;
        for(int i=1;i<ss.Length;i++)
        {
            if(dp[i]>dp[max]) max = i;
        }
        
        return s.Substring((max-dp[max]-1)/2,dp[max]);
    }
}
