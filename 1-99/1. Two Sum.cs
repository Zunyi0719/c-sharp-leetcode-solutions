public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        
        int []res = {-1,-1};
        
        Hashtable ht = new Hashtable();
        
        for(int i=0;i<nums.Length;i++)
        {
            if(ht.Contains(target-nums[i]))
            {
                res[0] = (int)ht[target-nums[i]];
                res[1] = i;
                return res;
            }
            if(!ht.Contains(nums[i]))
            {
                ht.Add(nums[i],i);
        
            }
        }
        return res;
    }
}
