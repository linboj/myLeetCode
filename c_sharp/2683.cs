public class Solution {
    public bool DoesValidArrayExist(int[] derived) {
        bool first = false;

        foreach (var item in derived)
        {
            if (item == 1) first = !first;
        }

        return first == false;
    }
}

public class Solution2 {
    public bool DoesValidArrayExist(int[] derived) {
        int sum = 0;

        foreach (var item in derived)
        {
            sum += item;
        }

        return sum % 2 == 0;
    }
}